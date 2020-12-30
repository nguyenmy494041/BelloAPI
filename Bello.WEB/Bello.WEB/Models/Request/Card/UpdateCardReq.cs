using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bello.WEB.Models.Request.Card
{
    public class UpdateCardReq
    {
        public int CardId { get; set; }
        public string CardName { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public string ModifiedBy { get; set; }
        public int Priority { get; set; }
    }
}
