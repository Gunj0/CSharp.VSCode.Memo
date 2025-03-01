using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VSCode.Memo.Domain.ValueObjects
{
    public sealed class Condition : ValueObject<Condition>
    {
        // 区分の場合のValueObjectの実装

        /// <summary>
        /// 不明
        /// </summary>
        public static readonly Condition None = new Condition(0);

        /// <summary>
        /// 晴れ
        /// </summary>
        public static readonly Condition Sunny = new Condition(1);

        /// <summary>
        /// 曇り
        /// </summary>
        public static readonly Condition Cloudy = new Condition(2);

        /// <summary>
        /// 雨
        /// </summary>
        public static readonly Condition Rain = new Condition(3);

        public Condition(int value)
        {
            Value = value;
        }

        public int Value { get; }

        public string DisplayValue
        {
            get
            {
                // ValueObjectなのでValueの等価性で判断できる
                if (this == None)
                {
                    return "不明";
                }
                else if (this == Sunny)
                {
                    return "晴れ";
                }
                else if (this == Cloudy)
                {
                    return "曇り";
                }
                else if (this == Rain)
                {
                    return "雨";
                }
                else
                {
                    return "不明";
                }
            }
        }

        protected override bool EqualsCore(Condition other)
        {
            return Value == other.Value;
        }
    }
}