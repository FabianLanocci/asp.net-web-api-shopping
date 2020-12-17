using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories
{
    public interface IProductRepository
    {
        Boolean Add(Product product);
        void Remove(Product product);
        void Modify(Product product);
        IList<Product> GetAll();
        Product GetByName(string name);
        Product GetById(int id);
        IProductRepository GetInstance();
    }
}
