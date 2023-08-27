using UnityEngine;

namespace ItemPicker.Sound
{
    public class BackGroundSound : MonoBehaviour
    {
        #region Variables

        [Header("Tags")]
        [SerializeField] private string _createTag;

        #endregion

        #region Unity lifecycle

        private void Awake()
        {
            GameObject obj = GameObject.FindWithTag(_createTag);
            if (obj != null)
            {
                Destroy(gameObject);
            }
            else
            {
                gameObject.tag = _createTag;
                DontDestroyOnLoad(gameObject);
            }
        }

        #endregion
    }
}