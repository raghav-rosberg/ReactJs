using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleWebApi.Model.Entities
{
    public class LocalUser
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("User Name")]
        public string UserName { get; set; }
        public string Designation { get; set; }

        [Required]
        [DisplayName("Email Id")]
        public string EmailId { get; set; }

        [Required]
        [DisplayName("Mobile Number")]
        public string MobileNo { get; set; }
    }
}
