using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Marina_Club.Command.SiteManagerCommand;
using Marina_Club.Command.UpdateCommand;
using Marina_Club.Command.WaterFunCommand;
using Marina_Club.Model;
using Marina_Club.Pagination;
using Marina_Club.Repositories.SiteManagement;
using Microsoft.AspNetCore.Mvc;

namespace Marina_Club.Services.SiteManagement
{
    public class SiteManagementService : ISiteManagementService
    {
        private readonly ISiteManagementRepository _siteManagementRepository;
        public SiteManagementService(ISiteManagementRepository siteManagementRepository)
        {
            _siteManagementRepository = siteManagementRepository;
        }

        /// <summary>
        /// Get Suggestion
        /// </summary>
        /// <returns></returns>
        public async Task<List<Suggestion>> GetSuggestionAsync(PaginationCommand command)
        {
            return await _siteManagementRepository.GetSuggestionAsync(command.PageSize, command.PageNumber,command.ETitleOfSuggestion);
        }

        //public async Task<List<SliderSuggestion>> GetTitleOfSuggestionAsync()
        //{
        //    return await _siteManagementRepository.GetTitleOfSuggestionAsync();
        //}

        /// <summary>
        /// Add Suggestion
        /// </summary>
        /// <returns></returns>
        public async Task<bool> AddSuggestionAsync(AddSuggestionCommand command)
        {
            var suggestion = new Suggestion();
            suggestion.SuggestionId = Guid.NewGuid();
            suggestion.FunTypeSuggestion = command.FunTypeSuggestion;
            suggestion.ETitleOfSuggestions = command.ETitleOfSuggestions;
            suggestion.SliderSuggestion = ToDto15(command.SliderSuggestion);

            return await _siteManagementRepository.AddSuggestionAsync(suggestion);
        }

        private List<SliderSuggestion> ToDto15(IList<AddSliderSuggestionCommand> commands)
        {
            return commands.Select(q => new SliderSuggestion()
            {
                TextFileSuggestion = q.TextFileSuggestion,
                NameFileSuggestion = q.NameFileSuggestion,
                PathFileSuggestion = q.PathFileSuggestion,
                SliderSuggestionId = Guid.NewGuid()

            }).ToList();
        }

        /// <summary>
        /// Update Suggestion
        /// </summary>
        /// <returns></returns>
        public async Task<bool> UpdateSuggestionAsync(UpdateSuggestionCommand command)
        {
            var suggestion = await _siteManagementRepository.GetSuggestionForUpdate(command.SuggestionId);
            suggestion.SliderSuggestion = ToDto16(command.NewSliderSuggestion);
            suggestion.FunTypeSuggestion = command.NewFunTypeSuggestion;
            suggestion.ETitleOfSuggestions = command.NewETitleOfSuggestions;
            return await _siteManagementRepository.UpdateSuggestionAsync();
        }

        private List<SliderSuggestion> ToDto16(IList<UpdateSliderSuggestionCommand> commands)
        {
            return commands.Select(q => new SliderSuggestion()
            {
                TextFileSuggestion = q.NewTextFileSuggestion,
                NameFileSuggestion = q.NewNameFileSuggestion,
                PathFileSuggestion = q.NewPathFileSuggestion
            }).ToList();
        }

        public async Task<bool> DeleteSuggestionAsync(DeleteSuggestionCommand command)
        {
            var suggestion = await _siteManagementRepository.GetSuggestionForDelete(command.SuggestionId);
            if (suggestion is null)
                return false;
            return await _siteManagementRepository.DeleteSuggestionAsync(suggestion);
        }

        /// <summary>
        /// Delete Suggestion
        /// </summary>
        /// <returns></returns>
        /// 
        //public async Task<bool> DeleteTitleOfSuggestionAsync(DeleteTitleOfSuggestionCommand command)
        //{
        //    var titleOfSuggestion = await _siteManagementRepository.GetTitleOfSuggestionForDelete(command.TitleOfSuggestionId);
        //    if (titleOfSuggestion is null)
        //        return false;

        //    return await _siteManagementRepository.DeleteTitleOfSuggestionAsync(titleOfSuggestion);
        //}

        /// <summary>
        /// Get Introducing
        /// </summary>
        /// <returns></returns>
        public async Task<List<IntroducingWaterFun>> GetIntroducingAsync(PaginationCommand command)
        {
            return await _siteManagementRepository.GetIntroducingAsync(command.PageSize, command.PageNumber);
        }

        /// <summary>
        /// Add Introducing
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public async Task<bool> AddIntroducingAsync(AddIntroducingCommand command)
        {
            var funType = await _siteManagementRepository.OneGetWaterFunAsync(command.WaterFunIntroducing);
            var introducingWaterFun = new IntroducingWaterFun();
            introducingWaterFun.SliderIntroducingId = Guid.NewGuid();
            introducingWaterFun.IntroducingText = command.IntroducingText;
            introducingWaterFun.WaterFunIntroducing = command.WaterFunIntroducing;
            introducingWaterFun.SliderpathFileIntroducing = command.pathFileIntroducing;
            introducingWaterFun.IconePathFileIntroducing = command.NameFileIntroducing;
            introducingWaterFun.FunTypeIntroducing = funType.FunType;

            return await _siteManagementRepository.AddIntroducingAsync(introducingWaterFun);
        }

        public async Task<Model.WaterFun> OneGetWaterFunAsync(OneGetWaterFunCommand command)
        {
            var waterFun = await _siteManagementRepository.OneGetWaterFunAsync(command.Id);
            return waterFun;
        }

        /// <summary>
        /// add massage
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public async Task<bool> AddMessageAsync([FromBody] AddMessageCommand command)
        {
            var waterFun = new Model.Message()
            {
                MessageId = Guid.NewGuid(),
                TextMessage = command.TextMessage,
                ListMessages = ToDto6(command.ListMessageCommands),
                DateMessage = DateTime.Now
            };
            return await _siteManagementRepository.AddMessageAsync(waterFun);
        }

        private List<ListMessage> ToDto6(List<ListMessageCommand> commands)
        {
            return commands.Select(q => new ListMessage
            {
                PhoneNumberSellerForMessage = q.PhoneNumberForMessage,
                NameSellerForMessage = q.NameForMessage,
            }).ToList();
        }

        public async Task<List<Model.Message>> GetMessageAsync(PaginationCommand command)
        {
            return await _siteManagementRepository.GetMessageAsync(command.PageSize, command.PageNumber);
        }

        /// <summary>
        /// Comment
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public async Task<bool> AddCommentAsync([FromBody] AddCommentCommand command)
        {
            var comment = new Model.Comment()
            {
                IsConfirmComment = false,
                TextComment = command.TextComment,
                CommentTime = DateTime.Now,
                UserName = command.UserName,
                FunTypeId = command.FunTypeId,
            };
            return await _siteManagementRepository.AddCommentAsync(comment);
        }

        public async Task<List<Model.Comment>> GetCommentAsync(PaginationCommand command)
        {
            var result= await _siteManagementRepository.GetCommentAsync(command.PageSize, command.PageNumber);
           
            return result;

        }

        public async Task<bool> UpdateCommentAsync(UpdateCommentCommand command)
        {
            var contactUs = await _siteManagementRepository.GetCommentForUpdateAsync(command.Id);
            contactUs.IsConfirmComment = command.NewIsConfirmComment;

            return await _siteManagementRepository.UpdateCommentAsync();
        }

        public async Task<List<Model.Comment>> GetCommentsAsync(GetCommentInSiteCommand command)
        {
            var result=await _siteManagementRepository.GetCommentsAsync(command.FunTypeId);
            var result3 = new List<Comment>();
            var  result1 = result/*.Where(q=>q.FunTypeId==command.FunTypeId).*/.Where(q=>q.IsConfirmComment==true).ToList();

            var result2=result1
                 .Skip((command.PageNumber - 1) * command.PageSize)
                .Take(command.PageSize).ToList();
            return result1;
        }

        /// <summary>
        /// Add Slider
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public async Task<bool> AddSliderAsync(AddSlidersCommand command)
        {
            var slider = new Sliders();
            slider.SlidersId = Guid.NewGuid();
            slider.NameSlider = command.NameSlider;
            slider.PathSlider = command.PathSlider;

            return await _siteManagementRepository.AddSliderAsync(slider);
        }

        public async Task<List<Sliders>> GetSliderAsync()
        {
            return await _siteManagementRepository.GetSliderAsync();
        }

        public async Task<bool> DeleteSliderAsync(DeleteCommand command)
        {
            var suggestion = await _siteManagementRepository.GetSliderForDelete(command.SlidersId);
            if (suggestion is null)
                return false;
            return await _siteManagementRepository.DeleteSliderAsync(suggestion);
        }

        public async Task<bool> DeleteCommentAsync(DeleteCommand command)
        {
            var suggestion = await _siteManagementRepository.GetCommentForDelete(command.Id);
            if (suggestion is null)
                return false;
            return await _siteManagementRepository.DeleteCommentAsync(suggestion);
        }

        public async Task<bool> DeleteIntroducingAsync(DeleteCommand command)
        {
            var suggestion = await _siteManagementRepository.GetIntroducingForDelete(command.SliderIntroducingId);
            if (suggestion is null)
                return false;
            return await _siteManagementRepository.DeleteIntroducingAsync(suggestion);
        }
    }
}