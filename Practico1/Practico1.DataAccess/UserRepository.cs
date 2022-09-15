using System;
using System.Linq;
using Practico1.Domain;
using Practico1.IDataAccess;

namespace Practico1.DataAccess
{
    public class UserRepository : IUserRepository
    {
        private ContextDb _contextDb;

        public UserRepository(ContextDb contextDb)
        {
            _contextDb = contextDb;
        }

        public void Add(User entity)
        {
            _contextDb.Users.Add(entity);
            _contextDb.SaveChanges();
        }

        public IQueryable<User> GetAll()
        {
            return _contextDb.Users;
        }

        public void Remove(User entity)
        {
            _contextDb.Remove(entity);
            _contextDb.SaveChanges();
        }

        public User GetById(int id)
        {
            return _contextDb.Users.Find(id);
        }
    }
}

