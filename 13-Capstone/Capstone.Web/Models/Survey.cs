using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class Survey
    {
        public int SurveyId { get; set; }

        [Required]
        public string ParkCode { get; set; }

        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string ActivityLevel { get; set; }

        public List<Park> ParkList { get; set; }

        public int SurveyCount { get; set; }
    }
}
