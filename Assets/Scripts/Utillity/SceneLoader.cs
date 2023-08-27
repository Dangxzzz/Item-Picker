using UnityEngine.SceneManagement;

namespace ItemPicker.Utillity
{
    public class SceneLoader : SingletonMonoBehaviour<SceneLoader>
    {
        #region Public methods

        public void LoadChosenScene(int chose)
        {
            SceneManager.LoadScene(chose);
        }

        public void ReloadCurrentScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        #endregion
    }
}