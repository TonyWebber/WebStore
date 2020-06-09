using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.Data.Models
{
    public class Order
    {
        [BindNever]
        public int Id { get; set; }
        [Display(Name = "Enter Your name")]
        [StringLength(25)]
        [Required(ErrorMessage = "Enter real name. Thanks.")]
        public string Name { get; set; }
        [Display(Name = "Enter Your surname")]
        [StringLength(25)]
        [Required(ErrorMessage = "Enter real surname. Thanks.")]
        public string Surname { get; set; }
        [Display(Name = "Enter Your address")]
        [StringLength(25)]
        [Required(ErrorMessage = "Enter real address. Thanks.")]
        public string Address { get; set; }
        [Display(Name = "Enter Your phone")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(12)]
        [Required(ErrorMessage = "Enter real phone number. Thanks.")]
        public string Phone { get; set; }
        [Display(Name = "Enter Your E-mail")]
        [DataType(DataType.EmailAddress)]
        [StringLength(12)]
        [Required(ErrorMessage = "Enter real E-mail. Thanks.")]
        public string Email { get; set; }
        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime OrderTime { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }

    }
}
