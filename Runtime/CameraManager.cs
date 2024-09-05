using UnityEngine;

namespace Guinea.Core.Cam
{
    public class CameraManager: MonoBehaviour
    {
        [SerializeField]bool m_setMainCameraAtStart;
        private static Camera s_mainCamera;

        public static Camera Main=> s_mainCamera;

        void Start()
        {
            if(m_setMainCameraAtStart)
            {
                s_mainCamera = Camera.main;
            }
        }

        public static SetMainCamera(Camera camera)
        {
            s_mainCamera = camera
        }

        public static bool WorldToCanvasPosition(Vector3 worldPosition, RectTransform rect, out Vector2 localPoint, Camera cam = null)
        {
            Vector3 screenPosition = s_mainCamera.WorldToScreenPoint(worldPosition);
            return RectTransformUtility.ScreenPointToLocalPointInRectangle(
            rect,
            screenPosition,
            cam, // Since it's Screen Space - Overlay, the camera is null
            out localPoint);
        }
    }
}
