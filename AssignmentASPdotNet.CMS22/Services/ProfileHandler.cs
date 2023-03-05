using AssignmentASPdotNet.CMS22.Models.Identity;
using Microsoft.AspNetCore.Identity;

namespace AssignmentASPdotNet.CMS22.Services
{
    public class ProfileHandler
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly SignInManager<AppUser> _signInManager;

        public ProfileHandler(IWebHostEnvironment webHostEnvironment, SignInManager<AppUser> signInManager)
        {
            _webHostEnvironment = webHostEnvironment;
            _signInManager = signInManager;
        }

        public async Task<string> UploadProfileImageAsync(IFormFile profileImage)
        {
            var profilePath = $"{_webHostEnvironment.WebRootPath}/images/profiles";
            var imageName =$"profile_{Guid.NewGuid()}{Path.GetExtension(profileImage.FileName)}";
            string filePath = $"{profilePath}/{imageName}";

            using var fs = new FileStream(filePath, FileMode.Create);
            await profileImage.CopyToAsync(fs);

            return imageName;
        }

        public async Task LoggOutAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
