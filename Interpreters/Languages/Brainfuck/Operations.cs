using System;
using System.Collections.Generic;
using System.Text;

namespace Interpreters
{
    internal class Operations
    {
        internal const char PIncrement = '>'; //increment the pointer position.
        internal const char PDecrement = '<'; //decrement the pointer position.
        internal const char Increment = '+'; //increment the value of the cell the pointer is pointing to.
        internal const char Decrement = '-'; //decrement the value of the cell the pointer is pointing to.
        internal const char Print = '.'; //output the value of the pointed cell, interpreting it as an ASCII value.
        internal const char Store = ','; //accept a positive one byte integer as input and store it in the pointed cell.
        internal const char Jump = '['; //jump to the instruction after the corresponding ] if the pointed cell's value is 0.
        internal const char JumpBack = ']'; //jump to the instruction after the corresponding ] if the pointed cell's value is 0.
    }
}
