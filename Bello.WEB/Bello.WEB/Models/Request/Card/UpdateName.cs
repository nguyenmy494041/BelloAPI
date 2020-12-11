using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bello.WEB.Models.Request.Card
{
    public class UpdateName
    {
        public int CardId { get; set; }
        public string CardName { get; set; }
        public string UserId { get; set; }

    }
}
