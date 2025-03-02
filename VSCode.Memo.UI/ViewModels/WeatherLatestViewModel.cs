using VSCode.Memo.Domain.Entities;
using VSCode.Memo.Domain.Exceptions;
using VSCode.Memo.Domain.Repositories;
using VSCode.Memo.Infrastructure.Sqlite;

namespace VSCode.Memo.UI.ViewModels
{
    public class WeatherLatestViewModel
    {
        private readonly IWeatherRepository _weatherRepository;
        private readonly IAreaRepository _areaRepository;

        // 引数がなければSqliteを使う
        public WeatherLatestViewModel() : this(new WeatherSqlite(), new AreaSqlite())
        {
        }

        // 引数があればそれを使う
        public WeatherLatestViewModel(IWeatherRepository weatherRepository, IAreaRepository areaRepository)
        {
            _weatherRepository = weatherRepository;
            _areaRepository = areaRepository;

            foreach (var area in _areaRepository.GetData())
            {
                Areas.Add(area);
            }
        }

        public string? AreaIdText { get; set; } = string.Empty;
        public string? DataDateText { get; set; } = string.Empty;
        public string? ConditionText { get; set; } = string.Empty;
        public string? TemperatureText { get; set; } = string.Empty;
        public List<AreaEntity> Areas { get; set; } = new List<AreaEntity>();

        public void Search()
        {
            if (Convert.ToInt32(AreaIdText) < 0)
            {
                throw new InputException("エリアIDは0以上の数値を入力してください");
            }

            var entity = _weatherRepository.GetLatest(Convert.ToInt32(AreaIdText));
            if (entity != null)
            {
                DataDateText = entity.DataDate.ToString("yyyy/MM/dd");
                ConditionText = entity.Condition.DisplayValue;
                TemperatureText = entity.Temperature.DisplayValueWithUnit;
            }
        }
    }
}
