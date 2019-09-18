using System.Collections.Generic;

namespace Ecommerce.App.Features.Shared
{
    public interface IResult
    {
        bool Success { get; }

        string[] Messages { get; }

        object Content { get; }
    }
}
