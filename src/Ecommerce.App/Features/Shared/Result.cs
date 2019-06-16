using System.Collections.Generic;

namespace Ecommerce.App.Features.Shared
{
    public class Result : IResult
    {
        private Result() { }

        public Result(object content, bool success = true)
        {
            Success = success;
            Content = content;
        } 

        public Result(string[] messages, bool success = true)
        {
            Success = success;
            Messages = messages;
        }

        public Result(bool success, string[] messages, object content)
        {
            Success = success;
            Messages = messages;
            Content = content;
        }

        public bool Success { get; private set; }

        public object Content { get; private set; }

        public string[] Messages { get; private set; }
    }
}
