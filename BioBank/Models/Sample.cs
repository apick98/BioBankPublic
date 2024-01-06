using System;
namespace BioBank.Models
{
    public class Sample
    {
        public int SampleID { get; set; }
        public int CollectionID { get; set; }
        public int DonorCount { get; set; }
        public required string MaterialType { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}