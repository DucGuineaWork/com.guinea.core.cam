using UnityEngine;

namespace Guinea.Core.Cam
{
    public class CameraManager: MonoBehaviour
    {
        private static Camera s_mainCamera;
        public static Camera Main{
            get{
                s_mainCamera = s_mainCamera ?? Camera.main;
                return s_mainCamera;
            }
        }
        public static void SetMainCamera(Camera camera)
        {
            s_mainCamera = camera;
        }

        public static bool WorldToCanvasPosition(Vector3 worldPosition, RectTransform rect, out Vector2 localPoint, Camera cam = null)
        {
            Vector3 screenPosition = Main.WorldToScreenPoint(worldPosition);
            return RectTransformUtility.ScreenPointToLocalPointInRectangle(
            rect,
            screenPosition,
            cam, // Since it's Screen Space - Overlay, the camera is null
            out localPoint);
        }
    }
}
