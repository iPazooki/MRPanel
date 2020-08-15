using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace MRPanel.EntityFrameworkCore
{
    public static class MRPanelDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<MRPanelDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<MRPanelDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
