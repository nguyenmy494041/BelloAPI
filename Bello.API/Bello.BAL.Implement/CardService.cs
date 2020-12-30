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

        public async Task<SaveCardRes> ChangeStatus(int cardId, int status, string userId)
        {
            return await CardRepository.ChangeStatus(cardId, status, userId);
        }

        public async Task<SaveCardRes> CompleteCard(int cardId, string userId)
        {
            return await CardRepository.CompleteCard(cardId, userId);
        }

        public async Task<SaveCardRes> Create(SaveCardReq saveCardReq)
        {
            return await CardRepository.Create(saveCardReq);
        }

        public async Task<SaveCardRes> DrapDropCard(DrapDropReq drapDropReq)
        {
            return await CardRepository.DrapDropCard(drapDropReq);
        }

        public async Task<CardView> Get(int cardId)
        {

            return await CardRepository.Get(cardId);
        }

        public async Task<IEnumerable<CardView>> GetCardSaved(int BoardId)
        {
            return await CardRepository.GetCardSaved(BoardId);
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

        public async Task<SaveCardRes> Update(UpdateCardReq updateCardReq)
        {
            return await CardRepository.Update(updateCardReq);
        }

        public async Task<SaveCardRes> UpdateName(UpdateName updateName)
        {
            return await CardRepository.UpdateName(updateName);
        }
    }
}
