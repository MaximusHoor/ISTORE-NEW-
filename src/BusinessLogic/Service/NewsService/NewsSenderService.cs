using Business.Infrastructure;
using DataAccess.UnitOfWork;
using Domain.EF_Models;
using Domain.Infrastructure;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service.NewsService
{
    public class NewsSenserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmailSender _emailSenderService;
      
        public NewsSenserService(IUnitOfWork unitOfWork, IEmailSender emailSender)
        {
            _unitOfWork = unitOfWork;
            _emailSenderService = emailSender;
           
        }

        
        public async Task<OperationDetail> AddObserver(string email)
        {
            var subscriber = new Subscriber() { Email = email };   

            if ((await _unitOfWork.SubscriberRepository.FindByConditionAsync(x => x.Email == email)).Count != 0)
            {
                return new OperationDetail() { IsError = true, Message = "Email exists" };
            }
            else
            {
                var res = await _unitOfWork.SubscriberRepository.CreateAsync(subscriber);
                await _unitOfWork.SaveChangesAsync();
                return res;
            }           
        }

        public async Task<OperationDetail>  NotifyObserver(News news)
        {
            try
            {
                foreach (var item in await _unitOfWork.SubscriberRepository.GetAllAsync())
                {
                    await _emailSenderService.SendEmailAsync("", item.Email, news.Text);
                }
                return new OperationDetail() {IsError=false, Message= "Sending out" };
            } 
            catch(Exception ex)
            {
                return new OperationDetail() { IsError = true, Message=ex.Message };
            }
        }

        public Task RemoveObserver(string email)
        {
            //отписаться
            throw new NotImplementedException();
        }
    }
}
