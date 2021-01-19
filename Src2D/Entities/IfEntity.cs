using Src2D.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Src2D.Entities
{
    [SrcEntity("logic_if",
        Description = "An entity that compares two values, and emits the output.",
        Icon = "EntityIcons/logic_if", UseEditorAsset = true)]
    [Gizmo("Position2d")]
    public class IfEntity : BaseEntity
    {
        public enum CompareAsType
        {
            String,
            Int,
            Float,
            Bool
        }

        public enum IfCompareType
        {
            Equals,
            LessThan,
            GreaterThan,
            And,
            Or
        }

        [SrcProperty("A", Description = "The first value to compare as.")]
        public string A { get; set; } = "";
        [SrcProperty("B", Description = "The first value to compare as.")]
        public string B { get; set; } = "";

        [SrcProperty("CompareAs", DefaultValue = CompareAsType.String, Description = "What to compare A and B as.")]
        public SrcEnum<CompareAsType> CompareAs { get; set; } = CompareAsType.String;

        [SrcProperty("CompareType", DefaultValue = IfCompareType.Equals, Description = "The way to compare A and B. You can only use Less than or Greater than if you compare as a number type.")]
        public SrcEnum<IfCompareType> CompareType { get; set; } = IfCompareType.Equals;

        [SrcEvent("OnCompare", Description = "After calling the Compare action, execute this action.", ExportsParam = true, ParamType = Data.EventParamType.Bool)]
        public event SrcEvent OnCompare;

        [SrcEvent("OnTrue", Description = "After calling the Compare action, execute this action if it's true.", ExportsParam = false)]
        public event SrcEvent OnTrue;

        [SrcEvent("OnFalse", Description = "After calling the Compare action, execute this action if it's false.", ExportsParam = false)]
        public event SrcEvent OnFalse;

        [SrcAction("SetA", Description = "Set A.", HasParam = true, ParamType = Data.EventParamType.String)]
        public void SetA(string param)
        {
            A = param;
        }

        [SrcAction("SetB", Description = "Set B.", HasParam = true, ParamType = Data.EventParamType.String)]
        public void SetB(string param)
        {
            B = param;
        }

        [SrcAction("Compare", HasParam = false, Description = "Run the comparison.")]
        public void Compare(string param)
        {
            bool value = Compare();
            OnCompare?.Invoke(value.ToString());
            if(value) OnTrue?.Invoke("");
            else OnFalse?.Invoke("");
        }

        public bool Compare()
        {
            switch (CompareAs.EnumValue)
            {
                case CompareAsType.String:
                    if (CompareType.EnumValue == IfCompareType.Equals)
                    {
                        return A == B;
                    }
                    else
                    {
                        throw new Exception($"Can only use Equals to compare A and B when comparing as strings.");
                    }
                case CompareAsType.Int:
                    {
                        if (int.TryParse(A, out int a) && int.TryParse(B, out int b))
                        {
                            switch (CompareType.EnumValue)
                            {
                                case IfCompareType.Equals:
                                    return a == b;
                                case IfCompareType.LessThan:
                                    return a < b;
                                case IfCompareType.GreaterThan:
                                    return a > b;
                                default:
                                    throw new Exception($"Can only use Equals, Greater than, or Less than to compare A and B when comparing as integers.");
                            }
                        }
                        else
                        {
                            throw new Exception("When comparing as integers, make sure A and B are integers.");
                        }
                    }
                case CompareAsType.Float:
                    {
                        if (float.TryParse(A, out float a) && float.TryParse(B, out float b))
                        {
                            switch (CompareType.EnumValue)
                            {
                                case IfCompareType.Equals:
                                    return a == b;
                                case IfCompareType.LessThan:
                                    return a < b;
                                case IfCompareType.GreaterThan:
                                    return a > b;
                                default:
                                    throw new Exception($"Can only use Equals, Greater than, or Less than to compare A and B when comparing as floats.");
                            }
                        }
                        else
                        {
                            throw new Exception("When comparing as floats, make sure A and B are floats.");
                        }
                    }
                case CompareAsType.Bool:
                    {
                        if (bool.TryParse(A, out bool a) && bool.TryParse(B, out bool b))
                        {
                            switch (CompareType.EnumValue)
                            {
                                case IfCompareType.Equals:
                                    return a == b;
                                case IfCompareType.And:
                                    return a && b;
                                case IfCompareType.Or:
                                    return a || b;
                                default:
                                    throw new Exception($"Can only use Equals, And, or Or to compare A and B when comparing as booleans.");
                            }
                        }
                        else
                        {
                            throw new Exception("When comparing as booleans, make sure A and B are booleans.");
                        }
                    }
                default:
                    return false;
            }
        }
    }
}
