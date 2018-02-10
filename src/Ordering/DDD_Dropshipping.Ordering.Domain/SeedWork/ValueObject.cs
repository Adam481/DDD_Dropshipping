using System;
using System.Collections.Generic;
using System.Reflection;

namespace DDD_Dropshipping.Ordering.Domain.SeedWork
{
    public abstract class ValueObject<T> : IEquatable<T>
        where T : ValueObject<T>
    {        
        public override int GetHashCode()
        {
            int startValue = 17;
            int multiplier = 59;
            int hashCode = startValue;
            
            foreach (var value in GetAtomicValues())
            {
                if (value != null)
                    hashCode = hashCode * multiplier + value.GetHashCode();
            }

            return hashCode;
        }


        public static bool operator !=(ValueObject<T> x, ValueObject<T> y)
            => !(x == y);


        public static bool operator ==(ValueObject<T> x, ValueObject<T> y)
            => x.Equals(y);


        public override bool Equals(object obj)
            => obj == null ? false : Equals(obj as T);


        public virtual bool Equals(T obj)
        {
            if (obj == null || obj.GetType() != GetType())
            {
                return false;
            }

            var other = (ValueObject<T>)obj;
            IEnumerator<object> thisValues = GetAtomicValues().GetEnumerator();
            IEnumerator<object> otherValues = other.GetAtomicValues().GetEnumerator();
            
            while (thisValues.MoveNext() && otherValues.MoveNext())
            {
                if (ReferenceEquals(thisValues.Current, null) ^ ReferenceEquals(otherValues.Current, null))
                {
                    return false;
                }

                if (thisValues.Current != null && !thisValues.Current.Equals(otherValues.Current))
                {
                    return false;
                }
            }
            return !thisValues.MoveNext() && !otherValues.MoveNext();
        }
        

        protected abstract IEnumerable<object> GetAtomicValues();
    }
}
