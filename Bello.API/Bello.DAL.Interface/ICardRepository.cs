﻿
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
        Task<SaveCardRes> ChangeStatus(int cardId, int status,string userid);
        Task<SaveCardRes> CompleteCard(int cardId,string userid);
        Task<SaveCardRes> Create(SaveCardReq saveCardReq,string userid);
        Task<SaveCardRes> Update(UpdateCardReq updateCardReq,string userid);
        Task<SaveCardRes> DrapDropCard(DrapDropReq drapDropReq);
        Task<SaveCardRes> UpdateName(UpdateName updateName,string userid);
        Task<IEnumerable<CardView>> OrderByName(int ListId);
        Task<IEnumerable<CardView>> OrderByDueDate(int ListId);
        Task<IEnumerable<CardView>> GetCardSaved();
    }
}
