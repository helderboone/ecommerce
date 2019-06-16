using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Ecommerce.App.Features.Admin.Product.Commands;
using Ecommerce.App.Features.Shared;
using Ecommerce.Infra.Context;
using MediatR;

namespace Ecommerce.App.Features.Admin.Product.Handlers
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, IResult>
    {
        private readonly DatabaseContext db;
        private readonly IMapper mapper;

        public CreateProductCommandHandler(DatabaseContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<IResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = mapper.Map<CreateProductCommand, Domain.Entities.Product>(request);

            db.Products.Add(product);

            await db.SaveChangesAsync();

            return new Result(new string[] { "Product created with success!" });
        }
    }
}
