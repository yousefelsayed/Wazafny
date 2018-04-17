using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace job_offer_website.Models
{
    public class JobsViewModel
    {
        public string JobTitle { get; set; }
        public IEnumerable<ApplyForJob> Items { get; set; }
    }
}