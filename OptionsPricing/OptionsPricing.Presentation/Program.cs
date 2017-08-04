using OptionsPricing.Application;

namespace OptionsPricing.Presentation
{
    class Program
    {        
        static void Main(string[] args)
        {
            var executionProcess = new ExecutionProcess();
            executionProcess.Execute();
        }
    }
}
