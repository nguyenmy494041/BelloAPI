using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bello.WEB.Models.Request.List
{
    public class ChangeStatusReq
    {
        public int ListId { get; set; }
        public int Status { get; set; }
    }
}
