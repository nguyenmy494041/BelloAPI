using System;
using System.Collections.Generic;
using System.Text;

namespace Bello.Domain.Request.Card
{
    public class SaveCardReq
    {
        public string CardName { get; set; }
        public int ListId { get; set; }
        public string CreateBy { get; set; }
    }
}
