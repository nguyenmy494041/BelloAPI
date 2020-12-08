﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bello.BAL.Interface;
using Bello.Domain.Request.Card;
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

        [HttpGet("api/card/gets/{ListId}")]
        public async Task<OkObjectResult> GetsCard(int ListId)
        {
            var cards = await CardService.Gets(ListId);
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
        [HttpPost("api/card/save")]
        public async Task<OkObjectResult> Save(SaveCardReq saveCardReq)
        {
            var result = await CardService.Create(saveCardReq);
            return Ok(result);
        }
        [HttpPatch("api/card/update")]
        public async Task<OkObjectResult> Update(UpdateCardReq updateCardReq)
        {
            var result = await CardService.Update(updateCardReq);
            return Ok(result);
        }
        [HttpPost("api/card/drapdrop")]
        public async Task<OkObjectResult> DrapDrop(DrapDropReq drapDropReq)
        {
            var result = await CardService.DrapDropCard(drapDropReq);
            return Ok(result);
        }
        [HttpPatch("api/card/updatename")]
        public async Task<OkObjectResult> UpdateName(UpdateName updateName)
        {
            var result = await CardService.UpdateName(updateName);
            return Ok(result);
        }
    }
}
