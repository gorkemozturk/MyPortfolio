using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPortfolio.Models.ViewModels.Dashboard
{
    public class DashboardViewModel
    {
        public int DailyUsers { get; set; }
        public int DailyContacts { get; set; }
        public IEnumerable<Contact> Contacts { get; set; }
    }
}
