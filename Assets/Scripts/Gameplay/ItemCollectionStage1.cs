using UnityEngine;
using System.Collections;

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
                    break;

                case "ItemTime-":
                    _timer.DeductTime(5);
                    break;

                case "ItemScore+":
                    _scoreManager.AddScore(500);
                    break;

                case "ItemScore-":
                    _scoreManager.DeductScore(500);
                    break;

                case "KillBox":
                    _gameManager.LoadScene("Scene-GameOver-Lose");
                    break;
            }

            other.gameObject.GetComponent<ItemBehaviour>().PlaySound();
            Destroy(other.gameObject);
        }
    }
}