using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace donationInformation
{
    public class donationInfo
    {
        public int id { get; set; }
        public int Donor_id { get; set; }

        public string receptorName { get; set; }

        public readonly DateTime regDate;
        public donationInfo()
        {
            id = 0;
            regDate = DateTime.UtcNow.Date;
        }
    }
}
