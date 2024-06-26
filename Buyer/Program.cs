using FamousPaintingManagementServices;
using FamousPaintingManagementModels;
using System;
using System.Collections.Generic;

namespace Buyer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FamousPaintingGetServices getServices = new FamousPaintingGetServices();

            var paintings = getServices.GetFamousPaintingsByStatus(1);

            foreach (var painting in paintings)
            {
                Console.WriteLine($"Title: {painting.Title}");
                Console.WriteLine($"Artist: {painting.Artist}");
                Console.WriteLine($"Year Created: {painting.YearCreated}");
                Console.WriteLine($"Status: {painting.Status}");
                Console.WriteLine();
            }
        }
    }
}
