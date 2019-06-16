using AutoMapper;
using Ecommerce.App.Features.Admin.Product.Commands;
using Ecommerce.App.Features.Admin.Product.Queries;
using Ecommerce.App.Features.Shared;
using Ecommerce.Domain.Entities;
using Ecommerce.Infra.Context;
using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ecommerce.App.Features.Admin.Product.Handlers
{
    public class CreateProductQueryHandler : IRequestHandler<CreateProductQuery, IResult>
    {
        private readonly DatabaseContext db;
        private readonly IMapper mapper;

        public CreateProductQueryHandler(DatabaseContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }
        

        public async Task<IResult> Handle(CreateProductQuery request, CancellationToken cancellationToken)
        {
            var categories = await db.Categories.AsNoTracking().ToListAsync();

            var mapped = mapper.Map<IEnumerable<Category>, IEnumerable<SelectListItem>>(categories);

            return new Result(new CreateProductCommand { Categories = mapped });
        }
    }
}
