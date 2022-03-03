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
        public IActionResult Get()
        {
            try
            {
                return Ok(_seedBeedService.GetData());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<SeedBeedController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SeedBeedController>
        [HttpPost]
        public IActionResult Post([FromBody]SeedBeedModel formData)
        {
            try
            {
                bool result = _seedBeedService.AddUpdate(formData);
                if (result)
                    return Ok(_seedBeedService.GetData());
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
                    return Ok(_seedBeedService.GetData());
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
