using Interpreters.Utils;

namespace Interpreters.SimpleCPU.Operations
{
    [OpCode('5')]
    internal class AndOp : IOperation
    {
        public void Exec(int[] registers, string operation)
        {
            int x = Utility.ParseHex(operation[1]); //register x
            int y = Utility.ParseHex(operation[2]); ; //register y
            registers[x] &= registers[y];
        }
    }
}
