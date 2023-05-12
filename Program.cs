using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector; //NuGet-tel feltelepítettük a MySqlConnector csomagot

namespace adatbazis
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector; //NuGet-tel feltelepítettük a MySqlConnector csomagot

namespace adatbazis
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString; //A kapcsolat létrehozásához szükséges adatok
            connectionString = @"server = localhost;user = root;database = proba";
            MySqlConnection kapcsolat; //Az adatbázissal kapcsolódunk (még egyéb műveletet nem végez)
            kapcsolat = new MySqlConnection(connectionString);
            List<string> adatbazislista = new List<string>();
            try
            {
                kapcsolat.Open(); //Ha nem jók a kapcsolat létrehozásához szüséges adatok, akkor itt áll le,
                                  //ha sikeres, akkor innentől elérhető az adatbázis
                string sql = "SELECT * FROM személy"; //A futtatandó lekérdezés parancsa
                MySqlCommand mSqlCmd = new MySqlCommand(sql, kapcsolat); //A parancs futtatásához szükséges objektum,

                string nev = "sanyi";
                string telepules = "peru";

                MySqlCommand hozzaad = new MySqlCommand($"INSERT INTO `személy` (`nev`, `telepules`) VALUES('{nev}', '{telepules}')",kapcsolat);
                hozzaad.ExecuteNonQuery();

                //adott parancsot a kapcsolattal összeköti
                MySqlDataReader adatok = mSqlCmd.ExecuteReader();//A parancsot futtatjuk,
                                                                 //a keletkező adatokat tároljuk
                                                                 //ahhoz hasonló, mint a StreamReader
               

                while (adatok.Read()) //Az adatok.Read() beolvas egy rekordot (sort) az eredménytáblából
                {
                    //összeállítok egy stringet az adatokból
                    StringBuilder ujString = new StringBuilder();
                    for (int i = 0; i < adatok.FieldCount; i++)
                    {
                        ujString.Append(adatok[i] + " ");
                    }
                    adatbazislista.Add(Convert.ToString(ujString)); //Az adatok utáni index jelzi,
                                                                    //hogy hányadik mezőt kérem az eredménytáblából
                }
                for (int i = 0; i < adatbazislista.Count; i++)
                {
                    Console.WriteLine(adatbazislista[i]);
                }
                kapcsolat.Close(); //A műveletek befejezése után mindig zárjuk a kapcsolatot!
            }
            catch (Exception)
            {
                Console.WriteLine("Valami hiba történt!");
            }

            Console.ReadKey();
        }
    }
}

