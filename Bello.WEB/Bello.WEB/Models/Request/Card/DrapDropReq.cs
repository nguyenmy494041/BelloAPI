using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bello.WEB.Models.Request.Card
{
    public class DrapDropReq
    {
        public int CardId { get; set; }
        public int ListIdAfter { get; set; }
        public int PositionNew { get; set; }

    }
}
