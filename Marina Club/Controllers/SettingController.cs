using System.Threading.Tasks;
using Marina_Club.Command.SettingCommand;
using Marina_Club.Command.UpdateCommand;
using Marina_Club.Services.Setting;
using Microsoft.AspNetCore.Mvc;

namespace Marina_Club.Controllers
{

    [Route("api/[controller]")]
    public class SettingController : Controller
    {
        private readonly ISettingService _settingService;
        public SettingController(ISettingService settingService)
        {
            _settingService = settingService;
        }

        #region Setting

        /// <summary>
        /// GetRules
        /// </summary>
        /// <returns>گرفتن قوانین</returns>
        [HttpGet("Get-Rules")]
        public async Task<IActionResult> GetRulesAsync()
        {
            var result = await _settingService.GetRulesAsync();

            if (result.Count == 0 || result == null)
                return NotFound(new { Message = "اطلاعات مورد نظر یافت نشد" });
            return Ok(new { Message = "عملیات با موفقیت انجام شد", Result = result });
        }

        /// <summary>
        /// PostRules
        /// </summary>
        /// <param name="command">دادن متن قوانین</param>
        /// <returns>ساخت متن قوانین</returns>
        [HttpPost("Add-Rules")]
        public async Task <IActionResult> AddRulesAsync([FromBody] AddRulesCommand command)
        {
            if (string.IsNullOrEmpty(command.TextRules))
                return BadRequest(new { Message = "اطلاعات مورد نظر یافت نشد" });
            var result = await _settingService.AddRulesAsync(command);
            return Ok(new { Message = "عملیات با موفقیت انجام شد", Result = result });
        }

        /// <summary>
        /// PutRules
        /// </summary>
        /// <param name="command">دادن متن و متن جدید</param>
        /// <returns>تغییر متن قوانین</returns>
        [HttpPut("Update-Rules")]
        public async Task<IActionResult> UpdateRulesAsync([FromBody] UpdateRulesCommand command)
        {
            if (string.IsNullOrEmpty(command.RulesId.ToString()))
                return BadRequest(new { Message = "اطلاعات مورد نظر یافت نشد" });
            var result = await _settingService.UpdateRulesAsync(command);
            return Ok(new { Message = "عملیات با موفقیت انجام شد", Result = result });
        }

        /// <summary>
        /// GetAboutUs
        /// </summary>
        /// <returns>گرفتن درباره ما</returns>
        [HttpGet("Get-AboutUs")]
        public async Task<IActionResult> GetAboutUsAsync()
        {
            var result = await _settingService.GetAboutUsAsync();

            if (result.Count == 0 || result == null)
                return NotFound(new { Message = "اطلاعات مورد نظر یافت نشد" });

            return Ok(new { Message = "عملیات با موفقیت انجام شد", Result = result });
        }

        /// <summary>
        /// PostAboutUs
        /// </summary>
        /// <param name="command">دادن متن </param>
        /// <returns>ساخت متن درباره ما</returns>
        [HttpPost("Add-AboutUs")]
        public async Task<IActionResult> AddAboutUsAsync([FromBody] AddAboutUsCommand command)
        {
            if (string.IsNullOrEmpty(command.TextAboutUs))
                return BadRequest(new { Message = "اطلاعات مورد نظر یافت نشد" });
            var result = await _settingService.AddAboutUsAsync(command);
            return Ok(new { Message = "عملیات با موفقیت انجام شد", Result = result });
        }

        /// <summary>
        /// PutAboutUs
        /// </summary>
        /// <param name="command">دادن متن و متن جدید</param>
        /// <returns> تغییر متن درباره ما</returns>
        [HttpPut("Update-AboutUs")]
        public async Task<IActionResult> UpdateAboutUsAsync([FromBody] UpdateAboutUsCommand command)
        {
            if (string.IsNullOrEmpty(command.AboutUsId.ToString()))
                return BadRequest("لطفا همه فیلد ها را پر کنید");
            var result = await _settingService.UpdateAboutUsAsync(command);
            return Ok(new { Message = "عملیات با موفقیت انجام شد", Result = result });
        }

        /// <summary>
        /// GetContactUs
        /// </summary>
        /// <returns>گرفتن تماس با ما</returns>
        [HttpGet("Get-ContactUs")]
        public async Task<IActionResult> GetContactUsAsync()
        {
            var result = await _settingService.GetContactUsAsync();
            if (result.Count == 0 || result == null)
                return NotFound(new { Message = "اطلاعات مورد نظر یافت نشد" });
            return Ok(new { Message = "عملیات با موفقیت انجام شد", Result = result });
        }

        /// <summary>
        /// PostContactUs
        /// </summary>
        /// <param name="command">دادن متن و شماره و ایمیل و ادرس</param>
        /// <returns>ساخت تماس با ما</returns>
        [HttpPost("Add-ContactUs")]
        public async Task<IActionResult> AddContactUsAsync([FromBody] AddContactUsCommand command)
        {
            if (string.IsNullOrEmpty(command.AddressMarina) && string.IsNullOrEmpty(command.EmailMarina)
                && string.IsNullOrEmpty(command.FaxMarina) && string.IsNullOrEmpty(command.PhoneMarina))
                return BadRequest(new { Message = "اطلاعات مورد نظر یافت نشد" });
            var result = await _settingService.AddContactUsAsync(command);
            return Ok(new { Message = "عملیات با موفقیت انجام شد", Result = result });
        }

        /// <summary>
        /// PutContactUs
        /// </summary>
        /// <param name="command">دادن متن و متن جدید</param>
        /// <returns>تغییر متن تماس با ما</returns>
        [HttpPut("Update-ContactUs")]
        public async Task<IActionResult> UpdateContactUsAsync([FromBody] UpdateContactUsCommand command)
        {
            if (string.IsNullOrEmpty(command.ContactUsId.ToString()))

            return BadRequest("لطفا همه فیلد ها را پر کنید");
            var result = await _settingService.UpdateContactUsAsync(command);
            return Ok(new { Message = "عملیات با موفقیت انجام شد", Result = result });
        }

        /// <summary>
        /// GetDuplicateQuestions
        /// </summary>
        /// <returns>گرفتن سوالات تکراری</returns>
        [HttpGet("Get-DuplicateQuestions")]
        public async Task<IActionResult> GetDuplicateQuestionsAsync()
        {
            var result = await _settingService.GetDuplicateQuestionsAsync();

            if (result.Count == 0 )
                return NotFound(new { Message = "اطلاعات مورد نظر یافت نشد" });

            return Ok(new { Message = "عملیات با موفقیت انجام شد", Result = result });
        }

        /// <summary>
        /// PostDuplicateQuestions
        /// </summary>
        /// <param name="command">دادن متن </param>
        /// <returns>ساخت سوالات تکراری</returns>
        [HttpPost("Add-DuplicateQuestions")]
        public async Task<IActionResult> AddDuplicateQuestionsAsync([FromBody] AddDuplicateQuestionsCommand command)
        {
            if (string.IsNullOrEmpty(command.TextDuplicateQuestions))
                return BadRequest(new { Message = "اطلاعات مورد نظر یافت نشد" });
            var result = await _settingService.AddDuplicateQuestionsAsync(command);
            return Ok(new { Message = "عملیات با موفقیت انجام شد", Result = result });
        }

        /// <summary>
        /// PutDuplicateQuestions
        /// </summary>
        /// <param name="command">دادن متن و متن جدید</param>
        /// <returns>تغییر متن سوالات تکراری</returns>
        [HttpPut("Update-DuplicateQuestions")]
        public async Task<IActionResult> UpdateDuplicateQuestionsAsync([FromBody] UpdateDuplicateQuestionsCommand command)
        {
            if (string.IsNullOrEmpty(command.NewTextDuplicateQuestions))

                return BadRequest("لطفا همه فیلد ها را پر کنید");
            var result = await _settingService.UpdateDuplicateQuestionsAsync(command);
            return Ok(new { Message = "عملیات با موفقیت انجام شد", Result = result });
        }

        #endregion
    }
}
