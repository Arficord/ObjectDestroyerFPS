using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Arf.Player.Abilities;
using UnityEngine;

namespace Arf.ReflectionUtils
{
    public static class Reflection
    {
        public static IEnumerable<Type> GetAllInheritedClasses<T>()
        {
            return AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(assembly => assembly.GetTypes())
                .Where(type => type.IsSubclassOf(typeof(T)));
            //return GetAllInheritedClasses(typeof(T));
        }
        
        public static IEnumerable<Type> GetAllInheritedClasses(Type parentType)
        {
            return AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(assembly => assembly.GetTypes())
                .Where(type => type.IsSubclassOf(parentType));
        }
    }
}
