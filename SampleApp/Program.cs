using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Interpreters;

public class Program
{
    static void Main(string[] args)
    {
        //you can reuse all created instances

        var bf = new BfInterpreter(500)
        {
            Code = "++++++++++[>+++++++>++++++++++>+++<<<-]>++.>+.+++++++..+++.>++.<<+++++++++++++++.>.+++.------.--------.>+.",
        };
        var cpuEmu = new SEmulator()
        {
            Code = "100F111271122001A0010000300100002001"
        };


        try
        {
            cpuEmu.Execute();
            bf.Execute();
        }
        catch (InterpreterException e)
        {
            Console.Write(e.Message);
        }
        
        Console.WriteLine(bf.Output);
        Console.WriteLine(cpuEmu.Output);

        Console.ReadKey();
    }
}
