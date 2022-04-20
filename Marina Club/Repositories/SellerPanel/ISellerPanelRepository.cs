using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Marina_Club.Command.TicketCommand;
using Marina_Club.Model;

namespace Marina_Club.Repositories.SellerPanel
{
   public interface ISellerPanelRepository
    {
        //ReservationDto
        Task<Model.Ticket> GetSellerPanelAsync(Guid SellerPanelId);
        Task<Model.WaterFun> GetSellerReservationDtoAsync(Guid Id);

        Task<List<Model.Ticket>> GetReservationSellerAsync(int PageNumber,int PageSize);

        void AddReservationSellerAsync(Model.Ticket ticket);
        
        Task<Model.Ticket> GetReservationForDelete(Guid ReservSellerId);

        /// <summary>
        /// Seller Manager Dto
        /// </summary>
        /// <returns></returns>
        Task<List<Model.Ticket>> GetSellerPanelDtoAsync(int PageSize, int PageNumber);

        /// <summary>
        /// search
        /// </summary>
        /// <returns></returns>
        Task<List<Model.Ticket>> GetSellerPanelsDtoAsync();

        Task<bool> DeleteReservationAsync(Model.Ticket reservationSellerInfo);
        
        //Task<List<Model.ReservationSellerInfo>> GetSellerMyReservDtoAsync(string FunTypeSearchMyReservationSeller, DateTime DateSearchSansMyReservationSeller);

        Task <Model.WaterFun> OneGetWaterFunAsync(Guid waterFunId);

        Task <Model.Sans> OneGetSansAsync(Guid sansId);
        //
        Task<int> UpdateSoldTicketAsync();
        Task<Model.Ticket> GetTicketPanelForUpdateAsync(Guid TicketId);
        Task<bool> UpdateTicketPanelAsync();
    }
}
