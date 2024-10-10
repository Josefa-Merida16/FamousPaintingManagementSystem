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
        private FamousPaintingEmail _emailService;

        public BuyerController()
        {
            _getServices = new FamousPaintingGetServices();
            _transactionServices = new FamousPaintingTransactionServices();
            _emailService = new FamousPaintingEmail();
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
        public IActionResult AddPainting([FromBody] FamousPainting request)
        {
            if (request == null)
            {
                return BadRequest("Invalid data received.");
            }

            var painting = new FamousPaintingManagementModels.FamousPainting
            {
                Title = request.Title,
                Artist = request.Artist,
                YearCreated = request.YearCreated,
                Status = request.Status
            };

            var result = _transactionServices.AddFamousPainting(painting);

            if (result)
            {
                _emailService.SendPaintingAddedEmail(painting.Title);
                return Ok();
            }
            else
            {
                return StatusCode(500, "Failed to add painting.");
            }
        }

        [HttpPatch]
        public JsonResult UpdatePainting([FromBody] FamousPainting request)
        {
            var painting = new FamousPaintingManagementModels.FamousPainting
            {
                Title = request.Title,
                Artist = request.Artist,
                YearCreated = request.YearCreated,
                Status = request.Status
            };

            var result = _transactionServices.UpdateFamousPainting(painting);

            if (result)
            {
                _emailService.SendPaintingUpdatedEmail(painting.Title);
            }

            return new JsonResult(result);
        }

        [HttpDelete]
        public JsonResult DeletePainting([FromBody] FamousPainting request)
        {
            var painting = new FamousPaintingManagementModels.FamousPainting
            {
                Title = request.Title,
                Artist = request.Artist,
                YearCreated = request.YearCreated,
                Status = request.Status
            };

            var result = _transactionServices.DeleteFamousPainting(painting);

            if (result)
            {
                _emailService.SendPaintingDeletedEmail(painting.Title);
            }

            return new JsonResult(result);
        }
    }
}


