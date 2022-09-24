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



            // Disconnected Model

            DataTable StudentTable = new DataTable();
            DataTable UniversityTable = new DataTable();

            DataColumn IdColumn = new DataColumn();
            IdColumn.ColumnName = "Id";
            IdColumn.DataType = typeof(int);
            DataColumn NameColumn = new DataColumn("Name", typeof(string));
            DataColumn StdUniIdColumn = new DataColumn("UId", typeof(int));


            DataColumn UniIdColumn = new DataColumn();
            UniIdColumn.ColumnName = "Id";
            UniIdColumn.DataType = typeof(int);
            DataColumn UniNameColumn = new DataColumn("Name", typeof(string));

            UniIdColumn.AutoIncrement = true;
            UniIdColumn.AutoIncrementSeed = 1;
            UniIdColumn.AutoIncrementStep = 1;

            IdColumn.AutoIncrement = true;
            IdColumn.AutoIncrementSeed = 1;
            IdColumn.AutoIncrementStep = 1;



            StudentTable.Columns.Add(IdColumn);
            StudentTable.Columns.Add(NameColumn);
            StudentTable.Columns.Add(StdUniIdColumn);


            UniversityTable.Columns.Add(UniIdColumn);
            UniversityTable.Columns.Add(UniNameColumn);

            StudentTable.PrimaryKey = new DataColumn[] { IdColumn };
            UniversityTable.PrimaryKey = new DataColumn[] { UniIdColumn };


            DataSet ds = new DataSet();
            ds.Tables.Add(StudentTable);
            ds.Tables.Add(UniversityTable);

            DataRelation rel1 =
                new DataRelation("usr", UniversityTable.Columns["Id"], StudentTable.Columns["UId"]);
            ds.Relations.Add(rel1);
            /* ye 1 database ma tables ke relation ka function ha pehle argument ma relation ka nam dusr ma
             primary key aur tesre ma foreign key aati ha jis ma foreign key hoti ha wo child table hota
             ha  */

            //Adding some data

            DataRow r1 = UniversityTable.NewRow();
            DataRow r2 = UniversityTable.NewRow();

            r1["Name"] = "PU";
            r2["Name"] = "PUCIT";


            UniversityTable.Rows.Add(r1);
            UniversityTable.Rows.Add(r2);

            DataRow r3 = StudentTable.NewRow();
            r3["Name"] = "Ali";
            r3["UId"] = 1;

            DataRow r4 = StudentTable.NewRow();
            r4["Name"] = "Ali 123";
            r4["UId"] = 2;


            StudentTable.Rows.Add(r3);
            StudentTable.Rows.Add(r4);


            foreach (DataRow row in UniversityTable.Rows)
            {


                Console.WriteLine("University Id : " + row[0]);
                Console.WriteLine("University Name : " + row[1]);

                DataRow[] childRows = row.GetChildRows("usr");
                foreach (DataRow crow in childRows)
                {
                    Console.WriteLine("Student Id : " + crow[0]);
                    Console.WriteLine("student Name : " + crow[1]);
                    //     DataRow r5 = crow.GetParentRow("usr");

                }
            }
       //     select
            DataRow[] dr = StudentTable.Select("Id = 2");
            Console.WriteLine(dr[0][0]);



      //      delete row

            //StudentTable.AcceptChanges();
            //foreach (DataRow row in StudentTable.Rows)
            //{
            //    if (row[1].ToString() == "Ali")
            //    {
            //        row.Delete();
            //    }
            //}


          //  Update row

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
        }
    }
}