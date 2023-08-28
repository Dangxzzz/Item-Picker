using ItemPicker.Services;
using TMPro;
using UnityEngine;

namespace ItemPicker.Utillity
{
    public class SaveRecord : MonoBehaviour
    {
        #region Variables

        [SerializeField] private TextMeshProUGUI _label;

        private int _score;

        #endregion

        #region Unity lifecycle

        private void Awake()
        {
            if (PlayerPrefs.HasKey("Record"))
            {
                _score = PlayerPrefs.GetInt("Record");
            }

            PlayerPrefs.SetInt("Record", _score);
        }

        private void Update()
        {
            _label.text = "Record: " + _score;
            if (GameService.Instance.Score > PlayerPrefs.GetInt("Record"))
            {
                _score = GameService.Instance.Score;
                PlayerPrefs.SetInt("Record", GameService.Instance.Score);
            }
        }

        #endregion
    }
}