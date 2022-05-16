using BlazorViewer.Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace BlazorViewer.Server.Controllers
{
    [Route("api/storage/v1/[controller]")]
    [ApiController]
    public class DesignsController : ControllerBase
    {
        private readonly IProtoStorageService _storageService;

        public DesignsController(IProtoStorageService storageService)
        {
            _storageService = storageService;
        }

        [HttpGet("{name}")]
        public IActionResult Get(string name)
        {           
            try
            {
                Stream result = _storageService.Retrieve(name);
                return File(result, "application/octet-stream");
            }
            catch (FileNotFoundException)
            {
                return NotFound();
            }
            catch (Exception)
            {
                return Error();
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return new ObjectResult(_storageService.Retrieve());
            }
            catch(Exception)
            {
                return Error();
            }
        }

        [HttpPost]
        public IActionResult Post()
        {
            try
            {
                Stream input = Request.BodyReader.AsStream();
                _storageService.Create(input);

                return Ok();
            }
            catch (Exception)
            {
                return Error();
            }
        }

        [HttpPut("{name}")]
        public IActionResult Put(string name)
        {
            try
            {
                Stream input = Request.BodyReader.AsStream();
                _storageService.Update(name, input);

                return Ok();
            }
            catch (Exception)
            {
                return Error();
            }
        }

        [HttpDelete("{name}")]
        public IActionResult Delete(string name)
        {
            try
            {
                _storageService.Delete(name);

                return Ok();
            }
            catch (DirectoryNotFoundException)
            {
                return NotFound();
            }
            catch (Exception)
            {
                return Error();
            }
        }

        [NonAction]
        public IActionResult Error()
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}
