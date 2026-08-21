using Common;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;



namespace DVLD_DataAccessLayer
{
    public class clsLocalDrivingLicenseAppDataAccess
    {
        public static DataTable getAllLocalDrivingLicenseApps()
        {

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
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
            catch (Exception ex)
            {
                Logger.LogMessage(EventLogEntryType.Error, Logger.EventLogID.DL_ConnectionError, ex.Message, ""
                  , ex);
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

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

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
            catch (Exception ex)
            {
                Logger.LogMessage(EventLogEntryType.Error, Logger.EventLogID.DL_ConnectionError, ex.Message, ""
                  , ex);
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
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);


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
            catch (Exception ex)
            {
                Logger.LogMessage(EventLogEntryType.Error, Logger.EventLogID.DL_ConnectionError, ex.Message, ""
                  , ex);

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

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

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
            catch (Exception ex)
            {
                Logger.LogMessage(EventLogEntryType.Error, Logger.EventLogID.DL_ConnectionError, ex.Message, ""
                  , ex);

                return -1;
            }
            finally
            {
                connection.Close();
            }

        }
        public static bool UpdateLocalDrivingLicenseInfo(int id,  int applicationID,  int licenseClassID)
        {

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

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
            catch (Exception ex)
            {
                Logger.LogMessage(EventLogEntryType.Error, Logger.EventLogID.DL_ConnectionError, ex.Message, ""
                  , ex);

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


            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
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
            catch (Exception ex)
            {
                Logger.LogMessage(EventLogEntryType.Error, Logger.EventLogID.DL_ConnectionError, ex.Message, ""
                  , ex);
                return false; ;
            }
            finally
            {
                connection.Close();
            }

            return false;
        }




        //✅Örneğin: kişi en son yapılan vision test'i geçmiş mi? BU yüzden ID'ye göre büyükten küçe sıralıyor ki son yapılanı alabilesin.
        public static bool DoesPassTestType(int LDLAID,int testTypeID)
        {

            bool Result = false;

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = @" SELECT top 1 TestResult
                            FROM LocalDrivingLicenseApplications INNER JOIN
                                 TestAppointments ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID INNER JOIN
                                 Tests ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID
                            WHERE
                            (LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID) 
                            AND(TestAppointments.TestTypeID = @TestTypeID)
                            ORDER BY TestAppointments.TestAppointmentID desc";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LDLAID);
            command.Parameters.AddWithValue("@TestTypeID", testTypeID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && bool.TryParse(result.ToString(), out bool returnedResult))
                {
                    Result = returnedResult;
                }
            }
            catch (Exception ex)
            {
                Logger.LogMessage(EventLogEntryType.Error, Logger.EventLogID.DL_ConnectionError, ex.Message, ""
                  , ex);

            }

            finally
            {
                connection.Close();
            }

            return Result;
            
        }


        //✅DoesPassTestType Fonksyionunda göre Query'deki tek değişiklik Found=1 eklenmesi. Bu sayede eğer varsa sonuç Found=1 olur ve true döner. Ancak DoesPassTestType fonksiyonunda Result sorguluyorduk ve result 0 yani false'de dönebilirdi.
        public static bool DoesAttendTestType(int LocalDrivingLicenseApplicationID, int TestTypeID)

        {


            bool IsFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = @" SELECT top 1 Found=1
                            FROM LocalDrivingLicenseApplications INNER JOIN
                                 TestAppointments ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID INNER JOIN
                                 Tests ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID
                            WHERE
                            (LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID) 
                            AND(TestAppointments.TestTypeID = @TestTypeID)
                            ORDER BY TestAppointments.TestAppointmentID desc";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null)
                {
                    IsFound = true;
                }
            }

            catch (Exception ex)
            {
                Logger.LogMessage(EventLogEntryType.Error, Logger.EventLogID.DL_ConnectionError, ex.Message, ""
                  , ex);
            }

            finally
            {
                connection.Close();
            }

            return IsFound;

        }

        // ✅en basitinden, kişinin sınav türünden kaç adet kaydı olduğunu gösterir. Result önemli değildir. sadece kayıt
        public static byte TotalTrialsPerTest(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            byte TotalTrialsPerTest = 0;

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = @" SELECT TotalTrialsPerTest = count(TestID)
                            FROM LocalDrivingLicenseApplications INNER JOIN
                                 TestAppointments ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID INNER JOIN
                                 Tests ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID
                            WHERE
                            (LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID) 
                            AND(TestAppointments.TestTypeID = @TestTypeID)
                       ";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && byte.TryParse(result.ToString(), out byte Trials))
                {
                    TotalTrialsPerTest = Trials;
                }
            }

            catch (Exception ex)
            {
                Logger.LogMessage(EventLogEntryType.Error, Logger.EventLogID.DL_ConnectionError, ex.Message, ""
                  , ex);

            }

            finally
            {
                connection.Close();
            }

            return TotalTrialsPerTest;

        }


        // ✅ LDLA ve test türü için DB'de aktif bir sınav var mı
        public static bool IsThereAnActiveScheduledTest(int LocalDrivingLicenseApplicationID, int TestTypeID)

        {

            bool Result = false;

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = @" SELECT top 1 Found=1
                            FROM LocalDrivingLicenseApplications INNER JOIN
                                 TestAppointments ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID 
                            WHERE
                            (LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID)  
                            AND(TestAppointments.TestTypeID = @TestTypeID) and isLocked=0
                            ORDER BY TestAppointments.TestAppointmentID desc";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();


                if (result != null)
                {
                    Result = true;
                }

            }

            catch (Exception ex)
            {
                Logger.LogMessage(EventLogEntryType.Error, Logger.EventLogID.DL_ConnectionError, ex.Message, ""
                  , ex);
            }

            finally
            {
                connection.Close();
            }

            return Result;

        }

    }
}
