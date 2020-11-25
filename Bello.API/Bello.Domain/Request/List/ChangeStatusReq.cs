using System;
using System.Collections.Generic;
using System.Text;

namespace Bello.Domain.Request.List
{
    public class ChangeStatusReq
    {
        public int ListId { get; set; }
        public int Status { get; set; }
    }
}
