using TMPro;
using UnityEngine;


namespace parith
{
    public class Timer : MonoBehaviour
    {
        [SerializeField] private ScoreManager _scoreManager;
        [SerializeField] private TextMeshProUGUI _timerUI;
        private GameAppFlowManager _gameManager;
        private float _time = 30;

        private void Start()
        {
            _gameManager = GameAppFlowManager.Instance;
        }

        private void Update()
        {
            _time -= Time.deltaTime;
            CheckWinCondition();
            _timerUI.text = Mathf.Ceil(_time).ToString();
            _timerUI.SetText("Time Left: " + Mathf.Floor(_time));
        }

        private void CheckWinCondition()
        {
            if (_time <= 0)
            {
                if (_scoreManager.GetScore() >= 10000)
                {
                    _gameManager.LoadScene("Scene-GameOver-Win");
                }
                else
                {
                    _gameManager.LoadScene("Scene-GameOver-Lose");
                }
            }
        }

        public void AddTime(float _input) { _time += _input; }

        public void DeductTime(float _input)
        {
            _time -= _input;
            CheckWinCondition();
        }
    }
}