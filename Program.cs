using System;
using System.Collections.Generic;
using System.IO;

namespace Reply2018Final
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            p.Run();
        }

        public Provider[] prov;
        public Project[] proj;

        void Run()
        {
            Console.WriteLine("Starting...");
            StreamReader sr = new StreamReader("..\\..\\..\\input\\first_adventure.in");

            //Load first line.
            int providers = 0, products = 0, countries = 0, projects = 0, count = 0;
            Dictionary<string, int> country = new Dictionary<string, int>();
            string line = sr.ReadLine();
            string temp = "";
            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] != ' ')
                {
                    temp = temp + line[i];
                    if (i != line.Length - 1)
                    {
                        continue;
                    }
                }
                if (count == 0)
                {
                    providers = Int32.Parse(temp);
                    temp = "";
                }
                if (count == 1)
                {
                    products = Int32.Parse(temp);
                    temp = "";
                }
                if (count == 2)
                {
                    countries = Int32.Parse(temp);
                    temp = "";
                }
                if (count == 3)
                {
                    projects = Int32.Parse(temp);
                    temp = "";
                }
                count++;
            }

            //Load second line
            line = sr.ReadLine();
            temp = "";
            string[] productNames = new string[products];
            count = 0;
            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] != ' ')
                {
                    temp = temp + line[i];
                    if (i != line.Length - 1)
                    {
                        continue;
                    }
                }
                productNames[count] = temp;
                temp = "";
                count++;
            }

            //Load Third line
            line = sr.ReadLine();
            temp = "";
            count = 0;
            string[] countryNames = new string[countries];
            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] != ' ')
                {
                    temp = temp + line[i];
                    if (i != line.Length - 1)
                    {
                        continue;
                    }
                }
                countryNames[count] = temp;
                country.Add(temp, count);
                temp = "";
                count++;
            }

            Console.WriteLine("Providers: " + providers);
            Console.WriteLine("Products: " + products);
            Console.WriteLine("Countries: " + countries);
            Console.WriteLine("Projects: " + projects);

            Console.WriteLine("Product 3: " + productNames[2]);

            Console.WriteLine("Country 4: " + countryNames[3]);

            prov = new Provider[providers];
            proj = new Project[projects];
            LoadRegions(sr, providers, products, countries);
            LoadProjects(sr, projects, products, country);

            Console.ReadKey();


            //1st Open File
            //2nd Create Agent
            //3rd Load Agent
            //4th Take best agent and clone
            //5th repeat till we win.
        }

        public void LoadRegions(StreamReader sr, int providers, int products, int countries)
        {
            for (int p = 0; p < providers; p++)
            {
                string line = sr.ReadLine();
                string temp = "", name = "";
                int regs = 0;
                //Read Name and # of regions
                for (int i = 0; i < line.Length; i++)
                {
                    if (line[i] != ' ')
                    {
                        temp = temp + line[i];
                        if (i != line.Length - 1)
                        {
                            continue;
                        }
                    }
                    if (name == "")
                    {
                        name = temp;
                        temp = "";
                    }
                    else
                    {
                        regs = Int32.Parse(temp);
                        temp = "";
                    }
                }
                prov[p] = new Provider(name, regs);

                //Read regions
                for (int x = 0; x < prov[p].regionNum; x++)
                {
                    name = sr.ReadLine();
                    line = sr.ReadLine();
                    int count = 0, pNum = 0;
                    int[] prods = new int[products];
                    int[] latencies = new int[countries];
                    float price = 0.0f;
                    for (int i = 0; i < line.Length; i++)
                    {
                        if (line[i] != ' ')
                        {
                            temp = temp + line[i];
                            if (i != line.Length - 1)
                            {
                                continue;
                            }
                        }
                        if (count == 0)
                        {
                            pNum = Int32.Parse(temp);
                            temp = "";
                        }
                        else if (count == 1)
                        {
                            price = float.Parse(temp);
                            temp = "";
                        }
                        else
                        {
                            prods[count - 2] = Int32.Parse(temp);
                            temp = "";
                        }
                        count++;
                    }
                    count = 0;
                    line = sr.ReadLine();
                    for (int i = 0; i < line.Length; i++)
                    {
                        if (line[i] != ' ')
                        {
                            temp = temp + line[i];
                            if (i != line.Length - 1)
                            {
                                continue;
                            }
                        }
                        latencies[count] = Int32.Parse(temp);
                        temp = "";
                        count++;
                    }
                    prov[p].regions[x] = new Region(name, pNum, price, prods, latencies);
                }
            }
        }

        public void LoadProjects(StreamReader sr, int projects, int productNum, Dictionary<string, int> c)        {
            string line = "";
            string temp = "";
            string country = "";
            int penalty = -1, count = 0;
            int[] products = new int[productNum];
            for (int p = 0; p < projects; p++)
            {
                count = 0;
                temp = "";
                penalty = -1;
                line = sr.ReadLine();
                for (int i = 0; i < line.Length; i++)
                {
                    if (line[i] != ' ')
                    {
                        temp = temp + line[i];
                        if (i != line.Length - 1)
                        {
                            continue;
                        }
                    }
                    if (count == 0)
                    {
                        penalty = Int32.Parse(temp);
                        temp = "";
                    }
                    else if (count == 1)
                    {
                        country = temp;
                        temp = "";
                    }
                    else
                    {
                        products[count - 2] = Int32.Parse(temp);
                        temp = "";
                    }
                    count++;
                }
                proj[p] = new Project(penalty, c[country], products);
            }
        }
    }
}
