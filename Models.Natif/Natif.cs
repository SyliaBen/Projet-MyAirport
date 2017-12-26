using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAirport.Pim.Models
{
    public class Natif : AbstractDefinition
    {
        public override Entities.BagageDefinition GetBagage(int idBagage)
        {
            throw new NotImplementedException();
        }

        public override int CreateBagage(Entities.BagageDefinition bag)
        {
            throw new NotImplementedException();
        }

        public override List<Entities.BagageDefinition> GetBagage(string codeIataBagage)
        {
            /* List<Entities.BagageDefinition>  res = new List<Entities.BagageDefinition>();
             res.Add(new Entities.BagageDefinition() { CodeIata = "023232546100", Compagnie="AirFrance"});
             return res; */

            throw new NotImplementedException();
        }
    }

}
