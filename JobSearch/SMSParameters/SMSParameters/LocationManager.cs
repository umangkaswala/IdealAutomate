﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSParameters
{
    public class LocationManager
    {
        
        public ObservableCollection<JobApplicationLocations> ObsCollJobApplicationLocations;
        public ObservableCollection<JobApplicationLocations> GetLocations()
        {
            ObsCollJobApplicationLocations = new ObservableCollection<JobApplicationLocations>();
            // ********************************************************************
            // Code Generated by Ideal Tools Organizer at http://idealautomate.com
            // ********************************************************************
            // Define Query String
            string queryString =
                "Select * from jobapplicationlocations " +
               "";
           
            // Define .net fields to hold each column selected in query
         
            Int32 int_jobapplicationlocations_Id;
            String str_jobapplicationlocations_LocationName;
            String str_jobapplicationlocations_LinkedInGeoId;
            String str_jobapplicationlocations_GlassdoorLocation;
            String str_jobapplicationlocations_DiceLatitude;
            String str_jobapplicationlocations_DiceLongitude;
            Boolean bool_jobapplicationlocations_Enabled;
            // Define a datatable that we will define columns in to match the columns
            // selected in the query. We will use sqldatareader to read the results
            // from the sql query one row at a time. Then we will add each of those
            // rows to the datatable - this is where you can modify the information
            // returned from the sql query one row at a time. Finally, we will
            // bind the table to the gridview.
            DataTable dt = new DataTable();

            if (!String.IsNullOrEmpty(ConnectionString1.SqlConnString))
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString1.SqlConnString))
                {
                    SqlCommand command = new SqlCommand(queryString, connection);

                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    // Define a column in the table for each column that was selected in the sql query 
                    // We do this before the sqldatareader loop because the columns only need to be  
                    // defined once. 

                    DataColumn column = null;
                    column = new DataColumn("jobapplicationlocations_Id", Type.GetType("System.Int32"));
                    dt.Columns.Add(column);
                    column = new DataColumn("jobapplicationlocations_LocationName", Type.GetType("System.String"));
                    dt.Columns.Add(column);
                    column = new DataColumn("jobapplicationlocations_LinkedInGeoId", Type.GetType("System.String"));
                    dt.Columns.Add(column);
                    column = new DataColumn("jobapplicationlocations_GlassdoorLocation", Type.GetType("System.String"));
                    dt.Columns.Add(column);
                    column = new DataColumn("jobapplicationlocations_DiceLatitude", Type.GetType("System.String"));
                    dt.Columns.Add(column);
                    column = new DataColumn("jobapplicationlocations_DiceLongitude", Type.GetType("System.String"));
                    dt.Columns.Add(column);
                    column = new DataColumn("jobapplicationlocations_Enabled", Type.GetType("System.Boolean"));
                    dt.Columns.Add(column);
                    // Read the results from the sql query one row at a time 
                    while (reader.Read())
                    {
                        // define a new datatable row to hold the row read from the sql query 
                        DataRow dataRow = dt.NewRow();
                        // Move each field from the reader to a holding field in .net 
                        // ******************************************************************** 
                        // The holding field in .net is where you can alter the contents of the 
                        // field 
                        // ******************************************************************** 
                        // Then, you move the contents of the holding .net field to the column in 
                        // the datarow that you defined above 
                        JobApplicationLocations _jobapplicationlocations = new JobApplicationLocations();
                        if (!(reader.IsDBNull(0)))
                        {
                            int_jobapplicationlocations_Id = reader.GetInt32(0);
                            dataRow["jobapplicationlocations_Id"] = int_jobapplicationlocations_Id;
                            _jobapplicationlocations.Id = int_jobapplicationlocations_Id;
                        }
                        if (!(reader.IsDBNull(1)))
                        {
                            str_jobapplicationlocations_LocationName = reader.GetString(1);
                            dataRow["jobapplicationlocations_LocationName"] = str_jobapplicationlocations_LocationName;
                            _jobapplicationlocations.LocationName = str_jobapplicationlocations_LocationName;
                        }
                        if (!(reader.IsDBNull(2)))
                        {
                            str_jobapplicationlocations_LinkedInGeoId = reader.GetString(2);
                            dataRow["jobapplicationlocations_LinkedInGeoId"] = str_jobapplicationlocations_LinkedInGeoId;
                            _jobapplicationlocations.LinkedInGeoId = str_jobapplicationlocations_LinkedInGeoId;
                        }
                        if (!(reader.IsDBNull(3)))
                        {
                            str_jobapplicationlocations_GlassdoorLocation = reader.GetString(3);
                            dataRow["jobapplicationlocations_GlassdoorLocation"] = str_jobapplicationlocations_GlassdoorLocation;
                            _jobapplicationlocations.GlassdoorLocation = str_jobapplicationlocations_GlassdoorLocation;
                        }
                        if (!(reader.IsDBNull(4)))
                        {
                            str_jobapplicationlocations_DiceLatitude = reader.GetString(4);
                            dataRow["jobapplicationlocations_DiceLatitude"] = str_jobapplicationlocations_DiceLatitude;
                            _jobapplicationlocations.DiceLatitude = str_jobapplicationlocations_DiceLatitude;
                        }
                        if (!(reader.IsDBNull(5)))
                        {
                            str_jobapplicationlocations_DiceLongitude = reader.GetString(5);
                            dataRow["jobapplicationlocations_DiceLongitude"] = str_jobapplicationlocations_DiceLongitude;
                            _jobapplicationlocations.DiceLongitude = str_jobapplicationlocations_DiceLongitude;
                        }
                        if (!(reader.IsDBNull(6)))
                        {
                            bool_jobapplicationlocations_Enabled = reader.GetBoolean(6);
                            dataRow["jobapplicationlocations_Enabled"] = bool_jobapplicationlocations_Enabled;
                            _jobapplicationlocations.Enabled = bool_jobapplicationlocations_Enabled;
                        }
                        // Add the row to the datatable 
                        dt.Rows.Add(dataRow);
                        ObsCollJobApplicationLocations.Add(_jobapplicationlocations);
                    }

                    // Call Close when done reading. 
                    reader.Close();
                }
            }

            // assign the datatable as the datasource for the gridview and bind the gridview      
            return ObsCollJobApplicationLocations;
        }

        public ObservableCollection<JobApplicationLocations> GetLocationsEnabled()
        {
            ObsCollJobApplicationLocations = new ObservableCollection<JobApplicationLocations>();
            // ********************************************************************
            // Code Generated by Ideal Tools Organizer at http://idealautomate.com
            // ********************************************************************
            // Define Query String
            string queryString =
                "Select * from jobapplicationlocations where enabled = 1" +
               "";
            // Define Connection String
            string strConnectionString = null;
            strConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=IdealAutomateDB;Integrated Security=SSPI";
            // Define .net fields to hold each column selected in query

            Int32 int_jobapplicationlocations_Id;
            String str_jobapplicationlocations_LocationName;
            String str_jobapplicationlocations_LinkedInGeoId;
            String str_jobapplicationlocations_GlassdoorLocation;
            String str_jobapplicationlocations_DiceLatitude;
            String str_jobapplicationlocations_DiceLongitude;
            Boolean bool_jobapplicationlocations_Enabled;
            // Define a datatable that we will define columns in to match the columns
            // selected in the query. We will use sqldatareader to read the results
            // from the sql query one row at a time. Then we will add each of those
            // rows to the datatable - this is where you can modify the information
            // returned from the sql query one row at a time. Finally, we will
            // bind the table to the gridview.
            DataTable dt = new DataTable();
            if (!String.IsNullOrEmpty(ConnectionString1.SqlConnString))
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString1.SqlConnString))
               
            {
                SqlCommand command = new SqlCommand(queryString, connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                // Define a column in the table for each column that was selected in the sql query 
                // We do this before the sqldatareader loop because the columns only need to be  
                // defined once. 

                DataColumn column = null;
                column = new DataColumn("jobapplicationlocations_Id", Type.GetType("System.Int32"));
                dt.Columns.Add(column);
                column = new DataColumn("jobapplicationlocations_LocationName", Type.GetType("System.String"));
                dt.Columns.Add(column);
                column = new DataColumn("jobapplicationlocations_LinkedInGeoId", Type.GetType("System.String"));
                dt.Columns.Add(column);
                column = new DataColumn("jobapplicationlocations_GlassdoorLocation", Type.GetType("System.String"));
                dt.Columns.Add(column);
                column = new DataColumn("jobapplicationlocations_DiceLatitude", Type.GetType("System.String"));
                dt.Columns.Add(column);
                column = new DataColumn("jobapplicationlocations_DiceLongitude", Type.GetType("System.String"));
                dt.Columns.Add(column);
                column = new DataColumn("jobapplicationlocations_Enabled", Type.GetType("System.Boolean"));
                dt.Columns.Add(column);
                // Read the results from the sql query one row at a time 
                while (reader.Read())
                {
                    // define a new datatable row to hold the row read from the sql query 
                    DataRow dataRow = dt.NewRow();
                    // Move each field from the reader to a holding field in .net 
                    // ******************************************************************** 
                    // The holding field in .net is where you can alter the contents of the 
                    // field 
                    // ******************************************************************** 
                    // Then, you move the contents of the holding .net field to the column in 
                    // the datarow that you defined above 
                    JobApplicationLocations _jobapplicationlocations = new JobApplicationLocations();
                    if (!(reader.IsDBNull(0)))
                    {
                        int_jobapplicationlocations_Id = reader.GetInt32(0);
                        dataRow["jobapplicationlocations_Id"] = int_jobapplicationlocations_Id;
                        _jobapplicationlocations.Id = int_jobapplicationlocations_Id;
                    }
                    if (!(reader.IsDBNull(1)))
                    {
                        str_jobapplicationlocations_LocationName = reader.GetString(1);
                        dataRow["jobapplicationlocations_LocationName"] = str_jobapplicationlocations_LocationName;
                        _jobapplicationlocations.LocationName = str_jobapplicationlocations_LocationName;
                    }
                    if (!(reader.IsDBNull(2)))
                    {
                        str_jobapplicationlocations_LinkedInGeoId = reader.GetString(2);
                        dataRow["jobapplicationlocations_LinkedInGeoId"] = str_jobapplicationlocations_LinkedInGeoId;
                        _jobapplicationlocations.LinkedInGeoId = str_jobapplicationlocations_LinkedInGeoId;
                    }
                    if (!(reader.IsDBNull(3)))
                    {
                        str_jobapplicationlocations_GlassdoorLocation = reader.GetString(3);
                        dataRow["jobapplicationlocations_GlassdoorLocation"] = str_jobapplicationlocations_GlassdoorLocation;
                        _jobapplicationlocations.GlassdoorLocation = str_jobapplicationlocations_GlassdoorLocation;
                    }
                    if (!(reader.IsDBNull(4)))
                    {
                        str_jobapplicationlocations_DiceLatitude = reader.GetString(4);
                        dataRow["jobapplicationlocations_DiceLatitude"] = str_jobapplicationlocations_DiceLatitude;
                        _jobapplicationlocations.DiceLatitude = str_jobapplicationlocations_DiceLatitude;
                    }
                    if (!(reader.IsDBNull(5)))
                    {
                        str_jobapplicationlocations_DiceLongitude = reader.GetString(5);
                        dataRow["jobapplicationlocations_DiceLongitude"] = str_jobapplicationlocations_DiceLongitude;
                        _jobapplicationlocations.DiceLongitude = str_jobapplicationlocations_DiceLongitude;
                    }
                    if (!(reader.IsDBNull(6)))
                    {
                        bool_jobapplicationlocations_Enabled = reader.GetBoolean(6);
                        dataRow["jobapplicationlocations_Enabled"] = bool_jobapplicationlocations_Enabled;
                        _jobapplicationlocations.Enabled = bool_jobapplicationlocations_Enabled;
                    }
                    // Add the row to the datatable 
                    dt.Rows.Add(dataRow);
                    ObsCollJobApplicationLocations.Add(_jobapplicationlocations);
                }

                // Call Close when done reading. 
                reader.Close();
            }
        }
            // assign the datatable as the datasource for the gridview and bind the gridview      
            return ObsCollJobApplicationLocations;
        }

        public void Upsert(JobApplicationLocations myLocation)
        {
            SqlConnection thisConnection = null;
            if (String.IsNullOrEmpty(ConnectionString1.SqlConnString))
            {
                return;
            }
            else
            {
                thisConnection = new SqlConnection(ConnectionString1.SqlConnString);
            }

            //Create Command object
            SqlCommand nonqueryCommand = thisConnection.CreateCommand();

            try
            {
                // Open Connection
                thisConnection.Open();
                Console.WriteLine("Connection Opened");

                // Create INSERT statement with Locationd parameters
                nonqueryCommand.CommandText =
                   " IF NOT EXISTS(SELECT* FROM dbo.JobApplicationLocations WHERE ID = @Id)" +

                    "INSERT INTO [dbo].[JobApplicationLocations] " +
//"           ([Id] " +
"           ([LocationName] " +
"                ,[LinkedInGeoId] " +
"           ,[GlassdoorLocation] " +
"           ,[DiceLatitude] " +
"           ,[DiceLongitude] " +
"           ,[Enabled]) " +
"     VALUES " +
//"           (@Id " +
"           (@LocationName " +
"           ,@LinkedInGeoId " +
"           ,@GlassdoorLocation " +
"           ,@DiceLatitude " +
"           ,@DiceLongitude " +
"           ,@Enabled) " +
" ELSE " +
                "UPDATE [dbo].[JobApplicationLocations] " +
"   SET [LocationName] = @LocationName " +
"           ,[LinkedInGeoId] = @LinkedInGeoId " +
"           ,[GlassdoorLocation] = @GlassdoorLocation " +
"           ,[DiceLatitude] = @DiceLatitude " +
"           ,[DiceLongitude]  = @DiceLongitude " +
"      ,[Enabled] = @Enabled " +
" WHERE Id = @Id " +
"          ";


                // Add Parameters to Command Parameters collection
                nonqueryCommand.Parameters.Add("@Id", SqlDbType.Int);
                nonqueryCommand.Parameters.Add("@LocationName", SqlDbType.VarChar, 500);
                nonqueryCommand.Parameters.Add("@LinkedInGeoId", SqlDbType.VarChar, 100);
                nonqueryCommand.Parameters.Add("@GlassdoorLocation", SqlDbType.VarChar, 100);
                nonqueryCommand.Parameters.Add("@DiceLatitude", SqlDbType.VarChar, 100);
                nonqueryCommand.Parameters.Add("@DiceLongitude", SqlDbType.VarChar, 100);
                nonqueryCommand.Parameters.Add("@Enabled", SqlDbType.Bit);


                // Prepare command for repeated execution
                nonqueryCommand.Prepare();

                // Data to be inserted

                nonqueryCommand.Parameters["@Id"].Value = myLocation.Id;
                nonqueryCommand.Parameters["@LocationName"].Value = myLocation.LocationName;
                nonqueryCommand.Parameters["@LinkedInGeoId"].Value = myLocation.LinkedInGeoId ?? "";
                nonqueryCommand.Parameters["@GlassdoorLocation"].Value = myLocation.GlassdoorLocation ?? "";
                nonqueryCommand.Parameters["@DiceLatitude"].Value = myLocation.DiceLatitude ?? "";
                nonqueryCommand.Parameters["@DiceLongitude"].Value = myLocation.DiceLongitude ?? "";
                nonqueryCommand.Parameters["@Enabled"].Value = myLocation.Enabled;


                Console.WriteLine("Executing {0}", nonqueryCommand.CommandText);
                Console.WriteLine("Number of rows affected : {0}", nonqueryCommand.ExecuteNonQuery());

            }
            catch (SqlException ex)
            {
                // Display error
                Console.WriteLine("Error: " + ex.ToString());
            }
            finally
            {
                // Close Connection
                thisConnection.Close();
                Console.WriteLine("Connection Closed");

            }
        }

        public void Delete(int myId)
        {
            SqlConnection thisConnection = null;
            if (String.IsNullOrEmpty(ConnectionString1.SqlConnString))
            {
                return;
            }
            else
            {
                thisConnection = new SqlConnection(ConnectionString1.SqlConnString);
            }

            //Create Command object
            SqlCommand nonqueryCommand = thisConnection.CreateCommand();

            try
            {
                // Open Connection
                thisConnection.Open();
                Console.WriteLine("Connection Opened");

                // Create INSERT statement with Locationd parameters
                nonqueryCommand.CommandText =
                   " DELETE FROM dbo.JobApplicationLocations WHERE ID = @Id";


                // Add Parameters to Command Parameters collection
                nonqueryCommand.Parameters.Add("@Id", SqlDbType.Int);


                // Prepare command for repeated execution
                nonqueryCommand.Prepare();

                // Data to be inserted

                nonqueryCommand.Parameters["@Id"].Value = myId;


                Console.WriteLine("Executing {0}", nonqueryCommand.CommandText);
                Console.WriteLine("Number of rows affected : {0}", nonqueryCommand.ExecuteNonQuery());

            }
            catch (SqlException ex)
            {
                // Display error
                Console.WriteLine("Error: " + ex.ToString());
            }
            finally
            {
                // Close Connection
                thisConnection.Close();
                Console.WriteLine("Connection Closed");

            }
        }
    }
}
