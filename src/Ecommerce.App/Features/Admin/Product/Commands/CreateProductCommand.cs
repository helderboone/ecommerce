using MediatR;

namespace Ecommerce.App.Features.Admin.Product.Commands
{
    public class CreateProductCommand : IRequest
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
