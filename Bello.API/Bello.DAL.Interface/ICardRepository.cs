
using Bello.Domain.Request.Card;
using Bello.Domain.Response.Card;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bello.DAL.Interface
{
    public interface ICardRepository
    {
        Task<IEnumerable<CardView>> Gets(int ListId);
        Task<CardView> Get(int cardId);
        Task<SaveCardRes> ChangeStatus(int cardId, int status);
        Task<SaveCardRes> CompleteCard(int cardId);
        Task<SaveCardRes> Create(SaveCardReq saveCardReq);
        Task<SaveCardRes> Update(UpdateCardReq updateCardReq);
        Task<SaveCardRes> DrapDropCard(DrapDropReq drapDropReq);
        Task<SaveCardRes> UpdateName(UpdateName updateName);
        Task<IEnumerable<CardView>> OrderByName(int ListId);
        Task<IEnumerable<CardView>> OrderByDueDate(int ListId);
        Task<IEnumerable<CardView>> GetCardSaved();
    }
}
