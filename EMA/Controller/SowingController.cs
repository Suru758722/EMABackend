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
    public class SowingController : ControllerBase
    {
        private readonly ISowingService _sowingService;
        public SowingController(ISowingService sowingService)
        {
            _sowingService = sowingService;
        }
        // GET: api/<SowingController>
        [HttpGet]
        public IActionResult Get(int take)
        {
            try
            {
                return Ok(_sowingService.GetData(take));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // POST api/<SowingController>
        [HttpPost]
        public IActionResult Post([FromBody]SowingModel formData)
        {
            try
            {
                bool result = _sowingService.AddUpdate(formData);
                if (result)
                    return Ok(_sowingService.GetData(1));
                else
                    return BadRequest(result);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<SowingController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SowingController>/5
        [HttpDelete]
        public  IActionResult Delete(int id)
        {
            try
            {
                bool result = _sowingService.Delete(id);
                if (result)
                    return Ok(_sowingService.GetData(1));
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
