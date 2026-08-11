using System;
using Common;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace DVLD_DataAccessLayer
{
    public class ApplicationsDataAccess
    {

   
        public static DataTable getApplicationsRecord()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string sqlQuery = "select * from applications";

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



            }
            finally
            {
                connection.Close();
            }



            return dt;
        }

    
        public static bool findApplication(int applicationID, ref int applicantPersonID, ref DateTime ApplicationDate, ref int applicationTypeID, ref
           byte applicationStatus, ref DateTime LastStatusDate,ref double paidFee,ref int createdByUserID)
        {
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = "select * from applications where ApplicationID=@applicationID";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@applicationID", applicationID);

            try
            {
                connection.Open();
                SqlDataReader read = cmd.ExecuteReader();

                if (read.Read())
                {
                    applicationID = Convert.ToInt32(read["applicationID"]);
                    applicantPersonID =Convert.ToInt32(read["applicantPersonID"]);
                    ApplicationDate = Convert.ToDateTime(read["ApplicationDate"]);
                    applicationTypeID = Convert.ToInt32(read["applicationTypeID"]);
                    applicationStatus = Convert.ToByte(read["applicationStatus"]);
                    LastStatusDate = Convert.ToDateTime(read["LastStatusDate"]);
                    paidFee = Convert.ToDouble(read["paidFees"]);
                    createdByUserID = Convert.ToInt32(read["createdByUserID"]);

                    return true;
                }

            }
            catch (Exception)
            {
               
            }
            finally
            {
                connection.Close();

            }

            return false;
        }
    

        public static bool isApplicationExistByID(int applicationID)
        {
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            //bu sorgunun soncu: eğer kayıt varsa bir sütun oluşur adı found ve sütun tek satırlı olur (çünkü her ID bir adet olduğu için) satırda 1 yazar. Bu demek oluyor ki bu ID var.

            string query = "select found =1 from applications where applicationID=@applicationID";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@applicationID", applicationID);


            try
            {
                connection.Open();

                //Sorgu sonucu bir sayı geldiyse (ID tek olduğu için sadece bir adet sayı gelir eğer ID varsa) bu demektir ki o ID sistemde var. sayı dışında bir şey gelirse bu demek oluyor ki o kişi sistemde yok.

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



        public static int addApplication(int ApplicantPersonID, DateTime ApplicationDate, int ApplicationTypeID,
                 byte ApplicationStatus, DateTime LastStatusDate,
                 double PaidFees, int CreatedByUserID)
        {

            //this function will return the new person id if succeeded and -1 if not.
            int ApplicationID = -1;

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = @"INSERT INTO Applications ( 
                                ApplicantPersonID,ApplicationDate,ApplicationTypeID,
                                ApplicationStatus,LastStatusDate,
                                PaidFees,CreatedByUserID)
                                 VALUES (@ApplicantPersonID,@ApplicationDate,@ApplicationTypeID,
                                          @ApplicationStatus,@LastStatusDate,
                                          @PaidFees,   @CreatedByUserID);
                                 SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("ApplicantPersonID", @ApplicantPersonID);
            command.Parameters.AddWithValue("ApplicationDate", @ApplicationDate);
            command.Parameters.AddWithValue("ApplicationTypeID", @ApplicationTypeID);
            command.Parameters.AddWithValue("ApplicationStatus", @ApplicationStatus);
            command.Parameters.AddWithValue("LastStatusDate", @LastStatusDate);
            command.Parameters.AddWithValue("PaidFees", @PaidFees);
            command.Parameters.AddWithValue("CreatedByUserID", @CreatedByUserID);




            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    ApplicationID = insertedID;
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


            return ApplicationID;

        }
       


        public static bool updateApplicationInfo(int applicationID,int applicantPersonID, DateTime ApplicationDate, int applicationTypeID,
           byte applicationStatus, DateTime LastStatusDate, double paidFees, int createdByUserID)
        {

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = "update applications set applicantPersonID=@applicantPersonID,ApplicationDate=@ApplicationDate,applicationTypeID=@applicationTypeID,applicationStatus= @applicationStatus,LastStatusDate=@LastStatusDate,paidFees=@paidFees,createdByUserID=@createdByUserID where applicationID=@applicationID";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@applicationID", applicationID);

            cmd.Parameters.AddWithValue("@applicantPersonID", applicantPersonID);
            cmd.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);
            cmd.Parameters.AddWithValue("@applicationTypeID", applicationTypeID);
            cmd.Parameters.AddWithValue("@applicationStatus", applicationStatus);
            cmd.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
            cmd.Parameters.AddWithValue("@paidFees", paidFees);
            cmd.Parameters.AddWithValue("@createdByUserID", createdByUserID);



            try
            {
                connection.Open();
                //affectedRowsNumber==1 çünkü her seferinde sadece 1 satır günnceleyebiliriz onun dışındaki tüm durumlar beklenmedik durum.
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


        public static bool deleteApplication(int applicationID)
        {


            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = "delete applications where applicationID=@applicationID";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@applicationID", applicationID);


            try
            {
                connection.Open();

                //Sorgu sonucu bir sayı geldiyse (ID tek olduğu için sadece bir adet sayı gelir eğer ID varsa) bu demektir ki o ID sistemde var. sayı dışında bir şey gelirse bu demek oluyor ki o kişi sistemde yok.

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



        public static int GetActiveApplicationIDForLicenseClass(int ApplicantPersonID, int LicenseClassID, int ApplicationTypeID)
        {

            int ActiveApplicationID = -1;

            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = @"SELECT ActiveApplicationID=Applications.ApplicationID  
                            From
                            Applications INNER JOIN
                            LocalDrivingLicenseApplications ON Applications.ApplicationID = LocalDrivingLicenseApplications.ApplicationID
                            WHERE ApplicantPersonID = @ApplicantPersonID 
                            and ApplicationTypeID=@ApplicationTypeID 
							and LocalDrivingLicenseApplications.LicenseClassID = @LicenseClassID
                            and ApplicationStatus=1";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
            command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();


                if (result != null && int.TryParse(result.ToString(), out int AppID))
                {
                    ActiveApplicationID = AppID;
                }
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                return ActiveApplicationID;
            }
            finally
            {
                connection.Close();
            }

            return ActiveApplicationID;
        }
        public static bool updateStatus(int applicationID, short status)
        {
            SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString);
            string query = @"Update  Applications  
                                set 
                                    ApplicationStatus = @NewStatus, 
                                    LastStatusDate = @LastStatusDate
                                where ApplicationID=@ApplicationID;";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@applicationID", applicationID);
            cmd.Parameters.AddWithValue("@status", status);
            cmd.Parameters.AddWithValue("@LastStatusDate", DateTime.Now);


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

    }

}
