using System;
using System.Linq;
using System.Threading.Tasks;
using Marina_Club.Command.SellerPanel;
using Marina_Club.Command.UpdateCommand;
using Marina_Club.Command.WaterFunCommand;
using Marina_Club.Dto;
using Marina_Club.Services.WaterFun;
using Microsoft.AspNetCore.Mvc;
namespace Marina_Club.Controllers
{
    [Route("api/[controller]")]
    public class WaterFunController : Controller
    {
        private readonly IWaterFunService _waterFunService;
        public WaterFunController(IWaterFunService waterFunService)
        {
            _waterFunService = waterFunService;
        }

        #region WaterFun
        [HttpGet]
        public ActionResult<string> Get()
        {
            return "Hello Im Robin ;)";
        }
        /// <summary>
        /// Get WaterFun
        /// </summary>
        /// <returns>گرفتن کل تفریحات ابی </returns> 
        [HttpGet("All")]
        public async Task<IActionResult> GetAllAsyncWaterFun()
        {
            var result = await _waterFunService.ListAsyncWaterFun();

            if (result.Count == 0)
                return NotFound(new { Message = "اطلاعات مورد نظر یافت نشد" });

            return Ok(new { Message = "عملیات با موفقیت انجام شد", Result = result });
        }

        /// <summary>
        /// Post WaterFun
        /// </summary>
        /// <param name="command">دادن اطلاعات کلاس تقریحات ابی</param>
        /// <returns>ساخت تفزیحات دریایی</returns>
        [HttpPost("Add")]
        public async Task<IActionResult> AddWaterFunAsync([FromBody] AddWaterFunCommand command)
        {
            if (string.IsNullOrEmpty(command.FunType) &&
                string.IsNullOrEmpty(command.DurationMinutes.ToString())
                && string.IsNullOrEmpty(command.GapMinutes.ToString())
                && string.IsNullOrEmpty(command.Capacity.ToString())
                && string.IsNullOrEmpty(command.EndTimeWork)
                && string.IsNullOrEmpty(command.StartTimeWork)
                && string.IsNullOrEmpty(command.IsActiveWaterFun.ToString()))
                return BadRequest(new { Message = "اطلاعات مورد نظر یافت نشد" });

            var result = await _waterFunService.AddWaterFunAsync(command);

            return Ok(new { Message = "عملیات با موفقیت انجام شد", Result = result });
        }

        /// <summary>
        /// OneGetWaterFun
        /// </summary>
        /// <param name="command">دادن ایدی</param>
        /// <returns>گرفتن اطلاعات ایدی داده شده</returns>
        [HttpGet("{Id}")]
        public async Task<IActionResult> OneGetWaterFunAsync(Guid id)
        {
            var result = await _waterFunService.OneGetWaterFunAsync(id);

            if (id == Guid.Empty)
                return NotFound(new { Message = "اطلاعات مورد نظر یافت نشد" });

            return Ok(new { Message = "عملیات با موفقیت انجام شد", Result = result });
        }

        ///NOT USED this api
        /// <summary>
        /// GetIdWaterFun
        /// </summary>
        /// <param name="command">دادن ایدی </param>
        /// <returns>گرفتن لیست تمام اطلاعات مربوط به اون ایدی و بقیه ایدی </returns>
        [HttpGet("GetIdWaterFun")]
        public async Task<IActionResult> GetByIdWaterFunAsync([FromBody] GetByIdWaterFunCommand command)
        {
            var result = await _waterFunService.GetByIdWaterFunAsync(command);

            if (result.Count == 0 || command.Id == Guid.Empty)
                return NotFound(new { Message = "NotFound" });

            return Ok(result);
        }

        ///TODO : باید برای به ورز رسانی تخفیف مورد جدید در نظر گرفته بشود
        /// <summary>
        /// PutWaterFun
        /// </summary>
        /// <param name="command">دادن تمام اطلاعت تفریحات ابی </param>
        /// <returns>تغییرات همه اطلاعت یکی از تفریخات ابی</returns>
        [HttpPut("{Id}/update")]
        public async Task<IActionResult> UpdateWaterFunAsync([FromBody] UpdateWaterFun command)
        {
            if (command.Id == Guid.Empty)
                return BadRequest(new { Message = "اطلاعات مورد نظر یافت نشد" });

            var result = await _waterFunService.UpdateWaterFunAsync(command);

            return Ok(new { Message = "عملیات با موفقیت انجام شد", Result = result });
        }
        #endregion

        #region 
        /// <summary>
        /// dto seller panel Ticket For Report
        /// </summary>
        /// <param name="Command"></param>
        /// <returns></returns>
        [HttpGet("Seller-Report")]
        public async Task<IActionResult> GetSellerPanelDtoAsync([FromBody] SellerPanelDtoSearchCommand Command)
        {
            var result = await _waterFunService.GetSellerPanelTicketDtoAsync(Command);
            if (result == null)
                return NotFound("لطفا نام دسته بندی خود را را وارد کنید");

            var sellerDto = result.Select(q =>
                new SellerPanelTicketDto()
                {
                    Date = q.Date,
                    FunType = q.FunType,
                    TotalPrice = q.TotalPrice,
                    TicketReservation = q.TicketReservation
                });
            return Ok(new { Message = "عملیات با موفقیت انجام شد", Result = sellerDto });
        }
        #endregion
    }
}
