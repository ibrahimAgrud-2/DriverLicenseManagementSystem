using System;
using System.Data;
using System.Data.SqlClient;
using static System.Net.Mime.MediaTypeNames;


namespace DVLD_DataAccessLayer
{
    public class clsLocalDrivingLicenseAppDataAccess
    {
        public static DataTable getAllLocalDrivingLicenseApps()
        {

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);
            string sqlQuery = "select * from LocalDrivingLicenseApplications_View";

            SqlCommand cmd = new SqlCommand(sqlQuery, connection);

            try
            {
                connection.Open();
                SqlDataReader read = cmd.ExecuteReader();

                if (read.HasRows)
                {
                    dt.Load(read);
                }

                read.Close();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                connection.Close();
            }



            return dt;
        }


        public static bool Find(int id,ref int applicationID,ref int licenseClassID)
        {
            string query = "select * from LocalDrivingLicenseApplications where LocalDrivingLicenseApplicationID=@id";

            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@id", id);

            try
            {
                connection.Open();
                SqlDataReader read = cmd.ExecuteReader();

                if (read.Read())
                {
                    applicationID = Convert.ToInt32(read["ApplicationID"]);
                    licenseClassID = Convert.ToInt32(read["licenseClassID"]);
                    return true;
                }

            }
            catch (Exception)
            {

                return false;
            }
            finally
            {
                connection.Close();

            }

            return false;
        }

        public static bool isLocalDrivingLicenseAppExistByID(int id)
        {
            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);


            string query = "select found =1 from LocalDrivingLicenseApplications where LocalDrivingLicenseApplicationID=@id";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@id", id);


            try
            {
                connection.Open();


                object result = cmd.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int value))
                {
                    return true;
                }
            }
            catch (Exception)
            {

                return false; ;
            }
            finally
            {
                connection.Close();
            }

            return false;
        }


        public static int AddLocalDrivingLicense(int applicationID,  int licenseClassID)
        {

            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);

            string query = "insert into LocalDrivingLicenseApplications (ApplicationID,licenseClassID) values (@applicationID,@licenseClassID) Select Scope_Identity();";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@applicationID", applicationID);
            cmd.Parameters.AddWithValue("@licenseClassID", licenseClassID);

            try
            {
                connection.Open();

                object result = cmd.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int inserted))
                {
                    return inserted;
                }
                else
                {
                    return -1;
                }
            }
            catch (Exception)
            {

                return -1;
            }
            finally
            {
                connection.Close();
            }

        }


        public static bool UpdateLocalDrivingLicenseInfo(int id,  int applicationID,  int licenseClassID)
        {

            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);

            string query = "update LocalDrivingLicenseApplications set applicationID=@applicationID,licenseClassID=@licenseClassID where LocalDrivingLicenseApplicationID=@id";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@applicationID", applicationID);
            cmd.Parameters.AddWithValue("@licenseClassID", licenseClassID);



            try
            {
                connection.Open();

                int affectedRowsNumber = cmd.ExecuteNonQuery();
                if (affectedRowsNumber == 1)
                {
                    return true;
                }
            }
            catch (Exception)
            {

                return false; ;
            }
            finally
            {
                connection.Close();
            }

            return false;
        }

        public static bool deleteLocalDrivingLicenseApp(int id)
        {


            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);
            string query = "delete LocalDrivingLicenseApplications where LocalDrivingLicenseApplicationID=@id";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@id", id);


            try
            {
                connection.Open();


                int affectedRows = cmd.ExecuteNonQuery();
                if (affectedRows == 1)
                {
                    return true;
                }
            }
            catch (Exception)
            {

                return false; ;
            }
            finally
            {
                connection.Close();
            }

            return false;
        }


        //Eğer bir *kişi*, *Aynı license türünden* *New veya completed* başvurusu varsa true döner. BU sayde kişini bir sınıf türüne sadece bir adet  başvurus olabilir. Tabi eğer geçmiş başvurusu cancelled ise tekrar başvuru yapabilir.
        public static bool isSameLocalDrivingLicenseAppExistByPersonIDAndTestType(int personID, int AppForLicenseClassID)
        {
            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);
            bool isFound = false;

            string query = @"select * from LocalDrivingLicenseApplications join Applications on Applications.ApplicationID=LocalDrivingLicenseApplications.ApplicationID
where ApplicantPersonID=@personID and LicenseClassID=@AppForLicenseClassID and ApplicationStatus in (1,3);";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@personID", personID);
            cmd.Parameters.AddWithValue("@AppForLicenseClassID", AppForLicenseClassID);



            try
            {
                connection.Open();

                object result = cmd.ExecuteScalar();
                SqlDataReader read = cmd.ExecuteReader();
                isFound = read.HasRows;
           
            }
            catch (Exception)
            {

                return false; ;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static int GetPassedTestCount(int LocalDrivingLicenseApplication)
        {
            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);

                        string query = @"select COUNT(*)  from TestAppointments join LocalDrivingLicenseApplications on
            TestAppointments.LocalDrivingLicenseApplicationID =LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID
            join Tests on TestAppointments.TestAppointmentID=Tests.TestAppointmentID
            where LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplication and Tests.TestResult=1 ";

            SqlCommand cmd = new SqlCommand(query, connection);

            

            try
            {
                connection.Open();

                object result = cmd.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int count))
                {
                    return count;
                }
                else
                {
                    return -1;
                }
            }
            catch (Exception)
            {

                return -1;
            }
            finally
            {
                connection.Close();
            }

        }
    }
}
