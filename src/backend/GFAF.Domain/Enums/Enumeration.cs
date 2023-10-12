using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GFAF.Domain.Enums
{
    public abstract class Enumeration<T>: IComparable
        where T : Enumeration<T>
    {
        public int Id { get; private set; }

        public string Name { get; set; }

        protected Enumeration(int id, string name) => (Id, Name) = (id, name);

        public override string ToString() => this.Name;

        public static IEnumerable<T> GetAll() =>
        typeof(T).GetFields(BindingFlags.Public |
                            BindingFlags.Static |
                            BindingFlags.DeclaredOnly)
                 .Select(f => f.GetValue(null))
                 .Cast<T>();

        public override bool Equals(object? obj)
        {
            if (obj is not Enumeration<T> otherValue)
            {
                return false;
            }

            var typeMatches = GetType().Equals(obj.GetType());
            var valueMatches = Id.Equals(otherValue.Id);

            return typeMatches && valueMatches;
        }

        public int CompareTo(object? other) => Id.CompareTo((other as Enumeration<T>)?.Id);

        public override int GetHashCode()
        {
            return this.Id.GetHashCode() * 17 + this.Name.GetHashCode();
        }
    }
}
