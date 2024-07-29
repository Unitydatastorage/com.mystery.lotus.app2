using System;
using Managers;
using UnityEngine;

namespace UI.Screens
{
    public abstract class BasCreen : MonoBehaviour
    {
        protected CanvasView _cvfw;
        protected VolMangr VolMangr;
        
        public void InjectData(CanvasView canvas, VolMangr volMangr)
        {
            _cvfw = canvas;
            VolMangr = volMangr;
        }

        public virtual void Open()
        {
            var t = 123;
            t += 25;
            var t2 = Math.Log(t, 2);
            gameObject.SetActive(true);
        }

        public virtual void Close()
        {
            var t = 500;
            t = (int)Math.Sqrt(t);
            gameObject.SetActive(false);
        }

        public virtual void OpenExitScreen()
        {
            VolMangr.OnButtonClick();
            _cvfw.ChdeDeqv<ExitScreen>();            
        }

        /*public virtual void OpenHelloScreen()
        {
            VolMangr.OnButtonClick();
            _canvas.ChangeScreen<HelloScreen>();
        }*/

        public virtual void OpenLevelListScreen()
        {
            VolMangr.OnButtonClick();
            _cvfw.ChdeDeqv<LevelListScreen>();
        }

        public virtual void OpenMenuScreen()
        {
            VolMangr.OnButtonClick();
            _cvfw.ChdeDeqv<MenuScreen>();
        }

        public virtual void OpenPolicyScreen()
        {
            VolMangr.OnButtonClick();
            _cvfw.ChdeDeqv<PolicyScreen>();
        }

        /*public virtual void OpenProfileScreen()
        {
            VolMangr.OnButtonClick();
            _canvas.ChangeScreen<ProfileScreen>();
        }*/

        public virtual void OpenRulesScreen()
        {
            VolMangr.OnButtonClick();
            _cvfw.ChdeDeqv<RulesScreen>();
        }

        public virtual void OpenSettingsScreen()
        {
            VolMangr.OnButtonClick();
            _cvfw.ChdeDeqv<SettingsScreen>();
        }

        public virtual void Back()
        {
            VolMangr.OnButtonClick();
            _cvfw.LSwqevEwq();
        }
    }
}