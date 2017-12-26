using MyAirport.Pim.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MyAirport.Pim.Service
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IService1" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IServicePim
    {
        [OperationContract]
        BagageDefinition GetBagageById(int idBagage);
        [FaultContract(typeof(MultipleBagagesFault))]
        [OperationContract]
        BagageDefinition GetBagageByCodeIata(string codeIata);
        [OperationContract]
        int CreateBagage(BagageDefinition bag);

    }


}
