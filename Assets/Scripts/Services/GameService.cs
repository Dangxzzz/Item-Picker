using System;
using ItemPicker.Utillity;
using UnityEngine;

namespace ItemPicker.Services
{
    public class GameService : SingletonMonoBehaviour<GameService>
    {
        #region Variables

        [Header("Configs")]
        [SerializeField] private int _startHP = 3;

        #endregion

        #region Events

        public event Action<int> OnHPChanged;
        public event Action OnHPOver;

        #endregion

        #region Properties

        public int Health { get; private set; }
        public int Score { get; set; }

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            SetInitHealth();
        }

        #endregion

        #region Public methods

        public void ChangeHP(int count)
        {
            Health = Mathf.Max(0, Health += count);
            OnHPChanged?.Invoke(Health);
            if (Health <= 0)
            {
                OnHPOver?.Invoke();
            }
        }

        public void ChangeScore(int value)
        {
            Score = Mathf.Max(0, Score + value);
        }

        public void RestartLevel()
        {
            SetStartParameters();
            SceneLoader.Instance.ReloadCurrentScene();
        }

        public void SetStartParameters()
        {
            SetInitHealth();
            Score = 0;
            PauseService.Instance.TogglePause();
        }

        #endregion

        #region Protected methods

        protected override void OnAwake()
        {
            base.OnAwake();
            SetInitHealth();
        }

        #endregion

        #region Private methods

        private void SetInitHealth()
        {
            Health = _startHP;
            OnHPChanged?.Invoke(Health);
        }

        #endregion
    }
}