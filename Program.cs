using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace slagerlista
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] sorok = File.ReadAllLines("adatok.txt");
            string valasz = "";

            while (valasz != "3")
            {
                Console.WriteLine("Adja meg mit szeretne csinálni");
                Console.WriteLine("[1]Zeneszám felvétele");
                Console.WriteLine("[2]Slágerlista megtekintése");
                Console.WriteLine("[3]Kilépés");
                valasz = Console.ReadLine();
                List<string> zenelista = new List<string>();
                List<string> szerzolista = new List<string>();
                List<int> pontozas = new List<int>();

                int szamlalo = 0;
                if (valasz == "1")
                {
                    for (int i = 0; i < 11; i++)
                    {
                        Console.WriteLine("Adja meg az egyik kedvenc zenéjét");
                        string zene = Console.ReadLine();
                        Console.WriteLine("Adja meg a szerzőjét");
                        string szerzo = Console.ReadLine();



                        szamlalo = +1;

                        zenelista.Add(zene);
                        szerzolista.Add(szerzo);
                        pontozas.Add(pontszam);

                        zenelista.Sort();
                        szerzolista.Sort();
                        pontozas.Sort();

                        StreamWriter sw = File.AppendText("adatok.txt");


                        sw.WriteLine(zene + "\t" + szerzo + "");



                        sw.Close();

                    }
                }
                else if (valasz == "2")
                {

                    for (int i = 0; i < 11; i++)
                    {
                        Console.WriteLine("Cím:{0} , Szerző:{1} , Csillag{3}", zenelista[i], szerzolista[i], pontozas[i]);

                    }
                }
                else if (valasz == "3")
                {
                    System.Environment.Exit(0);
                }
            }
            
        }
    }
}
