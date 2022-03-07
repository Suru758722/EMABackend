using EMA.EntityModels;
using EMA.Models;
using EMA.Services;
using Microsoft.AspNetCore.Authorization;
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
    public class FarmerController : ControllerBase
    {
        private readonly IFarmerService _farmerService;
        public FarmerController(IFarmerService farmerService)
        {
            _farmerService = farmerService;
        }
        // GET: api/<FarmerController>
        [HttpGet]
        public IActionResult Get(int take)
        {
            try
            {

                return Ok(_farmerService.GetData(take));
            }catch(Exception ex)
            {
               return BadRequest(ex.Message);
            }
        }

        // GET api/<FarmerController>/5
        [Route("GetFarmerById")]
        [HttpGet]
        public IActionResult GetFarmerById(int Id,int cropId)
        {
            try
            {
                return Ok(_farmerService.GetDataById(Id,cropId));
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        // POST api/<FarmerController>
        [HttpPost]
        public IActionResult Post([FromBody]FarmerModel formData)
        {
            try
            {
               bool result =  _farmerService.AddUpdate(formData);
                if (result)
                    return Ok(_farmerService.GetData(1));
                else
                    return BadRequest(result);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        // PUT api/<FarmerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FarmerController>/5
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                bool result = _farmerService.Delete(id);
                if (result)
                    return Ok(_farmerService.GetData(1));
                else
                    return BadRequest(result);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpGet]
        [Route("GetSurveyDataByFarmerId")]
        public IActionResult GetSurveyDataByFarmerId(int farmerId)
        {
            try
            {
               
                    return Ok(_farmerService.DownloadSurwayDataByFarmerId(farmerId));
                

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
