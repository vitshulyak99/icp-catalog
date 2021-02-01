using System;
using Collections.Models.Collection;
using Collections.Models.Item;

namespace Collections.Models
{
    public class HomeIndexViewModel
    {
       
        public TagModel[] Tags { get; set; } = Array.Empty<TagModel>();
        public ItemViewModel[] LastItems { get; set; } = Array.Empty<ItemViewModel>();
        public CollectionSimpleModel[] TopCollections { get; set; } = Array.Empty<CollectionSimpleModel>();
    }
}