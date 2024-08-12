using UnityEngine;

namespace Guinea.Core.Cam
{
    public class TargetAiming : MonoBehaviour
    {
        [SerializeField]Transform m_target;
        [SerializeField]RectTransform m_rect;
        [SerializeField]RectTransform m_aiming;
        [SerializeField]Vector3 m_offset;

        void FixedUpdate()
        {
            CameraManager.WorldToCanvasPosition(m_target.position + m_offset, m_rect, out Vector2 localPoint);
            m_aiming.anchoredPosition = localPoint;
        }
    }
}
