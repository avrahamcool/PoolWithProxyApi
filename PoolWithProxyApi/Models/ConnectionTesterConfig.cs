using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace PoolWithProxyApi.Models
{
	public partial class Context : DbContext
	{
		public DbSet<ConnectionTesterModel> ConnectionTester { get; set; }

		private class DummyConfig : IEntityTypeConfiguration<ConnectionTesterModel>
		{
			public void Configure(EntityTypeBuilder<ConnectionTesterModel> builder)
			{
				builder.ToTable("CONNECTION_TESTER", "IIIIIIIII")
					.HasKey(d => d.Id);

				builder.Property(t => t.Id)
					.HasColumnName("ID")
					.ValueGeneratedOnAdd();

				builder.Property(t => t.InsertDate)
					.HasColumnName("INSERT_DATE")
					.ValueGeneratedOnAdd();

				builder.Property(t => t.UserName)
					.HasColumnName("USERNAME");
			}
		}
	}
}
