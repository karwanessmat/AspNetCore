using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DealDouble.Entities.Entities;
using DealDouble.Services.Extensions;
using DealDouble.Services.IRepository;
using DealDouble.Web.ViewModels.Production;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DealDouble.Web.Controllers
{
    public class ProductionController : Controller
    {
        private readonly IProductionRepository _productionRepository;

        public ProductionController(IProductionRepository productionRepository)
        {
            _productionRepository = productionRepository;
        }

        public async Task<IActionResult> Index()
        {
            var productions = await _productionRepository.GetAllAsync();


            if (Request.IsAjax())
            {
                return PartialView(productions);
            }

            return View(productions);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return PartialView();
        }



        [HttpPost]
        public async Task<IActionResult> Create(Production model)
        {
            if (!ModelState.IsValid) return View("Create");

            await _productionRepository.AddAsync(model);
            return RedirectToAction("Index");


        }


        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return View("Index");
            var production = await _productionRepository.GetByIdAsync(id.Value);
            var model = new EditProductionViewModel()
            {
                Production = production
            };
            //return View(model);
            return PartialView(model);


        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditProductionViewModel model)
        {
            if (ModelState == null) return View("Edit");
            await _productionRepository.UpdateAsync(model.Production);
            return RedirectToAction("Index");

        }


        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return View("Index");
            var production = await _productionRepository.GetByIdAsync(id.Value);
            var model = new EditProductionViewModel()
            {
                Production = production
            };
            //return View(model);
            return PartialView(model);


        }

        //[HttpPost]
        //public async Task<IActionResult> Delete(EditProductionViewModel model)
        //{
        //    if (ModelState == null) return View("Delete");
        //    await _productionRepository.DeleteAsync(model.Production);
        //    return RedirectToAction("Index");

        //}
        [HttpPost,ActionName("Delete")]
        public async Task<IActionResult> DeletePost(int? id)
        {
            if (id == null) return View("Delete");
            var production = await _productionRepository.GetByIdAsync((int) id);
            await _productionRepository.DeleteAsync(production);
            return RedirectToAction("Index");

        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id==null && (int)id==0)
            {
                return NoContent();
            }


            var product = await _productionRepository.GetByIdAsync(id.Value);
            return View(product);
        }
    }
}
