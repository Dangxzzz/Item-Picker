using ItemPicker.Services;
using UnityEngine;

namespace ItemPicker.Game
{
    public class Platform : MonoBehaviour
    {
        #region Unity lifecycle

        private void Update()
        {
            if (PauseService.Instance.IsPaused)
            {
                return;
            }
            else
            {
                MoveWithMouse();
            }
        }

        #endregion

        #region Private methods

        private void MoveWithMouse()
        {
            Vector3 mousePosition = Input.mousePosition;
            Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

            SetPosition(worldMousePosition);
        }

        private void SetPosition(Vector3 worldPosition)
        {
            Vector3 currentPosition = transform.position;
            currentPosition.x = worldPosition.x;
            transform.position = currentPosition;
        }

        #endregion
    }
}