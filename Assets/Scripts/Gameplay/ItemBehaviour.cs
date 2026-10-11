using UnityEditor.UI;
using UnityEngine;

namespace parith
{
    public class ItemBehaviour : MonoBehaviour
    {
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
    }

}