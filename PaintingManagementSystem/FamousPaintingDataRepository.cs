using FamousPaintingManagementModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FamousPaintingManagementData
{
    public class FamousPaintingDataRepository
    {
        private List<FamousPainting> _paintings;
        private SqlDbData _sqlData;

        public FamousPaintingDataRepository()
        {
            _paintings = new List<FamousPainting>();
            _sqlData = new SqlDbData();
        }

        public List<FamousPainting> GetFamousPaintings()
        {
            _paintings = _sqlData.GetFamousPaintings();
            return _paintings;
        }

        public int AddFamousPainting(FamousPainting painting)
        {
            return _sqlData.AddFamousPainting(painting.Title, painting.Artist, painting.YearCreated, painting.Status);
        }

        public int UpdateFamousPainting(FamousPainting painting)
        {
            return _sqlData.UpdateFamousPainting(painting.Title, painting.Artist, painting.YearCreated, painting.Status);
        }

        public int DeleteFamousPainting(FamousPainting painting)
        {
            return _sqlData.DeleteFamousPainting(painting.Title);
        }
    }
}
