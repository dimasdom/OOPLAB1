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
                this.EnergyConsuption = new List<EnergyConsuption>();
            }

            public void main()
            {
                Console.WriteLine("Welcome");
                Console.WriteLine("Choose what you want to get");

                this.startConsoleInterface();
            }
            private List<EnergyConsuption> EnergyConsuption { get; set; }
            public void addEnergyConsuption(string name, float plan, float fact)
            {
                this.EnergyConsuption.Add(new EnergyConsuption(name, plan, fact));
            }
            private void startConsoleInterface()
            {
                Console.WriteLine("Type 1 for set energy consumption data");
                Console.WriteLine("Type 2 for get all data in table");
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
                Console.WriteLine("Name of Factory, plan, fact consumtion. [Abcdef xxx,xx xxx,xxx]");
                for (int i = 0; i < Int32.Parse(count); i++)
                {
                    string data = Console.ReadLine();
                    string[] dataArr = new string[] { };
                    if (data.Contains(" "))
                    {
                        dataArr = data.Split(" ");
                    }
                    if (dataArr.Length == 3)
                    {
                        this.addEnergyConsuption(dataArr[0], float.Parse(dataArr[1]), float.Parse(dataArr[2]));

                    }
                    else
                    {
                        Console.WriteLine("Wrong data try again");
                        i -= 1;
                    }
                }
                this.startConsoleInterface();
            }
            private void consoleGetTotalSum()
            {

                Console.WriteLine("+----------------------------------------------------------------------+");
                Console.WriteLine("|             |  Energy consumption kwt*h  |    Deviation from plan    |");
                Console.WriteLine("|   Factory   |--------------------------------------------------------|");
                Console.WriteLine("|             |   planned   |     fact     |   in kwt*h   |     in%    |");
                Console.WriteLine("|----------------------------------------------------------------------|");
                this.EnergyConsuption.ForEach(e =>
                {
                    Console.WriteLine($"|   {e.name,-10}|   {e.plan,-10}|    {e.fact,-10}|  {this.getDeviation(e),-12}|  {this.getDeviationRate(e),-10}|");
                    Console.WriteLine("|----------------------------------------------------------------------|");
                });
                var sum = this.getSumResults();
                Console.WriteLine($"|    Sum      |   {sum.plan,-10}|    {sum.fact,-10}|                           |");
                Console.WriteLine("+----------------------------------------------------------------------+");
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
            public EnergyConsuption(string name, float plan, float fact)
            {
                this.name = name;
                this.plan = plan;
                this.fact = fact;
            }

            public string name { get; set; }
            public float plan { get; set; }
            public float fact { get; set; }
        }
    }
}