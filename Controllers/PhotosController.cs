using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using app.Data;
using app.Models;
using AutoMapper;
using Backend.net.Helpers;
using Backend.net.View;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Backend.net.Controllers
{
    [Route("api/users/{userId}/photos")]
    public class PhotosController : Controller
    {
        private readonly IUsersRepository _repo;
        private readonly IMapper _mapper;
        private readonly IOptions<CloudinarySettings> _cloudinaryConfig;
        private Cloudinary _cloudinary;

        public PhotosController(IUsersRepository repo, IMapper mapper, IOptions<CloudinarySettings> CloudinaryConfig)
        {
            _repo = repo;
            _mapper = mapper;
            _cloudinaryConfig = CloudinaryConfig;
            
            Account acc = new Account(
                _cloudinaryConfig.Value.CloudName,
                _cloudinaryConfig.Value.ApiKey,
                _cloudinaryConfig.Value.ApiSecret
            );

            _cloudinary = new Cloudinary(acc);
        }
        [HttpGet("id" , Name = "GetPhoto")]
        public async Task<IActionResult> GetPhoto(int id)
        {
            var photoFromRepo = await _repo.GetPhoto(id);
            var photo = _mapper.Map<PhotoForReturn>(photoFromRepo);
            return Ok(photo);
        }

        [HttpPost]
        public async Task<IActionResult> AddPhotoForUser(int userId, PhotoForCreation photoDto)
        {
            var user = await _repo.GetUser(userId);
            if (user == null)
            return BadRequest("Useri nuk u gjend");

            var currentUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            if(currentUserId != user.Id)
            return Unauthorized();

            var file = photoDto.File;
            var uploadResult = new ImageUploadResult();

            if(file.Length > 0)
            {
                using (var stream = file.OpenReadStream())
                {
                    var uploadParams = new ImageUploadParams
                    {
                        File = new FileDescription(file.Name, stream),
                        Transformation = new Transformation().Width(500).Height(500).Crop("fill").Gravity("face")
                    };

                    uploadResult = _cloudinary.Upload(uploadParams);
                }
            }
                photoDto.url = uploadResult.Uri.ToString();
                photoDto.PublicId = uploadResult.PublicId;

                var photo = _mapper.Map<Photos>(photoDto);
                photo.User = user;

                if (!user.Photos.Any(m => m.IsMain))
                    photo.IsMain = true;

                    user.Photos.Add(photo);

                    

                    if (await _repo.SaveAll())
                    {
                        var photoToReturn = _mapper.Map<PhotoForReturn>(photo);
                        return CreatedAtRoute("GetPhoto", new {id = photo.Id}, photoToReturn);
                    }

             return BadRequest("Could not add the photo");
        }
        [HttpPost("{id}/setMain")]
        public async Task<IActionResult> SetmainPhoto(int userId, int id)
        {
            if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
            return Unauthorized();

            var photoFromRepo = await _repo.GetPhoto(id);
            if (photoFromRepo == null)
            return NotFound();
            
            if (photoFromRepo.IsMain)
            return BadRequest("This is already the main photo");

            var currentMainPhoto = await _repo.GetMainPhotoForUser(userId);
            if(currentMainPhoto != null)
            currentMainPhoto.IsMain = false;

            photoFromRepo.IsMain = true;

            if(await _repo.SaveAll())
            return NoContent();

            return BadRequest ("Could not set photo to main");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePhoto(int userId, int id) {

             if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
            return Unauthorized();

            var photoFromRepo = await _repo.GetPhoto(id);
            if (photoFromRepo == null)
            return NotFound();
            
            if (photoFromRepo.IsMain)
            return BadRequest("You can not delete the main photo");

            if(photoFromRepo.PublicId != null)
            {
                var deleteParams = new DeletionParams(photoFromRepo.PublicId);

                var result = _cloudinary.Destroy(deleteParams);

                if(result.Result == "ok")
                _repo.Delete(photoFromRepo);

            }

            if (photoFromRepo.PublicId == null)
            {
                _repo.Delete(photoFromRepo);
            }

            if(await _repo.SaveAll())
            return Ok();

            return BadRequest("Failed to delete photo");
            
        }
    }
}