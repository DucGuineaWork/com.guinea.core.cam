using System;
using System.Collections.Generic;
using UnityEngine;

namespace Guinea.Core.Cam
{
    public static class BecameVisibleObjectManager
    {
        private static List<GameObject> s_visibleObjects = new List<GameObject>();
        public static List<GameObject> VisibleObjects=>s_visibleObjects;
        public static event Action OnChanged;

        public static void OnBecameVisibleEvent(GameObject gameObject)
        {
            if(!s_visibleObjects.Contains(gameObject))
            {
                s_visibleObjects.Add(gameObject);
                OnChanged?.Invoke();
            }
        }

        public static void OnBecameInvisibleEvent(GameObject gameObject)
        {
            s_visibleObjects.Remove(gameObject);
            OnChanged?.Invoke();
        }
    }
}