using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccessLayer
{
    public class ApplicationTypesDataAccess
    {

        public static DataTable getApplicationTypesRecords()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);
            string sqlQuery = "select * from applicationTypes";

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

        public static bool findApplicationType(int applicationTypeID, ref string applicationTypeTitle, ref double ApplicationFees)
        {
            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);

            string query = "select * from applicationTypes where applicationTypeID=@applicationTypeID";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@applicationTypeID", applicationTypeID);

            try
            {
                connection.Open();
                SqlDataReader read = cmd.ExecuteReader();

                if (read.Read())
                {
                    applicationTypeID = Convert.ToInt32(read["applicationTypeID"]);
                    applicationTypeTitle = read["applicationTypeTitle"].ToString();
                    ApplicationFees = Convert.ToDouble(read["ApplicationFees"]);


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

        public static bool isApplicationTypeExists(string applicationTypeTitle)
        {
            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);
            bool isFound = false;

            string query = "select found =1 from applicationTypes where applicationTypeTitle=@applicationTypeTitle";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@applicationTypeTitle", applicationTypeTitle);


            try
            {
                connection.Open();


                SqlDataReader read = cmd.ExecuteReader();
                isFound = read.HasRows;
                read.Close();
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
        public static bool UpdateApplicationType(int applicationTypeID,  string applicationTypeTitle,  double ApplicationFees)
        {

            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);

            string query = @"Update  applicationTypes  
                            set applicationTypeTitle = @applicationTypeTitle,
                                ApplicationFees = @ApplicationFees
                                where applicationTypeID = @applicationTypeID";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@applicationTypeID", applicationTypeID);
            cmd.Parameters.AddWithValue("@applicationTypeTitle", applicationTypeTitle);
            cmd.Parameters.AddWithValue("@ApplicationFees", ApplicationFees);



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

    }
}
