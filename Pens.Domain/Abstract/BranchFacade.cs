using Pens.Domain.Concrete;
using Pens.Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pens.Domain.Abstract
{
    public class BranchFacade
    {
        static BranchRepository branchRepository = new BranchRepository();

        public static List<Branch> GetBranches(String login)
        {
            Users user = UserFacade.GetUser(login); 

            List<Branch> branchList = branchRepository.Branch.Where(x => x.BranchID == user.BranchId || user.BranchId == null).ToList();
            return branchList;
        }

        public static IEnumerable<Branch> GetBranches()
        {
            return branchRepository.Branch;
        }

        public static Branch GetById(long BranchID)
        {
            return branchRepository.GetById(BranchID);
        }

        public static void Save(Branch branch)
        {
            branchRepository.Save(branch);
        }

        public static void Delete(long BranchID)
        {
            branchRepository.Delete(BranchID);
        }

        public static IEnumerable<Branch> GetBranchesById(long? branchId)
        {
            return branchRepository.Branch.Where(x => x.BranchID == (branchId ?? 0) || branchId == null);
        }
    }
}
