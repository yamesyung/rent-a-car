using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetOracle
{
    public class ComboItem
    {
        public string Text { get; set; }
        public int Value { get; set; }

        public ComboItem(string text, int value)
        {
            Text = text;
            Value = value;
        }
        public override string ToString()
        {
            return Text;
        }

        public override bool Equals(Object obj)
        {
            // If parameter is null return false.
            if (obj == null)
            {
                return false;
            }

            // If parameter cannot be cast to Point return false.
            ComboItem ci = obj as ComboItem;
            if ((System.Object)ci == null)
            {
                return false;
            }

            // Return true if the fields match:
            return (this.Text.Equals(ci.Text) && this.Value == ci.Value);
        }

        public override int GetHashCode()
        {
            return this.Value;
        }
    }
}
