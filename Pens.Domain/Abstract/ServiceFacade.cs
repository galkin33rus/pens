using Pens.Domain.Concrete;
using Pens.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pens.Domain.Abstract
{
    public class ServiceFacade
    {
        public static ServicesRepository servicesRepository = new ServicesRepository();

        public static void DeleteByDocId(long docId)
        {
            servicesRepository.DeleteByDocId(docId);
        }

        public static void Save(Services service)
        {
            servicesRepository.Save(service);
        }
    }
}
