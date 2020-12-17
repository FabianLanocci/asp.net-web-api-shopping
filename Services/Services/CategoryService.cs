using Models;
using Repositories.Interfaces;
using Repositories.Repositories;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Services
{
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository categories = new CategoryRepository();

        public bool Add(Category category)
        {
            Boolean succesful = false;

            try
            {
                if(categories.GetAll().Where(x => x.Name == category.Name).FirstOrDefault() == null)
                {
                    if(category != null)
                    {
                        categories.Add(category);
                        succesful = true;
                    }
                }

            }catch (Exception ex)
            {
                throw ex;
            }

            return succesful;
        }

        public IList<Category> GetAll()
        {
            try
            {
                return categories.GetAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Category GetByName(string name)
        {
            Category category = null;
            
            try
            {
                if(categories.GetAll().Where(x => x.Name == name).FirstOrDefault() != null)
                {
                   category = categories.GetByName(name);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return category;
        }

        public void Modify(Category category)
        {
            try
            {
                if (categories.GetAll().Where(x => x.CategoryId == category.CategoryId).FirstOrDefault() != null)
                {
                    categories.Modify(category);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Remove(Category category)
        {
            try
            {
                if (categories.GetAll().Where(x => x.CategoryId == category.CategoryId).FirstOrDefault() != null)
                {
                    categories.Remove(category);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
