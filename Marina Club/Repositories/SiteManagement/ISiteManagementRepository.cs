using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Marina_Club.Model;

namespace Marina_Club.Repositories.SiteManagement
{
    public interface ISiteManagementRepository
    { 
        /// <summary>
        /// Get Suggestion
        /// </summary>
        /// <returns></returns>
        Task<List<Suggestion>> GetSuggestionAsync(int PageSize,int PageNumber,ETitleOfSuggestion ETitleOfSuggestion);
        //Task<List<SliderSuggestion>> GetTitleOfSuggestionAsync();
        /// <summary>
        /// Add Suggestions
        /// </summary>
        /// <param name="suggestion"></param>
        /// <returns></returns>
        Task<bool> AddSuggestionAsync(Suggestion suggestion);
        /// <summary>
        /// Update Suggestion
        /// </summary>
        /// <param name="SliderSuggestions"></param>
        /// <param name="TitleOfSuggestions"></param>
        /// <param name="FunTypeSuggestion"></param>
        /// <returns></returns>
        Task<Suggestion> GetSuggestionForUpdate(Guid SuggestionId);
        Task<bool> UpdateSuggestionAsync();
        /// <summary>
        /// Delete Suggestion
        /// </summary>
        /// <param name="SuggestionId"></param>
        /// <returns></returns>
        Task<Suggestion> GetSuggestionForDelete(Guid SuggestionId);
        Task<bool> DeleteSuggestionAsync(Suggestion suggestion);
        //Task<SliderSuggestion> GetTitleOfSuggestionForDelete(Guid TitleOfSuggestionId);
        //Task<bool> DeleteTitleOfSuggestionAsync(SliderSuggestion titleOfSuggestion);
        /// <summary>
        /// معرفی تفریحات گرفتن
        /// </summary>
        /// <returns></returns>
        Task <List<IntroducingWaterFun>> GetIntroducingAsync(int PageSize, int PageNumber);
        /// <summary>
        /// Add Introducing
        /// </summary>
        /// <param name="introducingWaterFun"></param>
        /// <returns></returns>
        Task<bool> AddIntroducingAsync(IntroducingWaterFun introducingWaterFun);
        Task<Model.WaterFun> OneGetWaterFunAsync(Guid id);
        /// <summary>
        /// Add Message List
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        Task<bool> AddMessageAsync(Model.Message message);
        Task<List<Model.Message>> GetMessageAsync(int PageSize, int PageNumber);
        /// <summary>
        /// Comment
        /// </summary>
        /// <param name="comment"></param>
        /// <returns></returns>
        Task<bool> AddCommentAsync(Model.Comment comment);
        Task<List<Model.Comment>> GetCommentAsync(int PageSize, int PageNumber);
        Task<Model.Comment> GetCommentForUpdateAsync(Guid Id);
        Task<bool> UpdateCommentAsync();
        Task<List<Model.Comment>> GetCommentsAsync(Guid FunTypeId);
        Task<bool> AddSliderAsync(Sliders sliders);
        Task<List<Sliders>> GetSliderAsync();
        //
        Task<Sliders> GetSliderForDelete(Guid SliderId);
        Task<bool> DeleteSliderAsync(Sliders sliders);
        //
        Task<Comment> GetCommentForDelete(Guid Id);
        Task<bool> DeleteCommentAsync(Comment comment);
        //
        Task<IntroducingWaterFun> GetIntroducingForDelete(Guid IntroducingId);
        Task<bool> DeleteIntroducingAsync(IntroducingWaterFun introducingWaterFun);
    }
}
