using ItemPicker.Services;
using ItemPicker.Utillity;
using UnityEngine;

namespace ItemPicker.Game.Items
{
    public class Item : MonoBehaviour
    {
        #region Variables
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private Sprite[] _sprites;
        [SerializeField] private int _scoreToChange;
        [SerializeField] private GameObject _vfx;

        #endregion

        #region Unity lifecycle

        private void Awake()
        {
            int randomSprite = Random.Range(0, _sprites.Length);
            _spriteRenderer.sprite = _sprites[randomSprite];
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag(Tags.Platform))
            {
                PerformActions();
                Destroy(gameObject);
            }
        }

        private void InstantiateVfx()
        {
            Instantiate(_vfx, transform.position, Quaternion.identity);
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
    }
}