using System;
using System.Collections.Generic;
using System.Text;

namespace Bello.Domain.Request.Board
{
    public class ChangeStatusReq
    {
        public int BoardId { get; set; }
        public int Status { get; set; }
    }
}
