using System.Linq;
using Collections.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Collections.DAL.Expressions
{
    public static class FullTextSearchExtension
    {
        public static IQueryable<Tag> FullText(this IQueryable<Tag> self, string like) =>
            self.Where(x => EF.Functions.ToTsVector("english", x.Name).Matches(like));
        public static IQueryable<Item> FullText(this IQueryable<Item> self, string like) =>
            self.Where(x => EF.Functions.ToTsVector("english", x.Name).Matches(like));
        public static IQueryable<Collection> FullText(this IQueryable<Collection> self, string like) =>
            self.Where(x => EF.Functions.ToTsVector("english", x.Description + " " + x.Title).Matches(like)); 
        public static IQueryable<FieldValue> FullText(this IQueryable<FieldValue> self, string like) =>
            self.Where(x => EF.Functions.ToTsVector("english", x.Value).Matches(like));
        public static IQueryable<Comment> FullText(this IQueryable<Comment> self, string like) =>
            self.Where(x => EF.Functions.ToTsVector("english", x.Text).Matches(like));
    }
} 