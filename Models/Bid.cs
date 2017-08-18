using System;
namespace csharpbelt.Models{
    public class Bid : BaseEntity{
        public int BidId {get; set;}
        public double Amount {get; set;}
        public DateTime CreatedAt {get; set;}

        public int UserId {get; set;}
        public Userrecord Bidder {get; set;}

        public int AuctionObjId {get; set;}
        public AuctionObj Item {get; set;}
    }

}
