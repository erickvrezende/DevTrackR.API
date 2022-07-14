using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevTrackR.API.Entities;
using DevTrackR.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevTrackR.API.Controllers
{
    [ApiController]
    [Route("api/packages")]
    public class PackagesController : ControllerBase
    {
        // GET api/packages
        [HttpGet]
        public IActionResult GetAll() {
            var packages = new List<Package> {
                new Package("Pacote 1", 1.3M),
                new Package("Pacote 2", 0.2M)
            };
            return Ok(packages);
        }

        // GET api/packages/1234-5678-1234-5678
        [HttpGet("{code}")]
        public IActionResult GetByCode(string code){
            var package = new Package("Pacote 2", 0.2M);
            return Ok(package);
        }

        // POST api/packages
        [HttpPost]
        public IActionResult Post(AddPackageInputModel model){
            var package = new Package(model.Title, model.Weight);
            return Ok(package);
        }

        // POST api/packages/1234-5678-1234-5678/updates
        [HttpPost("{code}/updates")]
        public IActionResult PostUpdate(string code, AddPackageUpdateInputModel model){
            var package = new Package("Pacote 1", 1.2M);

            package.AddUpdate(model.Status, model.Delivered);

            return Ok();
        }
    }
}