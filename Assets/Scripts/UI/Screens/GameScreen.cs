using System;
using System.Collections;
using Core;
using Entities;
using Managers;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Screens
{
    public class GameScreen : PayloadedScreen<GamePayload>
    {
        [SerializeField] private Text scoreText;
        [SerializeField] private Text timeText;
        [SerializeField] private Transform gamePlace;
        [SerializeField] private Text levelText;
        [SerializeField] private int winScore = 550;
        
        private LongTerm _longTerm;
        
        private LvfeqxWwsq _lvfeqxWwsq;

        public void Bootstrap(LvfeqxWwsq lvfeqxWwsq)
        {
            _lvfeqxWwsq = lvfeqxWwsq;
        }

        public override void SetPayload(GamePayload payload)
        {
            base.SetPayload(payload);

            scoreText.text = $"0";
            // levelText.text = $"L E V E L   {TextFormatter.FormatScore(payload.SelectedLevel + 1)}";

            if (_longTerm != null)
            {
                _longTerm.OnWin -= OnWin;
                _longTerm.OnLose -= OnLose;
                _longTerm.OnScoreChange -= OnScoreChange;
                _longTerm.OnTimeChange -= OnTimeChange;
                Destroy(_longTerm.gameObject);
            }

            _longTerm = Instantiate(
                _lvfeqxWwsq.GetLevelData(payload.SelectedLevel), 
                gamePlace
            );
            _longTerm.OnWin += OnWin;
            _longTerm.OnLose += OnLose;
            _longTerm.OnScoreChange += OnScoreChange;
            _longTerm.OnTimeChange += OnTimeChange;
            
            _longTerm.Bootstrap(VolMangr, winScore, payload.SelectedLevel);
        }

        public override void Open()
        {
            base.Open();
            
            if(_longTerm != null)
                _longTerm.AwqefS();
        }

        public override void Close()
        {
            base.Close();
        }
        
        public void NextLevel()
        {
            VolMangr.OnButtonClick();
            if (_payload.SelectedLevel >= 8)
            {
                _cvfw.ChdeDeqv<MenuScreen>();
                return;
            }
            
            SetPayload(new GamePayload() { SelectedLevel = _payload.SelectedLevel + 1 });
        }

        private void OnWin()
        {
            _lvfeqxWwsq.IncreasePassedLevels(_payload.SelectedLevel);
            _lvfeqxWwsq.Score += _longTerm.Scrt;

            StartCoroutine(CallDelayed(() =>
            {
                _cvfw.ChdeDeqv<WinScreen, GamePayload>(new GamePayload
                {
                    Score = _longTerm.Scrt,
                    SelectedLevel = _payload.SelectedLevel
                });
            }));


            // winScreen.SetActive(true);
            // nextLevelButton.SetActive(true);
        }

        private void OnLose()
        {
            StartCoroutine(CallDelayed(() =>
            {
                _cvfw.ChdeDeqv<LoseScreen, GamePayload>(new GamePayload
                {
                    Score = _longTerm.Scrt,
                    SelectedLevel = _payload.SelectedLevel
                });
            }));
        }

        private void OnScoreChange(int score)
        {
            // scoreText.text = $"Score:\n{score}";
            scoreText.text = $"{TextFormatter.FormatScore(score)}";
        }

        private void OnTimeChange(int time)
        {
            timeText.text = $"TIME: {TextFormatter.FormatTime(time)}";
        }

        private IEnumerator CallDelayed(Action callback)
        {
            yield return new WaitForSeconds(1f);
            
            callback.Invoke();
        }
    }

    public class GamePayload
    {
        public int SelectedLevel;
        public int Score;
    }
}