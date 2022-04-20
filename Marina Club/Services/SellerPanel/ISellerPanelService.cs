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

namespace Marina_Club.Services.SellerPanel
{
    public interface ISellerPanelService
    {
        Task<Model.Ticket> GetSellerPanelAsync(Guid SellerPanelId);
        Task<Model.WaterFun> GetSellerReservationDtoAsync(GetOneDtoWaterFunInSellerPanel command);
        Task<List<Model.Ticket>> GetReservationSellerAsync(int PageSize, int PageNumber);
        Task<int> AddReservationSellerAsync(AddSellerTicketCommand command);
        Task<List<Model.Ticket>> GetSellerPanelDtoAsync(int PageSize, int PageNumber);
        Task<List<Model.Ticket>> GetSellerPanelsDtoAsync(int PageNumber, int PageSize, DateTime SearchWordDate, string SearchWordFunType);
        Task<bool> DeleteReservationAsync(DeleteReservationCommand command);
        Task<bool> UpdateTicketPanelAsync(UpdateTicketCommand command);
    }
}
