using System;
using System.Linq;
using System.Threading.Tasks;
using Marina_Club.Command.QueryCommand;
using Marina_Club.Command.SellerManagerCommand;
using Marina_Club.Command.TicketCommand;
using Marina_Club.Command.UpdateCommand;
using Marina_Club.Dto;
using Marina_Club.Model;
using Marina_Club.Pagination;
using Marina_Club.Services.SellerManager;
using Microsoft.AspNetCore.Mvc;
namespace Marina_Club.Controllers
{
    [Route("api/[controller]")]
    public class SellerManagerController : Controller
    {
        private readonly ISellerManagerService _sellerManagerService;
        public SellerManagerController(ISellerManagerService sellerManagerService)
        {
            _sellerManagerService = sellerManagerService;
        }

        #region SellerManager
        /// <summary>
        /// Get All SellerManager
        /// </summary>
        /// <returns>گرفتن تمام اطلاعات فروشنده برای نمایش در پنل فروشنده</returns>
        [HttpGet("All-info")]
        public async Task<IActionResult> GetSellerManagerAsync(Guid SellerManagerId)
        {
            var result = await _sellerManagerService.GetSellerManagerAsync(SellerManagerId);
            if (result == null)
                return NotFound("لطفا چیزی وارد کنید");
            return Ok(new { Message = "عملیات با موفقیت انجام شد", Result = result });
        }

        /// <summary>
        /// Add All infos Seller
        /// </summary>
        /// <param >گرفتن تمام اطلاعات فروشنده و رکورد جدید'</param>
        /// <returns></returns>
        [HttpPost("Add")]
        public async Task<IActionResult> AddSellerManagerAsync([FromBody] SellerCommand command)
        {
            if (string.IsNullOrEmpty(command.DiscountSeller.ToString()) &&
                    string.IsNullOrEmpty(command.SellerCode.ToString())
                    && string.IsNullOrEmpty(command.SellerInfoCommand.CardNumber)
                    && string.IsNullOrEmpty(command.SellerInfoCommand.CompanyNameSeller)
                    && string.IsNullOrEmpty(command.SellerInfoCommand.NationalCode)
                    && string.IsNullOrEmpty(command.SellerInfoCommand.PhoneNumber)
                    && string.IsNullOrEmpty(command.SellerInfoCommand.CellPhoneNumber)
                    && string.IsNullOrEmpty(command.SellerInfoCommand.FirstNameAndLastName)
                    && string.IsNullOrEmpty(command.SellerAddressCommand.Address)
                    && string.IsNullOrEmpty(command.SellerAddressCommand.PostalCode)
                    && string.IsNullOrEmpty(command.SellerAddressCommand.CityName))
                return BadRequest("لطفا همه فیلد ها را پر کنید");
            var result = await _sellerManagerService.AddSellerManagerAsync(command);
            return Ok(new { Message = "عملیات با موفقیت انجام شد", Result = result });
        }

        /// <summary>
        /// Update SellerManager
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateSellerManagerAsync([FromBody] UpdateSellerManagerCommand command)
        {
            if (command.SellerManagerId == Guid.Empty)

                return BadRequest("لطفا همه فیلد ها را پر کنید");
            var result = await _sellerManagerService.UpdateSellerManagerAsync(command);
            return Ok(new { Message = "عملیات با موفقیت انجام شد", Result = result });
        }

        /// <summary>
        /// Dto Seller
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpGet("Dto")]
        public async Task<IActionResult> GetSellerManagerDtoAsync(int PageNumber, int PageSize)
        {
            var result = await _sellerManagerService.GetSellerManagerDtoAsync(PageNumber, PageSize);
            if (result == null)
                return NotFound("لطفا نام دسته بندی خود را را وارد کنید");

            var sellerDto = result.Select(q =>
                new SellerManagerDto()
                {
                    SellerCode = q.SellerCode,
                    SellerInfo = ToDto(q.SellerInfo),
                    SellerAddress = ToDto2(q.SellerAddress)
                });
            return Ok(new { Message = "عملیات با موفقیت انجام شد", Result = sellerDto });
        }
        /// <summary>
        /// Search Seller
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpGet("Search")]
        public async Task<IActionResult> GetSellerManagersDtoAsync(int PageNumber, int PageSize, string SearchWordSeller)
        {
            var result = await _sellerManagerService.GetSellerManagersDtoAsync(PageNumber,PageSize, SearchWordSeller);
            if (result == null)
                return NotFound("لطفا نام دسته بندی خود را را وارد کنید");

            var sellerDto = result.Select(q =>
                new SellerManagerDto()
                {
                    SellerCode = q.SellerCode,
                    SellerInfo = ToDto(q.SellerInfo),
                    SellerAddress = ToDto2(q.SellerAddress)
                });
            return Ok(new { Message = "عملیات با موفقیت انجام شد", Result = sellerDto });
        }
        #endregion

        #region privateMethod
        private SellerInfoDto ToDto(SellerInfo sellerInfo)
        {
            return new SellerInfoDto
            {
                CompanyName = sellerInfo.CompanyName,
                FirstNameAndLastNameSeller = sellerInfo.FirstNameAndLastNameSeller,
                PhoneNumberSeller = sellerInfo.PhoneNumberSeller.ToString()
            };
        }
        private SellerAddressDto ToDto2(SellerAddress sellerAddress)
        {
            return new SellerAddressDto()
            {
                CityNameSeller = sellerAddress.CityNameSeller
            };
        }
        #endregion

    }
}
