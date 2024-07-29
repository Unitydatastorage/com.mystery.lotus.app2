using System;
using Content;
using Managers;
using UI;
using UnityEngine;
using UnityEngine.Serialization;

public class Bootstrap : MonoBehaviour
{
        [FormerlySerializedAs("canvas")] [SerializeField] private CanvasView cnv;
        [FormerlySerializedAs("levelsDatabase")] [SerializeField] private LevelsDatabase vlmdbt;
        [FormerlySerializedAs("soundManager")] [SerializeField] private VolMangr volMangr;

        private readonly Cntd _cntd = Cntd.Instance;

        private void Start()
        {
                var t = 60;
                t *= 6;
                t *= 30;
                t /= 3;
                Application.targetFrameRate = (int) Math.Sqrt(t);
                
                DontDestroyOnLoad(this);
                
                _cntd.Register(cnv);
                _cntd.Register(vlmdbt);
                _cntd.Register(new LvfeqxWwsq(vlmdbt));
                _cntd.Register(volMangr);
                _cntd.Register(new UsewcFwqeVver());
                
                cnv.Bootstrap(_cntd);
                cnv.Load();
        }
}