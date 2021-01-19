using Src2D.Attributes;
using Src2D.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Src2D.Entities
{
    [SrcEntity("math_counter", 
        Description = "A simple counter. Can go up or down. Also events for when the value changed.",
        Icon = "EntityIcons/math_counter", UseEditorAsset = true)]
    [Gizmo("Position2d")]
    public class CounterEntity : BaseEntity
    {
        [SrcProperty("StartingValue", Description = "The starting value of the counter.")]
        public int StartingValue { get; set; }

        [SrcEvent("OnValueChanged", Description = "Event when event value is changed.", ExportsParam = true, ParamType = EventParamType.Int)]
        public event SrcEvent OnValueChanged;

        [SrcAction("SetValue", Description = "Set the value.", HasParam = true, ParamType = EventParamType.Int)]
        public void SetValue(string param)
        {
            if(int.TryParse(param, out int newValue))
            {
                Value = newValue;
            }
            else
            {
                throw new ArgumentException($"Parameter has to be an integer. \"{param}\" is not an integer you donut.");
            }
        }

        [SrcAction("IncrementValue", Description = "Increment the value.", HasParam = true, ParamType = EventParamType.Int)]
        public void IncrementValue(string param)
        {
            if(int.TryParse(param, out int newValue))
            {
                Value += newValue;
            }
            else
            {
                Value++;
            }
        }

        [SrcAction("DecrementValue", Description = "Decrement the value.", HasParam = true, ParamType = EventParamType.Int)]
        public void DecrementValue(string param)
        {
            if(int.TryParse(param, out int newValue))
            {
                Value -= newValue;
            }
            else
            {
                Value--;
            }
        }

        public int Value
        {
            get => value;
            set
            {
                this.value = value;
                OnValueChanged?.Invoke(value.ToString());
            }
        }
        private int value;

        public override void Start()
        {
            base.Start();
            value = StartingValue;
        }
    }
}
