using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using donor_class;
using Microsoft.Data.SqlClient;

namespace DonationRepository
{
    public class donationRepository
    {
           
        
        public void addNewDonor()
        {
            
            
            string name;
            Console.WriteLine("enter name = ");
            name=Console.ReadLine();
            int age;
            Console.WriteLine("enter age = ");
            age =Convert.ToInt32(Console.ReadLine());
            string bloodgrp;
            Console.WriteLine("enter bloodgrp = ");
            bloodgrp =Console.ReadLine();
            Console.WriteLine("enter mobileNo = ");
            string No;
            No=Console.ReadLine();
            Console.WriteLine("enter email = ");
            string email;
            email = Console.ReadLine();
            Console.WriteLine("Is blood donated = ");
            string isdonated;
            isdonated = Console.ReadLine();
            Donor donor = new Donor()
            {
                donorName = name,
                donorBloodGrp = bloodgrp,
                donorAge = age,
                phoneNo = No,
                Email = email,
                isBloodDonted = isdonated                
            };
            string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BDS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            string query = $"Insert into [Table] (DonorName, DonorBloodGroup, DonorAge, isBloodDonated, DonorPhone, DonorEmail, RegisterationDate) values ('{donor.donorName}','{donor.donorBloodGrp}','{donor.donorAge}','{donor.isBloodDonted}','{donor.phoneNo}','{donor.Email}','{donor.regDate}')";
            SqlCommand cmd = new SqlCommand(query, con);
            int insertedRows = cmd.ExecuteNonQuery();
            if (insertedRows >= 1)
            {
                Console.WriteLine("row inserted");

            }
            else
            {
                Console.WriteLine("failed");

            }
            con.Close();
        }
        public void deleteDonor(int takeID)
        {
            string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BDS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            string query = $"delete from  [Table] where Id  = '{takeID}'";
            SqlCommand cmd = new SqlCommand(query, con);
            int insertedRows = cmd.ExecuteNonQuery();
            if (insertedRows >= 1)
            {
                Console.WriteLine("row deleted");

            }
            else
            {
                Console.WriteLine("The given id to delete is not in database");

            }
            con.Close();

        }
        public void UpdateDonor(int takeID)
        {
            string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BDS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            string query = $"select * from [Table]";
            SqlCommand cmd = new SqlCommand(query, con);

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (dr[0].ToString() == takeID.ToString())
                {
                    Console.WriteLine("Your required search for id is : ");
                    Console.WriteLine($"id : {dr.GetValue(0)}, Name: {dr[1]}, Blood Group: {dr[2]}, Age: {dr[3]}, Is blood donated: {dr[4]}, Donor PhoneNo: {dr[5]}, Donor Email: {dr[6]}, Reg.Date: {dr[7]}");
                }

            }
            con.Close();

            Console.WriteLine("Now enter the entities you want to update");
            Console.WriteLine("1.  Add updated Donor name");
            Console.WriteLine("2.  Add updated Donor age");
            Console.WriteLine("3.  Add updated Donor bloodGrp");
            int date;
            Console.WriteLine("Enter value : ");
            date=Convert.ToInt32(Console.ReadLine());
            
            con.Open();
            switch (date)
            {
                case 1:
                    string name;
                    Console.WriteLine("Enter updated name :");
                    name = Console.ReadLine();
                    string query1 = $"update [Table] set DonorName = '{name}' where Id  = '{takeID}'";
                    SqlCommand cmd1 = new SqlCommand(query1, con);
                    cmd1.ExecuteNonQuery();

                    break;

                case 2:
                    int age;
                    Console.WriteLine("Enter updated age :");
                    age = Convert.ToInt32(Console.ReadLine());
                    string query2 = $"update [Table] set DonorAge = '{age}' where Id  = '{takeID}'";
                    SqlCommand cmd2 = new SqlCommand(query2, con);
                    cmd2.ExecuteNonQuery();
                    break;

                case 3:
                    string bloodgp;
                    Console.WriteLine("Enter updated blood gp :");
                    bloodgp = Console.ReadLine();
                    string query3 = $"update [Table] set DonorBloodGroup = '{bloodgp}' where Id  = '{takeID}'";
                    SqlCommand cmd3 = new SqlCommand(query3, con);
                    int insertedRows = cmd3.ExecuteNonQuery();
                    break;
            }
            con.Close();

        }
        public void displayDonorInfo()
        {
            string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BDS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            string query = $"select * from [Table]";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Console.WriteLine($"id : {dr.GetValue(0)}, Name: {dr[1]}, Blood Group: {dr[2]}, Age: {dr[3]}, Is blood donated: {dr[4]}, Donor PhoneNo: {dr[5]}, Donor Email: {dr[6]}, Reg.Date: {dr[7]}");
            }
            con.Close();
        }
        public void searchDonor()
        {
            string name;
            Console.WriteLine("enter name = ");
            name = Console.ReadLine();
            int age;
            Console.WriteLine("enter age = ");
            age = Convert.ToInt32(Console.ReadLine());
            string bloodgrp;
            Console.WriteLine("enter bloodgrp = ");
            bloodgrp = Console.ReadLine();
            Console.WriteLine("enter id = ");
            int id;
            id = Convert.ToInt32(Console.ReadLine());

            string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BDS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            string query = $"select * from [Table]";
            SqlCommand cmd = new SqlCommand(query, con);

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (dr[0].ToString() == id.ToString())
                {
                    Console.WriteLine("Your required search for id is : ");
                    Console.WriteLine($"id : {dr.GetValue(0)}, Name: {dr[1]}, Blood Group: {dr[2]}, Age: {dr[3]}, Is blood donated: {dr[4]}, Donor PhoneNo: {dr[5]}, Donor Email: {dr[6]}, Reg.Date: {dr[7]}");
                }
                if (dr[1].ToString() == name)
                {
                    Console.WriteLine("Your required search for name is : ");
                    Console.WriteLine($"id : {dr.GetValue(0)}, Name: {dr[1]}, Blood Group: {dr[2]}, Age: {dr[3]}, Is blood donated: {dr[4]}, Donor PhoneNo: {dr[5]}, Donor Email: {dr[6]}, Reg.Date: {dr[7]}");
                }
                if (dr[2].ToString() == bloodgrp)
                {
                    Console.WriteLine("Your required search for bloodgrp is : ");
                    Console.WriteLine($"id : {dr.GetValue(0)}, Name: {dr[1]}, Blood Group: {dr[2]}, Age: {dr[3]}, Is blood donated: {dr[4]}, Donor PhoneNo: {dr[5]}, Donor Email: {dr[6]}, Reg.Date: {dr[7]}");
                }
                if (dr[3].ToString() == age.ToString())
                {
                    Console.WriteLine("Your required search for age is : ");
                    Console.WriteLine($"id : {dr.GetValue(0)}, Name: {dr[1]}, Blood Group: {dr[2]}, Age: {dr[3]}, Is blood donated: {dr[4]}, Donor PhoneNo: {dr[5]}, Donor Email: {dr[6]}, Reg.Date: {dr[7]}");
                }
            }
            con.Close();

        }
    }
}
