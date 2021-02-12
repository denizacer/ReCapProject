using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        public Result(bool success, string message) : this(success)
        {
            //this clasın kendisi demek .alttaki cons. çağırdı thislle ve birlikte çalışması sağlandı
            Message = message;

        }
        public Result(bool success)
        {

            Success = success;//overloading
        }
        //iki tane constructor oldu
        public bool Success { get; }

        public string Message { get; }
    }
}
