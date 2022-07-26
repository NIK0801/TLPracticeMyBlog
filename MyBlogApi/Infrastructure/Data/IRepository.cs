using System.Collections.Generic;
using MyBlogApi.Domain;

namespace MyBlogApi.Infrastructure.Data
{
    public interface IRepository
    {
        public interface IRepository<T>
        {
            List<T> GetAll();
            T GetById(int id);
            int Create(T domain);
            void Delete(T domain);
            void Update(T domain);
        }
    }
}
