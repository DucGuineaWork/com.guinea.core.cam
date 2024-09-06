using System;
using System.Collections.Generic;
using UnityEngine;

namespace Guinea.Core.Cam
{
    public class BecameVisibleObjectManager: MonoBehaviour
    {
        private static HashSet<GameObject> s_visibleObjects = new HashSet<GameObject>();
        public static HashSet<GameObject> VisibleObjects=>s_visibleObjects;
        public static event Action OnChanged;

        void OnEnable()
        {
            BecameVisibleObject.OnBecameVisibleEvent += OnBecameVisibleEvent;
            BecameVisibleObject.OnBecameInvisibleEvent += OnBecameInvisibleEvent;
        }
        void OnDisable()
        {
            BecameVisibleObject.OnBecameVisibleEvent -= OnBecameVisibleEvent;
            BecameVisibleObject.OnBecameInvisibleEvent -= OnBecameInvisibleEvent;
        }

        private void OnBecameVisibleEvent(GameObject gameObject)
        {
            s_visibleObjects.Add(gameObject);
            OnChanged?.Invoke();
        }

        private void OnBecameInvisibleEvent(GameObject gameObject)
        {
            s_visibleObjects.Remove(gameObject);
            OnChanged?.Invoke();
        }
    }
}