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

		public List<Employee> GetEmployeesByParams(string pFirstName)
		{
			List<Employee> employees = new List<Employee>();
			try
			{
				using (con = new SqlConnection(conString))
				{
					con.Open();
					com = new SqlCommand("sp_GetEmployees", con);
					com.CommandType = CommandType.StoredProcedure;
					if (!String.IsNullOrEmpty(pFirstName))
					{
						com.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = pFirstName;
					}

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

		public int UpdateEmployee(Employee emp)
		{
			int result = 0;
			try
			{
				using (con = new SqlConnection(conString))
				{
					con.Open();
					com = new SqlCommand("sp_UpdateEmployee", con);
					com.CommandType = CommandType.StoredProcedure;
					if (emp == null)
					{
						log.WriteToFile("Object can not be null");
					}
					else
					{
						if (emp.ID > 0)
						{
							com.Parameters.Add("@ID", SqlDbType.Int).Value = emp.ID;
						}
						if (!String.IsNullOrEmpty(emp.FirstName))
						{
							com.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = emp.FirstName;
						}
						else
						{
							log.WriteToFile($"FirstName can not null");
						}
						if (!String.IsNullOrEmpty(emp.LastName))
						{
							com.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = emp.LastName;
						}
						if (!String.IsNullOrEmpty(emp.Gender))
						{
							com.Parameters.Add("@Gender", SqlDbType.NVarChar).Value = emp.Gender;
						}
						if (emp.Salary > 0)
						{
							com.Parameters.Add("@Salary", SqlDbType.NVarChar).Value = emp.Salary;
						}
						result = com.ExecuteNonQuery();
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
			return result;
		}

		public Employee GetEmployeeByID(int ID)
		{
			Employee emp = new Employee();
			try
			{
				using (con = new SqlConnection(conString))
				{
					con.Open();
					com = new SqlCommand("sp_GetEmployeeByID", con);
					com.CommandType = CommandType.StoredProcedure;
					if (ID > 0)
					{
						com.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
					}
					else
					{
						log.WriteToFile($"{ID} not Valid");
					}

					using (SqlDataReader reader = com.ExecuteReader())
					{
						
						while (reader.Read())
						{							
							emp.ID = reader.GetInt32(0);
							emp.FirstName = reader.GetString(1);
							emp.LastName = reader.GetString(2);
							emp.Gender = reader.GetString(3);
							emp.Salary = reader.GetInt32(4);							
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
			return emp;
		}

		public int AddNewEmployee(Employee emp)
		{
			int result = 0;
			List<Employee> employees = new List<Employee>();
			try
			{

				using (con = new SqlConnection(conString))
				{
					con.Open();
					com = new SqlCommand("AddNewEmployee", con);
					com.CommandType = CommandType.StoredProcedure;
					if (!String.IsNullOrEmpty(emp.FirstName))
					{
						com.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = emp.FirstName;
					}
					else
					{
						log.WriteToFile($"FirstName can not Valid");
					}
					if (!String.IsNullOrEmpty(emp.LastName))
					{
						com.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = emp.LastName;
					}
					if (!String.IsNullOrEmpty(emp.Gender))
					{
						com.Parameters.Add("@Gender", SqlDbType.NVarChar).Value = emp.Gender;
					}
					if (emp.Salary > 0)
					{
						com.Parameters.Add("@Salary", SqlDbType.NVarChar).Value = emp.Salary;
					}
					result = com.ExecuteNonQuery();
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
			return result;
		}
	}
}