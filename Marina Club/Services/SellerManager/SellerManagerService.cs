using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Marina_Club.Command.QueryCommand;
using Marina_Club.Command.SellerManagerCommand;
using Marina_Club.Command.TicketCommand;
using Marina_Club.Command.UpdateCommand;
using Marina_Club.Model;
using Marina_Club.Pagination;
using Marina_Club.Repositories.SellerManager;
namespace Marina_Club.Services.SellerManager
{
    public class SellerManagerService : ISellerManagerService
    {
        private readonly ISellerManagerRepository _sellerManagerRepository;
        public SellerManagerService(ISellerManagerRepository sellerManagerRepository)
        {
            _sellerManagerRepository = sellerManagerRepository;
        }

        #region Seller Manager

        /// <summary>
        /// Get Seller
        /// </summary>
        /// <returns></returns>
        public async Task<Model.SellerManager> GetSellerManagerAsync(Guid SellerManagerId)
        {
            var result = await _sellerManagerRepository.GetSellerManagerAsync(SellerManagerId);
            return result;
        }
        //public async Task<SellerInfo> GetSellerInfoAsync()
        //{
        //    var result = await _sellerManagerRepository.GetSellerInfoAsync();
        //    return result;
        //}
        //public async Task<SellerAddress> GetAddressSellerAsync()
        //{
        //    var result = await _sellerManagerRepository.GetAddressSellerAsync();
        //    return result;
        //}
        /// <summary>
        /// Add Seller
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public async Task<bool> AddSellerManagerAsync(SellerCommand command)
        {
            var sellerManager = new Model.SellerManager()
            {
                DiscountSeller = command.DiscountSeller,
                SellerCode = command.SellerCode,
                SellerInfo = ToDto7(command.SellerInfoCommand),
                SellerAddress = ToDto8(command.SellerAddressCommand)
            };

            var result = await _sellerManagerRepository.AddSellerManagerAsync(sellerManager);
            return result;
        }

        /// <summary>
        /// Update Seller
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public async Task<bool> UpdateSellerManagerAsync(UpdateSellerManagerCommand command)
        {
            var SellerManager = await _sellerManagerRepository.GetSellerManagerForUpdateAsync(command.SellerManagerId);
            SellerManager.DiscountSeller = command.NewDiscountSeller;
            SellerManager.SellerCode = command.NewSellerCode;
            SellerManager.SellerInfo = ToDto10(command.UpdateSellerInfoCommand);
            SellerManager.SellerAddress = ToDto11(command.UpdateSellerAddressCommand);

            return await _sellerManagerRepository.UpdateSellerManagerAsync();

        }

        /// <summary>
        /// Seller Dto
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public async Task<List<Model.SellerManager>> GetSellerManagerDtoAsync(int PageNumber, int PageSize)
        {
            var result = await _sellerManagerRepository.GetSellerManagerDtoAsync(PageNumber,PageSize);
            return result;
        }

        /// <summary>
        /// Seller Dto Search
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public async Task<List<Model.SellerManager>> GetSellerManagersDtoAsync(int PageNumber, int PageSize, string SearchWordSeller)
        {
            var sellers = await _sellerManagerRepository.GetSellerManagersDtoAsync(/*command.SearchWordSeller, command.PageSize, command.PageNumber*/);
            var result = new List<Model.SellerManager>();
            if (!string.IsNullOrEmpty(SearchWordSeller))
            {
                var serchNationalCode = sellers.Where(q => q.SellerInfo.NationalCodeSeller.Contains(SearchWordSeller)).ToList();
                var serchName = sellers.Where(s =>s.SellerInfo.FirstNameAndLastNameSeller.Contains(SearchWordSeller)).ToList();
                result.AddRange(serchName);
                result.AddRange(serchNationalCode);
            }
            var results = result.GroupBy(x => x.SellerManagerId)
                .Select(g => g.First())
                .Skip((PageNumber - 1) * PageSize)
                .Take(PageSize).ToList();
            return results;
        }
        #endregion


        #region MyMethod
        private SellerInfo ToDto7(SellerInfoCommand commands)
        {
            return new SellerInfo()
            {
                FirstNameAndLastNameSeller = commands.FirstNameAndLastName,
                CompanyName = commands.CompanyNameSeller,
                SellerEmail = commands.Email,
                NationalCodeSeller = commands.NationalCode,
                PhoneNumberSeller = commands.PhoneNumber,
                CellPhoneNumberseller = commands.CellPhoneNumber,
                CardNumberSeller = commands.CardNumber,
            };
        }
        private SellerAddress ToDto8(SellerAddressCommand commands)

        {
            return new SellerAddress()
            {
                CityNameSeller = commands.CityName,
                CompanyAddress = commands.Address,
                PostalCodeSeller = commands.PostalCode
            };
        }
        private SellerInfo ToDto10(UpdateSellerInfoCommand commands)
        {
            return new SellerInfo()
            {
                FirstNameAndLastNameSeller = commands.NewFirstNameAndLastNameSeller,
                CompanyName = commands.NewCompanyName,
                SellerEmail = commands.NewSellerEmail,
                NationalCodeSeller = commands.NewNationalCodeSeller,
                PhoneNumberSeller = commands.NewPhoneNumberSeller,
                CellPhoneNumberseller = commands.NewCellPhoneNumberSeller,
                CardNumberSeller = commands.NewCardNumberSeller,
            };
        }
        private SellerAddress ToDto11(UpdateSellerAddressCommand commands)
        {
            return new SellerAddress()
            {
                CityNameSeller = commands.NewCityNameSeller,
                CompanyAddress = commands.NewCompanyAddress,
                PostalCodeSeller = commands.NewPostalCodeSeller
            };
        }
        #endregion
    }
}
