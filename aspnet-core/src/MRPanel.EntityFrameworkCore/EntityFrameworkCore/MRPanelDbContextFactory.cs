using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using MRPanel.Configuration;
using MRPanel.Web;

namespace MRPanel.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class MRPanelDbContextFactory : IDesignTimeDbContextFactory<MRPanelDbContext>
    {
        public MRPanelDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<MRPanelDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            MRPanelDbContextConfigurer.Configure(builder, configuration.GetConnectionString(MRPanelConsts.ConnectionStringName));

            return new MRPanelDbContext(builder.Options);
        }
    }
}
