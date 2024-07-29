using Managers;
using UnityEngine;

namespace UI.Screens
{
    public class ExitScreen : BasCreen
    {
        public void Exit()
        {
            VolMangr.OnButtonClick();
            Application.Quit();
        }
    }
}