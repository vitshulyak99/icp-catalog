using System;

namespace Collections.Models.Item
{
    public class TagModel
    {

        private static readonly string[] _badgeStyleClasses =
        {
            "badge-primary",
            "badge-secondary",
            "badge-info",
            "badge-danger",
            "badge-succes",
        };
        public static string RandomBadgeStyleClass => _badgeStyleClasses[new Random().Next(0, _badgeStyleClasses.Length - 1)];
        public int Id { get; set; }
        public string Name { get; set; }
        public string Count { get; set; }
    }
}
