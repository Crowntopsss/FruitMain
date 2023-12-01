using Microsoft.AspNetCore.Mvc;
using FruitAPI.Models;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace FruitAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FruitsController : ControllerBase
    {
        private readonly string _jsonFilePath;

        public FruitsController(IWebHostEnvironment webHostEnvironment)
        {
            _jsonFilePath = Path.Combine(webHostEnvironment.ContentRootPath, "Data", "fruit.json");
        }

        [HttpGet]
        public IEnumerable<Fruit> GetAllFruits()
        {
            var jsonData = System.IO.File.ReadAllText(_jsonFilePath);
            var fruits = JsonSerializer.Deserialize<IEnumerable<Fruit>>(jsonData);
            return fruits;
        }
    }
}
