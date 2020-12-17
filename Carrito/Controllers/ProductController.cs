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
    public class ProductController : ControllerBase
    {
        private IProductService productService;

        public ProductController()
        {
            productService = new ProductService();
        }

        [Route("api/[controller]/GetAll")]
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(productService.GetAll());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Route("api/[controller]/GetById")]
        [HttpGet]
        public IActionResult GetById(int id)
        {
            try
            {
                Product product = productService.GetById(id);

                if (product == null)
                {
                    return BadRequest("ERROR: No se pudo encontrar el producto buscado por su id.");
                }
                else
                {
                    return Ok(product);
                }
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
                Product product = productService.GetByName(name);

                if(product == null)
                {
                    return BadRequest("ERROR: No se pudo encontrar el producto buscado por nombre.");
                }
                else
                {
                    return Ok(product);
                }   
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [Route("api/[controller]/Add")]
        [HttpPost]
        public IActionResult Add(Product product)
        {
            try
            {
                Boolean succesful = productService.Add(product);

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

        [Route ("api/[controller]/Modify")]
        [HttpPost]
        public IActionResult Modify(Product product)
        {
            try
            {
                productService.Modify(product);
                return Ok();
            }catch (Exception ex)
            {
                throw ex;
            }
        }

        [Route("api/[controller]/Remove")]
        [HttpPost]
        public IActionResult Remove(Product product)
        {
            try
            {
                productService.Remove(product);
                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
