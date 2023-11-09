using System.Configuration;
using System.Threading;
using System.Web.Http;

using Microsoft.EntityFrameworkCore;

using PoolWithProxyApi.Models;

namespace PoolWithProxyApi.Controllers
{
	public class ConnectionTesterController : ApiController
	{
		public string Post(string username)
		{
			string connectionString = string.Format(ConfigurationManager.AppSettings["ProxyConnectionString"], username);

			DbContextOptionsBuilder<Context> optionBuilder = new DbContextOptionsBuilder<Context>()
				.UseOracle(connectionString);

			using Context context = new(optionBuilder.Options);

			context.Database.BeginTransaction();

			context.ConnectionTester.Add(new ConnectionTesterModel()
			{
				UserName = username
			});

			context.SaveChanges();

			Thread.Sleep(1000);

			context.Database.CommitTransaction();

			return "Ok";
		}
	}
}
