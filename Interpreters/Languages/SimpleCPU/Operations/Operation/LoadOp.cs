using Interpreters.Utils;

namespace Interpreters.SimpleCPU.Operations
{
    [OpCode('1')]
    internal class LoadOp : IOperation
    {
        public void Exec(int[] registers, string operation)
        {
            int k = Utility.ParseHex(operation[0]);
            int nn = Utility.ParseHex(operation.Remove(0, 1)); //operation[2..] 
            registers[k] = nn; 
        }
    }
}
