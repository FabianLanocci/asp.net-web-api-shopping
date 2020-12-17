using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    public interface IProductService
    {
        Boolean Add(Product product);
        void Remove(Product product);
        void Modify(Product product);
        IList<Product> GetAll();
        Product GetById(int id);
        Product GetByName(string name);
    }
}
