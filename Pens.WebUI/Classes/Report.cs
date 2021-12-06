using Pens.Domain.Abstract;
using Pens.Domain.Entities;
using Pens.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pens.WebUI.Classes
{
    public class Report
    {
        public List<StatisticDoc> GetStatisticTable(String login)
        {
            List<Branch> branchList = BranchFacade.GetBranches(login);

            DocFilter docFilter = new DocFilter();
            List<StatisticDoc> statDocList = new List<StatisticDoc>();

            foreach (var branch in branchList)
            {
                List<Docs> docStat = DocFacade.GetDocs(docFilter.dateFrom, docFilter.dateTo, branch.BranchID);
                statDocList.Add(new StatisticDoc
                {
                    BranchTitle = branch.Title,
                    NupPeople = docStat.Count(),
                    SummPrice = docStat.Sum(s => s.Services.Sum(su => su.Cost * su.Quantity)),
                    SummSeb = docStat.Sum(s => s.Services.Sum(su => su.CostR * su.Quantity)),
                    SummDif = docStat.Sum(s => s.Services.Sum(su => su.CostR * su.Quantity) - s.Services.Sum(su => su.Cost * su.Quantity))
                });
            }
            return statDocList;
        }    
    }
}