using System;
using System.Collections.Generic;
using System.Linq;

namespace OOPLAB1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var ourFactory = new Factory();
            ourFactory.main();

        }
        class Factory
        {
            public Factory()
            {
                this.EnergyConsuption= new List<EnergyConsuption>();
            }

            public void main()
            {
                Console.WriteLine("Welcome");
                Console.WriteLine("Choose what you want to get");
                
                this.startConsoleInterface();
            }
            private List<EnergyConsuption> EnergyConsuption { get; set; }
            public void addEnergyConsuption(float plan, float fact)
            {
                this.EnergyConsuption.Add(new EnergyConsuption(plan, fact));
            }
            private void startConsoleInterface()
            {
                Console.WriteLine("Type 1 for set energy consumption data");
                Console.WriteLine("Type 2 for get deviation");
                Console.WriteLine("Type 3 for get deviation rate");
                Console.WriteLine("Type 4 for get all data in table");
                Console.WriteLine("Type exit to close a program");
                string variant = Console.ReadLine();
                switch (variant)
                {
                    case "1":
                        {
                            this.consoleSetCount();
                        }
                        break;
                    case "2":
                        {
                           this.consoleGetDeviation();
                        }
                        break;
                    case "3":
                        {
                            this.consoleGetDeviationRate();
                        }
                        break;
                    case "4":
                        {
                            this.consoleGetTotalSum();
                        }
                        break;
                    case "exit":
                        {
                            Console.WriteLine("END");
                        }
                        break;
                    default:
                        {
                            this.startConsoleInterface();
                        }
                        break;
                }
            }
            private void consoleSetCount()
            {
                Console.WriteLine("Set count of records");
                string count = Console.ReadLine();
                Console.WriteLine("First is plan second is fact consumtion");
                for (int i = 0; i < Int32.Parse(count); i++)
                {
                    string data = Console.ReadLine();
                    string[] dataArr = new string[] { };
                    if (data.Contains(" "))
                    {
                        dataArr = data.Split(" ");
                    }
                    if (dataArr.Length == 2)
                    {
                        this.addEnergyConsuption(float.Parse(dataArr[0]), float.Parse(dataArr[1]));

                    }
                    else
                    {
                        Console.WriteLine("Wrong data try again");
                        i -= 1;
                    }
                }
                this.startConsoleInterface();
            }
            private void consoleGetDeviation()
            {
                string data = Console.ReadLine();
                string[] dataArr = new string[] { };
                if (data.Contains(","))
                {
                    dataArr = data.Split(",");
                }
                else if (data.Contains(" "))
                {
                    dataArr = data.Split(" ");
                }
                if (dataArr.Length == 2)
                {
                    this.getDeviation(new EnergyConsuption(float.Parse(dataArr[0]), float.Parse(dataArr[1])));
                    this.startConsoleInterface();
                }
                else
                {
                    Console.WriteLine("Wrong data try again");
                    this.consoleGetDeviation();
                }
                this.startConsoleInterface();
            }
            private void consoleGetDeviationRate()
            {
                string data = Console.ReadLine();
                string[] dataArr = new string[] { };
                if (data.Contains(","))
                {
                    dataArr = data.Split(",");
                }
                else if (data.Contains(" "))
                {
                    dataArr = data.Split(" ");
                }
                if (dataArr.Length == 2)
                {
                    this.getDeviationRate(new EnergyConsuption(float.Parse(dataArr[0]), float.Parse(dataArr[1])));
                    this.startConsoleInterface();
                }
                else
                {
                    Console.WriteLine("Wrong data try again");
                    this.consoleGetDeviationRate();
                }
                this.startConsoleInterface();
            }
            private void consoleGetTotalSum()
            {

                Console.WriteLine("_______________________________________________________");
                Console.WriteLine("|Energy consumption kwt*h|    Deviation from plan     |");
                Console.WriteLine("|________________________|____________________________|");
                Console.WriteLine("|   planned |     fact   |    in kwt*h  |    in%      |");
                Console.WriteLine("|________________________|____________________________|");
                this.EnergyConsuption.ForEach(e =>
                {

                    Console.WriteLine($"|   {e.plan}      |     {e.fact}      |     {this.getDeviation(e)}     |    {this.getDeviationRate(e)}       |");
                });
                Console.WriteLine("|________________________|____________________________|");
                var sum = this.getSumResults();
                Console.WriteLine($"|     {sum.plan}     |      {sum.fact}     |                               |");
                Console.WriteLine("|________________________|____________________________|");
                this.startConsoleInterface();
            }
            private float getDeviation(EnergyConsuption energyConsuption)
            {
                return energyConsuption.plan - energyConsuption.fact;
            }
            private float getDeviationRate(EnergyConsuption energyConsuption)
            {
                return (energyConsuption.plan - energyConsuption.fact) * 100 / energyConsuption.plan;
            }
            (float plan, float fact) getSumResults()
            {
                return ((from consumption in this.EnergyConsuption select consumption.plan).Sum(), (from consumption in this.EnergyConsuption select consumption.fact).Sum());
            }
        }
        class EnergyConsuption
        {
            public EnergyConsuption(float plan, float fact)
            {
                this.plan = plan;
                this.fact = fact;
            }

            public float plan { get; set; }
            public float fact { get; set; }
        }
    }
}
