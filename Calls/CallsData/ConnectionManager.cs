using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CallsData
{
    public class ConnectionManager
    {
        private NpgsqlConnection _dbConnect { get; set; }

        public NpgsqlConnection ConnectGCP(String user, String pass)
        {
            String connString = "Host=127.0.0.1;Port=5433;Username=" + user + ";Password=" + pass + ";Database=postgres";

            try
            {
                _dbConnect = new NpgsqlConnection(connString);
                _dbConnect.Open();
                return _dbConnect;
            }
            catch (Npgsql.PostgresException)
            {
            }

            return null;

        }

        public NpgsqlConnection ConnectLocal(String user = "", String pass = "", bool newCredentials = true)
        {
            pass.Replace(" ", "");
            String connString = "Host=localhost;Port=5432;Username=" + user + ";Password=" + pass + ";Database=calls311";

            try
            {
                _dbConnect = new NpgsqlConnection(connString);
                _dbConnect.Open();
                return _dbConnect;
            }
            catch (Npgsql.PostgresException a) when (newCredentials == true)
            {
                this.ConnectLocal();
            }

            return null;

        }

        public void Import(List<Json311> dataset, String connString, string tableName = "calls", Boolean updateTime = true)
        {

            NpgsqlDateTime last_date = new NpgsqlDateTime();
            DateTime construct = new DateTime(0);
            NpgsqlDateTime most_recent = new NpgsqlDateTime(construct);

            if (updateTime == true)
            {
                using (NpgsqlCommand checkDate = new NpgsqlCommand("SELECT * FROM checktime", _dbConnect))
                using (NpgsqlDataReader reader = checkDate.ExecuteReader())
                {
                    try
                    {
                        while (reader.Read())
                        {
                            last_date = reader.GetTimeStamp(0);
                            reader.Close();
                        }
                    }
                    catch (Exception a) { Console.WriteLine(a); }
                }
            }
            int oldC = 0, newC = 0;

            using (var writer = _dbConnect.BeginBinaryImport("COPY " + tableName + " FROM STDIN (FORMAT BINARY)"))
            {
                foreach (Json311 entry in dataset)
                {

                    NpgsqlDateTime entryDate = Convert.ToDateTime(entry.Created_date);
                    if (entryDate < last_date)
                    {
                        if (most_recent < entryDate)
                        {
                            most_recent = entryDate;
                        }
                        oldC++;
                        continue;
                    }


                    writer.StartRow();
                    writer.Write(entry.Unique_key);

                    if (entry.Created_date == null)
                    {
                        writer.WriteNull();
                    }
                    else
                    {
                        NpgsqlDateTime cdate = Convert.ToDateTime(entry.Created_date);
                        writer.Write(cdate);
                    }


                    if (entry.Closed_date == null)
                    {
                        writer.WriteNull();
                    }
                    else
                    {
                        NpgsqlDateTime cdate = Convert.ToDateTime(entry.Closed_date);
                        writer.Write(cdate);
                    }

                    writer.Write(entry.Agency);
                    writer.Write(entry.Agency_name);
                    writer.Write(entry.Complaint_type);
                    writer.Write(entry.Descriptor);
                    writer.Write(entry.Location_type);
                    writer.Write(entry.Incident_zip);
                    writer.Write(entry.Incident_address);
                    writer.Write(entry.Street_name);
                    writer.Write(entry.Cross_street_1);
                    writer.Write(entry.Cross_street_2);
                    writer.Write(entry.Intersection_street_1);
                    writer.Write(entry.Intersection_street_2);
                    writer.Write(entry.Address_type);
                    writer.Write(entry.City);
                    writer.Write(entry.Landmark);
                    writer.Write(entry.Facility_type);
                    writer.Write(entry.Status);


                    if (entry.Due_date == null)
                    {
                        writer.WriteNull();
                    }
                    else
                    {
                        NpgsqlDateTime dDate = Convert.ToDateTime(entry.Due_date);
                        writer.Write(dDate);
                    }

                    writer.Write(entry.Resolution_description);


                    if (entry.Resolution_action_updated_date == null)
                    {
                        writer.WriteNull();
                    }
                    else
                    {
                        NpgsqlDateTime rDate = Convert.ToDateTime(entry.Resolution_action_updated_date);
                        writer.Write(rDate);
                    }

                    writer.Write(entry.Community_board);
                    writer.Write(entry.Bbl);
                    writer.Write(entry.Borough);
                    writer.Write(entry.X_coordinate_state_plane);
                    writer.Write(entry.Y_coordinate_state_plane);
                    writer.Write(entry.Open_data_channel_type);
                    writer.Write(entry.Park_facility_name);
                    writer.Write(entry.Park_borough);
                    writer.Write(entry.Vehicle_type);
                    writer.Write(entry.Taxi_company_borough);
                    writer.Write(entry.Taxi_pick_up_location);
                    writer.Write(entry.Bridge_highway_name);
                    writer.Write(entry.Bridge_highway_direction);
                    writer.Write(entry.Road_ramp);
                    writer.Write(entry.Bridge_highway_segment);
                    writer.Write(entry.Latitude);
                    writer.Write(entry.Longitude);
                    writer.Write(entry.Location_city);


                    if (entry.Location == null)
                    {
                        writer.WriteNull();
                    }
                    else
                    {
                        var dat = entry.Location.SelectToken("coordinates");
                        double x = (double)dat[0];
                        double y = (double)dat[1];
                        NpgsqlPoint nPoint = new NpgsqlPoint(x, y);
                        writer.Write(nPoint);
                    }

                    writer.Write(entry.Location_zip);
                    writer.Write(entry.Location_state);

                    newC++;
                }
                writer.Complete();
            }
            Console.WriteLine("New Records:" + newC + " Old Records: " + oldC);

            if (updateTime == true)
            {
                NpgsqlCommand dropCheck = new NpgsqlCommand("DROP TABLE checktime", _dbConnect);
                dropCheck.ExecuteNonQuery();
                NpgsqlCommand newCheck = new NpgsqlCommand("CREATE TABLE checktime (curr_up_date timestamp)", _dbConnect);
                newCheck.ExecuteNonQuery();
                using (var writer = _dbConnect.BeginBinaryImport("COPY checktime FROM STDIN (FORMAT BINARY)"))
                {
                    writer.StartRow();
                    writer.Write(most_recent);
                    writer.Complete();
                }
            }

        }

        public void CheckDate(out DateTime date)
        {

            date = DateTime.Now;
            using (NpgsqlCommand checkDate = new NpgsqlCommand("SELECT * FROM checktime", _dbConnect))
            using (NpgsqlDataReader reader = checkDate.ExecuteReader())
            {
                try
                {
                    while (reader.Read())
                    {
                        date = Convert.ToDateTime(reader.GetTimeStamp(0));
                    }
                }
                catch (Exception a)
                { 
                }
            }

        }

        public int GetRows()
        {
            int total = 0;

            using (NpgsqlCommand totalRows = new NpgsqlCommand("SELECT COUNT(*) FROM calls WHERE Created_date IS NOT NULL AND" +
                " Closed_date IS NOT NULL AND Due_date IS NOT NULL AND Resolution_action_updated_date IS NOT NULL", _dbConnect))
            using (NpgsqlDataReader reader = totalRows.ExecuteReader())
            {
                while (reader.Read())
                {
                    total = reader.GetInt32(0);
                }
            }

            return total;
        }

        public int GetRows(String filterField, String filterSelection)
        {
            int total = 0;

            using (NpgsqlCommand filterRows = new NpgsqlCommand("SELECT COUNT(*) FROM calls WHERE " + filterField +
                " = '" + filterSelection + "' AND Created_date IS NOT NULL", _dbConnect))
            using (NpgsqlDataReader reader = filterRows.ExecuteReader())
            {
                while (reader.Read())
                {
                    total = reader.GetInt32(0);
                }
            }

            return total;
        }

        public int GetRows(DateTime date1, DateTime date2)
        {
            NpgsqlDateTime start = date1, end = date2;
            int total = 0;

            using (NpgsqlCommand filterRows = new NpgsqlCommand("SELECT COUNT(*) FROM calls WHERE Created_date IS NOT NULL " +
                "AND Created_date <= " + end + " AND Created_date >= " + start, _dbConnect))
            using (NpgsqlDataReader reader = filterRows.ExecuteReader())
            {
                while (reader.Read())
                {
                    total = reader.GetInt32(0);
                }
            }

            return total;
        }

        public void Validate()
        {

            NpgsqlCommand dropCheck = new NpgsqlCommand("DROP TABLE IF EXISTS checktime", _dbConnect);
            dropCheck.ExecuteNonQuery();
            NpgsqlCommand newCheck = new NpgsqlCommand("CREATE TABLE checktime (curr_up_date timestamp)", _dbConnect);
            newCheck.ExecuteNonQuery();

            NpgsqlCommand drop = new NpgsqlCommand("DROP TABLE IF EXISTS calls", _dbConnect);
            drop.ExecuteNonQuery();
            NpgsqlCommand checkTable = new NpgsqlCommand(
                    "CREATE TABLE IF NOT EXISTS calls (" +
                    "Unique_key varchar," +
                    "Created_date timestamp," +
                    "Closed_date timestamp," +
                    "Agency varchar," +
                    "Agency_name varchar, " +
                    "Complaint_type varchar," +
                    "Descriptor varchar," +
                    "Location_type varchar," +
                    "Incident_zip varchar," +
                    "Incident_address varchar," +
                    "Street_name varchar," +
                    "Cross_street_1 varchar," +
                    "Cross_street_2 varchar," +
                    "Intersection_street_1 varchar," +
                    "Intersection_street_2 varchar," +
                    "Address_type varchar, " +
                    "City varchar, " +
                    "Landmark varchar," +
                    "Facility_type varchar," +
                    "Status varchar," +
                    "Due_date timestamp," +
                    "Resolution_description varchar," +
                    "Resolution_action_updated_date timestamp," +
                    "Community_board varchar," +
                    "Bbl varchar, " +
                    "Borough varchar, " +
                    "x_coordinate_state_plane varchar, " +
                    "y_coordinate_state_plane varchar," +
                    "open_data_channel_type varchar," +
                    "Park_facility_name varchar," +
                    "Park_borough varchar," +
                    "Vehicle_type varchar," +
                    "Taxi_company_borough varchar," +
                    "Taxi_pick_up_location varchar, " +
                    "Bridge_highway_name varchar," +
                    "Bridge_highway_direction varchar, " +
                    "Road_ramp varchar," +
                    "Bridge_highway_segment varchar," +
                    "Latitude varchar, " +
                    "Longitude varchar," +
                    "Location_city varchar," +
                    "Location point," +
                    "Location_zip varchar, " +
                    "Location_state varchar);", _dbConnect
                );
            checkTable.ExecuteNonQuery();


        }

    }
}
