using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Marina_Club.Model;

namespace Marina_Club.Repositories.Setting
{
    public interface ISettingRepository
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
        Task<bool> AddRulesAsync(Rules rules);
        /// <summary>
        /// PutRules
        /// </summary>
        /// <param name="command">دادن متن و متن جدید</param>
        /// <returns>تغییر متن قوانین</returns>
        Task<Model.Rules> GetRulesForUpdateAsync(Guid RulesId);
        Task<bool> UpdateRulesAsync();
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
        Task<bool> AddAboutUsAsync(AboutUs aboutUs);
        /// <summary>
        /// PutAboutUs
        /// </summary>
        /// <param name="command">دادن متن و متن جدید</param>
        /// <returns> تغییر متن درباره ما</returns>
        Task<Model.AboutUs> GetSellerAboutUsForUpdateAsync(Guid AboutUsId);
        Task<bool> UpdateAboutUsAsync();
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
        Task<bool> AddContactUsAsync(ContactUs contactUs);
        /// <summary>
        /// PutContactUs
        /// </summary>
        /// <param name="command">دادن متن و متن جدید</param>
        /// <returns>تغییر متن تماس با ما</returns>
        Task<Model.ContactUs> GetContactUsForUpdateAsync(Guid ContactUsId);
        Task<bool> UpdateContactUsAsync();
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
        Task<bool> AddDuplicateQuestionsAsync(DuplicateQuestions duplicateQuestions);
        /// <summary>
        /// PutNewsletters
        /// </summary>
        /// <param name="command">دادن متن و متن جدید</param>
        /// <returns>تغییر متن خبرنامه</returns>
        Task<DuplicateQuestions> GetDuplicateQuestionsForUpdateAsync(Guid duplicateQuestionsId);
        Task<bool> UpdateDuplicateQuestionsAsync();
    }
}
