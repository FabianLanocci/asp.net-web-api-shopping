using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Servicios
{
    public interface IProductService
    {
       bool Add(Product product);
        IList<Product> GetAll();

    }
}
