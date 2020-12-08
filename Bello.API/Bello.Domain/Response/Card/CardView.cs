using System;
using System.Collections.Generic;
using System.Text;

namespace Bello.Domain.Response.Card
{
    public class CardView
    {
        public int CardId { get; set; }
        public string CardName { get; set; }
        public string Description { get; set; }
        public int Position { get; set; }
        public DateTime DueDate { get; set; }
        public string DueDateStr { get; set; }

        public int ListId { get; set; }
        public int Priority { get; set; }
        public int Status { get; set; }
        public bool IsDone { get; set; }
        public string DueDateStr { get; set; }

    }
}
