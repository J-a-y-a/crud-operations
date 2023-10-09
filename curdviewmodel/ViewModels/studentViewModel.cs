using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

namespace curdviewmodel.ViewModels
{
    public class studentViewModel
    {
        public int? ID { get; set; }
        //[Remote("IsUserExists", "Studentdetails1", ErrorMessage = "Sid already in exists")]
        //[StringLength(5)]
        //[Required]
       // [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key()]
        public string Sid {get; set; }
       // [DataType(DataType.Text)]
       // [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Only Alphanumerics allowed.")]
        [StringLength(30)]
        [Required]
        public string Sname { get; set; }


        //[RegularExpression("^[0-9]*$", ErrorMessage = "should allow only numerics")]
        //[AdultAgeValidation]
       // [StringLength(3),MinLength(1)]
        //[MinValue(18)]
       // [Range(18,100)]
        public string Age { get; set; }
        public string Adress { get; set; }
        [StringLength(10)]
        public string classes { get; set; }
        [DataType(DataType.Text)]
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Only Alphanumerics allowed.")]
        [StringLength(30)]
        public string Fname { get; set; }
        [DataType(DataType.PhoneNumber)]
        //[RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Invalid Phone number")]
        //[StringLength(10)]
        public string Phno { get; set; }
        //[RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Email is not valid.")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "gmail required")]
        public string Gmail { get; set; }
       // [RegularExpression("^[0-9]*$", ErrorMessage = "should allow only numerics")]
        //[StringLength(6)]
        [Required(ErrorMessage="pincode required")]
        public string Pincode { get; set; }

    }
}