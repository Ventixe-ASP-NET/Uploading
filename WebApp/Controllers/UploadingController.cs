using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApp.Handlers;
using System.Threading.Tasks;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadingController : ControllerBase
    {
        private readonly IFileHandler _fileHandler;

        public UploadingController(IFileHandler fileHandler)
        {
            _fileHandler = fileHandler;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("File is not provided or is empty.");
            }

            try
            {
                var imageFileUri = await _fileHandler.UploadFileAsync(file);
                return Ok(new { ImageFileUri = imageFileUri });
            }
            catch (Exception ex)
            {
                // Log the exception (if logging is set up)
                return StatusCode(StatusCodes.Status500InternalServerError, new { Error = ex.Message });
            }
        }
    }
}

