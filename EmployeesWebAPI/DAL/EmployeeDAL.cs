using EmployeesWebAPI.Models;
using Microsoft.SqlServer.Server;
using System;
using System.Data;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EmployeesWebAPI.DAL
{
	public class EmployeeDAL
	{
		string conString = ConfigurationManager.ConnectionStrings["EmployeeConStr"].ToString();
		SqlConnection con;
		SqlCommand com;
		LogHandler log;
		public EmployeeDAL()
		{
			log = new LogHandler();
		}
		public List<Employee> GetEmployees()
		{
			List<Employee> employees = new List<Employee>();
			try
			{
				using (con = new SqlConnection(conString))
				{
					con.Open();
					com = new SqlCommand("sp_GetEmployees", con);
					com.CommandType = CommandType.StoredProcedure;
					using (SqlDataReader reader = com.ExecuteReader())
					{
						Employee emp;
						while (reader.Read())
						{
							emp = new Employee();
							emp.ID = reader.GetInt32(0);
							emp.FirstName = reader.GetString(1);
							emp.LastName = reader.GetString(2);
							emp.Gender = reader.GetString(3);
							emp.Salary = reader.GetInt32(4);
							employees.Add(emp);
						}
					}
					con.Close();
				}
			}
			catch (Exception ex)
			{
				log.WriteToFile(ex.Message);

			}
			finally
			{
				if (con.State == ConnectionState.Open)
				{
					con.Close();
				}
			}
			return employees;
		}
	}
}