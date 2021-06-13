using System;

namespace fengshui.Entity.Models
{
    public class MobileNumber
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public string ServiceProvider { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
    }
}
