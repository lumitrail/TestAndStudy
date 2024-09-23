using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAndStudy.Performances
{
    internal class SwitchDefault
    {
        List<double> Default = new();
        List<double> NoDefault = new();
        int DefaultFirst = 0;
        
        static Random rng = new(DateTime.Now.Millisecond);

        static int iterations => 50;
        static int IntervalMs => 100;

        public async Task SwitchDefaultBench()
        {
            string? input = Console.ReadLine();

            Console.WriteLine($"starting with {iterations} iterations.");

            for (int i = 0; i < iterations; ++i)
            {
                await Task.Delay(IntervalMs);
                double flipper = rng.NextDouble();

                if (flipper < 0.5)
                {
                    DefaultFirst++;
                    SwitchWithDefault(int.MaxValue);
                    SwitchWithoutDefault(int.MaxValue);
                }
                else
                {
                    SwitchWithoutDefault(int.MaxValue);
                    SwitchWithDefault(int.MaxValue);
                }
            }

            Console.WriteLine($"{iterations} iterations (default first {DefaultFirst} times)");
            Console.WriteLine($"Default avrg: {Default.Average()}ms");
            Console.WriteLine($"NoDefault avrg: {NoDefault.Average()}ms");

            input = Console.ReadLine();
        }

        void SwitchWithDefault(int iterations)
        {
            DateTime started = DateTime.Now;

            long modSum = 0;
            for (int i = 0; i < iterations; ++i)
            {
                int mod = i % 4;
                switch (mod)
                {
                    case 1:
                        modSum += 1;
                        break;
                    case 2:
                        modSum += 2;
                        break;
                    case 3:
                        modSum += 3;
                        break;
                    default:
                        modSum += 4;
                        break;
                }
            }

            DateTime ended = DateTime.Now;

            double ellapsedMs = (ended - started).TotalMilliseconds;

            Default.Add(ellapsedMs);

            //Console.WriteLine($"With default: {ellapsedMs}ms, sum {modSum}");
        }

        void SwitchWithoutDefault(int iterations)
        {
            DateTime started = DateTime.Now;

            long modSum = 0;
            for (int i = 0; i < iterations; ++i)
            {
                int mod = i % 4;
                switch (mod)
                {
                    case 1:
                        modSum += 1;
                        break;
                    case 2:
                        modSum += 2;
                        break;
                    case 3:
                        modSum += 3;
                        break;
                    case 0:
                        modSum += 4;
                        break;
                }
            }

            DateTime ended = DateTime.Now;

            double ellapsedMs = (ended - started).TotalMilliseconds;

            NoDefault.Add(ellapsedMs);

            //Console.WriteLine($"Without default: {ellapsedMs}ms, sum {modSum}");
        }
    }
}
