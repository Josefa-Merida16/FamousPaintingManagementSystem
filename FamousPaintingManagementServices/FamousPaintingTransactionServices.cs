using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FamousPaintingManagementData;
using FamousPaintingManagementModels;

namespace FamousPaintingManagementServices
{
    public class FamousPaintingTransactionServices
    {
        private FamousPaintingValidationServices _validationServices = new FamousPaintingValidationServices();
        private FamousPaintingDataRepository _dataRepository = new FamousPaintingDataRepository();

        public bool AddFamousPainting(FamousPainting painting)
        {
            bool result = _validationServices.CheckIfFamousPaintingTitleExists(painting.Title);
            if (result)
            {
                result = _dataRepository.AddFamousPainting(painting) > 0;
            }
            return result;
        }


        public bool UpdateFamousPainting(FamousPainting painting)
        {
            bool result = _validationServices.CheckIfFamousPaintingTitleExists(painting.Title);
            if (result)
            {
                result = _dataRepository.UpdateFamousPainting(painting) > 0;
            }
            return result;
        }


        public bool DeleteFamousPainting(FamousPainting painting)
        {
            bool result = _validationServices.CheckIfFamousPaintingTitleExists(painting.Title);
            if (result)
            {
                result = _dataRepository.DeleteFamousPainting(painting) > 0;
            }
            return result;
        }

        
    }
}
