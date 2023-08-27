using ItemPicker.Utillity;
using UnityEngine;

namespace ItemPicker.Services
{
    public class SoundService : SingletonMonoBehaviour<SoundService>
    {
        #region Variables

        [SerializeField] private AudioClip _FaleSound;
        [SerializeField] private AudioClip _pickUpCatch;
        [SerializeField] private AudioClip _loseGame;
        [SerializeField] private AudioClip _onCollision;
        [SerializeField] private AudioClip _pauseSound;

        [SerializeField] private AudioSource _audioSource;

        #endregion

        #region Properties

        public float SoundVolume
        {
            set => _audioSource.volume = value;
        }

        #endregion

        #region Public methods

        public void PlayCollisionSound()
        {
            _audioSource.PlayOneShot(_onCollision);
        }

        public void PlayFaleSound()
        {
            _audioSource.PlayOneShot(_FaleSound);
        }

        public void PlayPauseSound()
        {
            _audioSource.PlayOneShot(_pauseSound);
        }

        public void PlayLoseSound()
        {
            _audioSource.PlayOneShot(_loseGame);
        }

        public void PlayPickUpSound()
        {
            _audioSource.PlayOneShot(_pickUpCatch);
        }

        #endregion

        #region Protected methods

        protected override void OnAwake()
        {
            base.OnAwake();
            _audioSource = GetComponent<AudioSource>();
        }

        #endregion
    }
}