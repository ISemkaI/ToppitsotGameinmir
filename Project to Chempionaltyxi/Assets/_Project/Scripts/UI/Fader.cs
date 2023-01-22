using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class Fader : MonoBehaviour
{
    private CanvasGroup _canvasGroup;

    private Coroutine _fadeInCoroutine;
    private Coroutine _fadeOutCoroutine;

    private void Awake() 
        => _canvasGroup = GetComponent<CanvasGroup>();

    public void FadeIn()
    {
        StopOtherCoroutineIfExist(ref _fadeOutCoroutine);
        _fadeInCoroutine = StartCoroutine(FadeInCoroutine());
    }

    public void FadeOut()
    {
        StopOtherCoroutineIfExist(ref _fadeInCoroutine);
        _fadeOutCoroutine = StartCoroutine(FadeOutCoroutine());
    }

    public void HideImmediately()
        => _canvasGroup.alpha = 0.0f;

    private void StopOtherCoroutineIfExist(ref Coroutine otherFadeCoroutine)
    {
        if (otherFadeCoroutine != null)
        {
            StopCoroutine(otherFadeCoroutine);
            otherFadeCoroutine = null;
        }
    }
    
    IEnumerator FadeInCoroutine()
    {
        while (_canvasGroup.alpha > 0.0f)
        {
            yield return new WaitForSeconds(0.1f);
            _canvasGroup.alpha -= 0.1f;
        }

        _canvasGroup.alpha = 0.0f;
    }

    IEnumerator FadeOutCoroutine()
    {
        while (_canvasGroup.alpha < 1.0f)
        {
            yield return new WaitForSeconds(0.1f);
            _canvasGroup.alpha += 0.1f;
        }

        _canvasGroup.alpha = 1.0f;
    }
}
