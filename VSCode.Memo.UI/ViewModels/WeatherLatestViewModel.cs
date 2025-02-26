using VSCode.Memo.Domain.Common;
using VSCode.Memo.Domain.Repositories;
using VSCode.Memo.Domain.ValueObjects;

namespace VSCode.Memo.UI.ViewModels
{
    public class WeatherLatestViewModel
    {
        private readonly IWeatherRepository _weatherRepository;

        public WeatherLatestViewModel(IWeatherRepository weatherRepository)
        {
            _weatherRepository = weatherRepository;
        }

        public string? AreaIdText { get; set; } = string.Empty;
        public string? DataDateText { get; set; } = string.Empty;
        public string? ConditionText { get; set; } = string.Empty;
        public string? TemperatureText { get; set; } = string.Empty;

        public void Search()
        {
            var entity = _weatherRepository.GetLatest(Convert.ToInt32(AreaIdText));
            if (entity != null)
            {
                DataDateText = entity.DataDate.ToString("yyyy/MM/dd");
                ConditionText = entity.Condition.ToString();
                TemperatureText = entity.Temperature.DisplayValueWithUnit;
            }
        }
    }
}
