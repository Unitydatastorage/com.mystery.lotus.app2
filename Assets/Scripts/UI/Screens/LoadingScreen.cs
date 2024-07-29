using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Screens
{
    public class LoadingScreen : BasCreen
    {
        [SerializeField] private Image progress;
        [SerializeField] private float loadingDuration = 1f;
        
        public void Load()
        {
            StartCoroutine(LoadingCoroutine());
        }

        private IEnumerator LoadingCoroutine()
        {
            var loadingProgress = 0f;
            progress.fillAmount = loadingProgress;
            
            while (loadingProgress < loadingDuration)
            {
                loadingProgress += Time.deltaTime;
                
                progress.fillAmount = loadingProgress / loadingDuration;
                
                yield return null;
            }
            
            VolMangr.StartBackgroundMelody();
            _cvfw.ChdeDeqv<HelloScreen>();
        }
    }
}