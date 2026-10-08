using UnityEngine;

namespace parith.GameDev3.Chapter6
{
    public class GameAppFlowButtons : MonoBehaviour
    {
        public void LoadScene(string sceneName)
        {
            GameAppFlowManager.Instance.LoadScene(sceneName);
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