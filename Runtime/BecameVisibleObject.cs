using System;
using UnityEngine;

namespace Guinea.Core.Cam
{
    public class BecameVisibleObject: MonoBehaviour
    {
        public static event Action<GameObject> OnBecameVisibleEvent;
        public static event Action<GameObject> OnBecameInvisibleEvent;

        void OnBecameVisible()
        {
            OnBecameVisibleEvent?.Invoke(gameObject);
        }

        void OnBecameInvisible()
        {
            OnBecameInvisibleEvent?.Invoke(gameObject);
        }
    }
}