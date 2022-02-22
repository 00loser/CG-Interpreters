using System;

namespace Interpreters.SimpleCPU.Operations
{
    public class OpCode : Attribute
    {
        public char Code;

        public OpCode(char Code) =>
            this.Code = Code;       
    }
}
