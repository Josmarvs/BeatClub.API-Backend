﻿using System;
using System.Collections.Generic;

namespace BeatClub.API.BeatClub.Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        
        public string Nickname {get; set; }
        
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        
        public string UrlToImage { get; set; }
        public string TypeUser { get; set; }

        public string Trend { get; set; }
        
        public string Result { get; set; }
        
        public DateTime CreateAt { get; set; }
        
        //Relationships
        public int MembershipId { get; set; }
        public Membership Membership { get; set; }
        
    }
}