using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using csharpbelt.Models;
 
namespace csharpbelt.Models
{
    public class Userrecord : BaseEntity
    {
        [Key]
        public int UserId {get; set;}
        public string FirstName {get; set;}
        public string LastName {get; set;}
        public string Username {get; set;}
        public string Password {get; set;}
         public double Wallet {get; set;}
        // public DateTime Createdat {get;set;}
        // public DateTime Updatedat {get;set;}
        
        public List<Bid> Bid {get; set;}
        // public List<AuctionObj> CreatedAuctionObjs {get; set;}
        
        public Userrecord(){
           Wallet = 1000.00;
        Bid = new List<Bid>();
        // CreatedAuctionObjs = new List<AuctionObj>();
        }

    }
}