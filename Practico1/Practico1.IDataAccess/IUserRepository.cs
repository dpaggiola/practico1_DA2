using System;
using System.Linq;
using Practico1.Domain;

namespace Practico1.IDataAccess
{
    public interface IUserRepository
    {
        void Add(User entity);
        void Remove(User entity);
        IQueryable<User> GetAll();
        User GetById(int id);
    }
}

