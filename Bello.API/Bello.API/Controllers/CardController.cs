using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bello.BAL.Interface;
using Bello.Domain.Response.Card;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bello.API.Controllers
{
    [ApiController]
    public class CardController : ControllerBase
    {
        private readonly ICardService CardService;

        public CardController(ICardService CardService)
        {
            this.CardService = CardService;
        }

        [HttpGet("api/card/gets/{listId}")]
        public async Task<OkObjectResult> GetsCard(int listId)
        {
            var cards = await CardService.Gets(listId);
            return Ok(cards);
        }
        [HttpGet("api/card/get/{id}")]
        public async Task<OkObjectResult> GetCard(int id)
        {
            var Card = await CardService.Get(id);
            if (Card.CardId == 0)
                return Ok(new SaveCardRes()
                {
                    CardId = 0,
                    Message = "Something went wrong, please try again later!"
                });
            return Ok(Card);
        }
        [HttpPost("api/card/changestatus/{cardId}/{status}")]
        public async Task<OkObjectResult> ChangeStatus(int cardId, int status)
        {
            var result = await CardService.ChangeStatus(cardId, status);
            return Ok(result);
        }
        [HttpPost("api/card/complete/{cardId}")]
        public async Task<OkObjectResult> Complete(int cardId)
        {
            var result = await CardService.CompleteCard(cardId);
            return Ok(result);
        }
    }
}
