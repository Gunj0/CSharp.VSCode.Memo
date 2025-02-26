namespace VSCode.Memo.Domain.ValueObjects
{
    // ValueObjectの基底クラス
    // ValueObjectを継承するクラスは、自身の型を指定する
    public abstract class ValueObject<T> where T : ValueObject<T>
    {
        // 別インスタンスでも値が同じであれば同じとみなす①
        public override bool Equals(object? obj)
        {
            if (obj == null)
            {
                return false;
            }
            var vo = obj as T;
            if (vo == null)
            {
                return false;
            }
            return EqualsCore(vo);
            // こちらでも可
            // objがTemperature方ならtemperatureに代入し、Valueが等しいか判定
            // return obj is Temperature temperature &&
            //        Value == temperature.Value;

        }

        // 別インスタンスでも値が同じであれば同じとみなす②
        public static bool operator ==(ValueObject<T> vo1, ValueObject<T> vo2)
        {
            return vo1.Equals(vo2);
        }

        // ==は同時に!=も実装する
        public static bool operator !=(ValueObject<T> vo1, ValueObject<T> vo2)
        {
            return !vo1.Equals(vo2);
        }

        // 継承先でイコール判定を実装する
        protected abstract bool EqualsCore(T other);

        // これは警告が出るので書いただけ
        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}