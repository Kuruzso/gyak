using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using MySqlConnector;//NUGet-el feltelepítettük a mysql csomagot

namespace gyak
{
    class Program
    {
        static void Main(string[] args)
        {

            string connectionstring;//a kapcsolat létrehozásához szükséges adatok
          
            connectionstring = @"server=localhost;user=root;database=proba;";
            MySqlConnection kapcsolat;//az adatbázissal kapcsolódunk(még egyéb műveletet nem végez)
            kapcsolat = new MySqlConnection(connectionstring);
            kapcsolat.Open();//Ha nem jók a kapcsolat létrehozásához adatok akkor itt áll le

            string sql = "SELECT * FROM személy";//A futtatandó lekérdezés parancsa
            MySqlCommand mSqlCmd = new MySqlCommand(sql, kapcsolat);//A parancs futtatásához szükséges objektum
                                                                    //adott parancsot  akapcsolattal összeköti
            MySqlDataReader adatok = mSqlCmd.ExecuteReader();//A parancsokat futtatjuk,
                                                             //a keletkező adatokat tároljuk,
                                                             //ahoz hasonló mint a strteamreader
            while (adatok.Read())//Az adatok.read() beolvas egy rekordot (sort) az eredmény táblából
            {
                Console.WriteLine(adatok[0]);//Az adatok utáni index jelzi,
                                               //hogy hányadik mezőt kérem az eredménytáblából
            }

            kapcsolat.Clone();//a műveletek befejezése után mindig zárjuk a kapcsolatot!



            Console.ReadLine();
        }
    }
}
