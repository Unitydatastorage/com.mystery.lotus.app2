using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Serialization;

namespace Managers
{
    public class VolMangr : MonoBehaviour
    {
        private const string SoundKey = "Sound";
        private const string MusicKey = "Music";
        private const string MusicMutedKey = "MusicMuted";
        private const string SoundMutedKey = "SoundMuted";

        [FormerlySerializedAs("backgroundMusic")] [SerializeField] private AudioSource mel;
        [FormerlySerializedAs("buttonClick")] [SerializeField] private AudioSource bntCl;
        [FormerlySerializedAs("sphereClick")] [SerializeField] private AudioSource jiraClck;
        // [SerializeField] private AudioSource damageSound;
        [FormerlySerializedAs("winSound")] [SerializeField] private AudioSource wS;
        [FormerlySerializedAs("coinCollect")] [SerializeField] private AudioSource cC;
        [FormerlySerializedAs("soundMixerGroup")] [SerializeField] private AudioMixerGroup smGsaq;
        [FormerlySerializedAs("musicMixerGroup")] [SerializeField] private AudioMixerGroup mMGrp;

        private int _asqw = 80;
        private int _mdfq = 80;

        public int Asqw
        {
            get => _asqw;
            set
            {
                _asqw = value;
                CheckSoundSettings();
            }
        }

        public int Mdfq
        {
            get => _mdfq;
            set
            {
                _mdfq = value;
                CheckMusicSettings();
            }
        }
        
        public bool SndMtdw { get; set; }

        public bool MscMtd
        {
            get => mel.mute;
            set => mel.mute = value;
        }

        private void Start()
        {
            if (!PlayerPrefs.HasKey(SoundKey))
                PlayerPrefs.SetInt(SoundKey, _asqw);
            
            if (!PlayerPrefs.HasKey(MusicKey))
                PlayerPrefs.SetInt(MusicKey, _mdfq);
            
            if (!PlayerPrefs.HasKey(MusicMutedKey))
                PlayerPrefs.SetInt(MusicMutedKey, MscMtd ? 1 : 0);
            
            if (!PlayerPrefs.HasKey(SoundMutedKey))
                PlayerPrefs.SetInt(SoundMutedKey, SndMtdw ? 1 : 0);

            Asqw = PlayerPrefs.GetInt(SoundKey);
            Mdfq = PlayerPrefs.GetInt(MusicKey);
            MscMtd = PlayerPrefs.GetInt(MusicMutedKey) == 1;
            SndMtdw = PlayerPrefs.GetInt(SoundMutedKey) == 1;
            
            CheckSoundSettings();
            CheckMusicSettings();
        }

        private void OnDestroy()
        {
            PlayerPrefs.SetInt(SoundKey, Asqw);
            PlayerPrefs.SetInt(MusicKey, Mdfq);
        }

        public void OnButtonClick()
        {
            if (SndMtdw)
                return;
            
            bntCl.Play();
        }

        public void OnDiamondClick()
        {
            if (SndMtdw)
                return;

            jiraClck.Play();
        }

        public void OnCoinCollect()
        {
            if (SndMtdw)
                return;

            cC.Play();
        }

        public void OnWin()
        {
            if (SndMtdw)
                return;

            wS.Play();
        }

        /*public void OnDamage()
        {
            if (SoundMuted)
                return;

            damageSound.Play();
        }*/

        public void StartBackgroundMelody()
        {
            mel.Play();
        }

        private void CheckSoundSettings()
        {
            smGsaq.audioMixer.SetFloat("SoundVolume", _asqw);
        }

        private void CheckMusicSettings()
        {
            mMGrp.audioMixer.SetFloat("MusicVolume", _mdfq);
        }
    }
}