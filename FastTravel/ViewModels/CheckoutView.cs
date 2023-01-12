using FastTravel.Models;

namespace FastTravel.ViewModels
{
    public class CheckoutView
    {
        public Package package { get; set; }

        public int creditID { get; set; }
        public int fullName { get; set; }
        public int creditNum { get; set; }
        public string expiredDate { get; set; }
        public int expiredYear { get; set; }
        public int securityCode { get; set; }
        public int userID { get; set; }

        public bool saveCredit { get; set; }
        public int ticketCount { get; set; }
    }
}
