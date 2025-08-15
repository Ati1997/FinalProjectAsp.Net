using Microsoft.AspNetCore.Mvc;
using MultiPageApplication.ApplicationServices.Dtos.ProductDtos;
using MultiPageApplication.ApplicationServices.Services.Contracts;

namespace MultiPageApplication.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductApplicationService _productApplicationService;

        public ProductController(IProductApplicationService productApplicationService)
        {
            _productApplicationService = productApplicationService;
        }

        #region [-Index-]
        public async Task<IActionResult> Index()
        {
            var products = await _productApplicationService.GetAll();
            return View(products);
        }
        #endregion

        #region [-Details]
        public async Task<IActionResult> Detail(Guid id)
        {
            if (id == Guid.Empty)
                return BadRequest();

            var product = await _productApplicationService.Get(id);
            if (product == null)
                return NotFound();

            return View(product);
        }
        #endregion

        #region [-Create-]
        [HttpGet]
        public IActionResult Create()
        {
            return View(); // نمایش صفحه Create.cshtml
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Post_Product_Dto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            await _productApplicationService.Post(dto);
            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region [-Edit-]
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            if (id == Guid.Empty)
                return BadRequest();

            var product = await _productApplicationService.Get(id);
            if (product == null)
                return NotFound();

            var dto = new Put_Product_Dto
            {
                Id = product.Id,
                Title = product.Title,
                ProductDescription = product.ProductDescription,
                UnitPrice = product.UnitPrice
            };

            return View(dto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Put_Product_Dto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            await _productApplicationService.Put(dto);
            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region [-Delete-]
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == Guid.Empty)
                return BadRequest();

            var product = await _productApplicationService.Get(id);
            if (product == null)
                return NotFound();

            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (id == Guid.Empty)
                return BadRequest();

            var productDto = await _productApplicationService.Get(id);
            if (productDto == null)
                return NotFound();

            await _productApplicationService.Delete(id);

            return RedirectToAction(nameof(Index));
        }
        #endregion
    }
}
