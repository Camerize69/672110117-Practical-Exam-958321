
using parith;
using UnityEngine;
using UnityEngine.UI;

namespace parith
{
    public class SoundManager : MonoBehaviour
    {
        [SerializeField] protected SoundSettings m_SoundSettings;

        public Slider m_SliderMasterVolume;
        public Slider m_SliderBGMVolume;
        public Slider m_SliderSFXVolume;

        // Start is called before the first frame update
        private void Start()
        {
            InitialiseVolumes();
        }

        private void InitialiseVolumes()
        {
            SetMasterVolume(m_SoundSettings.MasterVolume);
            SetBGMVolume(m_SoundSettings.BGMVolume);
            SetSFXVolume(m_SoundSettings.SFXVolume);
        }

        public void SetMasterVolume(float vol)
        {
            m_SoundSettings.AudioMixer.SetFloat(m_SoundSettings.MasterVolumeName, vol);

            m_SoundSettings.MasterVolume = vol;

            if (m_SliderMasterVolume != null) { m_SliderMasterVolume.value = vol; }
        }

        public void SetBGMVolume(float vol)
        {
            m_SoundSettings.AudioMixer.SetFloat(m_SoundSettings.BGMVolumeName, vol);

            m_SoundSettings.BGMVolume = vol;

            if (m_SliderBGMVolume != null) { m_SliderBGMVolume.value = vol; }
        }

        public void SetSFXVolume(float vol)
        {
            m_SoundSettings.AudioMixer.SetFloat(m_SoundSettings.SFXVolumeName, vol);

            m_SoundSettings.SFXVolume = vol;

            if (m_SliderSFXVolume != null) { m_SliderSFXVolume.value = vol; }
        }
    }
}
