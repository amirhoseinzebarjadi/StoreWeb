using System.Collections.Generic;
using System.Threading.Tasks;
using Marina_Club.Command.SettingCommand;
using Marina_Club.Command.UpdateCommand;
using Marina_Club.Model;

namespace Marina_Club.Services.Setting
{
   public interface ISettingService
    {
        /// <summary>
        /// GetRules
        /// </summary>
        /// <returns>گرفتن قوانین</returns>
        Task<List<Rules>> GetRulesAsync();
        /// <summary>
        /// PostRules
        /// </summary>
        /// <param name="command">دادن متن قوانین</param>
        /// <returns>ساخت متن قوانین</returns>
        Task<bool> AddRulesAsync(AddRulesCommand command);
        /// <summary>
        /// PutRules
        /// </summary>
        /// <param name="command">دادن متن و متن جدید</param>
        /// <returns>تغییر متن قوانین</returns>
        Task<bool> UpdateRulesAsync(UpdateRulesCommand command);
        /// <summary>
        /// GetAboutUs
        /// </summary>
        /// <returns>گرفتن درباره ما</returns>
        Task<List<AboutUs>> GetAboutUsAsync();
        /// <summary>
        /// PostAboutUs
        /// </summary>
        /// <param name="command">دادن متن </param>
        /// <returns>ساخت متن درباره ما</returns>
        Task<bool> AddAboutUsAsync(AddAboutUsCommand command);
        /// <summary>
        /// PutAboutUs
        /// </summary>
        /// <param name="command">دادن متن و متن جدید</param>
        /// <returns> تغییر متن درباره ما</returns>
        Task<bool> UpdateAboutUsAsync(UpdateAboutUsCommand command);
        /// <summary>
        /// GetContactUs
        /// </summary>
        /// <returns>گرفتن تماس با ما</returns>
        Task<List<ContactUs>> GetContactUsAsync();
        /// <summary>
        /// PostContactUs
        /// </summary>
        /// <param name="command">دادن متن و شماره و ایمیل و ادرس</param>
        /// <returns>ساخت تماس با ما</returns>
        Task<bool> AddContactUsAsync(AddContactUsCommand command);
        /// <summary>
        /// PutContactUs
        /// </summary>
        /// <param name="command">دادن متن و متن جدید</param>
        /// <returns>تغییر متن تماس با ما</returns>
        Task<bool> UpdateContactUsAsync(UpdateContactUsCommand command);
        /// <summary>
        /// GetNewsletters
        /// </summary>
        /// <returns>گرفتن خیرنامه</returns>
        Task<List<DuplicateQuestions>> GetDuplicateQuestionsAsync();
        /// <summary>
        /// PostNewsletters
        /// </summary>
        /// <param name="command">دادن متن </param>
        /// <returns>ساخت خبرنامه</returns>
        Task<bool> AddDuplicateQuestionsAsync(AddDuplicateQuestionsCommand command);
        /// <summary>
        /// PutNewsletters
        /// </summary>
        /// <param name="command">دادن متن و متن جدید</param>
        /// <returns>تغییر متن خبرنامه</returns>
        Task<bool> UpdateDuplicateQuestionsAsync(UpdateDuplicateQuestionsCommand command);
    }
}
