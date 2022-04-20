using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Marina_Club.Repositories.Customer
{
    public interface ICustomerRepository
    {
        /// <summary>
        /// Get Customer
        /// </summary>
        /// <returns></returns>
        Task<List<Model.Customer>> ListAsyncCustomer(int PageSize, int PageNumber);
        /// <summary>
        /// Add Customer
        /// </summary>
        /// <param تمامی اطلاعات></param>
        /// <returns>اضافه کردن کاربر جدید</returns>
        Task<bool> CustomerAsync(Model.Customer customer);
        /// <summary>
        /// CustomerDto
        /// </summary>
        /// <param >نمایش در پیامک و کاربر</param>
        /// <returns>شهر و نام وشماره های کاربر</returns>
        Task<List<Model.Customer>> CustomerDtoAsync();
        /// <summary>
        /// OneGetCustomer
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        Task<Model.Customer> OneGetCustomerAsync(Guid customerId);
        /// <summary>
        /// GetByIdCustomer
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        Task<IList<Model.Customer>> GetByIdCustomerAsync(Guid customerId);
    }
}
