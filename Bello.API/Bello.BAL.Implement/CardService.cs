using Bello.BAL.Interface;
using Bello.DAL.Interface;
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

        public async Task<SaveCardRes> ChangeStatus(int cardId, int status)
        {
            return await CardRepository.ChangeStatus(cardId, status);
        }

        public async Task<SaveCardRes> CompleteCard(int cardId)
        {
            return await CardRepository.CompleteCard(cardId);
        }

        public async Task<CardView> Get(int cardId)
        {

            return await CardRepository.Get(cardId);
        }

        public async Task<IEnumerable<CardView>> Gets()
        {
            return await CardRepository.Gets();
        }
       
    }
}
