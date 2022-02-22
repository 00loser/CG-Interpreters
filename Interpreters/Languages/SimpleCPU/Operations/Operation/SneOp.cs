using System;
using Interpreters.Utils;

namespace Interpreters.SimpleCPU.Operations
{
    [OpCode('8')]
    internal class SneOp : IJumpOp
    {
        public void Exec(int[] registers, string operation, out bool jump)
        {
            int k = Utility.ParseHex(operation[0]);
            int nn = Utility.ParseHex(operation.Remove(0, 1)); //operation[2..] 
            jump = registers[k] != nn;
        }

        public void Exec(int[] registers, string operation) =>
            throw new NotImplementedException();
    }
}
