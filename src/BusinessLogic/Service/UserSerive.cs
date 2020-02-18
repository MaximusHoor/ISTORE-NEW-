using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.UnitOfWork;
using Domain.Context;
using Domain.EF_Models;

namespace Business.Service
{
   public class UserSerive
   {

       private IUnitOfWork _unitOfWork;
        public UserSerive(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void AddUser(User user)
        {
            _unitOfWork.UserRepository.Create(user);
            _unitOfWork.SaveChangesAsync();
        } 
    }
}
