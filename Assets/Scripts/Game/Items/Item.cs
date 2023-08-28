using System;
using ItemPicker.Services;
using ItemPicker.Utillity;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ItemPicker.Game.Items
{
    public class Item : MonoBehaviour
    {
        #region Variables

        [Header("Components")]
        [SerializeField] private GameObject _vfx;
        [SerializeField] private Rigidbody2D _rg;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [Header("Configs")]
        [SerializeField] private Sprite[] _sprites;
        [SerializeField] private int _scoreToChange;

        #endregion

        #region Events

        public static event Action<Item> OnCreated;

        #endregion

        #region Properties

        public Rigidbody2D ItemRigidBody => _rg;

        #endregion

        #region Unity lifecycle

        private void Awake()
        {
            int randomSprite = Random.Range(0, _sprites.Length);
            _spriteRenderer.sprite = _sprites[randomSprite];
        }

        private void Start()
        {
            OnCreated?.Invoke(this);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag(Tags.Platform))
            {
                PerformActions();
                Destroy(gameObject);
            }
        }

        #endregion

        #region Protected methods

        protected virtual void PerformActions()
        {
            SoundService.Instance.PlayCollisionSound();
            GameService.Instance.ChangeScore(_scoreToChange);
            InstantiateVfx();
        }

        #endregion

        #region Private methods

        private void InstantiateVfx()
        {
            Instantiate(_vfx, transform.position, Quaternion.identity);
        }

        #endregion
    }
}