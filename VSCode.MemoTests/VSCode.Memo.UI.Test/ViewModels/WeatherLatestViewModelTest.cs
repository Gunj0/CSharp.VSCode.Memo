using VSCode.Memo.Domain.Dtos;
using VSCode.Memo.Domain.Repositories;
using VSCode.Memo.UI.ViewModels;

namespace VSCode.Memo.UI.Test
{
    [TestClass]
    public class ViewModelTest
    {


        [TestMethod]
        public void シナリオ()
        {
            var viewModel = new WeatherLatestViewModel(new WeatherMock());

            // 初期値は空文字
            Assert.AreEqual("", viewModel.AreaIdText);
            Assert.AreEqual("", viewModel.DataDateText);
            Assert.AreEqual("", viewModel.ConditionText);
            Assert.AreEqual("", viewModel.TemperatureText);

            // 1を入れて検索ボタンを押すと1のデータが返ってくる
            viewModel.AreaIdText = "1";
            viewModel.Search();
            Assert.AreEqual("1", viewModel.AreaIdText);
            Assert.AreEqual("2021/01/01", viewModel.DataDateText);
            Assert.AreEqual("1", viewModel.ConditionText);
            Assert.AreEqual("1.00℃", viewModel.TemperatureText);

        }
    }

    class WeatherMock : IWeatherRepository
    {
        public WeatherDto GetLatest(int areaId)
        {
            if (areaId == 1)
            {
                return new WeatherDto
                {
                    AreaId = 1,
                    DataDate = new DateTime(2021, 1, 1),
                    Condition = 1,
                    Temperature = 1.0f
                };
            }
            else if (areaId == 2)
            {
                return new WeatherDto
                {
                    AreaId = 2,
                    DataDate = new DateTime(2021, 1, 2),
                    Condition = 2,
                    Temperature = 2.0f
                };
            }
            else
            {
                return new WeatherDto
                {
                    AreaId = 3,
                    DataDate = new DateTime(2021, 1, 3),
                    Condition = 3,
                    Temperature = 3.0f
                };
            }
        }
    }
}
