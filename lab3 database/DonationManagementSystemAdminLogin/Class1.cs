using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace DonationManagementSystemAdminLogin
{
    public class AdminLogin
    {

        public bool admin()
        {
            string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BDS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(connString);
            Console.Write("Enter User Name: ");
            string userName = Console.ReadLine();
            Console.Write("Enter Password: ");
            string pwd = Console.ReadLine();
            con.Open();
            string query = $"select * from AdminTable " +
                $"where username = @u and password = @p";

            SqlParameter P1 = new SqlParameter("u",userName);
            SqlParameter P2 = new SqlParameter("p",pwd);
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.Add(P1);
            cmd.Parameters.Add(P2);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if(dr[1].ToString() == userName || dr[2].ToString() == pwd)
                {
                    Console.WriteLine("Login Successfully");
                    return true;
                }
            }
            return false;
            con.Close();
        }


    }
}
