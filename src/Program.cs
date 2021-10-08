using DotnetActionsToolkit;
using System;
using System.Collections;
using System.Threading.Tasks;

namespace dotnet_sample_action
{
    public class Program
    {
        static readonly Core _core = new Core();

        static double Phi = (1 + Math.Pow(5, .5)) / 2;
        static double phi = (1 - Math.Pow(5, .5)) / 2;
        static ulong[] generateFibonaccisClosed(int n)
        {
            ulong[] fib = new ulong[n];
            for (int i = 0; i < n; i++)
            {
                fib[i] = (ulong)((Math.Pow(Phi, i) - Math.Pow(phi, i)) / (Phi - phi));
            }
            return fib;
        }

        static void Main(string[] args)
        {
            try
            {
                var fibNumber = Int32.Parse(_core.GetInput("fibNumber"));
                _core.Info($"Generating up to {fibNumber}..."); // debug is only output if you set teh secret ACTIONS_RUNNER_DEBUG to true

                _core.Debug(DateTime.Now.ToLongTimeString());
                var fibs = generateFibonaccisClosed(fibNumber);
                _core.Debug(DateTime.Now.ToLongTimeString());
                _core.Info(String.Join(',', fibs));

            }
            catch (Exception ex)
            {
                _core.SetFailed(ex.Message);
            }
        }
    }
}
