using Core;
using Managers;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace UI.Screens
{
    public class WinScreen : PayloadedScreen<GamePayload>
    {
        [FormerlySerializedAs("nextLevelButton")] [SerializeField] private Button ntlSLevBt;
        [FormerlySerializedAs("scoreText")] [SerializeField] private Text sctTer;
        
        private LvfeqxWwsq _lvfeqxWwsq;

        public void Bootstrap(LvfeqxWwsq lvfeqxWwsq)
        {
            _lvfeqxWwsq = lvfeqxWwsq;
        }

        public override void Open()
        {
            sctTer.text = $"{TextFormatter.FormatScore(_payload.Score)}";
            
            base.Open();
        }

        public void Next()
        {
            VolMangr.OnButtonClick();
            
            _cvfw.ChdeDeqv<GameScreen, GamePayload>(new GamePayload()
            {
                SelectedLevel = _lvfeqxWwsq.LastLevelIndex,
            });
        }
    }
}