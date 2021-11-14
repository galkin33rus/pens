using Pens.Domain.Concrete;
using Pens.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pens.Domain.Abstract
{
    public class BranchFacade
    {
        public static List<Branch> GetBranches(String login)
        {
            UserRepository userRepository = new UserRepository();
            BranchRepository branchRepository = new BranchRepository();

            Users user = userRepository.Users.Where(m => m.Login == login).FirstOrDefault();

            List<Branch> branchList = branchRepository.Branch.Where(x => x.BranchID == user.BranchId || user.BranchId == null).ToList();
            return branchList;
        }
    }
}
