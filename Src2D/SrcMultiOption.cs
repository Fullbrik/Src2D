using System;
using System.Collections.Generic;
using System.Text;

namespace Src2D
{
    public abstract class SrcMultiOption
    {
        public virtual string Value { get; set; }

        public abstract string[] GetOptions();
    }

    public class SrcEnum<T> : SrcMultiOption
        where T : Enum
    {
        public T EnumValue { get; set; }

        public override string Value { get => EnumValue.ToString(); set => EnumValue = (T)Enum.Parse(typeof(T), value); }

        public static implicit operator SrcEnum<T>(T enm) => new SrcEnum<T>(enm);

        public SrcEnum(){}
        public SrcEnum(T enm)
        {
            EnumValue = enm;
        }

        public override string[] GetOptions()
        {
            return Enum.GetNames(typeof(T));
        }
    }
}
