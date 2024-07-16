using System.Collections.Generic;
using UnityEngine;

namespace Helpers
{
    public static class Utils
    {
        internal static T GetRandomElement<T>(params T[] elements)
        {
            int index = Random.Range(0, elements.Length);
            
            return elements[index];
        }
        
        internal static T GetRandomElementFromList<T>(IList<T> elements)
        {
            int index = Random.Range(0, elements.Count);
            
            return elements[index];
        }
    }
}