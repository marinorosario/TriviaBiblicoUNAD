using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SNashENGINE.Share.DTOs.Archivos;
using System.Net;

namespace TriviaBiblicoUNAD2024.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuardarLogoController : ControllerBase
    {
        private readonly IHostEnvironment env;
        private readonly ILogger<GuardarLogoController> logger;

        public GuardarLogoController(IHostEnvironment _env,ILogger<GuardarLogoController> _logger)
        {
            env = _env;
            logger = _logger;
        }

        [HttpPost]
        public async Task<ActionResult<UploadResult>> PostFile([FromForm] IFormFile logoArchivo)
        {
            long maxFileSize = 1024 * 1024 * 15;
            Uri? resourcePath = new Uri($"{Request.Scheme}://{Request.Host}/");
            UploadResult uploadResultado = new();
            string trustedFileNameForFileStorage;

            var untrustedFileName = logoArchivo.FileName;
                uploadResultado.FileName = untrustedFileName;
            var trustedFileNameForDisplay = WebUtility.HtmlEncode(untrustedFileName);
            string? ExtensionLogo = logoArchivo.ContentType;

            if (logoArchivo.Length < maxFileSize)
            {
                try
                {
                    trustedFileNameForFileStorage = Path.GetRandomFileName();
                    var path = Path.Combine(env.ContentRootPath, "wwwroot" ,"Logos",
                                trustedFileNameForFileStorage);

                    await using FileStream fs = new(path, FileMode.Create);
                    await logoArchivo.CopyToAsync(fs);

                    logger.LogInformation("{FileName} saved at {Path}", trustedFileNameForDisplay, path);
                    uploadResultado.Uploaded = true;
                    uploadResultado.StoredFileName = trustedFileNameForFileStorage;
                    uploadResultado.Extension = ExtensionLogo;

                }
                catch (IOException Ex)
                {
                    logger.LogError("{FileName} error on upload (Err: 3): {Message}", trustedFileNameForDisplay, Ex.Message);
                    uploadResultado.ErrorCode = 3;
                }
            }
            else
            {
                logger.LogInformation("{FileName} of {Length} bytes is " +
                        "larger than the limit of {Limit} bytes (Err: 2)",
                        trustedFileNameForDisplay, logoArchivo.Length, maxFileSize);
                uploadResultado.ErrorCode = 2;
            }

            return new CreatedResult(resourcePath, uploadResultado);
        }
    }
}
