using System;
using System.Collections.Generic;
using UnityEngine;

namespace Guinea.Core.Cam
{
    public static class BecameVisibleObjectManager
    {
        private static HashSet<GameObject> s_visibleObjects = new HashSet<GameObject>();
        public static HashSet<GameObject> VisibleObjects=>s_visibleObjects;
        public static event Action OnChanged;

        public static void OnBecameVisibleEvent(GameObject gameObject)
        {
            s_visibleObjects.Add(gameObject);
            OnChanged?.Invoke();
        }

        public static void OnBecameInvisibleEvent(GameObject gameObject)
        {
            s_visibleObjects.Remove(gameObject);
            OnChanged?.Invoke();
        }
    }
}