using FamousPaintingManagementModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FamousPaintingManagementData
{
    public class FamousPaintingFactory
    {
        private List<FamousPainting> _dummyPaintings = new List<FamousPainting>();

        public List<FamousPainting> GetDummyFamousPaintings()
        {
            _dummyPaintings.Add(CreateDummyFamousPainting("Mona Lisa", "Leonardo da Vinci", 1503, 1));
            _dummyPaintings.Add(CreateDummyFamousPainting("Starry Night", "Vincent van Gogh", 1889, 1));
            _dummyPaintings.Add(CreateDummyFamousPainting("The Persistence of Memory", "Salvador Dalí", 1931, 1));
            _dummyPaintings.Add(CreateDummyFamousPainting("Girl with a Pearl Earring", "Johannes Vermeer", 1665, 1));

            return _dummyPaintings;
        }

        private FamousPainting CreateDummyFamousPainting(string Title, string Artist, int YearCreated, int Status)
        {
            FamousPainting painting = new FamousPainting
            {
                Title = Title,
                Artist = Artist,
                YearCreated = YearCreated,
                Status = Status,
            };

            return painting;
        }
    }
}
