using System;
using System.Collections.Generic;
using System.Text;

namespace Interpreters
{
    public class InterpreterException : Exception
    {
        private int _position;
        private string _error;
        private string _code;

        public int Position { get => _position; }
        public string Error { get => _error; }
        public string Code { get => _code; }

        public override string Message => $"{_error} at {_code} (pos: {_position})";

        public InterpreterException(int position, string code, string error)
        {
            _position = position;
            _error = error;
            _code = code;
        }
    }
}
