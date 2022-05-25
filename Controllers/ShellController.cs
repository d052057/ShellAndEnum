using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using ShellAndEnum.Helpers;
using Microsoft.Extensions.FileProviders;

namespace ShellAndEnum.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ShellController : Controller
    {
        
        [HttpGet]
        public ActionResult Get()
        {
            List<FileMetaData> list = new();
            string folder = (Path.Combine(Directory.GetCurrentDirectory(), @"data"));
            try
            {
                list = MediaMetaData.SingleDir(folder);
                foreach (FileMetaData d in list)
                {
                    Console.WriteLine(d.FullFileName);
                }
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message);
            }
            return Ok(list);
        }
    }
}
