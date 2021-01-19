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
            Float
        }

        [SrcProperty("A", Description = "The first value to compare as.")]
        public string A { get; set; } = "";
        [SrcProperty("B", Description = "The first value to compare as.")]
        public string B { get; set; } = "";
        [SrcProperty("CompareAs", DefaultValue = CompareAsType.String, Description = "What to compare A and B as.")]
        public SrcEnum<CompareAsType> CompareAs { get; set; } = CompareAsType.String;
    }
}
