using Bello.BAL.Interface;
using Bello.DAL.Interface;
using Bello.Domain.Request.Card;
using Bello.Domain.Response.Card;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bello.BAL.Implement
{
    public class CardService : ICardService
    {
        private readonly ICardRepository CardRepository;
        public CardService(ICardRepository CardRepository)
        {
            this.CardRepository = CardRepository;
        }

        public async Task<SaveCardRes> ChangeStatus(int cardId, int status,string userid)
        {
            return await CardRepository.ChangeStatus(cardId, status,userid);
        }

        public async Task<SaveCardRes> CompleteCard(int cardId,string userid)
        {
            return await CardRepository.CompleteCard(cardId,userid);
        }

        public async Task<SaveCardRes> Create(SaveCardReq saveCardReq,string userid)
        {
            return await CardRepository.Create(saveCardReq,userid);
        }

        public async Task<SaveCardRes> DrapDropCard(DrapDropReq drapDropReq)
        {
            return await CardRepository.DrapDropCard(drapDropReq);
        }

        public async Task<CardView> Get(int cardId)
        {

            return await CardRepository.Get(cardId);
        }

        public async Task<IEnumerable<CardView>> GetCardSaved()
        {
            return await CardRepository.GetCardSaved();
        }

        public async Task<IEnumerable<CardView>> Gets(int ListId)
        {
            return await CardRepository.Gets(ListId);
        }

        public async Task<IEnumerable<CardView>> OrderByDueDate(int ListId)
        {
            return await CardRepository.OrderByDueDate(ListId);
        }

        public async Task<IEnumerable<CardView>> OrderByName(int ListId)
        {
            return await CardRepository.OrderByName(ListId);
        }

        public async Task<SaveCardRes> Update(UpdateCardReq updateCardReq,string userid)
        {
            return await CardRepository.Update(updateCardReq,userid);
        }

        public async Task<SaveCardRes> UpdateName(UpdateName updateName,string userid)
        {
            return await CardRepository.UpdateName(updateName,userid);
        }
    }
}
