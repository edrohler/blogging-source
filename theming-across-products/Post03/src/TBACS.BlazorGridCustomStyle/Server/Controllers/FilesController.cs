using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace TBACS.BlazorGridCustomStyle.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly IWebHostEnvironment WebHostEnvironment;

        public FilesController(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        [Produces("application/json")]
        public IActionResult Get()
        {
            DirectoryInfo d = new(Path.Combine(WebHostEnvironment.ContentRootPath, "Reports"));

            FileInfo[] Files = d.GetFiles("*.trdp");

            string[] FileNames = new string[Files.Length];

            for (int i = 0; i < Files.Length; i++)
            {
                FileNames[i] = Files[i].Name;
            }

            if (FileNames.Length > 0)
            {
                return Ok(FileNames);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
