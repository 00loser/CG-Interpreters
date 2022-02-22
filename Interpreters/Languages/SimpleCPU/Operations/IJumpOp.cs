namespace Interpreters.SimpleCPU.Operations
{
    internal interface IJumpOp : IOperation
    {
        void Exec(int[] registers, string operation, out bool jump);
    }
}
