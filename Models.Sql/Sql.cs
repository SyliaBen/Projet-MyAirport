using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyAirport.Pim.Entities;
using System.Configuration;
using System.Data.SqlClient;

namespace MyAirport.Pim.Models
{
    public class Sql : AbstractDefinition
    {
        private string strCnx = ConfigurationManager.ConnectionStrings["MyAiport.Pim.Settings.DbConnect"].ConnectionString;

        string commandGetBagageId = "SELECT b.ID_BAGAGE, c.NOM as compagnie, b.CODE_IATA, b.LIGNE, b.DATE_CREATION, b.ESCALE, cc.PRIORITAIRE, b.EN_CONTINUATION, cast(iif( b.EN_CONTINUATION = '0', 0, 1) as bit ) as Continuation, bp.PARTICULARITE, cast(iif(bp.PARTICULARITE is null, 0, 1) as bit) as 'RUSH' FROM BAGAGE b left outer join BAGAGE_A_POUR_PARTICULARITE bap on bap.ID_BAGAGE = b.ID_BAGAGE left outer join BAGAGE_PARTICULARITE bp on bp.ID_PART = bap.ID_PARTICULARITE and bp.PARTICULARITE = 'RUSH' left outer join COMPAGNIE c on c.CODE_IATA = b.COMPAGNIE left outer join COMPAGNIE_CLASSE cc on cc.ID_COMPAGNIE = c.ID_COMPAGNIE and cc.CLASSE = b.CLASSE WHERE b.ID_BAGAGE = @id";

        string commandGetBagageByCodeIata = "SELECT b.ID_BAGAGE, c.NOM as compagnie, b.CODE_IATA, b.LIGNE, b.DATE_CREATION, b.ESCALE, b.PRIORITAIRE, cast(iif(b.CONTINUATION = 'Y', 1, 0) as bit ) as continuation, bp.PARTICULARITE, cast(iif(bp.PARTICULARITE is null, 0, 1) as bit) as 'RUSH' FROM BAGAGE b left outer join BAGAGE_A_POUR_PARTICULARITE bap on bap.ID_BAGAGE = b.ID_BAGAGE left outer join BAGAGE_PARTICULARITE bp on bp.ID_PART = bap.ID_PARTICULARITE and bp.PARTICULARITE = 'RUSH' left outer join COMPAGNIE c on c.CODE_IATA = b.COMPAGNIE left outer join COMPAGNIE_CLASSE cc on cc.ID_COMPAGNIE = c.ID_COMPAGNIE and cc.CLASSE = b.CLASSE WHERE b.CODE_IATA = @codeIATA";

        string commandAddBagageRush = "INSERT INTO BAGAGE (CODE_IATA, COMPAGNIE, LIGNE, JOUR_EXPLOITATION, ESCALE, CLASSE, ORIGINE_CREATION, DATE_CREATION, CONTINUATION, PRIORITAIRE) VALUES (@codeIata, @compagnie, @ligne, @jourExploi, @escale, @classe, @origine, @dateCrea, @continuation, @prioritaire); INSERT INTO BAGAGE_A_POUR_PARTICULARITE (ID_BAGAGE, ID_PARTICULARITE)  VALUES (IDENT_CURRENT('BAGAGE'), 15)";

        string commandAddBagage = "INSERT INTO BAGAGE (CODE_IATA, COMPAGNIE, LIGNE, JOUR_EXPLOITATION, ESCALE, CLASSE, ORIGINE_CREATION, DATE_CREATION, CONTINUATION, PRIORITAIRE) VALUES (@codeIata, @compagnie, @ligne, @jourExploi, @escale, @classe, @origine, @dateCrea, @continuation, @prioritaire)";


        public override BagageDefinition GetBagage(int idBagage)
        {
            BagageDefinition bagRes = null;

            using (SqlConnection cnx = new SqlConnection(strCnx))
            {
                SqlCommand cmd = new SqlCommand(this.commandGetBagageId, cnx);
                cmd.Parameters.AddWithValue("@id", idBagage);
                cnx.Open();
                //Implémenter ici le code de récupération et de convertion

                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    if (sdr.Read())
                    {
                        bagRes = new BagageDefinition();

                        bagRes.CodeIata = sdr.GetString(sdr.GetOrdinal("code_iata"));
                        bagRes.Compagnie = sdr.GetString(sdr.GetOrdinal("compagnie"));
                        bagRes.DateVol = sdr.GetDateTime(sdr.GetOrdinal("date_creation"));
                        bagRes.EnContinuation = sdr.GetBoolean(sdr.GetOrdinal("continuation"));
                        bagRes.IdBagage = sdr.GetInt32(sdr.GetOrdinal("id_bagage"));
                        bagRes.Itineraire = sdr.GetString(sdr.GetOrdinal("escale"));
                        bagRes.Ligne = sdr.GetString(sdr.GetOrdinal("ligne"));
                        bagRes.Prioritaire = sdr.GetBoolean(sdr.GetOrdinal("prioritaire"));
                    }
                }
            }
            return bagRes;

        }


        public override List<BagageDefinition> GetBagage(string codeIataBagage)
        {
            var listBagages = new List<BagageDefinition>(); 

            using (SqlConnection cnx = new SqlConnection(strCnx))
            {
                SqlCommand cmd = new SqlCommand(this.commandGetBagageByCodeIata, cnx);
                cmd.Parameters.AddWithValue("@codeIATA", codeIataBagage);
                cnx.Open();

                //Implémenter ici le code de récupération et de convertion

                using (SqlDataReader sdr = cmd.ExecuteReader())
                {

                    while (sdr.Read())
                    {
                       BagageDefinition bagRes = new BagageDefinition();

                        bagRes.CodeIata = sdr.GetString(sdr.GetOrdinal("code_iata"));
                        try
                        {
                            bagRes.Compagnie = sdr.GetString(sdr.GetOrdinal("compagnie"));
                        }
                        catch(Exception exp)
                        {
                            bagRes.Compagnie = "INTROUVABLE"; 
                            Console.WriteLine("La compagnie associée au Code Iata " + bagRes.CodeIata + "est introuvable. \nVous référez à l'exception " +exp.Message); 
                        }
                        bagRes.DateVol = sdr.GetDateTime(sdr.GetOrdinal("date_creation"));
                        bagRes.EnContinuation = sdr.GetBoolean(sdr.GetOrdinal("continuation"));
                        bagRes.IdBagage = sdr.GetInt32(sdr.GetOrdinal("id_bagage"));
                        bagRes.Itineraire = sdr.GetString(sdr.GetOrdinal("escale"));
                        bagRes.Ligne = sdr.GetString(sdr.GetOrdinal("ligne"));
                        bagRes.Prioritaire = sdr.GetBoolean(sdr.GetOrdinal("prioritaire"));
                        bagRes.Rush = sdr.GetBoolean(sdr.GetOrdinal("RUSH"));
                        listBagages.Add(bagRes); 
                    }
                }
            }

            return listBagages; 
        }


        public override int CreateBagage(BagageDefinition bag)
        {
            using (SqlConnection cnx = new SqlConnection(strCnx))
            {
                SqlCommand cmd;

                if (bag.Rush)
                { cmd = new SqlCommand(this.commandAddBagageRush, cnx); }
                else
                { cmd = new SqlCommand(this.commandAddBagage, cnx); }

                Console.WriteLine("Prioritaire : " + bag.Prioritaire);

                cmd.Parameters.AddWithValue("@codeIata", bag.CodeIata);
                cmd.Parameters.AddWithValue("@compagnie", bag.Compagnie);
                cmd.Parameters.AddWithValue("@ligne", bag.Ligne);
                cmd.Parameters.AddWithValue("@jourExploi", "7");
                cmd.Parameters.AddWithValue("@escale", bag.Itineraire);
                cmd.Parameters.AddWithValue("@classe", "Y");
                cmd.Parameters.AddWithValue("@origine", "D");
                cmd.Parameters.AddWithValue("@dateCrea", DateTime.Now);

                if(bag.Prioritaire)
                { cmd.Parameters.AddWithValue("@prioritaire", true); }
                else
                { cmd.Parameters.AddWithValue("@prioritaire", false); }
                
                if (bag.EnContinuation)
                { cmd.Parameters.AddWithValue("@continuation", "Y"); }
                else
                { cmd.Parameters.AddWithValue("@continuation", "N"); }

                cnx.Open();

                var Idbag = Convert.ToInt32(cmd.ExecuteScalar());

                bag.IdBagage = Idbag;

                return bag.IdBagage;
 


            }
        }
    }
}
