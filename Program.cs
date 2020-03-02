using System;
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

        void Run()
        {
            Console.WriteLine("Starting...");
            StreamReader sr = new StreamReader("..\\..\\..\\input\\first_adventure.in");

            //Load first line.
            int providers = 0, products = 0, countries = 0, projects = 0, count = 0;
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
            LoadRegions(sr, providers, products, countries);


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
    }
}
