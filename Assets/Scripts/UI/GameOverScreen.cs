using System;
using ItemPicker.Services;
using ItemPicker.Utillity;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ItemPicker.UI
{
    public class GameOverScreen : MonoBehaviour
    {
        #region Variables

        [SerializeField] private GameObject _contentObject;
        [SerializeField] private TextMeshProUGUI _scoreLabel;
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _exitButton;

        #endregion

        #region Unity lifecycle

        private void Awake()
        {
            _contentObject.SetActive(false);
        }

        private void Start()
        {
            _exitButton.onClick.AddListener(OnExitButtonClick);
            _restartButton.onClick.AddListener(OnRetryButtonClick);
            GameService.Instance.OnHPOver += OnHpOver;
        }

        private void OnDestroy()
        {
            GameService.Instance.OnHPOver -= OnHpOver;
        }

        #endregion

        #region Private methods

        private void OnHpOver()
        {
            PauseService.Instance.TogglePause();
            _contentObject.SetActive(true);
            _scoreLabel.text = "Score: " + Convert.ToString(GameService.Instance.Score);
        }

        private void OnExitButtonClick()
        {
            SceneLoader.Instance.LoadChosenScene(0);
        }

        private void OnRetryButtonClick()
        {
            _contentObject.SetActive(false);
            GameService.Instance.RestartLevel();
        }

        #endregion
    }
}