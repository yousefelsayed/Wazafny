using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace job_offer_website.Models
{
    public class Job
    {
        public int Id { get; set; }
        [DisplayName("اسم الوظيفه")]
        public string JobTitle { get; set; }
        [DisplayName("وصف الوظيفه")]
        public string JobContent { get; set; }
        [DisplayName("صوره الوظيفه")]
        public string JobImage { get; set; }
        [DisplayName("نوع الوظيفه")]
        public int CategoryId { get; set; }
        public string UserId { get; set; }
        public virtual Category Category { get; set; }
        public virtual ApplicationUser User { get; set; }

    }
}