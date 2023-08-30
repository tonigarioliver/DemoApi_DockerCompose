using DemoApp.Core.Repository;

namespace DemoApp.Core.IConfiguration;

public interface IUnitOfWork
{
    public DriverRepository Drivers {get;}
    public ILogger<IUnitOfWork> logger {get; }
    Task CompleteAsyn();
}