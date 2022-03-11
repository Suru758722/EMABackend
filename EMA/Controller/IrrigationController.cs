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
    public class IrrigationController : ControllerBase
    {
        private readonly IIrrigationService _irrigationService;
        public IrrigationController(IIrrigationService irrigationService)
        {
            _irrigationService = irrigationService;
        }

        // GET: api/<IrrigationController>
        [HttpGet]
        public IActionResult Get(int take)
        {
            try
            {
                return Ok(_irrigationService.GetData(take));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

     

        // POST api/<IrrigationController>
        [HttpPost]
        public IActionResult Post([FromBody]IrrigationModel formData)
        {
            try
            {
                bool result = _irrigationService.AddUpdate(formData);
                if (result)
                    return Ok(_irrigationService.GetData(1));
                else
                    return BadRequest(result);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<IrrigationController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<IrrigationController>/5
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                bool result = _irrigationService.Delete(id);
                if (result)
                    return Ok(_irrigationService.GetData(1));
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
