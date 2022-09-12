using System;
using System.Linq;
using Practico1.Domain;
using Practico1.IBusinessLogic;
using Practico1.IDataAccess;

namespace Practico1.BusinessLogic
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User Create(User user)
        {
            _userRepository.Add(user);
            return user;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<User> GetAll()
        {
            return _userRepository.GetAll();
        }
    }
}

