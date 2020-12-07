using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bello.WEB.Models.Request.Card
{
    public class SaveCardReq
    {
        public string CardName { get; set; }
        public int ListId { get; set; }
        public int CreateBy { get; set; }
    }
}
