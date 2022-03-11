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
    public class HarvestingController : ControllerBase
    {
        private readonly IHarvestingService _harvestingService;
        public HarvestingController(IHarvestingService harvestingService)
        {
            _harvestingService = harvestingService;
        }

        // GET: api/<HarvestingController>
        [HttpGet]
        public IActionResult Get(int take)
        {
            try
            {
                return Ok(_harvestingService.GetData(take));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

       

        // POST api/<HarvestingController>
        [HttpPost]
        public IActionResult Post([FromBody]HarvestingModel formData)
        {
            try
            {
                bool result = _harvestingService.AddUpdate(formData);
                if (result)
                    return Ok(_harvestingService.GetData(1));
                else
                    return BadRequest(result);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<HarvestingController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<HarvestingController>/5
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                bool result = _harvestingService.Delete(id);
                if (result)
                    return Ok(_harvestingService.GetData(1));
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
