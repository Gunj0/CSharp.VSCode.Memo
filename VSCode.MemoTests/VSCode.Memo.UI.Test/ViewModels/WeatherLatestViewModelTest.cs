using Moq;
using VSCode.Memo.Domain.Entities;
using VSCode.Memo.Domain.Exceptions;
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
            // モックを(Moq)使う
            var weatherMock = new Mock<IWeatherRepository>();
            weatherMock.Setup(x => x.GetLatest(1)).Returns(new WeatherEntity(1, new DateTime(2021, 1, 1), 2, 1.0f));
            weatherMock.Setup(x => x.GetLatest(2)).Returns(new WeatherEntity(2, new DateTime(2022, 1, 1), 1, 1.0f));
            weatherMock.Setup(x => x.GetLatest(3)).Returns(new WeatherEntity(3, new DateTime(2023, 1, 1), 3, 1.0f));

            var areaMock = new Mock<IAreaRepository>();
            var areas = new List<AreaEntity>
            {
                new AreaEntity(1, "東京"),
                new AreaEntity(2, "大阪"),
                new AreaEntity(3, "札幌"),
            };
            areaMock.Setup(x => x.GetData()).Returns(areas);

            var viewModel = new WeatherLatestViewModel(weatherMock.Object, areaMock.Object);

            // 初期値は空文字
            Assert.AreEqual("", viewModel.AreaIdText);
            Assert.AreEqual("", viewModel.DataDateText);
            Assert.AreEqual("", viewModel.ConditionText);
            Assert.AreEqual("", viewModel.TemperatureText);
            // コンボボックスの選択肢は3つ
            Assert.AreEqual(3, viewModel.Areas.Count);
            Assert.AreEqual("東京", viewModel.Areas[0].AreaName);
            Assert.AreEqual("大阪", viewModel.Areas[1].AreaName);
            Assert.AreEqual("札幌", viewModel.Areas[2].AreaName);

            // 1を入れて検索ボタンを押すと1のデータが返ってくる
            viewModel.AreaIdText = "1";
            viewModel.Search();
            Assert.AreEqual("1", viewModel.AreaIdText);
            Assert.AreEqual("2021/01/01", viewModel.DataDateText);
            Assert.AreEqual("曇り", viewModel.ConditionText);
            Assert.AreEqual("1.0℃", viewModel.TemperatureText);
        }

        [TestMethod]
        public void エリアIDが空文字の場合は例外が発生する()
        {
            var weatherMock = new Mock<IWeatherRepository>();
            var areaMock = new Mock<IAreaRepository>();
            areaMock.Setup(x => x.GetData()).Returns(new List<AreaEntity>());
            var viewModel = new WeatherLatestViewModel(weatherMock.Object, areaMock.Object);

            viewModel.AreaIdText = "-1";

            // 例外が発生することを確認
            var ex = Assert.ThrowsExactly<InputException>(() => viewModel.Search());
            // メッセージが正しいことを確認
            Assert.AreEqual("エリアIDは0以上の数値を入力してください", ex.Message);
        }
    }
}
