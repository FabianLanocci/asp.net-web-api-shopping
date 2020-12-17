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
    public class CategoryController : ControllerBase
    {
        private ICategoryService categoryService;

        public CategoryController()
        {
            categoryService = new CategoryService();
        }

        [Route("api/[controller]/GetAll")]
        [HttpGet]
        public IActionResult GetAll()
        {
            try{
                return Ok(categoryService.GetAll());
            }
            catch (Exception ex)
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
                Category category = categoryService.GetByName(name);

                if(category == null)
                {
                    return BadRequest("ERROR: No se pudo encontrar la categoría buscada por nombre.");
                }else
                {
                    return Ok(category);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Route("api/[controller]/Add")]
        [HttpPost]
        public IActionResult Add(Category category)
        {
            try
            {
                Boolean succesful = categoryService.Add(category);

                if (succesful == false)
                {
                    return BadRequest("ERROR: No se pudo realizar correctamente la query (affectedRows = 0) o ya existe un producto con ese mismo nombre.");
                }
                else
                {
                    return Ok(succesful);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Route("api/[controller]/Modify")]
        [HttpPost]
        public IActionResult Modify(Category category)
        {
            try
            {
                categoryService.Modify(category);
                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Route("api/[controller]/Remove")]
        [HttpPost]
        public IActionResult Remove(Category category
            )
        {
            try
            {
                categoryService.Remove(category);
                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
