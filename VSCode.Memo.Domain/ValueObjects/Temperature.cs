using VSCode.Memo.Domain.Helpers;

namespace VSCode.Memo.Domain.ValueObjects
{
    // バリューオブジェクト
    // …テーブルのカラムに対応する
    public sealed class Temperature : ValueObject<Temperature>
    {
        public const string UnitName = "℃";

        public const int DecimalPoint = 1;

        public Temperature(float value)
        {
            Value = value;
        }

        // 完全コストラクタパターン
        // …初期化時にのみセットされるので、不具合が混入しにくくなる
        public float Value { get; }

        // 値に対するロジック①
        public string DisplayValue
        {
            get
            {
                // 拡張メソッドを使った形
                return Value.RoundString(DecimalPoint);
                // 以下と同じ意味
                // return FloatHelper.RoundString(Value, DecimalPoint);
            }
        }

        // 値に対するロジック②
        public string DisplayValueWithUnit
        {
            get
            {
                // 拡張メソッドを使った形
                return Value.RoundString(DecimalPoint) + UnitName;
                // 以下と同じ意味
                // return FloatHelper.RoundString(Value, DecimalPoint) + UnitName;
            }
        }

        // バリューオブジェクトの等価性は値によって判断する
        protected override bool EqualsCore(Temperature other)
        {
            return Value == other.Value;
        }
    }
}
