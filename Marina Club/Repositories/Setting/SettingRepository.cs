using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Marina_Club.Context;
using Marina_Club.Model;
using Microsoft.EntityFrameworkCore;

namespace Marina_Club.Repositories.Setting
{
    public class SettingRepository : BaseRepository, ISettingRepository
    {
        //private ISettingRepository _settingRepository;
        public SettingRepository(MarinaClubContext context) : base(context)
        {
        }
        /// <summary>
        /// GetRules
        /// </summary>
        /// <returns>گرفتن قوانین</returns>
        public async Task<List<Model.Rules>> GetRulesAsync()
        {
            return await _context.Rules.ToListAsync();
        }
        /// <summary>
        /// PostRules
        /// </summary>
        /// <param name="command">دادن متن قوانین</param>
        /// <returns>ساخت متن قوانین</returns>
        public async Task<bool> AddRulesAsync(Model.Rules rules)
        {
            await _context.Rules.AddAsync(rules);
            var check = await _context.SaveChangesAsync();
            return check > 0;
        }
        /// <summary>
        /// PutRules
        /// </summary>
        /// <param name="command">دادن متن و متن جدید</param>
        /// <returns>تغییر متن قوانین</returns>
        public async Task<Model.Rules> GetRulesForUpdateAsync(Guid RulesId)
        {
            return await _context.Rules.FirstOrDefaultAsync(q => q.RulesId == RulesId);
        }
        public async Task<bool> UpdateRulesAsync()
        {
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }
        /// <summary>
        /// GetAboutUs
        /// </summary>
        /// <returns>گرفتن درباره ما</returns>
        public async Task<List<Model.AboutUs>> GetAboutUsAsync()
        {
            return await _context.AboutUs.ToListAsync();
        }
        /// <summary>
        /// PostAboutUs
        /// </summary>
        /// <param name="command">دادن متن </param>
        /// <returns>ساخت متن درباره ما</returns>
        public async Task<bool> AddAboutUsAsync(Model.AboutUs aboutUs)
        {
            await _context.AboutUs.AddAsync(aboutUs);
            var check = await _context.SaveChangesAsync();
            return check > 0;
        }
        /// <summary>
        /// PutAboutUs
        /// </summary>
        /// <param name="command">دادن متن و متن جدید</param>
        /// <returns> تغییر متن درباره ما</returns>
        public async Task<Model.AboutUs> GetSellerAboutUsForUpdateAsync(Guid AboutUsId)
        {
            return await _context.AboutUs.FirstOrDefaultAsync(q => q.AboutUsId == AboutUsId);
        }
        public async Task<bool> UpdateAboutUsAsync()
        {
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }
        /// <summary>
        /// GetContactUs
        /// </summary>
        /// <returns>گرفتن تماس با ما</returns>
        public async Task<List<ContactUs>> GetContactUsAsync()
        {
            return await _context.ContactUses.ToListAsync();
        }
        /// <summary>
        /// PostContactUs
        /// </summary>
        /// <param name="command">دادن متن و شماره و ایمیل و ادرس</param>
        /// <returns>ساخت تماس با ما</returns>
        public async Task<bool> AddContactUsAsync(ContactUs contactUs)
        {
            await _context.ContactUses.AddAsync(contactUs);
            var check = await _context.SaveChangesAsync();
            return check > 0;
        }
        /// <summary>
        /// PutContactUs
        /// </summary>
        /// <param name="command">دادن متن و متن جدید</param>
        /// <returns>تغییر متن تماس با ما</returns>
        public async Task<Model.ContactUs> GetContactUsForUpdateAsync(Guid ContactUsId)
        {
            return await _context.ContactUses.FirstOrDefaultAsync(q => q.ContactUsId == ContactUsId);
        }
        public async Task<bool> UpdateContactUsAsync()
        {
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }
        /// <summary>
        /// GetNewsletters
        /// </summary>
        /// <returns>گرفتن خیرنامه</returns>
        public async Task<List<DuplicateQuestions>> GetDuplicateQuestionsAsync()
        {
            return await _context.DuplicateQuestions.ToListAsync();
        }
        /// <summary>
        /// PostNewsletters
        /// </summary>
        /// <param name="command">دادن متن </param>
        /// <returns>ساخت خبرنامه</returns>
        public async Task<bool> AddDuplicateQuestionsAsync(DuplicateQuestions duplicateQuestions)
        {
            await _context.DuplicateQuestions.AddAsync(duplicateQuestions);
            var check = await _context.SaveChangesAsync();
            return check > 0;
        }
        /// <summary>
        /// PutNewsletters
        /// </summary>
        /// <param name="command">دادن متن و متن جدید</param>
        /// <returns>تغییر متن خبرنامه</returns>
        public async Task<DuplicateQuestions> GetDuplicateQuestionsForUpdateAsync(Guid duplicateQuestionsId)
        {
            return await _context.DuplicateQuestions.FirstOrDefaultAsync(q => q.DuplicateQuestionsId == duplicateQuestionsId);
        }
        public async Task<bool> UpdateDuplicateQuestionsAsync()
        {
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }
    }
}
