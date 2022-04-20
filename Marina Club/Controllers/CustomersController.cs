using System;
using System.Linq;
using System.Threading.Tasks;
using Marina_Club.Command.CustomerCommand;
using Marina_Club.Command.QueryCommand;
using Marina_Club.Dto;
using Marina_Club.Pagination;
using Marina_Club.Services.Customer;
using Microsoft.AspNetCore.Mvc;
namespace Marina_Club.Controllers
{
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        #region Customer

        /// <summary>
        /// Get Customer
        /// </summary>
        /// <returns>نمایش تمام اطلاعات یک کاربر</returns>
        [HttpGet("All")]
        public async Task<IActionResult> GetAllAsyncCustomer(int PageNumber,   int PageSize)
        {
            var result = await _customerService.ListAsyncCustomer(PageNumber,PageSize);

            if (result == null)
                return NotFound(new { Message = " موردی یافت نشد" });

            var results = result.Select(q =>
                new CustomerDto
                {
                    CityNameCustomer = q.CityNameCustomer,
                    FirstNameAndLastName = q.FirstNameAndLastName,
                    PhoneNumber = q.PhoneNumber,
                    CellPhoneNumber = q.CellPhoneNumber
                });

            return Ok(new { Message = "عملیات با موفقیت انجام شد", Result = results });
        }

        /// <summary>
        /// Add Customer
        /// </summary>
        /// <param تمامی اطلاعات></param>
        /// <param name="command"></param>
        /// <returns>اضافه کردن کاربر جدید</returns>
        [HttpPost("Add")]
        public async Task<IActionResult> AddCustomerAsync([FromBody] AddCustomerCommand command)
        {
            if (string.IsNullOrEmpty(command.CityNameCustomer) &&
                string.IsNullOrEmpty(command.PostalCodeCustomer) &&
                string.IsNullOrEmpty(command.NationalCode) &&
                string.IsNullOrEmpty(command.CellPhoneNumber) &&
                string.IsNullOrEmpty(command.CardNumber) &&
                string.IsNullOrEmpty(command.FirstNameAndLastName) &&
                string.IsNullOrEmpty(command.PhoneNumber))
                return BadRequest(new { Message = "ورودی مورد نیاز بافت نشد" });

            var result = await _customerService.AddCustomerAsync(command);
            return Ok(new { Message = "عملیات با موفقیت انجام شد", Result = result });
        }

        /// <summary>
        /// CustomerDto
        /// </summary>
        /// <param >نمایش در پیامک و کاربر</param>
        /// <param name="command"></param>
        /// <returns>شهر و نام وشماره های کاربر</returns>
        [HttpGet("Search")]
        public async Task<IActionResult> CustomerDtoAsync(int PageNumber, int PageSize,string SearchWord)
        {
            var result = await _customerService.CustomerDtoAsync(PageNumber, PageSize,SearchWord);
            if (result==null)
            {
                return BadRequest(new { Message = "  اطلاعات مورد نیاز بافت نشد  " });
            }
            var results = result.Select(q =>
                new CustomerDto
                {
                    CityNameCustomer = q.CityNameCustomer,
                    FirstNameAndLastName = q.FirstNameAndLastName,
                    PhoneNumber = q.PhoneNumber,
                    CellPhoneNumber = q.CellPhoneNumber
                });

            return Ok(new { Message = "عملیات با موفقیت انجام شد", Result = results });
        }

        /// <summary>
        /// OneGetCustomer
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        public async Task<IActionResult> OneGetCustomerAsync(Guid CustomerId)
        {
            var result = await _customerService.OneGetCustomerAsync(CustomerId);

            if (CustomerId == Guid.Empty)
                return NotFound(new { Message = "اطلاعات مورد نظر یافت نشد " });

            if (result == null)
                return NotFound(new { Message = "اطلاعات مورد نظر وجود ندارد" });

            return Ok(new { Message = "عملیات با موفقیت انجام شد", Result = result });
        }

        /// <summary>
        /// GetByIdCustomer
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpGet("Customer")]
        public async Task<IActionResult> GetByIdCommentAsync([FromBody] GetByIdCustomerCommand command)
        {
            var result = await _customerService.GetByIdCustomerAsync(command);

            if (result.Count == 0 || command.CustomerId == Guid.Empty)
                return NotFound(new { Message = "NotFound" });

            return Ok(result);
        }
        #endregion
    }
}
