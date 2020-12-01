using System;
using System.Collections.Generic;
using System.Text;

namespace Bello.Domain.Request.Card
{
    public class UpdateCardReq
    {
        public int CardId { get; set; }
        public string CardName { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public int ListId { get; set; }
        public int Priority { get; set; }
        public int ModifiedBy { get; set; }
    }
}
