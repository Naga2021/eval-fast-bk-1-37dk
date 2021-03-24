using FortCode.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FortCode.Data.Repository
{
    public class CityRepository : Repository<City>, ICityRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        public CityRepository(IUnitOfWork UnitOfWork) :base(UnitOfWork)
        {
            _unitOfWork = UnitOfWork;
        }
    }
}
