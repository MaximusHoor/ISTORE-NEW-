using DataAccess.UnitOfWork;
using Domain.EF_Models;
using System;
using System.Collections.Generic;
using System.Text;


namespace Business.Service
{
    public class BrandService
    {
        private IUnitOfWork _unitOfWork;
        public BrandService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void AddBrand(Brand brand)
        {
             
        }
    }
}
