using System;
using System.Reflection;
using System.Linq;
using Interpreters.SimpleCPU.Operations;
using Interpreters.Utils;
using System.Collections.Generic;

namespace Interpreters
{
    public class SEmulator
    {
        private static readonly Dictionary<char, IOperation> opDict;
        private readonly int[] registers = new int[3];
        private readonly List<char> jumpOp = new List<char>(4) { '7', '8', '9', 'A' };
        private string _code = string.Empty;
        private string _output = string.Empty;

        public string Code
        {
            get => _code;
            set => _code = value;
        }

        public string Output
        {
            get => _output;
        }

        static SEmulator() =>
            opDict = Assembly.GetAssembly(typeof(SEmulator)).GetTypes().Where(type => type.GetInterfaces().Contains(typeof(IOperation)) && !type.IsInterface)
            .ToDictionary(k => k.GetCustomAttribute<OpCode>().Code, v => (IOperation)Activator.CreateInstance(v));

        public SEmulator() {}

        public SEmulator(string code) =>
            _code = code;

        public void Execute()
        {
            if (_code.Length % 4 != 0)
                throw new Exception("Invalid code");
            var operations = _code.Chunks(4);
            int index = 0;
            _output = string.Empty;
            while (index < operations.Count)
            {
                char op_code = operations[index][0];
                IOperation operation;
                string op_params = operations[index].Remove(0, 1);
                bool shallJump = false;
                if (opDict.TryGetValue(op_code, out operation))
                {
                    if (!jumpOp.Contains(op_code))
                        operation.Exec(registers, op_params);
                    else
                        ((IJumpOp)operation).Exec(registers, op_params, out shallJump);
                }
                else if (op_code == '0') break; //exit opcode
                else throw new InterpreterException(index * operations[index].Length + 1, op_code.ToString(), "Invalid OpCode");
                index += 1 + Convert.ToInt32(shallJump);
            }
            _output = string.Join(" ", registers);
            for (int i = 0; i < registers.Length; registers[i] = 0, i++);
        }
    }
}
