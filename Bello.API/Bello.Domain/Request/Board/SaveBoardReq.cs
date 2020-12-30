using System;
using System.Collections.Generic;
using System.Text;

namespace Bello.Domain.Request.Board
{
    public class SaveBoardReq
    {
        public int BoardId { get; set; }
        public string BoardName { get; set; }
        public string UserId { get; set; }
    }
}
