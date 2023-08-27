using ItemPicker.Services;
using UnityEngine;

namespace ItemPicker.Game.Items
{
    public class BonusItem : Item
    {
        #region Variables

        [SerializeField] private int _count;

        #endregion

        #region Protected methods

        protected override void PerformActions()
        {
            base.PerformActions();
            GameService.Instance.ChangeHP(_count);
            SoundService.Instance.PlayPickUpSound();
        }

        #endregion
    }
}