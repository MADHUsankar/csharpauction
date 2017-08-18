using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace csharpbelt.Models{
    public class AuctionObj : BaseEntity{
        public int AuctionObjId {get; set;}
        public string Name {get; set;}     
        public string Description {get; set;}      
        public double StartingBid {get; set;}        
        public DateTime EndDate {get; set;}
        
        public int UserId {get; set;}
        public Userrecord CreatedBy {get; set;}

        public List<Bid> Bids {get; set;}

        public AuctionObj(){
            Bids = new List<Bid>();
        }

    }
}