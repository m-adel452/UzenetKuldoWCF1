using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using UzenetKuldoWCF.Models;

namespace UzenetKuldoWCF
{
    [ServiceContract]
    public interface IUzenetService
    {
        [OperationContract]
        List<Uzenet> GetAllUzenet();

        [OperationContract]
        string PostUzenet(Uzenet uzenet);

        [OperationContract]
        string PutUzenet(Uzenet uzenet);

        [OperationContract]
        string DeleteUzenet(int id);
    }
}