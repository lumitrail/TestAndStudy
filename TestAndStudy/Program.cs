namespace TestAndStudy
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            await new Performances.SwitchDefault().SwitchDefaultBench();
        }
    }
}
