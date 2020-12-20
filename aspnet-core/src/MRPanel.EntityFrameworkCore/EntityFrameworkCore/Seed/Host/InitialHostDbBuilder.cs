namespace MRPanel.EntityFrameworkCore.Seed.Host
{
    public class InitialHostDbBuilder
    {
        private readonly MRPanelDbContext _context;

        public InitialHostDbBuilder(MRPanelDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            new DefaultEditionCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();
            new DefaultSiteSettingCreator(_context).Create();
            new DefaultSiteContentCreator(_context).Create();

            _context.SaveChanges();
        }
    }
}