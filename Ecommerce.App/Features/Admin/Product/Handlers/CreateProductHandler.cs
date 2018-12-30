using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Ecommerce.App.Features.Admin.Product.Commands;
using MediatR;

namespace Ecommerce.App.Features.Admin.Product.Handlers
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand>
    {
        private readonly IMapper mapper;

        public CreateProductHandler(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public Task<Unit> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = mapper.Map<CreateProductCommand, Domain.Entities.Product>(request);

            return Unit.Task;
        }
    }
}
