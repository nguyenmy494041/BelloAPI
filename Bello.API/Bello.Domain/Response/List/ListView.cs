using System;
using System.Collections.Generic;
using System.Text;

namespace Bello.Domain.Response.List
{
    public class ListView
    {
        public int ListId { get; set; }
        public string ListName { get; set; }
        public  int BoardId  { get; set; }
        public  int Position  { get; set; }
        public  int Status  { get; set; }
    }
}
