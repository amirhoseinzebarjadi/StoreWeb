using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Marina_Club.Command.CustomerCommand;
using Marina_Club.Command.QueryCommand;
using Marina_Club.Pagination;

namespace Marina_Club.Services.Customer
{
    public interface ICustomerService
    {
        /// <summary>
        /// Get Customer
        /// </summary>
        /// <returns></returns>
        Task<List<Model.Customer>> ListAsyncCustomer(int PageNumber ,int PageSize);

        /// <summary>
        /// Add Customer
        /// </summary>
        /// <param تمامی اطلاعات></param>
        /// <returns>اضافه کردن کاربر جدید</returns>
        Task<bool> AddCustomerAsync(AddCustomerCommand command);

        /// <summary>
        /// CustomerDto
        /// </summary>
        /// <param >نمایش در پیامک و کاربر</param>
        /// <returns>شهر و نام وشماره های کاربر</returns>
        Task<List<Model.Customer>> CustomerDtoAsync(int PageNumber, int PageSize,string SearchWord);

        /// <summary>
        /// OneGetCustomer
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        Task<Model.Customer> OneGetCustomerAsync(Guid CustomerId);

        /// <summary>
        /// GetByIdCustomer
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        Task<IList<Model.Customer>> GetByIdCustomerAsync(GetByIdCustomerCommand command);
    }
}
