using RepositoryPattern.Data;
using RepositoryPattern.Model;
using RepositoryPattern.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepositoryPattern.Repository
{
    public class SampleRepository : Repository<Sample>, ISampleRepository
    {
        private SampleDbContext _db;
        public SampleRepository(SampleDbContext context) : base(context)
        {
            this._db = context;
        }
    }
}
