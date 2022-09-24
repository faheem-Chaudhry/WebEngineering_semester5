using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.SqlClient;
using System.Data;

namespace MyApp // Note: actual namespace depends on the project name.
{
    public class Program
    {
       
        public static void Main(string[] args)
        {
            string conn = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BlogApp;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection conn2 = new SqlConnection(conn);
            conn2.Open();
            string query = "select * from Userlogin join Blog on Userlogin.AdminID = Blog.AdminID";
            SqlCommand selectCmd = new SqlCommand(query, conn2);

            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = selectCmd;

            DataTable dt = new DataTable();
            //DataTable dt2 = new DataTable();


            adapter.Fill(dt);
            foreach (DataRow row in dt.Rows)
            {

                Console.WriteLine(row.ToString());
                //Console.WriteLine(row[1]);
                //Console.WriteLine(row[2]);
                //Console.WriteLine(row[3]);
                //Console.WriteLine(row[4]);
                //Console.WriteLine(row[5]);



            }












            // Disconnected Model

            // DataTable StudentTable = new DataTable();
            // DataTable UniversityTable = new DataTable();

            // DataColumn IdColumn = new DataColumn();
            // IdColumn.ColumnName = "Id";
            // IdColumn.DataType = typeof(int);
            // DataColumn NameColumn = new DataColumn("Name", typeof(string));
            // DataColumn StdUniIdColumn = new DataColumn("UId", typeof(int));


            // DataColumn UniIdColumn = new DataColumn();
            // UniIdColumn.ColumnName = "Id";
            // UniIdColumn.DataType = typeof(int);
            // DataColumn UniNameColumn = new DataColumn("Name", typeof(string));

            // UniIdColumn.AutoIncrement = true;
            // UniIdColumn.AutoIncrementSeed = 1;
            // UniIdColumn.AutoIncrementStep = 1;

            // IdColumn.AutoIncrement = true;
            // IdColumn.AutoIncrementSeed = 1;
            // IdColumn.AutoIncrementStep = 1;



            // StudentTable.Columns.Add(IdColumn);
            // StudentTable.Columns.Add(NameColumn);
            // StudentTable.Columns.Add(StdUniIdColumn);


            // UniversityTable.Columns.Add(UniIdColumn);
            // UniversityTable.Columns.Add(UniNameColumn);

            // StudentTable.PrimaryKey = new DataColumn[] { IdColumn };
            // UniversityTable.PrimaryKey = new DataColumn[] { UniIdColumn };


            // DataSet ds = new DataSet();
            // ds.Tables.Add(StudentTable);
            // ds.Tables.Add(UniversityTable);

            // DataRelation rel1 =
            //     new DataRelation("usr", UniversityTable.Columns["Id"], StudentTable.Columns["UId"]);
            // ds.Relations.Add(rel1);
            ///* ye 1 database ma tables ke relation ka function ha pehle argument ma relation ka nam dusr ma
            // primary key aur tesre ma foreign key aati ha jis ma foreign key hoti ha wo child table hota
            // ha  */

            // //Adding some data

            // DataRow r1 = UniversityTable.NewRow();
            // DataRow r2 = UniversityTable.NewRow();

            // r1["Name"] = "PU";
            // r2["Name"] = "PUCIT";


            // UniversityTable.Rows.Add(r1);
            // UniversityTable.Rows.Add(r2);

            // DataRow r3 = StudentTable.NewRow();
            // r3["Name"] = "Ali";
            // r3["UId"] = 1;

            // DataRow r4 = StudentTable.NewRow();
            // r4["Name"] = "Ali 123";
            // r4["UId"] = 2;


            // StudentTable.Rows.Add(r3);
            // StudentTable.Rows.Add(r4);


            // foreach (DataRow row in UniversityTable.Rows)
            // {


            //     Console.WriteLine("University Id : " + row[0]);
            //     Console.WriteLine("University Name : " + row[1]);

            //     DataRow[] childRows = row.GetChildRows("usr");
            //     foreach (DataRow crow in childRows)
            //     {
            //         Console.WriteLine("Student Id : " + crow[0]);
            //         Console.WriteLine("student Name : " + crow[1]);
            //    //     DataRow r5 = crow.GetParentRow("usr");

            //     }
            // }
            //select
            //DataRow[] dr = StudentTable.Select("Id = 2");
            //Console.WriteLine(dr[0][0]);



            //delete row 

            //StudentTable.AcceptChanges();
            //foreach(DataRow row in StudentTable.Rows)
            //{
            //    if(row[1].ToString() == "Ali")
            //    {
            //        row.Delete();
            //    }
            //}


            //Update row

            //StudentTable.AcceptChanges();
            //foreach (DataRow row in StudentTable.Rows)
            //{
            //    if (row[1].ToString() == "Ali")
            //    {
            //        row[1] = "Faheem";
            //    }
            //}
            //foreach (DataRow row in UniversityTable.Rows)
            //{


            //    Console.WriteLine("University Id : " + row[0]);
            //    Console.WriteLine("University Name : " + row[1]);

            //    DataRow[] childRows = row.GetChildRows("usr");
            //    foreach (DataRow crow in childRows)
            //    {
            //        Console.WriteLine("Student Id : " + crow[0]);
            //        Console.WriteLine("student Name : " + crow[1]);
            //        //     DataRow r5 = crow.GetParentRow("usr");

            //    }
            //}



















            //string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=student;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            //SqlConnection con = new SqlConnection(connString);
            //con.Open();
            //string query = "Select * from student";
            //SqlCommand cmd = new SqlCommand(query, con);
            //SqlDataReader dr = cmd.ExecuteReader();
            //while (dr.Read())
            //{
            //    Console.WriteLine($"id : {dr.GetValue(0)}, Name: {dr[1]}");
            //}
            //con.Close();










            //SqlConnection con = new SqlConnection(connection);
            //con.Open();
            //string query = "Select * from person";
            //SqlCommand cmd = new SqlCommand(query, con);
            //SqlDataReader dr = cmd.ExecuteReader();
            //while (dr.Read())
            //{
            //    Console.WriteLine($"id = {dr.GetValue(0)},    Name = {dr[1]}");
            //}
            //con.Close();

        }
    }
}
