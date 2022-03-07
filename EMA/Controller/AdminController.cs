using EMA.Models;
using EMA.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMA.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }
        [HttpGet]
        [Route("GetSurwayData")]
        public IActionResult GetSurwayData()
        {
            return Ok("Data");
        }

        [HttpGet]
        [Route("GetCrop")]
        public IActionResult GetCrop()
        {
            return Ok(_adminService.GetCrop());
        }
    }
}
