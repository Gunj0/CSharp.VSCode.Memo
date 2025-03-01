using VSCode.Memo.UI.ViewModels;

namespace VSCode.Memo.UI.Views
{
    public class WeatherLatestView
    {
        private WeatherLatestViewModel _viewModel = new WeatherLatestViewModel();

        public void Display()
        {
            // 初期表示
            Console.WriteLine($"{_viewModel.AreaIdText} {_viewModel.DataDateText} {_viewModel.ConditionText} {_viewModel.TemperatureText}");

            // AreaId:1で検索
            _viewModel.AreaIdText = "1";
            _viewModel.Search();
            Console.WriteLine($"{_viewModel.AreaIdText} {_viewModel.DataDateText} {_viewModel.ConditionText} {_viewModel.TemperatureText}");

            // AreaId:2で検索
            _viewModel.AreaIdText = "2";
            _viewModel.Search();
            Console.WriteLine($"{_viewModel.AreaIdText} {_viewModel.DataDateText} {_viewModel.ConditionText} {_viewModel.TemperatureText}");

        }

    }
}