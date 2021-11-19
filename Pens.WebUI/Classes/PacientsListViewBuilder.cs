using Pens.Domain.Abstract;
using Pens.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pens.WebUI.Classes
{
    public class PacientsListViewBuilder
    {
        public static PacientsListView GetPacientsListView(string seachText, int page, int pageSize)
        {
            PacientsListView pacients = new PacientsListView()
            {
                Pacients = PacientFacade.GetPacients(seachText, page, pageSize),
                PagingInfo = new PagingInfo()
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = PacientFacade.GetPacientsCount(seachText)
                }
            };
            return pacients;
        }
    }
}