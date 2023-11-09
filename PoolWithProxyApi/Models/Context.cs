using System.Diagnostics.Contracts;
using System.Linq;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;


namespace PoolWithProxyApi.Models
{
	public partial class Context : DbContext
	{
		public Context(DbContextOptions<Context> options) : base(options) { }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			Contract.Requires(modelBuilder != null);

			modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

			foreach (IMutableProperty property in modelBuilder.Model.GetEntityTypes().SelectMany(t => t.GetProperties()))
			{
				if (!property.IsUnicode().HasValue)
				{
					property.SetIsUnicode(false);
				}
			}
		}
	}
}
