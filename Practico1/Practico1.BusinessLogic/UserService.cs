using System;
using System.Linq;
using Practico1.DataAccess;
using Practico1.Domain;
using Practico1.IBusinessLogic;
using Practico1.IDataAccess;

namespace Practico1.BusinessLogic
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        private ContextDb _contextDb;

        public UserService(IUserRepository userRepository, ContextDb contextDb)
        {
            _userRepository = userRepository;
            _contextDb = contextDb;
        }

        public User Create(User user)
        {
            _userRepository.Add(user);
            return user;
        }

        public void Delete(int id)
        {
            var userToDelete = _contextDb.Users.Find(id);
            _userRepository.Remove(userToDelete);
        }

        public IQueryable<User> GetAll()
        {
            return _userRepository.GetAll();
        }
    }
}

