using Ecommerce.App.Features.Shared;
using MediatR;
using System.Collections.Generic;

namespace Ecommerce.App.Features.Admin.Product.Queries
{
    public class IndexProductQuery : IRequest<IResult>
    {
        public class Model
        {
            public IEnumerable<ProductModel> Products { get; set; }

            public class ProductModel
            {
                public int Id { get; set; }

                public string Name { get; set; }

                public string Description { get; set; }

                public int CategoryName { get; set; }
            }
        }
    }
}
