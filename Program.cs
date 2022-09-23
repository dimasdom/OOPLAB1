using System;
using System.Collections.Generic;
using System.Linq;

namespace OOPLAB1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

        }
        class Factory
        {
            public main()
            {
                Console.WriteLine();
                switch (Console.ReadLine())
                {
                    case:;
                        break;
                            default
                }
            }
            private List<EnergyConsuption> EnergyConsuption { get; set; }
            public void addEnergyConsuption(double plan, double fact)
            {
                this.EnergyConsuption.Add(new EnergyConsuption(plan, fact));
            }

            private double getDeviation(EnergyConsuption energyConsuption)
            {
                return energyConsuption.plan - energyConsuption.fact;
            }
            private double getDeviationRate(EnergyConsuption energyConsuption)
            {
                return (energyConsuption.plan - energyConsuption.fact) * 100 / energyConsuption.plan;
            }
            (double plan, double fact) getSumResults()
            {
                return ((from consumption in this.EnergyConsuption select consumption.plan).Sum(), (from consumption in this.EnergyConsuption select consumption.fact).Sum());
            }
        }
        class EnergyConsuption
        {
            public EnergyConsuption(double plan, double fact)
            {
                this.plan = plan;
                this.fact = fact;
            }

            public double plan { get; set; }
            public double fact { get; set; }
        }
    }
}
