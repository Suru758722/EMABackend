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
    public class InterCultureController : ControllerBase
    {
        private readonly IInterCultureService _interCultureService;
        public InterCultureController(IInterCultureService interCultureService)
        {
            _interCultureService = interCultureService;
        }
        // GET: api/<InterCultureController>
        [HttpGet]
        public IActionResult Get(int take)
        {
            try
            {
                return Ok(_interCultureService.GetData( take));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

      

        // POST api/<InterCultureController>
        [HttpPost]
        public IActionResult Post([FromBody]InterCultureModel formData)
        {
            try
            {
                bool result = _interCultureService.AddUpdate(formData);
                if (result)
                    return Ok(_interCultureService.GetData(1));
                else
                    return BadRequest(result);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<InterCultureController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<InterCultureController>/5
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                bool result = _interCultureService.Delete(id);
                if (result)
                    return Ok(_interCultureService.GetData(1));
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
