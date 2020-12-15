using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public class categorieRepository
    {
        DbProviderFactory factory;
        string provider;
        string connectionString;

        public categorieRepository()
        {
            provider = ConfigurationManager.AppSettings["provider"];
            connectionString = ConfigurationManager.AppSettings["connectionString"];
            factory = DbProviderFactories.GetFactory(provider);
        }

        public List<categorie> GetAll()
        {
            var cat = new List<categorie>();
            using (var connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();
                var command = factory.CreateCommand();
                command.Connection = connection;
                command.CommandText = "select * from recette;";
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cat.Add(new categorie
                        {
                            titre_recette = (string)reader["titre_recette"],
                            nbre_personne = (int)reader["nbre_personne"],
                            temps_cuisson = (string)reader["temps_cuisson"]

                        });
                    }
                }
            }

            return cat;
        }
    }
}
