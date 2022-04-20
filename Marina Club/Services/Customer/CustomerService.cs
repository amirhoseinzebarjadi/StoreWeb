using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Marina_Club.Command.CustomerCommand;
using Marina_Club.Command.QueryCommand;
using Marina_Club.Pagination;
using Marina_Club.Repositories.Customer;

namespace Marina_Club.Services.Customer
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        /// <summary>
        /// Get Customer
        /// </summary>
        /// <returns></returns>
        public async Task<List<Model.Customer>> ListAsyncCustomer(int PageNumber, int PageSize)
        {
            return await _customerRepository.ListAsyncCustomer(PageNumber,PageSize);
        }
        /// <summary>
        /// Add Customer
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public async Task<bool> AddCustomerAsync(AddCustomerCommand command)
        {
            var customer = new Model.Customer(command.FirstNameAndLastName,command.NationalCode,command.CellPhoneNumber,command.PhoneNumber,command.CardNumber,command.CityNameCustomer,command.Email,command.PostalCodeCustomer);
      
            return await _customerRepository.CustomerAsync(customer);
        }
        /// <summary>
        /// Customer Dto
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public async Task<List<Model.Customer>> CustomerDtoAsync(int PageNumber, int PageSize,string SearchWord)
        {
            var customers = await _customerRepository.CustomerDtoAsync();

            var result = new List<Model.Customer>();

            if (!string.IsNullOrEmpty(SearchWord))
            {
                var customersByNameSearch = customers.Where(q => q.FirstNameAndLastName.Contains(SearchWord)).ToList();

                var customersByNationalCodeSearch = customers.Where(s => s.NationalCode.Contains(SearchWord)).ToList();

                result.AddRange(customersByNameSearch);
                result.AddRange(customersByNationalCodeSearch);
            }

            var results = result
                .GroupBy(x => x.CustomerId)
                .Select(g => g.First())
                .Skip((PageNumber - 1) * PageSize)
                .Take(PageSize)
                .ToList();

            return results;
        }
        public async Task<Model.Customer> OneGetCustomerAsync(Guid CustomerId)
        {
            var customer = await _customerRepository.OneGetCustomerAsync(CustomerId);
            return customer;
        }
        public async Task<IList<Model.Customer>> GetByIdCustomerAsync(GetByIdCustomerCommand command)
        {
            var customer = await _customerRepository.GetByIdCustomerAsync(command.CustomerId);
            return customer;
        }
    }
}
