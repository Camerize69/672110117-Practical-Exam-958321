using UnityEditor.UI;
using UnityEngine;

namespace parith
{
    public class ItemBehaviour : MonoBehaviour
    {
        [SerializeField] private GameObject _sfxPrefab;
        private Transform _self;
        private float _rand;

        private void Start()
        {
            _self = transform;
            _rand = Random.Range(45f, 55f);
        }
        void Update()
        {
            _self.Rotate(Vector3.up * _rand * Time.deltaTime);
        }

        public void PlaySound()
        {
            SFXPlayer sfxPlayer = Instantiate(_sfxPrefab, _self.position, Quaternion.identity).GetComponent<SFXPlayer>();
            sfxPlayer.Initialize(gameObject.GetComponent<AudioSource>().clip);
            sfxPlayer.gameObject.SetActive(true);
        }
    }
}