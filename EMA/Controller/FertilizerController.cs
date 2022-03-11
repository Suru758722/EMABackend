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
    public class FertilizerController : ControllerBase
    {
        private readonly IFertilizerService _fertilizerService;
        public FertilizerController(IFertilizerService fertilizerService)
        {
            _fertilizerService = fertilizerService;
        }

        // GET: api/<FertilizerController>
        [HttpGet]
        public IActionResult Get(int take)
        {
            try
            {
                return Ok(_fertilizerService.GetData(take));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

       
        // POST api/<FertilizerController>
        [HttpPost]
        public IActionResult Post([FromBody]FertilizerModel formData)
        {
            try
            {
                bool result = _fertilizerService.AddUpdate(formData);
                if (result)
                    return Ok(_fertilizerService.GetData(1));
                else
                    return BadRequest(result);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<FertilizerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FertilizerController>/5
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                bool result = _fertilizerService.Delete(id);
                if (result)
                    return Ok(_fertilizerService.GetData(1));
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
