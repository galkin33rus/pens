using Pens.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pens.Domain.Concrete
{
    public class UserRepository
    {
        PensEntities context = new PensEntities();

        public IEnumerable<Users> Users
        {
            get { return context.Users; }
        }

        public Users GetById(long UserId)
        {
            return context.Users.Where(x => x.Id == UserId).FirstOrDefault();
        }

        public Users Delete(long UserId)
        {
            Users dbEntry = context.Users.Find(UserId);
            if (dbEntry != null)
            {
                context.Users.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

        public void Save(Users user)
        {
            if (user.Id == 0)
                context.Users.Add(user);
            else
            {
                Users dbEntry = context.Users.Find(user.Id);
                if (dbEntry != null)
                {
                    dbEntry.Name = user.Name;
                    dbEntry.Login = user.Login;
                    dbEntry.Password = user.Password;
                    dbEntry.Position = user.Position;
                    dbEntry.BranchId = user.BranchId;
                    dbEntry.RoleId = user.RoleId;                    
                }
            }
            context.SaveChanges();
        }

    }
}
