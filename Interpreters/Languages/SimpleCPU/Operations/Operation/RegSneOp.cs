using System;
using Interpreters.Utils;

namespace Interpreters.SimpleCPU.Operations
{
    [OpCode('A')]
    class RegSneOp : IJumpOp
    {
        public void Exec(int[] registers, string operation, out bool jump)
        {
            int x = Utility.ParseHex(operation[1]); //register x
            int y = Utility.ParseHex(operation[2]); //register y
            jump = registers[x] != registers[y];
        }

        public void Exec(int[] registers, string operation) =>
            throw new NotImplementedException();
    }
}
