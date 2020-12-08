using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bello.WEB.Models.Request.Board
{
    public class SaveBoardReq
    {
        public int BoardId { get; set; }
        public string BoardName { get; set; }
    }
}
