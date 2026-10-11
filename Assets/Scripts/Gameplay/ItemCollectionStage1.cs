using UnityEngine;

namespace parith
{
    public class ItemCollectionStage1 : MonoBehaviour
    {
        [SerializeField] private ScoreManager _scoreManager;
        [SerializeField] private Timer _timer;
        private GameAppFlowManager _gameManager;

        private void Start()
        {
            _gameManager = GameAppFlowManager.Instance;
        }

        private void OnTriggerEnter(Collider other)
        {
            switch (other.gameObject.tag)
            {
                case "ItemTime+": _timer.AddTime(3);
                    Destroy(other.gameObject);
                    break;

                case "ItemTime-":
                    _timer.DeductTime(5);
                    Destroy(other.gameObject);
                    break;

                case "ItemScore+":
                    _scoreManager.AddScore(500);
                    Destroy(other.gameObject);
                    break;

                case "ItemScore-":
                    _scoreManager.DeductScore(500);
                    Destroy(other.gameObject);
                    break;

                case "KillBox":
                    _gameManager.LoadScene("Scene-GameOver-Lose");
                    break;
            }
        }
    }
}