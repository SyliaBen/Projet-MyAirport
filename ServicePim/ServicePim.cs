using MyAirport.Pim.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using MyAirport.Pim.Entities;

namespace MyAirport.Pim.Service
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" à la fois dans le code et le fichier de configuration.
    public class ServicePim : IServicePim
    {
        int NbAppelTotal = 0; 
        public int CreateBagage(BagageDefinition bag)
        {
            return Models.Factory.Model.CreateBagage(bag); 
        }

        public BagageDefinition GetBagageByCodeIata(string codeIata)
        {
            NbAppelTotal++; 
            List<BagageDefinition> bags = MyAirport.Pim.Models.Factory.Model.GetBagage(codeIata);
            if (bags != null)
            {
                if(bags.Count() == 0 )
                {
                    return null; 
                }
                if(bags.Count == 1)
                {
                    return bags[0]; 
                }
                else
                {

                    var excp = new MultipleBagagesFault();
                    excp.CodeIata = codeIata;
                    excp.Message = "Trop bagages en base";
                    excp.ListBagages = bags;
 
                    throw new FaultException<MultipleBagagesFault>(excp, new FaultReason("Trop de bagages correspondent à la requête"));

                }
            }
            else
            {
                return null; 
            }

        }

        public BagageDefinition GetBagageById(int idBagage)
        {
            return MyAirport.Pim.Models.Factory.Model.GetBagage(idBagage); 
        }
    }
}
