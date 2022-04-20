using System;
using System.Threading.Tasks;
using Marina_Club.Command.SiteManagerCommand;
using Marina_Club.Command.UpdateCommand;
using Marina_Club.Command.WaterFunCommand;
using Marina_Club.Model;
using Marina_Club.Pagination;
using Marina_Club.Services.SiteManagement;
using Microsoft.AspNetCore.Mvc;
namespace Marina_Club.Controllers
{
    [Route("api/[controller]")]
    public class SiteManagementController : Controller
    {
        private readonly ISiteManagementService _siteManagementService;
        public SiteManagementController(ISiteManagementService siteManagementService)
        {
            _siteManagementService = siteManagementService;
        }


        #region SiteManagement

        #region Suggestion

        /// <summary>
        /// دریافت پیشنهادات
        /// </summary>
        /// <returns> لیستی از پیشنهادات</returns>
        [HttpGet("suggestions")]
        public async Task<IActionResult> GetSuggestionAsync([FromBody] PaginationCommand command)
        {
            var result = await _siteManagementService.GetSuggestionAsync(command);
            if (result.Count == 0 || result == null)
                return NotFound(new { Message = "NotFound" });
            return Ok(new { Message = "عملیات با موفقیت انجام شد", Result = result });
        }

        /// <summary>
        /// AddSuggestionss
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("Add-Suggestions")]
        public async Task<IActionResult> AddSuggestionAsync([FromBody] AddSuggestionCommand command)
        {
            if (string.IsNullOrEmpty(command.ETitleOfSuggestions.ToString()) &&
                (string.IsNullOrEmpty(command.FunTypeSuggestion.ToString()))
                && command.SliderSuggestion.Count == 0)
            {
                return BadRequest(new { Message = "Bad Request" });
            }
            var result = await _siteManagementService.AddSuggestionAsync(command);
            return Ok(new { Message = "عملیات با موفقیت انجام شد", Result = result });
        }

        /// <summary>
        /// Update Suggestion
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("Update-Suggestion")]
        public async Task<IActionResult> UpdateSuggestionAsync([FromBody] UpdateSuggestionCommand command)
        {
            if (string.IsNullOrEmpty(command.SuggestionId.ToString()))
            {
                return BadRequest(new { Message = "Bad Request" });
            }
            var result = await _siteManagementService.UpdateSuggestionAsync(command);
            return Ok(new { Message = "عملیات با موفقیت انجام شد", Result = result });
        }

        /// <summary>
        /// Delete Suggestion
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpDelete("Delete-Suggestion")]
        public async Task<IActionResult> DeleteSuggestionAsync([FromBody] DeleteSuggestionCommand command)
        {
            if (command.SuggestionId == Guid.Empty)
                BadRequest(new { Message = "Bad Request" });
            var result = await _siteManagementService.DeleteSuggestionAsync(command);
            return Ok(new { Message = "عملیات با موفقیت انجام شد", Result = result });
        }

        #endregion

        #region Comment

        /// <summary>
        /// GetComment
        /// </summary>
        /// <returns></returns>
        [HttpGet("Get-Messages")]
        public async Task<IActionResult> GetMessageAsync([FromBody] PaginationCommand command)
        {
            var result = await _siteManagementService.GetMessageAsync(command);
            if (result.Count == 0 || result == null)
                return NotFound(new { Message = "NotFound" });
            return Ok(result);
        }

        /// <summary>
        /// Get Comment
        /// </summary>
        /// <returns></returns>
        [HttpGet("Show-All-Comment")]
        public async Task<IActionResult> GetCommentAsync([FromBody] PaginationCommand command)
        {
            var result = await _siteManagementService.GetCommentAsync(command);
            if (result == null)
            { return NotFound(new { Message = "NotFound" }); }
            var comment = new Comment();

            if (comment.IsConfirmComment = false)

                return NotFound(new { Message = "FFF" });


            return Ok(new { Message = "عملیات با موفقیت انجام شد", Result = result });
        }

        /// <summary>
        /// Add Comment
        /// </summary>
        /// <param تمامی اطلاعات></param>
        /// <returns>اضافه کردن کاربر جدید</returns>
        [HttpPost("Add-Comment")]
        public async Task<IActionResult> AddCommentAsync([FromBody] AddCommentCommand command)
        {
            if (string.IsNullOrEmpty(command.TextComment) &&
                string.IsNullOrEmpty(command.UserName) &&
                string.IsNullOrEmpty(command.FunTypeId.ToString()))
                return BadRequest(new { Message = "Bad Request" });
            var result = await _siteManagementService.AddCommentAsync(command);
            return Ok(new { Message = "عملیات با موفقیت انجام شد", Result = result });
        }

        [HttpDelete("Delete-Slider")]
        public async Task<IActionResult> DeleteSliderAsync([FromBody] DeleteCommand command)
        {
            if (command.SlidersId == Guid.Empty)
                BadRequest(new { Message = "Bad Request" });
            var result = await _siteManagementService.DeleteSliderAsync(command);
            return Ok(new { Message = "عملیات با موفقیت انجام شد", Result = result });
        }

        [HttpDelete("Delete-Comment")]
        public async Task<IActionResult> DeleteCommentAsync([FromBody] DeleteCommand command)
        {
            if (command.Id == Guid.Empty)
                BadRequest(new { Message = "Bad Request" });
            var result = await _siteManagementService.DeleteCommentAsync(command);
            return Ok(new { Message = "عملیات با موفقیت انجام شد", Result = result });
        }

        [HttpPut("Update-Comment")]
        public async Task<IActionResult> UpdateCommentAsync([FromBody] UpdateCommentCommand command)
        {
            if (command.Id == Guid.Empty)
                return BadRequest("لطفا همه فیلد ها را پر کنید");
            var result = await _siteManagementService.UpdateCommentAsync(command);
            return Ok(new { Message = "عملیات با موفقیت انجام شد", Result = result });
        }

        [HttpGet("Show-Comment-In-Site")]//
        public async Task<IActionResult> GetCommentsAsync(GetCommentInSiteCommand command)
        {
            var result = await _siteManagementService.GetCommentsAsync(command);

            if (result == null)
                return NotFound(new { Message = "NotFound" });

            return Ok(new { Message = "عملیات با موفقیت انجام شد", Result = result });
        }

        #endregion

        /// <summary>
        /// Get Introducing WaterFun In Site
        /// </summary>
        /// <returns></returns>
        [HttpGet("Get-Introducing")]
        public async Task<IActionResult> GetIntroducingAsync([FromBody] PaginationCommand command)
        {
            var result = await _siteManagementService.GetIntroducingAsync(command);
            if (result.Count == 0 || result == null)
                return NotFound(new { Message = "NotFound" });
            return Ok(new { Message = "عملیات با موفقیت انجام شد", Result = result });
        }

        /// <summary>
        /// Add Introducing WaterFun In Site
        /// </summary>
        /// <returns></returns>
        [HttpPost("Add-Introducing")]
        public async Task<IActionResult> AddIntroducingAsync([FromBody] AddIntroducingCommand command)
        {
            if ((command.WaterFunIntroducing == Guid.Empty) &&
                (string.IsNullOrEmpty(command.IntroducingText))
                && string.IsNullOrEmpty(command.pathFileIntroducing))
            {
                return BadRequest(new { Message = "Bad Request" });
            }
            var result = await _siteManagementService.AddIntroducingAsync(command);
            return Ok(new { Message = "عملیات با موفقیت انجام شد", Result = result });
        }

        [HttpDelete("Delete-Introducing")]
        public async Task<IActionResult> DeleteIntroducingAsync([FromBody] DeleteCommand command)
        {
            if (command.SliderIntroducingId == Guid.Empty)
                BadRequest(new { Message = "Bad Request" });
            var result = await _siteManagementService.DeleteIntroducingAsync(command);
            return Ok(new { Message = "عملیات با موفقیت انجام شد", Result = result });
        }

        /// <summary>
        ///Add Message
        /// </summary>
        /// <param >Dto هاش رو قبلا زدماز همونا استفاده بشه</param>
        /// <returns></returns>
        [HttpPost("Add-Messages")]
        public async Task<IActionResult> AddWaterFunAsync([FromBody] AddMessageCommand command)
        {
            if (string.IsNullOrEmpty(command.TextMessage) &&
                command.ListMessageCommands.Count == 0
                && command.MessageId == Guid.Empty)
                return BadRequest(new { Message = "Bad Request" });
            var result = await _siteManagementService.AddMessageAsync(command);
            return Ok(new { Message = "عملیات با موفقیت انجام شد", Result = result });
        }

        /// <summary>
        /// Add-slider
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("Add-Sliders")]
        public async Task<IActionResult> AddSliderAsync([FromBody] AddSlidersCommand command)
        {
            if (string.IsNullOrEmpty(command.PathSlider))
            {
                return BadRequest(new { Message = "Bad Request" });
            }
            var result = await _siteManagementService.AddSliderAsync(command);
            return Ok(new { Message = "عملیات با موفقیت انجام شد", Result = result });
        }

        /// <summary>
        /// Get Slider
        /// </summary>
        /// <returns></returns>
        [HttpGet("List-Slider")]
        public async Task<IActionResult> GetSliderAsync()
        {
            var result = await _siteManagementService.GetSliderAsync();
            if (result.Count == 0 || result == null)
                return NotFound(new { Message = "NotFound" });
            return Ok(new { Message = "عملیات با موفقیت انجام شد", Result = result });
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> OneGetWaterFunAsync([FromBody] OneGetWaterFunCommand command)
        {
            var result = await _siteManagementService.OneGetWaterFunAsync(command);

            if (result.Id == Guid.Empty)
                return NotFound(new { Message = "اطلاعات مورد نظر یافت نشد" });

            return Ok(new { Message = "عملیات با موفقیت انجام شد", Result = result });
        }

        #endregion
    }
}

//Entity.Select(q=>q.Peraperty).Where(q=>q.peraperty==3).Tolist();