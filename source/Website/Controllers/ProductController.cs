using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Website.Models;

namespace Website.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }

        public IActionResult ListProducts(int page = 1, int pageSize = 24)
        {
            var model = new ProductsListViewModel()
            {
                CurrentPage = page
            };

            //fetch products from our "index"
            var lookupresult = new Shared.Index.IndexService().GetProducts(new Shared.Index.Models.LookupRequest
            {
                CultureCode = "en-GB",
                Page = page,
                PageSize = pageSize
            }, out int total);

            model.TotalResults = total;

            foreach (var item in lookupresult)
            {
                var priceRange = item.Variants.Any() ? $"{item.Variants.Min(x => x.Price)} - {item.Variants.Max(x => x.Price)}" : "N/A";
                model.Products.Add(new ListProductViewModel
                {
                    Id = item.Id,
                    Name = item.Name,
                    PriceRange = priceRange,
                    ImageUrl = item.ImageUrl
                });
            }

            return View(model);
        }

        public IActionResult ProductPage(int productId, int? variantId = null)
        {
            var model = new ProductPageViewModel();

            //get product from our "index"
            var product = new Shared.Index.IndexService().GetProduct(productId, "en-GB");

            if (product == null)
            {
                return NotFound();
            }
            
            //map the product to the view model
            model.Id = product.Id;
            model.Name = product.Name;
            model.Description = product.Description;           
            model.Brand = product.Brand;
            model.Variants = product.Variants;
            model.ImageUrl = product.ImageUrl;
            if (variantId.HasValue)
            {
                model.Variant = product.Variants.FirstOrDefault(x => x?.Id == variantId.Value);
            }
            else
            {
                model.Variant = product.Variants.FirstOrDefault();
            }           


            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
