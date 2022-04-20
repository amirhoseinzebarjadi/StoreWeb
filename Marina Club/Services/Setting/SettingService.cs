using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Marina_Club.Command.SettingCommand;
using Marina_Club.Command.UpdateCommand;
using Marina_Club.Model;
using Marina_Club.Repositories.Setting;

namespace Marina_Club.Services.Setting
{
    public class SettingService : ISettingService
    {
        private readonly ISettingRepository _settingRepository;

        public SettingService(ISettingRepository settingRepository)
        {
            _settingRepository = settingRepository;
        }
        /// <summary>
        /// GetRules
        /// </summary>
        /// <returns>گرفتن قوانین</returns>
        public async Task<List<Model.Rules>> GetRulesAsync()
        {
            return await _settingRepository.GetRulesAsync();
        }
        /// <summary>
        /// PostRules
        /// </summary>
        /// <param name="command">دادن متن قوانین</param>
        /// <returns>ساخت متن قوانین</returns>
        public async Task<bool> AddRulesAsync(AddRulesCommand command)
        {
            var rules= new Model.Rules();
            rules.RulesId = Guid.NewGuid();
            rules.TextRules = command.TextRules;

            return await _settingRepository.AddRulesAsync(rules);
        }
        /// <summary>
        /// PutRules
        /// </summary>
        /// <param name="command">دادن متن و متن جدید</param>
        /// <returns>تغییر متن قوانین</returns>
        public async Task<bool> UpdateRulesAsync(UpdateRulesCommand command)
        {


            var rules = await _settingRepository.GetRulesForUpdateAsync(command.RulesId);
                rules.TextRules= command.NewTextRules;
            

            return await _settingRepository.UpdateRulesAsync();
        }
        /// <summary>
        /// GetAboutUs
        /// </summary>
        /// <returns>گرفتن درباره ما</returns>
        public async Task<List<Model.AboutUs>> GetAboutUsAsync()
        {
            return await _settingRepository.GetAboutUsAsync();
        }
        /// <summary>
        /// PostAboutUs
        /// </summary>
        /// <param name="command">دادن متن </param>
        /// <returns>ساخت متن درباره ما</returns>
        public async Task<bool> AddAboutUsAsync(AddAboutUsCommand command)
        {
            var aboutUs = new Model.AboutUs();
            aboutUs.AboutUsId = Guid.NewGuid();
            aboutUs.TextAboutUs = command.TextAboutUs;

            return await _settingRepository.AddAboutUsAsync(aboutUs);
        }
        /// <summary>
        /// PutAboutUs
        /// </summary>
        /// <param name="command">دادن متن و متن جدید</param>
        /// <returns> تغییر متن درباره ما</returns>
        public async Task<bool> UpdateAboutUsAsync(UpdateAboutUsCommand command)
        {
            var abutUs = await _settingRepository.GetSellerAboutUsForUpdateAsync(command.AboutUsId);
            abutUs.TextAboutUs= command.NewTextAboutUs;

            return await _settingRepository.UpdateAboutUsAsync();
        }
        /// <summary>
        /// GetContactUs
        /// </summary>
        /// <returns>گرفتن تماس با ما</returns>
        public async Task<List<Model.ContactUs>> GetContactUsAsync()
        {
            return await _settingRepository.GetContactUsAsync();
        }
        /// <summary>
        /// PostContactUs
        /// </summary>
        /// <param name="command">دادن متن و شماره و ایمیل و ادرس</param>
        /// <returns>ساخت تماس با ما</returns>
        public async Task<bool> AddContactUsAsync(AddContactUsCommand command)
        {
            var contactUs = new ContactUs();
            contactUs.ContactUsId = Guid.NewGuid();
            contactUs.PhoneMarina = command.PhoneMarina;
            contactUs.FaxMarina = command.FaxMarina;
            contactUs.AddressMarina = command.AddressMarina;
            contactUs.EmailMarina = command.EmailMarina;

            return await _settingRepository.AddContactUsAsync(contactUs);
        }
        /// <summary>
        /// PutContactUs
        /// </summary>
        /// <param name="command">دادن متن و متن جدید</param>
        /// <returns>تغییر متن تماس با ما</returns>
        public async Task<bool> UpdateContactUsAsync(UpdateContactUsCommand command)
        {
            var contactUs = await _settingRepository.GetContactUsForUpdateAsync(command.ContactUsId);
            contactUs.PhoneMarina = command.NewPhoneMarina;
            contactUs.AddressMarina = command.NewAddressMarina;
            contactUs.FaxMarina = command.NewFaxMarina;
            contactUs.EmailMarina = command.NewEmailMarina;

            return await _settingRepository.UpdateContactUsAsync();
        }
        /// <summary>
        /// GetNewsletters
        /// </summary>
        /// <returns>گرفتن خیرنامه</returns>
        public async Task<List<DuplicateQuestions>> GetDuplicateQuestionsAsync()
        {
            return await _settingRepository.GetDuplicateQuestionsAsync();
        }
        /// <summary>
        /// PostNewsletters
        /// </summary>
        /// <param name="command">دادن متن </param>
        /// <returns>ساخت خبرنامه</returns>
        public async Task<bool> AddDuplicateQuestionsAsync(AddDuplicateQuestionsCommand command)
        {
           var duplicateQuestions = new DuplicateQuestions();
           duplicateQuestions.DuplicateQuestionsId = Guid.NewGuid();
           duplicateQuestions.TextDuplicateQuestions = command.TextDuplicateQuestions;

           return await _settingRepository.AddDuplicateQuestionsAsync(duplicateQuestions);
        }
        /// <summary>
        /// PutNewsletters
        /// </summary>
        /// <param name="command">دادن متن و متن جدید</param>
        /// <returns>تغییر متن خبرنامه</returns>
        public async Task<bool> UpdateDuplicateQuestionsAsync(UpdateDuplicateQuestionsCommand command)
        {
            var duplicateQuestions = await _settingRepository.GetDuplicateQuestionsForUpdateAsync(command.DuplicateQuestionsId);
            duplicateQuestions.TextDuplicateQuestions = command.NewTextDuplicateQuestions;

            return await _settingRepository.UpdateDuplicateQuestionsAsync();
        }
    }
}
