using FamousPaintingManagementServices;
using FamousPaintingManagementModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FamousPaintingManagementAPI.Controllers
{
    [ApiController]
    [Route("api/paintings")]
    public class BuyerController : Controller
    {
        private FamousPaintingGetServices _getServices;
        private FamousPaintingTransactionServices _transactionServices;

        public BuyerController()
        {
            _getServices = new FamousPaintingGetServices();
            _transactionServices = new FamousPaintingTransactionServices();
        }

        [HttpGet]
        public IEnumerable<FamousPaintingManagementAPI.FamousPainting> GetPaintings()
        {
            var activePaintings = _getServices.GetFamousPaintingsByStatus(1);
            List<FamousPaintingManagementAPI.FamousPainting> paintings = new List<FamousPaintingManagementAPI.FamousPainting>();

            foreach (var item in activePaintings)
            {
                paintings.Add(new FamousPaintingManagementAPI.FamousPainting
                {
                    Title = item.Title,
                    Artist = item.Artist,
                    YearCreated = item.YearCreated,
                    Status = item.Status
                });
            }

            return paintings;
        }

        [HttpPost]
        public JsonResult AddPainting(FamousPaintingManagementAPI.FamousPainting request)
        {
            var painting = new FamousPaintingManagementModels.FamousPainting
            {
                Title = request.Title,
                Artist = request.Artist,
                YearCreated = request.YearCreated,
                Status = request.Status
            };

            var result = _transactionServices.FamousPainting(painting);
            return new JsonResult(result);
        }

        [HttpPatch]
        public JsonResult UpdatePainting(FamousPaintingManagementAPI.FamousPainting request)
        {
            var painting = new FamousPaintingManagementModels.FamousPainting
            {
                Title = request.Title,
                Artist = request.Artist,
                YearCreated = request.YearCreated,
                Status = request.Status
            };

            var result = _transactionServices.UpdateFamousPainting(painting);
            return new JsonResult(result);
        }

        [HttpDelete]
        public JsonResult DeletePainting(FamousPaintingManagementAPI.FamousPainting request)
        {
            var painting = new FamousPaintingManagementModels.FamousPainting
            {
                Title = request.Title,
                Artist = request.Artist,
                YearCreated = request.YearCreated,
                Status = request.Status
            };

            var result = _transactionServices.DeleteFamousPainting(painting);
            return new JsonResult(result);
        }
    }
}