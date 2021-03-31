using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Hosting;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase

    {
        private ICarImageService _carImageService;
        private IWebHostEnvironment _environment;

        public CarImagesController(ICarImageService carImageService, IWebHostEnvironment environment)
        {
            _carImageService = carImageService;
            _environment = environment;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carImageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _carImageService.GetAllByCarId(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getimagesbycarid")]
        public IActionResult GetImagesByCarId(int id)
        {
            var result = _carImageService.GetAllByCarId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm(Name =("Image"))] IFormFile file,[FromForm] CarImage carImage )
        {
            string path = _environment.WebRootPath + "\\Images\\";
           var newGuidPath = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            using (FileStream fileStream=System.IO.File.Create(path+newGuidPath))
            {
                file.CopyTo(fileStream);
                fileStream.Flush();
                
            }

            if (file==null)
            {
                carImage.ImagePath = path + "default.jpg";
            }

            var result = _carImageService.Add(new CarImage
            {
                CarId = carImage.CarId,
                Date = DateTime.Now,
                ImagePath = newGuidPath
            });

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("Delete")]
        public IActionResult Delete(CarImage carImage)
        {
            string path = _environment.WebRootPath + "\\Images\\";
            System.IO.File.Delete(path+carImage.ImagePath);
            var result = _carImageService.Delete(carImage);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update([FromForm(Name = ("Image"))] IFormFile file, [FromForm] CarImage carImage)
        {
            string path = _environment.WebRootPath + "\\Images\\";
            string updateImagePath = Path.Combine(path, carImage.ImagePath);
            string newGuid = Guid.NewGuid() + Path.GetExtension(file.FileName);

            var newGuidPath = Path.Combine(path, newGuid);
            System.IO.File.Move(updateImagePath,newGuidPath);

            carImage.ImagePath = newGuid;
            carImage.Date=DateTime.Now;
            var result = _carImageService.Update(carImage);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
