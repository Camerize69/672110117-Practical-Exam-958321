using UnityEngine;
using System.Collections;

namespace parith
{
    public class SFXPlayer : MonoBehaviour
    {
        private AudioClip _sfxToPlay;
        private AudioSource _audioSource;

        public void Initialize(AudioClip _sfx)
        {
            _sfxToPlay = _sfx;
        }

        void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
            _audioSource.PlayOneShot(_sfxToPlay);
            StartCoroutine(WaitAndExecute());
        }

        IEnumerator WaitAndExecute()
        {
            yield return new WaitForSeconds(.5f);
            Destroy(gameObject);
        }
    }
}
