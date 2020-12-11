using System;
using System.Collections.Generic;
using System.Text;

namespace Bello.Domain.Request.List
{
    public class SaveListReq
    {
        public int ListId { get; set; }
        public string ListName { get; set; }
        public int BoardId { get; set; }
        public string UserId { get; set; }
    }
}
