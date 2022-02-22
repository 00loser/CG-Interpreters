namespace Interpreters.SimpleCPU.Operations
{
    internal interface IOperation
    {
        void Exec(int[] registers, string operation);
    }
}
