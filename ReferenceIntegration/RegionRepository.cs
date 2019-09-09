using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReferenceIntegration
{
    public class RegionRepository : IReadOnlyRepository<Region>
    {
        private readonly Dictionary<string, Region> regionDictionary;
        public RegionRepository()
        {
            this.regionDictionary = new Dictionary<string, Region>();

            PopulateRegion();
        }

        public Region Find(string id)
        {
            //Get From Cache instead of dictionary
            //If the id is not found in cache, reload cache
            //If still not found, log error using ILogger

            if (!regionDictionary.TryGetValue(id, out Region region))
            {
                throw new Exception("Not Found");
            }

            return region;
        }

        public IEnumerable<Region> ListAll()
        {
            return regionDictionary.Select(r => r.Value);
        }

        private void PopulateRegion()
        {
            //Api to fill Region

            //Sample data hard coded
            //Have to implement caching here?
            
            Region r1 = new Region { Code = "1", Description = "Country1" };
            Region r2 = new Region { Code = "2", Description = "Country2" };
            Region r3 = new Region { Code = "3", Description = "Country3" };
            Region r4 = new Region { Code = "4", Description = "Country4" };

            regionDictionary.Add("1", r1);
            regionDictionary.Add("2", r2);
            regionDictionary.Add("3", r3);
            regionDictionary.Add("4", r4);
        }

        public void AddNewRegion()
        {
            Region r5 = new Region { Code = "5", Description = "Country5" };

            regionDictionary.Add("5", r5);
        }
    }
}
