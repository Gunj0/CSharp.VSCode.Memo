namespace VSCode.Memo.Domain.Helpers
{
    public static class FloatHelper
    {
        // 引数にthisをつけると、その型のインスタンスに対してメソッドを追加できる
        // これを拡張メソッドという
        public static string RoundString(this float value, int decimalPoint)
        {
            var temp = Convert.ToSingle(Math.Round(value, decimalPoint));
            return temp.ToString($"F{decimalPoint}");
        }
    }
}