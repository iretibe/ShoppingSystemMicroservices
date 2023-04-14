using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace Ordering.Infrastructure.Persistence
{
	public class OrderContextFactory: IDesignTimeDbContextFactory<OrderContext>
	{
		public OrderContext CreateDbContext(string[] args)
		{
			var optionsBuilder = new DbContextOptionsBuilder<OrderContext>();
			
			optionsBuilder.UseSqlServer("Server=PSL-SWD10\\SQL2022;Database=OrderDb;User ID=sa;Password=Persol@2023;Trusted_Connection=False;MultipleActiveResultSets=true;TrustServerCertificate=True");

			return new OrderContext(optionsBuilder.Options);
		}
	}
}