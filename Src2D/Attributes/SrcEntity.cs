using System;
using System.Collections.Generic;
using System.Text;

namespace Src2D.Attributes
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public sealed class SrcEntityAttribute : Attribute
    {
        private readonly string name;

        public SrcEntityAttribute(string name)
        {
            this.name = name;
        }

        public string Name { get => name; }
        public string Description { get; set; } = "";
        /// <summary>
        /// What is the name of the icon asset to be rendered in the editor viewport
        /// </summary>
        public string Icon { get; set; } = null;
        /// <summary>
        /// Used internally by the engine to load icons that are included in the editor, but not the game.
        /// </summary>
        public bool UseEditorAsset { get; set; } = false;
        /// <summary>
        /// What is the name of the assignable asset to be rendered in the editor viewport. Will use if Icon isn't assigned.
        /// </summary>
        public string SpriteAsset { get; set; } = null;
    }
}
