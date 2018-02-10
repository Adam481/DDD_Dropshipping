
using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace DDD_Dropshipping.Ordering.Domain.SeedWork
{
    // based on Jimmy Bogards Enumeration class and github example: https://gist.github.com/spewu/5933739
    [Serializable]
    [DebuggerDisplay("{DisplayName} - {Value}")]
    public abstract class Enumeration<TEnumeration, TValue> : IComparable<TEnumeration>, IEquatable<TEnumeration>
    where TEnumeration : Enumeration<TEnumeration, TValue>
    where TValue : IComparable
    {
        private static readonly TEnumeration[] Enumerations = GetEnumerations();

        private readonly string _displayName;
        private readonly TValue _value;


        protected Enumeration(TValue value, string displayName)
        {
            _value = value;
            _displayName = displayName;
        }


        public TValue Value
        {
            get { return _value; }
        }


        public string DisplayName
        {
            get { return _displayName; }
        }


        public override sealed string ToString()
            => DisplayName;


        public int CompareTo(TEnumeration other)
            => Value.CompareTo(other.Value);


        public override bool Equals(object obj) 
            => Equals(obj as TEnumeration);


        public bool Equals(TEnumeration other)
            => other != null && Value.Equals(other.Value);


        public override int GetHashCode()
            => Value.GetHashCode();


        public static TEnumeration FromValue(TValue value)
            => Parse(value, "value", item => item.Value.Equals(value));


        public static TEnumeration Parse(string displayName)
            => Parse(displayName, "display name", item => item.DisplayName == displayName);


        public static bool TryParse(TValue value, out TEnumeration result)
            => TryParse(x => x.Value.Equals(value), out result);


        public static bool TryParse(string displayName, out TEnumeration result)
            => TryParse(x => x.DisplayName == displayName, out result);


        public static TEnumeration[] GetAll()
            => Enumerations;
        

        private static TEnumeration[] GetEnumerations()
        {
            var enumerationType = typeof(TEnumeration);

            return enumerationType
                .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly)
                .Where(info => enumerationType.IsAssignableFrom(info.FieldType))
                .Select(info => info.GetValue(null))
                .Cast<TEnumeration>()
                .ToArray();
        }


        private static TEnumeration Parse(object value, string description, Func<TEnumeration, bool> predicate)
            => TryParse(predicate, out TEnumeration result)
                ? result
                : throw new ArgumentException($"'{value}' is not a valid {description} in {typeof(TEnumeration)}", "value");


        private static bool TryParse(Func<TEnumeration, bool> predicate, out TEnumeration result)
        {
            result = GetAll().FirstOrDefault(predicate);
            return result != null;
        }
    }
}
