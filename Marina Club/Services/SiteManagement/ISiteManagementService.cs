using System.Collections.Generic;
using System.Threading.Tasks;
using Marina_Club.Command.SiteManagerCommand;
using Marina_Club.Command.UpdateCommand;
using Marina_Club.Command.WaterFunCommand;
using Marina_Club.Model;
using Marina_Club.Pagination;

namespace Marina_Club.Services.SiteManagement
{
    public interface ISiteManagementService
    {
        /// <summary>
        /// دریافت پیشنهادات
        /// </summary>
        /// <returns> لیستی از پیشنهادات</returns>
        Task<List< Suggestion>> GetSuggestionAsync(PaginationCommand command);
        /// <summary>
        /// Get List Titles Suggestion
        /// </summary>
        /// <returns> نمایش لیستی از پیشنهادات</returns>
        //Task<List<SliderSuggestion>> GetTitleOfSuggestionAsync();
        /// <summary>
        /// Get List SliderSuggestion
        /// </summary>
        /// <returns>نمایش لیستی از عکس ها هر پیشنهاد و هر تفریح</returns>
        //Task<List<SliderSuggestion>> GetSliderSuggestionAsync();
        /// <summary>
        /// AddSuggestionss
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        Task<bool> AddSuggestionAsync(AddSuggestionCommand command);
        /// <summary>
        /// Update Suggestion
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        Task<bool> UpdateSuggestionAsync(UpdateSuggestionCommand command);
        /// <summary>
        /// Delete Suggestion
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        Task<bool> DeleteSuggestionAsync(DeleteSuggestionCommand command);
        /// <summary>
        /// Delete Suggestion Sliders
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        //Task<bool> DeleteSliderSuggestionAsync(DeleteSliderSuggestionCommand command);
        /// <summary>
        /// Get Introducing WaterFun In Site
        /// </summary>
        /// <returns></returns>
        Task<List<IntroducingWaterFun>> GetIntroducingAsync(PaginationCommand command);
        Task<Model.WaterFun> OneGetWaterFunAsync(OneGetWaterFunCommand command);
        /// <summary>
        /// Add Introducing WaterFun In Site
        /// </summary>
        /// <returns></returns>
        Task<bool> AddIntroducingAsync(AddIntroducingCommand command);
        /// <summary>
        ///Add Message
        /// </summary>
        /// <param >Dto هاش رو قبلا زدماز همونا استفاده بشه</param>
        /// <returns></returns>
        Task<bool> AddMessageAsync(AddMessageCommand command);

        Task<List<Message>> GetMessageAsync(PaginationCommand command);
        /// <summary>
        /// GetComment
        /// </summary>
        /// <returns></returns>
        Task<List<Model.Comment>> GetCommentAsync(PaginationCommand command);
        /// <summary>
        /// AddComment
        /// </summary>
        /// <param name="command">user</param>
        /// <returns></returns>
        Task<bool> AddCommentAsync(AddCommentCommand command);
        Task<bool> UpdateCommentAsync( UpdateCommentCommand command);
        Task <List<Comment>> GetCommentsAsync(GetCommentInSiteCommand command);
        Task<bool> AddSliderAsync(AddSlidersCommand command);
        Task<List<Sliders>> GetSliderAsync();
        Task<bool> DeleteSliderAsync(DeleteCommand command);
        Task<bool> DeleteCommentAsync(DeleteCommand command);
        Task<bool> DeleteIntroducingAsync(DeleteCommand command);
    }
}
