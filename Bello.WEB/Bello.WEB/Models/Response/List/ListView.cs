using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bello.WEB.Models.Response.List
{
    public class ListView
    {
        public int ListId { get; set; }
        public string ListName { get; set; }
        public int BoardId { get; set; }
        public int Position { get; set; }
        public int Status { get; set; }
    }
}
