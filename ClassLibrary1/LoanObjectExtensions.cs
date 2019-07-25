using External;
using System;
using System.Collections.Generic;

namespace ExternalMapping
{
    public static class LoanObjectExtensions
    {
        public static bool ContainsValues(this LoanObject lo, params int[] ids)
        {
            foreach (var id in ids)
            {
                if (lo.Properties.ContainsKey(id))
                {
                    return true;
                }
            }

            return false;
        }

        public static void MapValue<T>(this LoanObject lo, int id, T value, T emptyValue = default) where T : IComparable<T>
        {
            if (value.CompareTo(emptyValue) == 0)
            {
                lo.RemoveValue(id);
            }
            else
            {
                lo.SetValue(id, value.ToString());
            }
        }

        public static void MapValue(this LoanObject lo, int id, string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                lo.RemoveValue(id);
            }
            else
            {
                lo.SetValue(id, value.ToString());
            }
        }

        public static void SetValue(this LoanObject lo, int id, string value)
        {
            if (lo.Properties == null)
            {
                lo.Properties = new Dictionary<int, LoanProperty>();
            }

            lo.Properties[id] = new LoanProperty() { Id = id, Value = value };
        }

        public static void RemoveValue(this LoanObject lo, int id)
        {
            if (lo.Properties?.ContainsKey(id) ?? false)
            {
                lo.Properties.Remove(id);
            }
        }
    }
}

