using VSCode.Memo.Domain.Entities;
using VSCode.Memo.Domain.Repositories;
using VSCode.Memo.UI.ViewModels;

namespace VSCode.Memo.UI.Test
{
    [TestClass]
    public class WeatherLatestViewModelTest
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
        public WeatherEntity GetLatest(int areaId)
        {
            if (areaId == 1)
            {
                return new WeatherEntity(1, new DateTime(2021, 1, 1), 1, 1.0f);
            }
            else if (areaId == 2)
            {
                return new WeatherEntity(2, new DateTime(2021, 1, 2), 2, 2.0f);
            }
            else
            {
                return new WeatherEntity(3, new DateTime(2021, 1, 3), 3, 3.0f);
            }
        }
    }
}
