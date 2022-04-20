using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Marina_Club.Context;
using Microsoft.EntityFrameworkCore;

namespace Marina_Club.Repositories.Customer
{
    public class CustomerRepository : BaseRepository, ICustomerRepository
    {
        public CustomerRepository(MarinaClubContext context) : base(context)
        {
        }

        /// <summary>
        /// Get Customer
        /// </summary>
        /// <returns></returns>
        public async Task<List<Model.Customer>> ListAsyncCustomer(int PageSize, int PageNumber)
        {
            return await _context.Customers
                .Skip((PageNumber - 1) * PageSize)
                .Take(PageSize).ToListAsync();
        }

        /// <summary>
        /// Add Customer
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public async Task<bool> CustomerAsync(Model.Customer customer)
        {
            await _context.Customers.AddAsync(customer);
            var check = await _context.SaveChangesAsync();
            return check > 0;
        }

        /// <summary>
        /// Customer Dto
        /// </summary>
        /// <param name="SearchWordCityCustomer"></param>
        /// <param name="SearchWordCustomer"></param>
        /// <returns></returns>
        public async Task<List<Model.Customer>> CustomerDtoAsync()
        {
            var result = await _context.Customers.ToListAsync();
            return result;
        }


        public async Task<Model.Customer> OneGetCustomerAsync(Guid customerId)
        {
            return await _context.Customers.FirstOrDefaultAsync(q => q.CustomerId == customerId);
        }
        public async Task<IList<Model.Customer>> GetByIdCustomerAsync(Guid customerId)
        {
            return await _context.Customers.Where(q => q.CustomerId == customerId).ToListAsync();
        }
    }
}
