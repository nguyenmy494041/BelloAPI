using System;
using System.Collections.Generic;
using System.Text;

namespace Bello.Domain.Request.Card
{
    public class UpdateName
    {
        public int CardId { get; set; }
        public string CardName { get; set; }
        public int UserId { get; set; }
        
    }
}
