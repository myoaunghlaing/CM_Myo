using System;
using System.Collections.Generic;
using System.Text;

namespace CM_Quizz
{
    public class InvalidTriangleException : Exception
    {
        public static readonly string defaultMessage = "Triangle is invalid";
        public InvalidTriangleException() : base(defaultMessage) { }
        public InvalidTriangleException(string message) : base(message) { }
    }
}
