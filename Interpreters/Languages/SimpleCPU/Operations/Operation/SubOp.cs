using System;
using Interpreters.Utils;

namespace Interpreters.SimpleCPU.Operations
{
    [OpCode('3')]
    internal class SubOp : IOperation
    {
        public void Exec(int[] registers, string operation)
        {
            int x = Utility.ParseHex(operation[1]); //register x
            int y = Utility.ParseHex(operation[2]); ; //register y
            registers[x] = registers[x] - registers[y];
            registers[0x2] = Convert.ToInt32(registers[x] < registers[y]);
            if (registers[x] < 0)
                registers[x] += 256;
        }
    }
}
