using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        public Result(bool success)
        {
            this.success = success;
        }

        public Result(bool success, string message): this(success)
        {
            this.message = message;
        }

        public bool success { get; }

        public string message {get; }

    }
}
