using Core;
using Managers;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Screens
{
    public class MenuScreen : BasCreen
    {
        [SerializeField] private Text profileName;
        [SerializeField] private Image profilePhoto;
        [SerializeField] private RectTransform photoMask;
        [SerializeField] private Text scoreText;
        private UsewcFwqeVver _usewcFwqeVver;
        private LvfeqxWwsq _lvfeqxWwsq;

        public void Bootstrap(
            LvfeqxWwsq lvfeqxWwsq,
            UsewcFwqeVver usewcFwqeVver
        )
        {
            _lvfeqxWwsq = lvfeqxWwsq;
            _usewcFwqeVver = usewcFwqeVver;
        }

        public void StartGame()
        {
            VolMangr.OnButtonClick();
            _cvfw.ChdeDeqv<GameScreen, GamePayload>(
                new GamePayload() { SelectedLevel = _lvfeqxWwsq.LastLevelIndex }
            );
            // _canvas.ChangeScreen<GameScreen, GamePayload>(new GamePayload { SelectedLevel = _levelSavesManager.LastLevelIndex });
        }

        public override void Open()
        {
            profileName.text = PlayerPrefs.HasKey(ProfileScreen.NicknameKey) 
                ? PlayerPrefs.GetString(ProfileScreen.NicknameKey) 
                : "Name";
            profilePhoto.sprite = _usewcFwqeVver.UserPhoto;
            scoreText.text = $"{TextFormatter.FormatScore(_lvfeqxWwsq.Score)}";
            profilePhoto.SetNativeSize();
            
            var verticalCoeff = photoMask.rect.height / profilePhoto.rectTransform.rect.height / 
                                profilePhoto.transform.localScale.y;
            var horizontalCoeff = photoMask.rect.width / profilePhoto.rectTransform.rect.width
                / profilePhoto.transform.localScale.x;

            if (verticalCoeff < .9 && horizontalCoeff < .9) 
                profilePhoto.transform.localScale *= Mathf.Max(verticalCoeff, horizontalCoeff);
            
            profilePhoto.color = new Color(255, 255, 255, profilePhoto.sprite is null ? 0 : 255);
            
            base.Open();
        }
        
        public void Exit()
        {
            VolMangr.OnButtonClick();
            Application.Quit();
        }
    }
}