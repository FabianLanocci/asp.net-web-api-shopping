using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    public interface ICategoryService
    {
        Boolean Add(Category category);
        void Modify(Category category);
        void Remove(Category category);
        IList<Category> GetAll();
        Category GetByName(string name);
    }
}
