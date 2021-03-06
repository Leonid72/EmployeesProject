using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace EmployeesWebAPI.DAL
{
	public class LogHandler
	{
		public void WriteToFile(string Message)
		{
			string path = AppDomain.CurrentDomain.BaseDirectory + "\\Logs";
			if (!Directory.Exists(path))
			{
				Directory.CreateDirectory(path);
			}
			string filepath = AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\ServiceLog_" + DateTime.Now.Date.ToShortDateString().Replace('/', '_') + ".txt";

			if (!File.Exists(filepath))
			{

				using (StreamWriter sw = File.CreateText(filepath))
				{
					sw.WriteLine(DateTime.Now + " : " + Message);
				}
			}
			else
			{
				using (StreamWriter sw = File.AppendText(filepath))
				{
					sw.WriteLine(DateTime.Now + " : " + Message);
				}
			}
		}
	}
}