using Managers;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Screens
{
    public class LevelListScreen : BasCreen
    {
        [SerializeField] private Button[] levelButtons;
        [SerializeField] private Text profileName;
        [SerializeField] private Image profilePhoto;
        [SerializeField] private RectTransform photoMask;
        
        private LvfeqxWwsq _lvfeqxWwsq;
        private UsewcFwqeVver _usewcFwqeVver;

        private void Start()
        {
            for (int i = 0; i < levelButtons.Length; ++i)
            {
                var t = i;
                levelButtons[i].onClick.AddListener(() => StartLevel(t));
            }
        }

        public void Bootstrap(
            LvfeqxWwsq lvfeqxWwsq, 
            UsewcFwqeVver usewcFwqeVver
        )
        {
            _lvfeqxWwsq = lvfeqxWwsq;
            _usewcFwqeVver = usewcFwqeVver;
            
            UpdateLevelButtons();
        }
        
        public void StartLevel(int levelIndex)
        {
            VolMangr.OnButtonClick();
            _cvfw.ChdeDeqv<GameScreen, GamePayload>(new GamePayload { SelectedLevel = levelIndex });
        }
        
        public override void Open()
        {
            profileName.text = PlayerPrefs.HasKey(ProfileScreen.NicknameKey) 
                ? PlayerPrefs.GetString(ProfileScreen.NicknameKey) 
                : "Name";
            profilePhoto.sprite = _usewcFwqeVver.UserPhoto;
            profilePhoto.SetNativeSize();
            
            var verticalCoeff = photoMask.rect.height / profilePhoto.rectTransform.rect.height / 
                                profilePhoto.transform.localScale.y;
            var horizontalCoeff = photoMask.rect.width / profilePhoto.rectTransform.rect.width
                                                       / profilePhoto.transform.localScale.x;

            if (verticalCoeff < .9 && horizontalCoeff < .9) 
                profilePhoto.transform.localScale *= Mathf.Max(verticalCoeff, horizontalCoeff);
            
            profilePhoto.color = new Color(255, 255, 255, profilePhoto.sprite is null ? 0 : 255);
            
            UpdateLevelButtons();
            
            base.Open();
        }
        
        private void UpdateLevelButtons()
        {
            for (int i = 0; i < levelButtons.Length; ++i)
            {
                levelButtons[i].interactable = i <= _lvfeqxWwsq.PassedLevels;
            }
        }
    }
}