using System;
using TMPro;
using Unity.Loading;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace parith
{
    public class GameAppFlowManager : Singleton<GameAppFlowManager>
    {
        protected static bool IsSceneOptionsLoaded;
        private ScoreManager _scoreManager;
        private TextMeshProUGUI _scoreText;
        private string _prevSceneName;
        private float score;

        public void LoadScene(string sceneName)
        {
            _scoreManager = FindAnyObjectByType<ScoreManager>();
            if (_scoreManager != null) { score = _scoreManager.GetScore(); }

            _prevSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        }

        public void UnloadScene(string sceneName)
        {
            SceneManager.UnloadSceneAsync(sceneName);
        }

        public void LoadSceneAdditive(string sceneName)
        {
            SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
        }

        public void LoadPreviousScene()
        {
            SceneManager.LoadScene(_prevSceneName, LoadSceneMode.Single);
        }

        public void LoadOptionsScene(string optionSceneName)
        {
            if (!IsSceneOptionsLoaded)
            {
                SceneManager.LoadScene(optionSceneName, LoadSceneMode.Additive);
                IsSceneOptionsLoaded = true;
            }
        }

        public void UnloadOptionsScene(string optionSceneName)
        {
            if (IsSceneOptionsLoaded)
            {
                SceneManager.UnloadSceneAsync(optionSceneName);
                IsSceneOptionsLoaded = false;
            }
        }

        public void ExitGame()
        {
            Application.Quit();
        }

        #region Scene Load and Unload Events Handler

        private void OnEnable()
        {
            SceneManager.sceneUnloaded += SceneUnloadEventHandler;
            SceneManager.sceneLoaded += SceneLoadedEventHandler;
        }

        private void OnDisable()
        {
            SceneManager.sceneUnloaded -= SceneUnloadEventHandler;
            SceneManager.sceneLoaded -= SceneLoadedEventHandler;
        }

        private void SceneUnloadEventHandler(Scene scene)
        {
        }

        private void SceneLoadedEventHandler(Scene scene, LoadSceneMode mode)
        {
            //If the loaded scene is not the SceneOptions , set flag IsOptionsLoaded to false
            if (scene.name.CompareTo("SceneOptions") != 0)
            {
                // IsSceneOptionsLoaded = false;
            }

            if (scene.name == "Scene-GameOver-Win" || scene.name == "Scene-GameOver-Lose")
            {
                GameObject scoreObject = GameObject.Find("Text-FinalScore");

                if (scoreObject != null)
                {
                    _scoreText = scoreObject.GetComponent<TextMeshProUGUI>();

                    if (_scoreText != null)
                    {
                        _scoreText.text = "Score: " + score.ToString();
                    }
                }
                else
                {
                    Debug.LogError("Text-FinalScore was not found in the Game Over scene!");
                }
            }
        }

        #endregion
    }
}