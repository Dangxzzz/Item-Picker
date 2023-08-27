using ItemPicker.Services;
using ItemPicker.Utillity;
using UnityEngine;
using UnityEngine.UI;

namespace ItemPicker.UI
{
    public class PauseMenu : MonoBehaviour
    {
        #region Variables

        [SerializeField] private GameObject _contentObject;
        [SerializeField] private Button _exitButton;

        #endregion

        #region Unity lifecycle

        private void Awake()
        {
            _contentObject.SetActive(false);
            _exitButton.onClick.AddListener(OnExitButtonClick);
        }

        private void Start()
        {
            PauseService.Instance.OnPaused += OnPaused;
        }

        private void OnDestroy()
        {
            PauseService.Instance.OnPaused -= OnPaused;
        }

        #endregion

        #region Private methods

        private void OnExitButtonClick()
        {
            PauseService.Instance.TogglePause();
            SceneLoader.Instance.LoadChosenScene(0);
        }

        private void OnPaused(bool isPaused)
        {
            _contentObject.SetActive(isPaused);
        }

        #endregion
    }
}