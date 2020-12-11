using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bello.WEB.Models.Request.List
{
    public class SaveListReq
    {
        public int ListId { get; set; }
        public string ListName { get; set; }
        public int BoardId { get; set; }
    }
}
