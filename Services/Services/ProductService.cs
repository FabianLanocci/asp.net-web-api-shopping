using Models;
using Repositories;
using Repositories.Repositories;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Services
{
    public class ProductService : IProductService
    {
        private IProductRepository productRepository = new ProductRepository();

        public bool Add(Product product)
        {
            //Succesful puede devolver False en 2 instancias. Una al hacer mal la query (0 affectedRows) y la otra si acá ya existe otro product con el mismo name
            Boolean succesful = false;
            try
            {
                if (productRepository.GetAll().Where(x => x.Name == product.Name).FirstOrDefault() == null)
                {
                    if (product != null)
                    {
                        productRepository.Add(product);
                        succesful = true;
                    }
                }

            } catch (Exception ex){
                throw ex;
            }

            return succesful;
        }

        public IList<Product> GetAll()
        {
            try
            {
                return productRepository.GetAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Product GetById(int id)
        {
            Product product = null;
            try
            {
                if (productRepository.GetAll().Where(x => x.ProductId == id).FirstOrDefault() != null)
                {
                    product = productRepository.GetById(id);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return product;
        }

        public Product GetByName(string name)
        {
            Product product = null;
            try
            {
                if (productRepository.GetAll().Where(x => x.Name == name).FirstOrDefault() != null)
                {
                    product = productRepository.GetByName(name);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return product;
        }

        public void Modify(Product product)
        {
            try
            {
                if (productRepository.GetAll().Where(x => x.ProductId == product.ProductId).FirstOrDefault() != null)
                {
                    if (product != null)
                    {
                        productRepository.Modify(product);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Remove(Product product)
        {
            try
            {
                if (productRepository.GetAll().Where(x => x.ProductId == product.ProductId).FirstOrDefault() != null)
                {
                    if (product != null)
                    {
                        productRepository.Remove(product);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
