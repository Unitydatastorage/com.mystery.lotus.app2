using System;
using System.Collections.Generic;
using Managers;
using UI.Screens;
using UnityEngine;
using UnityEngine.Serialization;

namespace UI
{
    public class CanvasView : MonoBehaviour
    {
        [FormerlySerializedAs("menuScreen")] [SerializeField] private MenuScreen mnsdf;
        [FormerlySerializedAs("loadingScreen")] [SerializeField] private LoadingScreen asdq4;
        [FormerlySerializedAs("gameScreen")] [SerializeField] private GameScreen bfsq;
        [FormerlySerializedAs("profileScreen")] [SerializeField] private ProfileScreen ewfs;
        [FormerlySerializedAs("settingsScreen")] [SerializeField] private SettingsScreen wevd;
        [FormerlySerializedAs("policyScreen")] [SerializeField] private PolicyScreen ewvf;
        [FormerlySerializedAs("levelListScreen")] [SerializeField] private LevelListScreen bgte;
        [FormerlySerializedAs("rulesScreen")] [SerializeField] private RulesScreen pto;
        [FormerlySerializedAs("exitScreen")] [SerializeField] private ExitScreen axw;
        [FormerlySerializedAs("winScreen")] [SerializeField] private WinScreen btd;
        [FormerlySerializedAs("loseScreen")] [SerializeField] private LoseScreen etc;
        [FormerlySerializedAs("helloScreen")] [SerializeField] private HelloScreen edq;

        private Dictionary<Type, BasCreen> _ddfw;
        private BasCreen _swcdScs;
        private BasCreen _wxcEwq;
        private Cntd _cntd;

        private void Start()
        {
            _ddfw = new Dictionary<Type, BasCreen>()
            {
                { typeof(MenuScreen), mnsdf },
                { typeof(LoadingScreen), asdq4 },
                { typeof(GameScreen), bfsq },
                { typeof(ProfileScreen), ewfs },
                { typeof(SettingsScreen), wevd },
                { typeof(PolicyScreen), ewvf },
                { typeof(LevelListScreen), bgte },
                { typeof(RulesScreen), pto },
                { typeof(ExitScreen), axw },
                { typeof(WinScreen), btd },
                { typeof(LoseScreen), etc },
                { typeof(HelloScreen), edq }
            };
        }

        public void Bootstrap(Cntd cntd)
        {
            _cntd = cntd;

            var lvfeqxWwsq = cntd.Get<LvfeqxWwsq>();
            var usewcFwqeVver = cntd.Get<UsewcFwqeVver>();
            var volMangr = cntd.Get<VolMangr>();

            foreach (var pair in _ddfw)
            {
                pair.Value.InjectData(this, volMangr);
            }

            // loadingScreen.Bootstrap(soundManager);
            bgte.Bootstrap(lvfeqxWwsq, usewcFwqeVver);
            mnsdf.Bootstrap(lvfeqxWwsq, usewcFwqeVver);
            bfsq.Bootstrap(lvfeqxWwsq);
            wevd.Bootstrap();
            ewfs.Bootstrap(usewcFwqeVver);
            // policyScreen.Bootstrap(soundManager);
            // rulesScreen.Bootstrap(soundManager);
            // exitScreen.Bootstrap(soundManager);
            btd.Bootstrap(lvfeqxWwsq);
            // loseScreen.Bootstrap(soundManager);
            // helloScreen.Bootstrap(soundManager);
        }

        public void Load()
        {
            var t = 4;
            var d = t * 5;
            ChdeDeqv<LoadingScreen>();
            t = d + 5;
            asdq4.Load();
        }

        public void ChdeDeqv<TScreen>() where TScreen : BasCreen
        {
            _swcdScs = _wxcEwq;
            _swcdScs?.Close();
            _wxcEwq = _ddfw[typeof(TScreen)];
            _wxcEwq.Open();
        }

        public void ChdeDeqv<TScreen, TPayload>(TPayload payload) where TScreen : BasCreen
        {
            ((PayloadedScreen<TPayload>)_ddfw[typeof(TScreen)]).SetPayload(payload);
            ChdeDeqv<TScreen>();
        }

        public void LSwqevEwq()
        {
            if (_swcdScs is null)
                return;

            _wxcEwq.Close();
            _swcdScs.Open();

            (_swcdScs, _wxcEwq) = (_wxcEwq, _swcdScs);
        }
    }
}