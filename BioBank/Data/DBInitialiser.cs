using System;
using System.Diagnostics;
using BioBank.Models;

namespace BioBank.Data
{
    public static class DbInitialiser
    {
        public static void Initialise(BioBankContext context)
        {
            // Look for any collections.
            if (context.Collections.Any())
            {
                return;   // DB has been seeded
            }

            var collections = new Collection[]
            {
                new Collection{DiseaseTerm="Cirrhosis of liver",Title="Mothers Pregnancy Samples"},
                new Collection{DiseaseTerm="Malignant tumour of breast",Title="Phase II multicentre study"},
                new Collection{DiseaseTerm="Fit and well",Title="Lymphoblastoid cell lines"},
                new Collection{DiseaseTerm="Chronic fatigue syndrome",Title="Samples available include ME/CFS Cases"},
                new Collection{DiseaseTerm="Malignant tumour of breast",Title="A randomised placebo-controlled trial"}
            };

            context.Collections.AddRange(collections);
            context.SaveChanges();

            var samples = new Sample[]
            {
                new Sample{CollectionID=4,DonorCount=90210,MaterialType="Cerebrospinal fluid",LastUpdated=DateTime.Parse("2019-06-03")},
                new Sample{CollectionID=2,DonorCount=512,MaterialType="Cerebrospinal fluid",LastUpdated=DateTime.Parse("2019-03-08")},
                new Sample{CollectionID=2,DonorCount=7777,MaterialType="Core biopsy",LastUpdated=DateTime.Parse("2019-05-04")}
            };

            context.Samples.AddRange(samples);
            context.SaveChanges();
        }
    }
}