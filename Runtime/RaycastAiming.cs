using UnityEngine;
using UnityEngine.UI;

namespace Guinea.Core.Cam
{
    public class RaycastAiming : MonoBehaviour
    {
        [SerializeField]Transform m_target;
        [SerializeField]RectTransform m_rect;
        [SerializeField]RectTransform m_aiming;
        [SerializeField]Vector3 m_offset;
        [SerializeField]float m_maxDistance;
        [SerializeField]LayerMask m_layer;
        [SerializeField]string m_includeTag;
        [SerializeField]Image m_image;
        [SerializeField]Color m_defaultColor;
        [SerializeField]Color m_targetColor;
        [SerializeField]bool m_setActivation;

        void FixedUpdate()
        {
            bool isHit = Physics.Raycast(m_target.position + m_target.TransformDirection(m_offset), m_target.forward, out RaycastHit hit, m_maxDistance, m_layer) && 
            (string.IsNullOrEmpty(m_includeTag)||hit.collider.gameObject.CompareTag(m_includeTag));

            if(isHit)
            {
                CameraManager.WorldToCanvasPosition(hit.point, m_rect, out Vector2 localPoint);
                m_aiming.anchoredPosition = localPoint;
            }

            if(m_image!=null)
            {
                m_image.color = isHit ? m_targetColor: m_defaultColor;
                if(m_setActivation)
                {
                    m_image.enabled = isHit;
                }
            }

        }
    }
}