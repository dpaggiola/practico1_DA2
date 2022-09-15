using System;
using System.Linq;
using Practico1.Domain;

namespace Practico1.IBusinessLogic
{
    public interface IUserService
    {
        User Create(User user);
        IQueryable<User> GetAll();
        void Delete(int id);
    }
}

