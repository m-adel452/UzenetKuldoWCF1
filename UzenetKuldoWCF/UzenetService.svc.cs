using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using UzenetKuldoWCF.Models;
using UzenetKuldoWCF.Interfaces;
using UzenetKuldoWCF.Services;

namespace UzenetKuldoWCF
{
    public class Service1 : IUzenetService
    {
        public string DeleteUzenet(int id)
        {
            return new UzenetServices().Delete(id);
        }

        public List<Uzenet> GetAllUzenet()
        {
            List<Uzenet> uzenetList = new List<Uzenet>();
            List<Tablazat> tablazatList = new UzenetServices().Read();
            foreach (var tablazat in tablazatList)
            {
                uzenetList.Add((Uzenet)tablazat);
            }
            return uzenetList;
        }

        public string PostUzenet(Uzenet uzenet)
        {
            return new UzenetServices().Create(uzenet);
        }

        public string PutUzenet(Uzenet uzenet)
        {
            return new UzenetServices().Update(uzenet);
        }
    }
}
