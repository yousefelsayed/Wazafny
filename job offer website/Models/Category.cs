using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace job_offer_website.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("نوع الوظيفه")]
        public string CategoryName { get; set; }
        [Required]
        [DisplayName("وصف الوظيفه")]
        public string CategoryDescription { get; set; }
        public virtual ICollection<Job> Jobs { get; set; }
    }
}