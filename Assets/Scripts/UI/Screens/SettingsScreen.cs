using UnityEngine;
using UnityEngine.UI;

namespace UI.Screens
{
    public class SettingsScreen : BasCreen
    {
        [SerializeField] private Image musicIcon;
        [SerializeField] private Image soundIcon;
        [SerializeField] private Toggle soundToggle;
        [SerializeField] private Toggle musicToggle;
        [SerializeField] private Slider musicSlider;
        [SerializeField] private Slider soundSlider;
        [SerializeField] private Sprite musicSprite;
        [SerializeField] private Sprite soundSprite;
        [SerializeField] private Sprite musicDisabledSprite;
        [SerializeField] private Sprite soundDisabledSprite;
        
        public void Bootstrap()
        {
            UpdateIcons();
        }

        /*
        public void ToggleMusic()
        {
            _soundManager.OnButtonClick();
            _soundManager.IsMusicTurnedOn = !_soundManager.IsMusicTurnedOn;
            UpdateIcons();
        }

        public void ToggleSound()
        {
            _soundManager.OnButtonClick();
            _soundManager.IsSoundTurnedOn = !_soundManager.IsSoundTurnedOn;
            UpdateIcons();
        }*/

        public void ChangeSoundLevel()
        {
            VolMangr.Asqw = (int)(soundSlider.value * 100) - 100;
        }

        public void ChangeMusicLevel()
        {
            VolMangr.Mdfq = (int)(musicSlider.value * 100) - 100;
        }

        public void ToggleMusic()
        {
            VolMangr.MscMtd = !VolMangr.MscMtd;
            VolMangr.OnButtonClick();
            UpdateIcons();
        }

        public void ToggleSound()
        {
            VolMangr.SndMtdw = !VolMangr.SndMtdw;
            VolMangr.OnButtonClick();
            UpdateIcons();
        }

        private void UpdateIcons()
        {
            soundIcon.sprite = VolMangr.SndMtdw 
                ? soundDisabledSprite 
                : soundSprite;
            musicIcon.sprite = VolMangr.MscMtd
                ? musicDisabledSprite
                : musicSprite;
            
            // soundToggle.isOn = _soundManager.IsSoundTurnedOn;
            // musicToggle.isOn = _soundManager.IsMusicTurnedOn;

            soundSlider.value = (float)(VolMangr.Asqw + 100) / 100;
            musicSlider.value = (float)(VolMangr.Mdfq + 100) / 100;
        }
    }
}