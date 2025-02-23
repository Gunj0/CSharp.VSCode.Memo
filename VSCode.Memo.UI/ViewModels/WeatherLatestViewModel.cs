using VSCode.Memo.Domain.Repositories;
using VSCode.Memo.UI.Common;
using VSCode.Memo.UI.Data;

namespace VSCode.Memo.UI.ViewModels
{
    public class WeatherLatestViewModel
    {
        private IWeatherRepository _weatherRepository;

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
            var dto = _weatherRepository.GetLatest(Convert.ToInt32(AreaIdText));
            if (dto != null)
            {
                AreaIdText = dto.AreaId.ToString();
                DataDateText = dto.DataDate.ToString("yyyy/MM/dd");
                ConditionText = dto.Condition.ToString();
                TemperatureText = CommonFunc.RoundString(
                    dto.Temperature, CommonConst.TemperatureDecimalPoint)
                    + CommonConst.TemperatureUnitName;
            }
        }
    }
}
