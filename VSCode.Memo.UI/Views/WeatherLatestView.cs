using VSCode.Memo.Infrastructure;
using VSCode.Memo.UI.ViewModels;

var weather = new WeatherSqlite();
var viewModel = new WeatherLatestViewModel(weather);
Console.WriteLine($"{viewModel.AreaIdText} {viewModel.DataDateText} {viewModel.ConditionText} {viewModel.TemperatureText}");

