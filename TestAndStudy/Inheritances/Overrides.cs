using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAndStudy.Inheritances
{
    internal static class Overrides
    {
        public class Parent
        {
            public virtual IReadOnlySet<int> SomeSet { get; }

            public Parent(IEnumerable<int> setInputs)
            {
                SomeSet = setInputs.ToHashSet();
            }
        }

        public class Child : Parent
        {
            public override IReadOnlySet<int> SomeSet => _ownSet;

            private HashSet<int> _ownSet = new();

            public Child(IEnumerable<int> setInputs)
                : base([])
            {
                _ownSet = setInputs.ToHashSet();
            }
        }

        public static void Casting()
        {
            int[] setInputs = [0, 1, 2, 3, 4, 5];

            Parent p = new(setInputs);
            Console.WriteLine($"p: {string.Join(',', p.SomeSet)}");

            Child c = new(setInputs);
            Console.WriteLine($"c: {string.Join(',', c.SomeSet)}");

            if (p is Child childOfGrandParents)
            {
                Console.WriteLine($"downcasting: {string.Join(',', childOfGrandParents.SomeSet)}");
            }

            if (c is Parent childBecameParent)
            {
                Console.WriteLine($"upcasting: {string.Join(',', childBecameParent.SomeSet)}");
            }
        }
    }
}
