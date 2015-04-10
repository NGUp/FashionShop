using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace FashionShop.Models
{
    /// <summary>
    /// Support execute C.R.U.D with the database.
    /// </summary>
    public class Provider
    {
        /// <summary>
        /// The connection
        /// </summary>
        private SqlConnection connection;

        /// <summary>
        /// Open connection to Microsoft SQL Server.
        /// </summary>
        /// <returns>SqlConnection conection</returns>
        private SqlConnection openConnection()
        {
            if (this.connection == null)
            {
                this.connection = new SqlConnection("Server=.\\SQLEXPRESS;Database=FashionShop;Integrated Security=SSPI;");
            }

            if (this.connection.State == ConnectionState.Closed)
            {
                this.connection.Open();
            }

            return this.connection;
        }

        /// <summary>
        /// Close connection.
        /// </summary>
        private void closeConnection()
        {
            try
            {
                this.connection.Close();
            }
            catch (Exception exception)
            {
                throw exception;
            }
            
        }

        /// <summary>
        /// Execute Insert/Update/Delete.
        /// </summary>
        /// <param name="sql">T-SQL string</param>
        /// <returns>bool isSuccessful</returns>
        public bool executeNonQuery(string sql)
        {
            try
            {
                SqlCommand command = new SqlCommand(sql, this.openConnection());
                int state = command.ExecuteNonQuery();

                if (state == 1)
                {
                    return true;
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                this.closeConnection();
            }

            return false;
        }

        /// <summary>
        /// Get data from the database.
        /// </summary>
        /// <param name="sql">T-SQL string</param>
        /// <returns>DataTable data from database</returns>
        public DataTable executeQuery(string sql)
        {
            DataTable table = new DataTable();

            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(sql, this.openConnection());
                adapter.FillSchema(table, SchemaType.Mapped);
                adapter.Fill(table);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                this.closeConnection();
            }

            return table;
        }
    }
}