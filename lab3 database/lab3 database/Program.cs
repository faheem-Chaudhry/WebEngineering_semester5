using System;
using System.Collections.Generic;
using System.Linq;
using DonationRepository;
using DonationManagementSystem;
using Microsoft.Data.SqlClient;
using DonationManagementSystemAdminLogin;
using System.Data;

namespace MyApp // Note: actual namespace depends on the project name.
{
    public class Program
    {
        public static void Main(string[] args)
        {
            DataTable Donor = new DataTable();

            DataColumn IdColumn = new DataColumn();
            IdColumn.ColumnName = "Id";
            IdColumn.DataType = typeof(int);
            DataColumn NameColumn = new DataColumn("Name", typeof(string));
            DataColumn StdUniIdColumn = new DataColumn("BloodGrp", typeof(string));






            IdColumn.AutoIncrement = true;
            IdColumn.AutoIncrementSeed = 1;
            IdColumn.AutoIncrementStep = 1;



            Donor.Columns.Add(IdColumn);
            Donor.Columns.Add(NameColumn);
            Donor.Columns.Add(StdUniIdColumn);



            Donor.PrimaryKey = new DataColumn[] { IdColumn };


            DataSet ds = new DataSet();
            ds.Tables.Add(Donor);





            //Adding some data






            DataRow r3 = Donor.NewRow();
            r3["Name"] = "Ali";
            r3["BloodGrp"] = "A-";

            DataRow r4 = Donor.NewRow();
            r4["Name"] = "Ali 123";
            r4["BloodGrp"] = "AB+";


            Donor.Rows.Add(r3);
            Donor.Rows.Add(r4);


            foreach (DataRow row in Donor.Rows)
            {


                Console.WriteLine("University Id : " + row[0]);
                Console.WriteLine("University Name : " + row[1]);
                Console.WriteLine("Blood grp : " + row[2]);



            }
            AdminLogin adminLogin = new AdminLogin();

            

            if (adminLogin.admin() == true)
            {
                donationManagementSys donationManagementSys = new donationManagementSys();

                donationManagementSys.displayMenu();
            }
            else
            {
                Console.WriteLine("You enter wrong password");
            }



           

        }
    }
}