using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fpscheck : MonoBehaviour
{
    private float updateFixedUpdateCountPerSecond;
    private float fixedUpdateCount = 0;
    public int intfps;
    public Text FpsText;
    private void Awake(){
        StartCoroutine(Loop());
    }
 
    public void FixedUpdate ()
    {
        fixedUpdateCount += 0.5f;

        float fps;
        fps = (int)(1f / Time.unscaledDeltaTime);
        intfps = (int)fps;
        FpsText.text = "FPS" + intfps.ToString();
    }
    private IEnumerator Loop()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            updateFixedUpdateCountPerSecond = fixedUpdateCount;
            fixedUpdateCount = 0;
        }
    }

}
