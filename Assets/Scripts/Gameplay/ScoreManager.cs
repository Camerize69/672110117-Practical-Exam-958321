using TMPro;
using UnityEngine;

namespace parith
{
    public class ScoreManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _scoreUI;
        private float score = 0;

        private void Update()
        {
            _scoreUI.SetText("Score: " + Mathf.Floor(score));
        }

        public void AddScore(float _input) { score += _input; }

        public void DeductScore(float _input) { score -= _input; }

        public float GetScore() { return score; }
    }
}