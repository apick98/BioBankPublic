using System;
namespace BioBank.Models
{
    public class Collection
    {
        public int ID { get; set; }
        public required string DiseaseTerm { get; set; }
        public required string Title { get; set; }

        public ICollection<Sample> Samples { get; set; }
    }
}