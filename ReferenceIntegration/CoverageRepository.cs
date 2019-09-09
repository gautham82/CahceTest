using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReferenceIntegration
{
    public class CoverageRepository : IReadOnlyRepository<Coverage>
    {
        private static string key___ = "COVERAGE";
        public Dictionary<string, Coverage> coverageDictionary
        {
            get
            {
                object val_ = CachedRepositoryDecorator<Coverage>.Find(key___);
                return (Dictionary<string, Coverage>)val_;
            }
            set
            {
                bool added = CachedRepositoryDecorator<Coverage>.CreateEntry(key___, value);
                if (!added)
                {
                    CachedRepositoryDecorator<Coverage>._cache.Remove(key___);
                    added = CachedRepositoryDecorator<Coverage>.CreateEntry(key___, value);
                }
            }
        }

        public CoverageRepository()
        {
            PopulateCoverage();
        }

        public Coverage Find(string id)
        {
            PopulateCoverageCacheCheck();
            if (!coverageDictionary.TryGetValue(id, out Coverage region))
            {
                throw new Exception("Not Found");
            }
            return region;
        }

        public IEnumerable<Coverage> ListAll()
        {
            PopulateCoverageCacheCheck();
            return coverageDictionary.Select(r => r.Value);
        }

        public bool IsCacheKeyExists
        {
            get
            {
                return CachedRepositoryDecorator<Coverage>.IsKeyAlreadyExists(key___);
            }
        }

        private void PopulateCoverageCacheCheck()
        {
            if(!IsCacheKeyExists)
            {
                PopulateCoverage();
            }
        }

        private void PopulateCoverage()
        {
            Coverage r1 = new Coverage { Id = "1", Des = "Cov1" };
            Coverage r2 = new Coverage { Id = "2", Des = "Cov2" };
            Coverage r3 = new Coverage { Id = "3", Des = "Cov3" };
            Coverage r4 = new Coverage { Id = "4", Des = "Cov4" };

            Dictionary<string, Coverage> coverageDictionary_ =  new Dictionary<string, Coverage>();
            coverageDictionary_.Add("1", r1);
            coverageDictionary_.Add("2", r2);
            coverageDictionary_.Add("3", r3);
            coverageDictionary_.Add("4", r4);

            coverageDictionary = coverageDictionary_;
        }
    }

}
