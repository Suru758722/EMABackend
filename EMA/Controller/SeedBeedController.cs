using EMA.Data;
using EMA.Models;
using EMA.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EMA.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeedBeedController : ControllerBase
    {
        private readonly ISeedBeedService _seedBeedService;
        public SeedBeedController(ISeedBeedService seedBeedService)
        {
            _seedBeedService = seedBeedService;
        }

        // GET: api/<SeedBeedController>
        [HttpGet]
        public IActionResult Get(int take)
        {
            try
            {
                return Ok(_seedBeedService.GetData(take));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        

        // POST api/<SeedBeedController>
        [HttpPost]
        public IActionResult Post([FromBody]SeedBeedModel formData)
        {
            try
            {
                bool result = _seedBeedService.AddUpdate(formData);
                if (result)
                    return Ok(_seedBeedService.GetData(1));
                else
                    return BadRequest(result);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // PUT api/<SeedBeedController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SeedBeedController>/5
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                bool result = _seedBeedService.Delete(id);
                if (result)
                    return Ok(_seedBeedService.GetData(1));
                else
                    return BadRequest(result);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
