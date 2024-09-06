using System;
using UnityEngine;

namespace Guinea.Core.Cam
{
    public class BecameVisibleObject: MonoBehaviour
    {
        public event Action<GameObject> OnBecameVisibleEvent;
        public event Action<GameObject> OnBecameInvisibleEvent;

        void OnBecameVisible()
        {
            BecameVisibleObjectManager.OnBecameVisibleEvent(gameObject);
            OnBecameVisibleEvent?.Invoke(gameObject);
        }

        void OnBecameInvisible()
        {
            BecameVisibleObjectManager.OnBecameInvisibleEvent(gameObject);
            OnBecameInvisibleEvent?.Invoke(gameObject);
        }
    }
}