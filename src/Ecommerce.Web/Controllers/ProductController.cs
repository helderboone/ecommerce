using Ecommerce.App.Features.Admin.Product.Commands;
using Ecommerce.App.Features.Admin.Product.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IMediator mediator;

        public ProductController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Index(IndexProduct.Query query)
        {
            var result = await mediator.Send(query);

            if (result.Success) return View(result.Content);

            TempData["ErrorMessage"] = "Something wrong happend, please try again";
            return RedirectToAction("Error");            
        }

        [HttpGet]
        public async Task<IActionResult> Create(CreateProductQuery query)
        {
            var result = await mediator.Send(query);

            if (result.Success) return View(result.Content);

            TempData["ErrorMessage"] = "Something wrong happend, please try again";

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductCommand command)
        {
            if (!ModelState.IsValid) return View(command);

            var result = await mediator.Send(command);

            if (result.Success)
            {
                TempData["SuccessMessage"] = result.Messages.FirstOrDefault();

                return RedirectToAction(nameof(Index));
            }

            TempData["ErrorMessage"] = result.Messages.FirstOrDefault();

            return RedirectToAction("Index", "Home");

        }
    }
}
