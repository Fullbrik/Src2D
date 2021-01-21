using Src2D.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Src2D.Editor
{
    public interface IPropertyEditable
    {
        Dictionary<string, PropertyData> GetAllProperties();

        object GetProperty(string name);
        void SetProperty(string name, object value);
    }
}
