namespace VSCode.Memo.Domain.Helpers
{
    public static class FloatHelper
    {
        public static string RoundString(float value, int decimalPoint)
        {
            var temp = Convert.ToSingle(Math.Round(value, decimalPoint));
            return temp.ToString($"F{decimalPoint}");
        }
    }
}