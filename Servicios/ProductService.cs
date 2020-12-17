using Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Servicios
{
    public class ProductService: IProductService
    {
        private IProductRepository productRepository;

        public ProductService()
        {
            productRepository = ProductRepository.GetInstance();
        }
        public bool Add(Product product)
        {
            var result = false;
           if(productRepository.GetByName(product.Name) == null)
            {
                productRepository.Add(product);
                result = true;
            }
            return result; 
        }

        
        public IList<Product> GetAll()
        {
            return productRepository.GetAll();

        }
    }
}
