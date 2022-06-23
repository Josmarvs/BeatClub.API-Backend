﻿using System;

namespace BeatClub.API.BeatClub.Resources
{
    public class UserResource
    {
        public int Id { get; set; }
        public string Nickname { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string UrlToImage { get; set; }
        public string TypeUser { get; set; }
        public string Trend { get; set; }
        public string Result { get; set; }
        public int MembershipId { get; set; }
        public DateTime CreateAt { get; set; }
    }
}