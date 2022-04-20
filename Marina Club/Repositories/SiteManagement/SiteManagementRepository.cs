using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Marina_Club.Context;
using Marina_Club.Model;
using Microsoft.EntityFrameworkCore;

namespace Marina_Club.Repositories.SiteManagement
{
    public class SiteManagementRepository : BaseRepository, ISiteManagementRepository
    {
        public SiteManagementRepository(MarinaClubContext context) : base(context)
        {
        }
        /// <summary>
        /// Get Suggestion
        /// </summary>
        /// <returns></returns>
        public async Task<List<Suggestion>> GetSuggestionAsync(int PageSize,int PageNumber,ETitleOfSuggestion ETitleOfSuggestion)
        {
            return await _context.Suggestions
                .Skip((PageNumber - 1) * PageSize)
                .Take(PageSize)
                .Include(q=>q.SliderSuggestion).ToListAsync();
        }
        //public async Task<List<SliderSuggestion>> GetTitleOfSuggestionAsync()
        //{
        //    return await _context.TitleOfSuggestions.ToListAsync();
        //}
        /// <summary>
        /// Suggestion Add
        /// </summary>
        /// <param name="suggestion"></param>
        /// <returns></returns>
        public async Task<bool> AddSuggestionAsync(Suggestion suggestion)
        {
            await _context.Suggestions.AddRangeAsync(suggestion);
            return await _context.SaveChangesAsync() > 0;
        }
        /// <summary>
        /// Delete Suggestion 
        /// </summary>
        /// <param name="SuggestionId"></param>
        /// <returns></returns>
        public async Task<Suggestion> GetSuggestionForDelete(Guid SuggestionId)
        {
            return await _context.Suggestions
                .Include(q=>q.SliderSuggestion).FirstOrDefaultAsync(e => e.SuggestionId == SuggestionId);
        }
        public async Task<bool> DeleteSuggestionAsync(Suggestion suggestion)
        {
            _context.Suggestions.RemoveRange(suggestion);
            var check = await _context.SaveChangesAsync();
            return check > 0;
        }
        //public async Task<SliderSuggestion> GetTitleOfSuggestionForDelete(Guid TitleOfSuggestionId)
        //{
        //    return await _context.TitleOfSuggestions.FirstOrDefaultAsync(e => e.TitleSuggestionId == TitleOfSuggestionId);
        //}
        //public async Task<bool> DeleteTitleOfSuggestionAsync(SliderSuggestion titleOfSuggestion)
        //{
        //    _context.TitleOfSuggestions.RemoveRange(titleOfSuggestion);
        //    var check = await _context.SaveChangesAsync();
        //    return check > 0;
        //}
        /// <summary>
        /// Update Suggestion 
        /// </summary>
        /// <param name="SliderSuggestions"></param>
        /// <param name="TitleOfSuggestions"></param>
        /// <param name="FunTypeSuggestion"></param>
        /// <returns></returns>
        public async Task<Suggestion> GetSuggestionForUpdate(Guid SuggestionId)
        {
            return await _context.Suggestions.FirstOrDefaultAsync(q => q.SuggestionId == SuggestionId);
        }
        public async Task<bool> UpdateSuggestionAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
        /// <summary>
        /// Get Introducing
        /// </summary>
        /// <returns></returns>
        public async Task <List<IntroducingWaterFun>> GetIntroducingAsync(int PageSize, int PageNumber)
        {
            return await _context.IntroducingWaterFuns
                .Skip((PageNumber - 1) * PageSize)
                .Take(PageSize).ToListAsync();
        }
        /// <summary>
        /// Add IntroducingWaterFun
        /// </summary>
        /// <param name="introducingWaterFun"></param>
        /// <returns></returns>
        public async Task<bool> AddIntroducingAsync(IntroducingWaterFun introducingWaterFun)
        {
            await _context.IntroducingWaterFuns.AddAsync(introducingWaterFun);
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<Model.WaterFun> OneGetWaterFunAsync(Guid id)
        {
            return await _context.WaterFuns
                .Include(q => q.Discounts)
                .FirstOrDefaultAsync(q => q.Id == id);
        }
        //#Message
        /// <summary>
        /// Add Message
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task<bool> AddMessageAsync(Model.Message message)
        {
            await _context.Messages.AddRangeAsync(message);
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<List<Model.Message>> GetMessageAsync(int PageSize, int PageNumber)
        {
            return await _context.Messages
                .Include(q=>q.ListMessages)
                .Skip((PageNumber - 1) * PageSize)
                .Take(PageSize).ToListAsync();
        }
        /// <summary>
        /// Comment
        /// </summary>
        /// <param name="comment"></param>
        /// <returns></returns>
        public async Task<bool> AddCommentAsync(Model.Comment comment)
        {
            await _context.Comments.AddAsync(comment);
            var check = await _context.SaveChangesAsync();
            return check > 0;
        }
        public async Task<List<Model.Comment>> GetCommentAsync(int PageSize, int PageNumber)
        {
            return await _context.Comments
                .Skip((PageNumber - 1) * PageSize)
                .Take(PageSize).ToListAsync();
        }
        public async Task<Model.Comment> GetCommentForUpdateAsync(Guid Id)
        {
            return await _context.Comments.FirstOrDefaultAsync(q => q.Id==Id);
        }
        public async Task<bool> UpdateCommentAsync()
        {
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }
        public async  Task<List<Model.Comment>> GetCommentsAsync(Guid FuntypeId)
        {
            var  result =await _context.Comments.ToListAsync();
         
            return result;
        }
        /// <summary>
        /// add Slider
        /// </summary>
        /// <param name="introducingWaterFun"></param>
        /// <returns></returns>
        public async Task<bool> AddSliderAsync(Sliders sliders)
        {
            await _context.Sliders.AddAsync(sliders);
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<List<Sliders>> GetSliderAsync()
        {
            return await _context.Sliders.ToListAsync();
        }
        //
        public async Task<Sliders> GetSliderForDelete(Guid SliderId)
        {
            return await _context.Sliders.FirstOrDefaultAsync(e => e.SlidersId==SliderId);
        }
        public async Task<bool> DeleteSliderAsync(Sliders sliders)
        {
            _context.Sliders.RemoveRange(sliders);
            var check = await _context.SaveChangesAsync();
            return check > 0;
        }
        //
        public async Task<Comment> GetCommentForDelete(Guid Id)
        {
            return await _context.Comments.FirstOrDefaultAsync(e => e.Id==Id);
        }
        public async Task<bool> DeleteCommentAsync(Comment comment)
        {
            _context.Comments.RemoveRange(comment);
            var check = await _context.SaveChangesAsync();
            return check > 0;
        }
        //
        public async Task<IntroducingWaterFun> GetIntroducingForDelete(Guid IntroducingId)
        {
            return await _context.IntroducingWaterFuns.FirstOrDefaultAsync(e => e.SliderIntroducingId==IntroducingId);
        }
        public async Task<bool> DeleteIntroducingAsync(IntroducingWaterFun introducingWaterFun)
        {
            _context.IntroducingWaterFuns.RemoveRange(introducingWaterFun);
            var check = await _context.SaveChangesAsync();
            return check > 0;
        }
        //
    }
}
