using VSCode.Memo.Domain.Entities;

namespace VSCode.Memo.Domain.Repositories
{
    public interface IWeatherRepository
    {
        WeatherEntity? GetLatest(int areaId);
    }
}