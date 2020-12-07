using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bello.WEB.Models.Response.Board
{
    public class BoardView
    {
        public int BoardId { get; set; }
        public string BoardName { get; set; }
        public int Status { get; set; }
    }
}
