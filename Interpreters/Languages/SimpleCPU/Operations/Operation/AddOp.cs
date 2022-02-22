using System;
using Interpreters.Utils;

namespace Interpreters.SimpleCPU.Operations
{
    [OpCode('2')]
    internal class AddOp : IOperation
    {
        public void Exec(int[] registers, string operation)
        {
            int x = Utility.ParseHex(operation[1]); //register x
            int y = Utility.ParseHex(operation[2]); ; //register y
            registers[x] = (registers[x] + registers[y]) & 0xFF;
            registers[0x2] = Convert.ToInt32(registers[x].ToString().Length > 2);
        }
    }
}
