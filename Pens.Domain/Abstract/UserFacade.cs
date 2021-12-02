using Pens.Domain.Concrete;
using Pens.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pens.Domain.Abstract
{
   
    public class UserFacade
    {
        static UserRepository usersRepository = new UserRepository();

        public static bool ValidateUser(string login, string password)
        {
            bool isValid = false;

            Users user = usersRepository.Users.Where(x => x.Login == login && x.Password == password).FirstOrDefault();

            if (user != null)
            {
                isValid = true;
            }

            return isValid;
        }

        public static Users GetUser(string login)
        {
            return usersRepository.Users.Where(m => m.Login == login).FirstOrDefault();
        }

    }
}
