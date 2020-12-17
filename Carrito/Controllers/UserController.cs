using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services.Interfaces;
using Services.Services;

namespace Carrito.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserService userService;

        public UserController() {
            userService = new UserService();
        }

        [Route("api/[controller]/GetAll")]
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(userService.GetAll());
            }catch (Exception ex)
            {
                throw ex;
            }
        }

        [Route("api/[controller]/GetByName")]
        [HttpGet]
        public IActionResult GetByName(string name)
        {
            try
            {
                User user = userService.GetByName(name);

                if(user == null)
                {
                    return BadRequest("ERROR: No se pudo encontrar el usuario buscado por nombre.");
                }
                else
                {
                    return Ok(user);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Route("api/[controller]/Login")]
        [HttpPost]
        public IActionResult login(string email, string password)
        {
            try
            {
                if (userService.Login(email, password) == false)
                {
                    return BadRequest("ERROR:El email o la contraseña incorrectos.");
                }
                return Ok("Correcto!");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [Route("api/[controller]/Add")]
        [HttpPost]
        public IActionResult Add(User user)
        {
            try
            {
                userService.Add(user);
                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Route("api/[controller]/Modify")]
        [HttpPost]
        public IActionResult Modify(User user)
        {
            try
            {
                userService.Modify(user);
                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Route("api/[controller]/Remove")]
        [HttpPost]
        public IActionResult Remove(User user)
        {
            try
            {
                userService.Remove(user);
                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
