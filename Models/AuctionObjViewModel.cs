using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace csharpbelt.Models{
    public class AuctionObjViewModel : BaseEntity{
        public int AuctionObjId {get; set;}

        [Required]
        [MinLength(3)]
        public string Name {get; set;}


        [Required]
        [MinLength(10)]
        public string Description {get; set;}

        [Required]
        // must be > 0
        public int StartingBid {get; set;}

        [Required]
        // must be in the future
        public DateTime EndDate {get; set;}


        

    }
}