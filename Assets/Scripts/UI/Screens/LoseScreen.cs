using Core;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Screens
{
    public class LoseScreen : PayloadedScreen<GamePayload>
    {
        [SerializeField] private Text scoreText;

        public override void Open()
        {
            scoreText.text = $"{TextFormatter.FormatScore(_payload.Score)}";
            
            base.Open();
        }
        
        public void TryAgain()
        {
            VolMangr.OnButtonClick();

            _cvfw.ChdeDeqv<GameScreen, GamePayload>(_payload);
        }
    }
}