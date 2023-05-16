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
            string[] zenek = new string[sorok.Length];
            string[] szerzok = new string[sorok.Length];
            int[] csillagok = new int[sorok.Length];
            List<string> zenelista = new List<string>();
            List<string> szerzolista = new List<string>();
            List<int> csillaglista = new List<int>();
            for (int i = 0; i < sorok.Length; i++)
            {
                zenek[i] = sorok[i].Split('\t')[1];
                zenelista.Add(zenek[i]);
                szerzok[i] = sorok[i].Split('\t')[2];
                szerzolista.Add(szerzok[i]);
                csillagok[i] = int.Parse(sorok[i].Split('\t')[0]);
                csillaglista.Add(csillagok[i]);
            }
            List<string> minden = new List<string>();
            while (valasz != "3")
            {
                Console.WriteLine("Adja meg mit szeretne csinálni");
                Console.WriteLine("[1]Zeneszám felvétele");
                Console.WriteLine("[2]Slágerlista megtekintése");
                Console.WriteLine("[3]Kilépés");
                valasz = Console.ReadLine();
                string zene ="";
                string szerzo="";
                if (valasz == "1")
                {
                    for (int i = 0; i < 9; i++)
                    {
                        Console.WriteLine("Adja meg az egyik kedvenc zenéjét");
                        zene = Console.ReadLine();
                        Console.WriteLine("Adja meg a szerzőjét");
                        szerzo = Console.ReadLine();
                        for (int f = 0; f < zenelista.Count; f++)
                        {
                            if ((zenelista[f] == zene) && (szerzolista[f] == szerzo))
                            {                          
                                csillaglista[f] = csillaglista[f] + 1;
                                break;
                            }
                            if (f == zenelista.Count-1)
                            {
                                zenelista.Add(zene);
                                szerzolista.Add(szerzo);
                                csillaglista.Add(1);
                            }
                        }
                    }                                    
                    Console.Clear();
                   
                    StreamWriter sw = File.AppendText("adatok.txt");

                    for (int i = 0; i < zenelista.Count; i++)
                    {
                        sw.WriteLine(csillaglista[i] + "\t" + szerzolista[i] +"\t"+ zenelista[i]);
                    }
                        sw.Close();
                }
                else if (valasz == "2")
                {
                    for (int i = 0; i < zenelista.Count; i++)
                    {
                        minden.Add( csillaglista[i] + "\t" + szerzolista[i] + "\t" + zenelista[i]);
                    }
                    string ideiglenes;
                    for (int i = 0; i < minden.Count - 1; i++)
                    {
                        for (int j = 0; j < minden.Count - 1; j++)
                        {
                            if (int.Parse(minden[j].Split('\t')[0]) < int.Parse(minden[j + 1].Split('\t')[0]))
                            {
                                ideiglenes = minden[j];
                                minden[j] = minden[j + 1];
                                minden[j + 1] = ideiglenes;
                            }
                        }
                    }
                    int hosz = 10;
                    if (minden.Count < 10)
                    {
                        hosz = minden.Count;
                    }
                    for (int i = 0; i < hosz; i++)
                    {
                        Console.WriteLine("{0}", minden[i]);
                    }
                    Console.WriteLine("Nyomjon entert a visszalépéshez");
                    Console.ReadLine();
                    Console.Clear();
                }
                else if (valasz == "3")
                {
                    System.Environment.Exit(0);
                }
            }

        }
    }
}