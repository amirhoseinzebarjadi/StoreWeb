using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Marina_Club.Repositories.SellerManager
{
    public interface ISellerManagerRepository
    {
        /// <summary>
        /// Get Sellers
        /// </summary>
        /// <returns></returns>
        Task<Model.SellerManager> GetSellerManagerAsync(Guid SellerManagerId);

        //Task<SellerInfo> GetSellerInfoAsync();
        //Task<SellerAddress> GetAddressSellerAsync();
        /// <summary>
        /// Add Sellers
        /// </summary>
        /// <param name="sellerManager"></param>
        /// <returns></returns>
        Task<bool> AddSellerManagerAsync(Model.SellerManager sellerManager);

        /// <summary>
        /// UpdateSeller
        /// </summary>
        /// <param name="DiscountSeller"></param>
        /// <param name="SellerCode"></param>
        /// <returns></returns>
        Task<Model.SellerManager> GetSellerManagerForUpdateAsync(Guid SellerManagerId);

        Task<bool> UpdateSellerManagerAsync();

        /// <summary>
        /// Seller Manager Dto
        /// </summary>
        /// <param name="SearchWordSeller"></param>
        /// <param name="SearchWordCityNameSeller"></param>
        /// <returns></returns>
        Task <List<Model.SellerManager>> GetSellerManagerDtoAsync(int PageSize, int PageNumber);

        /// <summary>
        /// search
        /// </summary>
        /// <param name="SearchWordSeller"></param>
        /// <param name="SearchWordCityNameSeller"></param>
        /// <param name="PageSize"></param>
        /// <param name="PageNumber"></param>
        /// <returns></returns>
        Task<List<Model.SellerManager>> GetSellerManagersDtoAsync();

       
    }
}
