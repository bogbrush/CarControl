using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace CarControl2.Controllers
{
	public class Helper
	{
		public static bool HasPermission()
		{
			if (CurrentUsername() == "steven")
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		private static string CurrentUsername()
		{
			HttpContext httpContext = HttpContext.Current;

			string authHeader = httpContext.Request.Headers["Authorization"];
			string username;

			if (authHeader != null && authHeader.StartsWith("Basic"))
			{
				string encodedUsernamePassword = authHeader.Substring("Basic ".Length).Trim();
				Encoding encoding = Encoding.GetEncoding("iso-8859-1");
				string usernamePassword = encoding.GetString(Convert.FromBase64String(encodedUsernamePassword));

				int seperatorIndex = usernamePassword.IndexOf(':');

				username = usernamePassword.Substring(0, seperatorIndex);
			}
			else
			{
				//Handle what happens if that isn't the case
				throw new Exception("The authorization header is either empty or isn't Basic.");
			}

			return username;
		}
	}
}