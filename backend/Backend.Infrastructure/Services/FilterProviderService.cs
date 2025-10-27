namespace Backend.Infrastructure.Services;

// TODO: DELETE THIS FILE
public class FilterProviderService
{
    // public CpuFilters GetCpuFilters()
    // {
    //     return new CpuFilters
    //     {
    //         BrandNames = GetBrands<Cpu>(),
    //         Cores = [4, 6, 8, 10, 12, 14, 16, 20, 24],
    //         Threads = [8, 12, 16, 20, 24, 28, 32],
    //         Socket = Enum.GetNames<Socket>().ToList(),
    //         Tdp = new Range<int>(50, 250),
    //         BaseClockSpeed = new Range<double>(1.0, 10.0),
    //         BoostClockSpeed = new Range<double>(1.0, 10.0)
    //     };
    // }
    //
    // public SsdFilters GetSsdFilters()
    // {
    //     return new SsdFilters
    //     {
    //         BrandNames = GetBrands<Ssd>(),
    //         CapacityInGb = new Range<int>(1000, 5000),
    //         StorageInterfaces = Enum.GetNames<StorageInterface>().ToList(),
    //         ReadSpeed = new Range<int>(1000, 10000),
    //         WriteSpeed = new Range<int>(1000, 10000)
    //     };
    // }
    //
    // private List<string> GetBrands<T>() where T : ProductBase
    //     => context.Set<T>().Include(entity => entity.Brand).Select(entity => entity.Brand.BrandName).Distinct().ToList();
}