using EMA.Models;
using EMA.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMA.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signIn)
        {
            _accountService = accountService;
        }

        [HttpGet]
        [Route("GetAllUser")]
        public IActionResult GetAllUser(int take)
        {
            return Ok(_accountService.GetAllUser(take));
        }

        [HttpGet]
        [Route("ChangeUserStatus")]
        public IActionResult ChangeUserStatus(string Id,int take)
        {
            try
            {
                if (_accountService.ChangeUserStatus(Id))
                {
                    return Ok(_accountService.GetAllUser(take));
                }
                else
                {
                    return BadRequest("An Error Occured");
                }
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody]LoginModel data)
        {
            try
            {
                
                return Ok(new JsonResult(await _accountService.Login(data)));
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody]RegisterModel data)
        {
            try
            {         
                if(await _accountService.Register(data) )
                {
                    return Ok(true);
                }else
                return BadRequest("An Error Occured");

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("DownloadSurway")]
        public IActionResult DownloadSurway()
        {
            try
            {

                return Ok(_accountService.DownloadSurway());

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }

   
}
