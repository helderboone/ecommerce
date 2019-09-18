using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Ecommerce.App.Features.Admin.Product.Queries;
using Ecommerce.App.Features.Shared;
using Ecommerce.Infra.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.App.Features.Admin.Product.Handlers
{
    public class IndexProductQueryHandler : IRequestHandler<IndexProductQuery, IResult>
    {
        private readonly DatabaseContext db;
        private readonly IMapper mapper;

        public IndexProductQueryHandler(DatabaseContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }
        public async Task<IResult> Handle(IndexProductQuery request, CancellationToken cancellationToken)
        {
            var products = await db.Products.AsNoTracking().ToListAsync();

            var mapped = mapper.Map<IEnumerable<Domain.Entities.Product>, IEnumerable<IndexProductQuery.Model.ProductModel>>(products);

            return new Result(new IndexProductQuery.Model { Products = mapped });
        }
    }
}
