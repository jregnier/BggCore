using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace BggCoreSdk.Core
{
    public abstract class Enumeration : IComparable
    {
        protected Enumeration()
        {
        }

        protected Enumeration(int value, string name)
        {
            Value = value;
            Name = name;
        }

        public string Name { get; }

        public int Value { get; }

        public int CompareTo(object obj)
        {
            return Value.CompareTo(((Enumeration)obj).Value);
        }

        public override bool Equals(object obj)
        {
            var otherValue = obj as Enumeration;
            if (otherValue == null)
            {
                return false;
            }

            return
                GetType().Equals(obj.GetType()) &&
                Value.Equals(otherValue.Value);
        }

        public static IEnumerable<T> GetAll<T>() where T : Enumeration, new()
        {
            var fields = typeof(T)
                .GetTypeInfo()
                .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);

            foreach (var info in fields)
            {
                var instance = new T();
                var locatedValue = info.GetValue(instance) as T;
                if (locatedValue != null)
                {
                    yield return locatedValue;
                }                
            }
        }

        public static T FromString<T>(string name) where T : Enumeration, new()
        {
            var item = GetAll<T>().FirstOrDefault(x => x.Name == name);
            if (item == null)
            {
                return null;
            }

            return item;
        }

        public static T FromValue<T>(int value) where T : Enumeration, new()
        {
            var item = GetAll<T>().FirstOrDefault(x => x.Value == value);
            if (item == null)
            {
                return null;
            }

            return item;
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public override string ToString()
        {
            return Name;
        }
    }
}