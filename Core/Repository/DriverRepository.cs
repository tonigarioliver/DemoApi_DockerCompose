using DemoApp.Models;
using DemoApp.Data;

namespace DemoApp.Core.Repository;

public class DriverRepository:GenericRespository<Driver>
{
    public DriverRepository(ApiDbContext apiDbContext,ILogger logger):base(apiDbContext, logger)
    {
    }
}