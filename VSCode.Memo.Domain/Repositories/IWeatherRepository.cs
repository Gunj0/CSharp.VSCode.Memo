using VSCode.Memo.Domain.Dtos;

namespace VSCode.Memo.Domain.Repositories
{
    public interface IWeatherRepository
    {
        WeatherDto GetLatest(int areaId);
    }
}