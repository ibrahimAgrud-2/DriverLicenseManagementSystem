using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_DataAccessLayer
{
    public class clsTestDataAccess
    {
        public static DataTable getTestRecords()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string sqlQuery = "select * from Tests";

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

        public static bool findTestByID(int testID, ref int testAppointmentID, ref int testResult,
            ref string notes, ref int createdByUserID)
        {
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = "select * from Tests where TestID = @testID";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@testID", testID);

            try
            {
                connection.Open();
                SqlDataReader read = cmd.ExecuteReader();

                if (read.Read())
                {
                    testAppointmentID = read["TestAppointmentID"] != DBNull.Value ? Convert.ToInt32(read["TestAppointmentID"]) : 0;
                    testResult = read["TestResult"] != DBNull.Value ? Convert.ToInt32(read["TestResult"]) : 0;
                    notes = read["Notes"] != DBNull.Value ? read["Notes"].ToString() : null;
                    createdByUserID = read["CreatedByUserID"] != DBNull.Value ? Convert.ToInt32(read["CreatedByUserID"]) : 0;

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


        public static bool isTestExist(int testID)
        {
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = "select found = 1 from Tests where TestID = @testID";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@testID", testID);

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
                return false;
            }
            finally
            {
                connection.Close();
            }

            return false;
        }

        public static int addTest(int testAppointmentID, int testResult, string notes, int createdByUserID)
        {
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = @"INSERT INTO Tests (TestAppointmentID, TestResult, Notes, CreatedByUserID) 
                     VALUES (@testAppointmentID, @testResult, @notes, @createdByUserID);
                   UPDATE TestAppointments 
                    SET IsLocked=1 where TestAppointmentID = @TestAppointmentID;

                     SELECT SCOPE_IDENTITY();";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@testAppointmentID", testAppointmentID);
            cmd.Parameters.AddWithValue("@testResult", testResult);
            cmd.Parameters.AddWithValue("@createdByUserID", createdByUserID);

            if (string.IsNullOrEmpty(notes))
                cmd.Parameters.AddWithValue("@notes", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@notes", notes);

            try
            {
                connection.Open();
                object result = cmd.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    return insertedID;
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

        public static bool updateTest(int testID, int testAppointmentID, int testResult, string notes)
        {
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = @"UPDATE Tests 
                     SET TestAppointmentID = @testAppointmentID,
                         TestResult = @testResult,
                         Notes = @notes
                     WHERE TestID = @testID";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@testID", testID);
            cmd.Parameters.AddWithValue("@testAppointmentID", testAppointmentID);
            cmd.Parameters.AddWithValue("@testResult", testResult);

            if (string.IsNullOrEmpty(notes))
                cmd.Parameters.AddWithValue("@notes", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@notes", notes);

            try
            {
                connection.Open();
                int affectedRowsNumber = cmd.ExecuteNonQuery();
                return (affectedRowsNumber == 1);
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        //--------------------------------------------------


        //ilgili LDLA için geçtiği sınav sayısı ✅
        public static int GetPassedTestCount(int LocalDrivingLicenseID)
        {
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            byte PassedTestCount = 0;

            string query = @"SELECT PassedTestCount = count(TestTypeID)
                         FROM Tests INNER JOIN
                         TestAppointments ON Tests.TestAppointmentID = TestAppointments.TestAppointmentID
						 where LocalDrivingLicenseApplicationID =@LocalDrivingLicenseApplicationID and TestResult=1";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseID);


            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && byte.TryParse(result.ToString(), out byte ptCount))
                {
                    PassedTestCount = ptCount;
                }
            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);

            }

            finally
            {
                connection.Close();
            }

            return PassedTestCount;
        }


        //Kişinin test türünden belli sınıfa göre test'i var mı kontrol eder. ✅
        public static bool GetLastTestByPersonAndTestTypeAndLicenseClass
                 (int PersonID, int LicenseClassID, int TestTypeID, ref int TestID,
                   ref int TestAppointmentID, ref bool TestResult,
                   ref string Notes, ref int CreatedByUserID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = @"SELECT  top 1 Tests.TestID, 
                Tests.TestAppointmentID, Tests.TestResult, 
			    Tests.Notes, Tests.CreatedByUserID, Applications.ApplicantPersonID
                FROM            LocalDrivingLicenseApplications INNER JOIN
                                         Tests INNER JOIN
                                         TestAppointments ON Tests.TestAppointmentID = TestAppointments.TestAppointmentID ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID INNER JOIN
                                           Applications ON LocalDrivingLicenseApplications.ApplicationID = Applications.ApplicationID
                WHERE        (Applications.ApplicantPersonID = @PersonID) 
                        AND (LocalDrivingLicenseApplications.LicenseClassID = @LicenseClassID)
                        AND ( TestAppointments.TestTypeID=@TestTypeID)
                ORDER BY Tests.TestAppointmentID DESC";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    // The record was found
                    isFound = true;
                    TestID = (int)reader["TestID"];
                    TestAppointmentID = (int)reader["TestAppointmentID"];
                    TestResult = (bool)reader["TestResult"];
                    if (reader["Notes"] == DBNull.Value)

                        Notes = "";
                    else
                        Notes = (string)reader["Notes"];

                    CreatedByUserID = (int)reader["CreatedByUserID"];

                }
                else
                {
                    // The record was not found
                    isFound = false;
                }

                reader.Close();


            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }




    }
}