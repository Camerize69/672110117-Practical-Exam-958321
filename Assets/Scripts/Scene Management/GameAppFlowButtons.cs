using UnityEngine;
using UnityEngine.SceneManagement;

namespace parith
{
    public class GameAppFlowButtons : MonoBehaviour
    {
        private Scene _prevScene;

        private void Start()
        {
            _prevScene = SceneManager.GetActiveScene();
        }
        
        public void LoadScene(string sceneName)
        {
            GameAppFlowManager.Instance.LoadScene(sceneName);
        }

        public void LoadPreviousScene()
        {
            GameAppFlowManager.Instance.LoadScene(_prevScene.name);
        }

        public void LoadOptionsScene(string optionSceneName)
        {
            GameAppFlowManager.Instance.LoadOptionsScene(optionSceneName);
        }

        public void UnloadOptionsScene(string optionSceneName)
        {
            GameAppFlowManager.Instance.UnloadOptionsScene(optionSceneName);
        }

        public void ExitGame()
        {
            GameAppFlowManager.Instance.ExitGame();
        }
    }
}