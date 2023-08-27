using ItemPicker.Game.Items;
using ItemPicker.Services;
using ItemPicker.Utillity;
using UnityEngine;

namespace ItemPicker.Game
{
    [RequireComponent(typeof(Collider2D))]
    public class BottomWall : MonoBehaviour
    {
        #region Unity lifecycle
        
        
        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag(Tags.GoodItem))
            {
                GameService.Instance.ChangeHP(-1);
                SoundService.Instance.PlayFaleSound();
            }
            Destroy(other.gameObject);
        }

        #endregion
    }
}