using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Marina_Club.Command.QueryCommand;
using Marina_Club.Command.SellerManagerCommand;
using Marina_Club.Command.UpdateCommand;
using Marina_Club.Pagination;

namespace Marina_Club.Services.SellerManager
{
    public interface ISellerManagerService
    {
       /// <summary>
       /// Get Sellers
       /// </summary>
       /// <returns></returns>
        Task <Model.SellerManager> GetSellerManagerAsync(Guid SellerManagerId);

        //Task <SellerAddress> GetAddressSellerAsync();
        //Task <SellerInfo> GetSellerInfoAsync();
        /// <summary>
        /// AddSellers
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        Task<bool> AddSellerManagerAsync(SellerCommand command);

        /// <summary>
        /// Update Sellers
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        Task<bool> UpdateSellerManagerAsync(UpdateSellerManagerCommand command);

        /// <summary>
        /// Seller Dto
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        Task <List<Model.SellerManager>> GetSellerManagerDtoAsync(int PageNumber, int PageSize);

        Task<List<Model.SellerManager>> GetSellerManagersDtoAsync(int PageNumber, int PageSize, string SearchWord);

    }
}
