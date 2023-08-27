using UnityEngine;

namespace ItemPicker.Utillity
{
    public class GetCameraSize : MonoBehaviour
    {
        #region Variables

        public static float _camHeight;
        public static float _camWidth;

        #endregion

        #region Unity lifecycle

        private void Awake()
        {
            _camHeight = Camera.main.orthographicSize;
            _camWidth = _camHeight * Camera.main.aspect;
        }

        #endregion
    }
}