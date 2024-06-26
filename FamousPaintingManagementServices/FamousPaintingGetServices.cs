using FamousPaintingManagementData;
using FamousPaintingManagementModels;
using System.Collections.Generic;

namespace FamousPaintingManagementServices
{
    public class FamousPaintingGetServices
    {

        public List<FamousPainting> GetAllFamousPaintings()
        {
            FamousPaintingDataRepository dataRepository = new FamousPaintingDataRepository();
            return dataRepository.GetFamousPaintings();
        }

        public List<FamousPainting> GetFamousPaintingsByStatus(int status)
        {
            List<FamousPainting> paintingsByStatus = new List<FamousPainting>();

            foreach (var painting in GetAllFamousPaintings())
            {
                if (painting.Status == status)
                {
                    paintingsByStatus.Add(painting);
                }
            }

            return paintingsByStatus;
        }

        public FamousPainting GetFamousPainting(string title)
        {
            FamousPainting foundPainting = new FamousPainting();

            foreach (var painting in GetAllFamousPaintings())
            {
                if (painting.Title == title)
                {
                    foundPainting = painting;
                }
            }

            return foundPainting;
        }
    }
}