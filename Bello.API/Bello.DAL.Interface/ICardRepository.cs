using Bello.Domain.Response.Card;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bello.DAL.Interface
{
    public interface ICardRepository
    {
        Task<IEnumerable<CardView>> Gets(int listId);
        Task<CardView> Get(int cardId);
        Task<SaveCardRes> ChangeStatus(int cardId, int status);
        Task<SaveCardRes> CompleteCard(int cardId);
    }
}
