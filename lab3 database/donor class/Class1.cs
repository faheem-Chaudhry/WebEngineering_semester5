using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace donor_class
{
    public class Donor
    {
        public int id { get; set; }

        public string donorName { get; set; }
        public string donorBloodGrp {  get; set; }
        public string isBloodDonted { get; set; }
        public int donorAge { get; set; }
        public string phoneNo { get; set; }
        public string Email { get; set; }

        public readonly DateTime regDate;
        public Donor()
        {
            id = 0;
            regDate = DateTime.UtcNow.Date;
        }

    }
}
