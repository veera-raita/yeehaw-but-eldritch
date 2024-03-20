using UnityEngine;

namespace GBE
{
    public class Billboard2D : MonoBehaviour
    {
        #region Variables
        public bool alignToCamera = true;

        private Transform m_cameraTransform;
        private Transform m_localTransform;
        #endregion

        #region Built-In Methods
        private void Start()
        {
            m_cameraTransform = Camera.main.transform;
            m_localTransform = transform;
        }

        private void LateUpdate()
        {
            // If enabled, align the sprite to the camera direction,
            // otherwise turn the sprite directly towards the camera.
            if (alignToCamera)
            {
                m_localTransform.forward = m_cameraTransform.forward;
            }
            else
            {
                m_localTransform.LookAt(m_cameraTransform, Vector3.up);
            }
        }
        #endregion
    }
}