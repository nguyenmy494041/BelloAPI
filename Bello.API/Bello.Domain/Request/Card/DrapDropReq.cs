using System;
using System.Collections.Generic;
using System.Text;

namespace Bello.Domain.Request.Card
{
    public class DrapDropReq
    {
        public int CardId { get; set; }
        public int ListIdAfter { get; set; }
        public int PositionNew { get; set; }

    }
}
