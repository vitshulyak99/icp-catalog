using System;
using Collections.DAL.Entities.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NpgsqlTypes;

namespace Collections.DAL.Entities
{
    public class Comment : BaseEntity
    {
        public DateTime Date { get; set; }
        public string Text { get; set; }
        public AppUser Sender { get; set; }
        public Item Item { get; set; }

        public NpgsqlTsVector SearchVector { get; set; }
    }
}