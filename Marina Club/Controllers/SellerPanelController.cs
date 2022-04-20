using System;
using System.Linq;
using System.Threading.Tasks;
using Marina_Club.Command.QueryCommand;
using Marina_Club.Command.SellerManagerCommand;
using Marina_Club.Command.TicketCommand;
using Marina_Club.Command.UpdateCommand;
using Marina_Club.Dto;
using Marina_Club.Pagination;
using Marina_Club.Services.SellerPanel;
using Microsoft.AspNetCore.Mvc;
namespace Marina_Club.Controllers
{
    [Route("api/[controller]")]
    public class SellerPanelController : Controller
    {
        private readonly ISellerPanelService _sellerPanelService;
        public SellerPanelController(ISellerPanelService sellerPanelService)
        {
            _sellerPanelService = sellerPanelService;
        }

        #region SellerPannel

        /// <summary>
        /// Get WaterFunDto In Seller Panel
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpGet("Get-Water-Dto")]
        public async Task<IActionResult> GetSellerReservationDtoSansAsync([FromBody]GetOneDtoWaterFunInSellerPanel command)
        {
            var result = await _sellerPanelService.GetSellerReservationDtoAsync(command);
            if (result == null)
                return NotFound("لطفا نام دسته بندی خود را را وارد کنید");
            var reservDto = new ReservationDto()
            {
                FunTypes = result.FunType,
                Price = result.Price,
                DurationMinutes = result.DurationMinutes,
            };
            return Ok(reservDto);
        }

        /// <summary>
        /// Get All SellerManager
        /// </summary>
        /// <returns>گرفتن تمام اطلاعات فروشنده برای نمایش در پنل فروشنده</returns>
        [HttpGet("All-info")]
        public async Task<IActionResult> GetSellerPanelAsync(Guid SellerPanelId)
        {
            var result = await _sellerPanelService.GetSellerPanelAsync( SellerPanelId);
            if (result == null)
                return NotFound("لطفا چیزی وارد کنید");
            return Ok(new { Message = "عملیات با موفقیت انجام شد", Result = result });
        }

        /// <summary>
        /// Get List Reservation
        /// </summary>
        /// <returns></returns>
        [HttpGet("List-Reserve")]
        public async Task<IActionResult> GetReservationSellerAsync(int PageSize, int PageNumber)
        {
            var result = await _sellerPanelService.GetReservationSellerAsync( PageSize,  PageNumber);
            if (result == null)
                return NotFound("لطفا نام دسته بندی خود را را وارد کنید");
            return Ok(result);
        }

        /// <summary>
        /// Add SellerPannel
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("Add-Seller-Panel")]
        public async Task<IActionResult> AddReservationSellerAsync([FromBody]AddSellerTicketCommand command)
        {
            if (
                       string.IsNullOrEmpty(command.WaterFunId.ToString())
                    && string.IsNullOrEmpty(command.SellerInfoId.ToString()))
                return BadRequest("لطفا همه فیلد ها را پر کنید");

            var result = await _sellerPanelService.AddReservationSellerAsync(command);

            if (result == 0)
            {
                return BadRequest("عملیات با موفقیت انجام نشد");
            }

            else if (result == 2)
            {
                return BadRequest("تعداد بلیط درخواستی از تعداد بلیط باقی مانده بیشتر است");
            }
            else
            {
                return Ok(result); 
            }
           
        }

        /// <summary>
        /// dto seller panel
        /// </summary>
        /// <param name="Command"></param>
        /// <returns></returns>
        [HttpGet("Dto")]
        public async Task<IActionResult> GetSellerPanelDtoAsync(int PageSize, int PageNumber)
        {
            var result = await _sellerPanelService.GetSellerPanelDtoAsync( PageSize, PageNumber);
            if (result == null)
                return NotFound("لطفا نام دسته بندی خود را را وارد کنید");

            var sellerDto = result.Select(q =>
                new SellerPanelDto()
                {
                   FirstNameAndLastName = q.FirstNameAndLastName,
                   FunType = q.FunType,
                   Date = q.Date,
                   NationalCode = q.NationalCode,
                   PhoneNumber = q.PhoneNumber
                });
            return Ok(new { Message = "عملیات با موفقیت انجام شد", Result = sellerDto });
        }

        /// <summary>
        /// Search Seller
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpGet("Search")]
        public async Task<IActionResult> GetSellerPanelsDtoAsync(int PageNumber, int PageSize, DateTime SearchWordDate, string SearchWordFunType)
        {
            var result = await _sellerPanelService.GetSellerPanelsDtoAsync( PageNumber,  PageSize,  SearchWordDate,  SearchWordFunType);
            if (result == null)
                return NotFound("عملیات انجام نشد");
            if (string.IsNullOrEmpty(SearchWordFunType))
                return NotFound("لطفا فیلد سرچ را پر کنید");

            var sellerDto = result.Select(q =>
                new SellerPanelDto()
                {
                    FirstNameAndLastName = q.FirstNameAndLastName,
                    FunType = q.FunType,
                    Date = q.Date,
                    NationalCode = q.NationalCode,
                    PhoneNumber = q.PhoneNumber
                });
            return Ok(new { Message = "عملیات با موفقیت انجام شد", Result = sellerDto });
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpDelete("Delete-Reservation")]
        public async Task<IActionResult> DeleteReservationAsync([FromBody] DeleteReservationCommand command)
        {
            if (command.ReservSellerInfoId == Guid.Empty)
                BadRequest(new { Message = "لطفا همه فیلد ها را پر کنید" });
            var result = await _sellerPanelService.DeleteReservationAsync(command);
            return Ok(result);
        }

        /// <summary>
        /// Cancel 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateTicketPanelAsync([FromBody] UpdateTicketCommand command)
        {
            if (command.TicketId == Guid.Empty)

                return BadRequest("لطفا همه فیلد ها را پر کنید");

            var result = await _sellerPanelService.UpdateTicketPanelAsync(command);

            return Ok(new { Message = " عملیات با موفقیت انجام شد", Result = result });
        }

        #endregion
    }
}
