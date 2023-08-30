using DemoApp.Core.IConfiguration;
using DemoApp.Core.Repository;

namespace DemoApp.Data;
public class UnitOfWork: IUnitOfWork,IDisposable
{
    private readonly ApiDbContext _appDbContext;
    public DriverRepository Drivers {get;}
    public ILogger<IUnitOfWork> logger { get;}

    public UnitOfWork(ApiDbContext appDbContext,ILogger<IUnitOfWork> logger)
    {
        _appDbContext = appDbContext;
        this.logger = logger;
        Drivers = new DriverRepository(appDbContext,logger);
    }
    public async Task CompleteAsyn()
    {
        await _appDbContext.SaveChangesAsync();
    }

    public void Dispose()
    {
        _appDbContext.Dispose();
    }
}