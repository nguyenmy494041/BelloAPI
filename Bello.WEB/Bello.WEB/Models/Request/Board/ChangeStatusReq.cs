using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bello.WEB.Models.Request.Board
{
    public class ChangeStatusReq
    {
        public int BoardId { get; set; }
        public int Status { get; set; }
    }
}
