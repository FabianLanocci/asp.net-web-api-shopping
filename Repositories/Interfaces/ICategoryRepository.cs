using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        Boolean Add(Category category);
        void Modify(Category category);
        void Remove(Category category);
        IList<Category> GetAll();
        Category GetByName(string name);
        ICategoryRepository GetInstance();
    }
}
