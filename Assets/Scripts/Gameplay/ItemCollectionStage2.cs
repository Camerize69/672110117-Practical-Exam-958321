using StarterAssets;
using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.InputSystem;

namespace parith
{
    public class ItemCollectionStage : MonoBehaviour
    {
        [SerializeField] private ScoreManager _scoreManager;
        [SerializeField] private Timer _timer;
        private GameAppFlowManager _gameManager;
        private List<GameObject> collidingItems = new List<GameObject>();
        private GameObject currentCollidingItem;
        private StarterAssetsInputs _input;

        private void Start()
        {
            _gameManager = GameAppFlowManager.Instance;
            _input = GetComponent<StarterAssetsInputs>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("KillBox"))
            {
                _gameManager.LoadScene("Scene-GameOver-Lose");
            }
            else
            {
                collidingItems.Add(other.gameObject);
                currentCollidingItem = collidingItems[0];
            }

        }

        private void OnTriggerExit(Collider other)
        {
            collidingItems.Remove(other.gameObject);
            if (collidingItems.Count > 0)
            {
                currentCollidingItem = collidingItems[0];
            }
            else
            {
                currentCollidingItem = null;
            }
        }

        void Update()
        {
            if (_input.interact)
            {
                _input.interact = false;

                if (currentCollidingItem != null)
                {
                    switch (currentCollidingItem.tag)
                    {
                        case "ItemTime+":
                            _timer.AddTime(3);
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
                    }

                    currentCollidingItem.gameObject.GetComponent<ItemBehaviour>().PlaySound();
                    collidingItems.Remove(currentCollidingItem);
                    Destroy(currentCollidingItem);

                    if (collidingItems.Count > 0)
                    {
                        currentCollidingItem = collidingItems[0];
                    }
                    else
                    {
                        currentCollidingItem = null;
                    }
                }
            }
        }
    }
}