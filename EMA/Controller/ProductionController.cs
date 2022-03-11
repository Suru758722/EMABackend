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
    public class ProductionController : ControllerBase
    {
        private readonly IProductionService _productionService;
        public ProductionController(IProductionService productionService)
        {
            _productionService = productionService;
        }

        // GET: api/<ProductionController>
        [HttpGet]
        public IActionResult Get(int take)
        {
            try
            {
                return Ok(_productionService.GetData(take));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

       

        // POST api/<ProductionController>
        [HttpPost]
        public IActionResult Post([FromBody]ProductionModel formData)
        {
            try
            {
                bool result = _productionService.AddUpdate(formData);
                if (result)
                    return Ok(_productionService.GetData(1));
                else
                    return BadRequest(result);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ProductionController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductionController>/5
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                bool result = _productionService.Delete(id);
                if (result)
                    return Ok(_productionService.GetData(1));
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
