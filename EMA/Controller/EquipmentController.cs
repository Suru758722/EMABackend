﻿using EMA.Models;
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
    public class EquipmentController : ControllerBase
    {
        private readonly IEquipmentService _equipmentService;
        public EquipmentController(IEquipmentService equipmentService)
        {
            _equipmentService = equipmentService;
        }
        // GET: api/<EquipmentController>
        [HttpGet]
        public IActionResult Get(int take)
        {
            try
            {
                return Ok(_equipmentService.GetData(take));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

       

        // POST api/<EquipmentController>
        [HttpPost]
        public IActionResult Post([FromBody]EquipmentModel formData)
        {
            try
            {
                bool result = _equipmentService.AddUpdate(formData);
                if (result)
                    return Ok(_equipmentService.GetData(1));
                else
                    return BadRequest(result);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // PUT api/<EquipmentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EquipmentController>/5
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                bool result = _equipmentService.Delete(id);
                if (result)
                    return Ok(_equipmentService.GetData(1));
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
