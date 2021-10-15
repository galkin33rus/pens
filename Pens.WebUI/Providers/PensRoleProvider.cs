using Pens.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace Pens.WebUI.Providers
{
    public class PensRoleProvider : RoleProvider
    {
        public override string[] GetRolesForUser(string login)
        {
            string[] role = new string[] { };
            using (PensEntities _db = new PensEntities())
            {
                try
                {
                    // Получаем пользователя
                    Users user = (from u in _db.Users
                                 where u.Login == login
                                 select u).FirstOrDefault();
                    if (user != null)
                    {
                        // получаем роль
                        Pens.Domain.Entities.Roles userRole = _db.Roles.Find(user.RoleId);

                        if (userRole != null)
                        {
                            role = new string[] { userRole.Name };
                        }
                    }
                }
                catch
                {
                    role = new string[] { };
                }
            }
            return role;
        }
        public override bool IsUserInRole(string username, string roleName)
        {
            bool outputResult = false;
            // Находим пользователя
            using (PensEntities _db = new PensEntities())
            {
                try
                {
                    // Получаем пользователя
                    Users user = (from u in _db.Users
                                 where u.Login == username
                                 select u).FirstOrDefault();
                    if (user != null)
                    {
                        // получаем роль
                        Pens.Domain.Entities.Roles userRole = _db.Roles.Find(user.RoleId);

                        //сравниваем
                        if (userRole != null && userRole.Name == roleName)
                        {
                            outputResult = true;
                        }
                    }
                }
                catch
                {
                    outputResult = false;
                }
            }
            return outputResult;
        }
        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }
        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }

    }
}