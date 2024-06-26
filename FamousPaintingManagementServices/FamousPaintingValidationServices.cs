using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamousPaintingManagementServices
{
    public class FamousPaintingValidationServices
    {
        private FamousPaintingGetServices getServices = new FamousPaintingGetServices();

        public bool CheckIfFamousPaintingTitleExists(string title)
        {
            bool result = getServices.GetFamousPainting(title) != null;
            return result;
        }
    }
}
