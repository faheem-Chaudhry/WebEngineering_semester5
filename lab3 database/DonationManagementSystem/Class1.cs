using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DonationRepository;

namespace DonationManagementSystem
{
    public class donationManagementSys
    {
        donationRepository donationRepository = new donationRepository();
        public void displayMenu()
        {
            Console.WriteLine("--------------Welcome to BDS----------");
            Console.WriteLine("1.  Add Donor");
            Console.WriteLine("2.  Delete employee");
            Console.WriteLine("3.  Update employee");
            Console.WriteLine("4.  Display AllDonors");
            Console.WriteLine("5.  Search Donor");
            int day;
            int id;
            char c;

            do
            {
                Console.WriteLine("Enter value :");
                day = Convert.ToInt32(Console.ReadLine());
                switch (day)
                {
                    case 1:
                        Console.WriteLine("------- Add Donor ---------");
                        donationRepository.addNewDonor();
                        break;

                    case 2:
                        Console.WriteLine("Enter id to delete donor : ");
                        id = Convert.ToInt32(Console.ReadLine());
                        donationRepository.deleteDonor(id);
                        break;

                    case 3:
                        Console.WriteLine("Enter id to update donor : ");
                        id = Convert.ToInt32(Console.ReadLine());
                        donationRepository.UpdateDonor(id);
                        break;

                    case 4:
                        donationRepository.displayDonorInfo();                       
                        break;
                    case 5:

                        donationRepository.searchDonor();
                        break;
                }
                Console.WriteLine("Enter Y or y if you want to quit otherwise enter any key to continue :");
                c = char.Parse(Console.ReadLine());
                if (c == 'y' || c == 'Y')
                {
                    break;
                }
            } while (true);
        }
    }
}
