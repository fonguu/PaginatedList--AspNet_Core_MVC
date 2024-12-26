using System;
using System.ComponentModel.DataAnnotations;
namespace ListExample.Models.ViewModels
{
    public class OrderIndexViewModel
    {
        [Display(Name = "訂單編號")]

        public string Number { get; set; }
        [Display(Name = "寄送日期")]

        public DateTime ShippingDate { get; set; }
        [Display(Name = "寄送地址")]

        public string ShippingAddress { get; set; }
        [Display(Name = "客戶簽收")]

        public string CustomerSignature { get; set; }
        [Display(Name = "客戶編號")]

        public string CustomerNumber { get; set; }
        [Display(Name = "總額")]

        public decimal Total { get; set; }
        [Display(Name = "客戶名稱")]

        public string CustomerName { get; set; }
        [Display(Name = "客戶電話")]

        public string CustomerTel { get; set; }

    }
}
