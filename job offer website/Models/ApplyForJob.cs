﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace job_offer_website.Models
{
    public class ApplyForJob
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime ApplyDate { get; set; }
        public int JobId { get; set; }
        public string UserId { get; set; }
        public  virtual Job job { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}