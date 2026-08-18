using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Custom_DarkenSkyboxOverTime : MonoBehaviour
{

    public int HowFastToDarken = 2;
    public float startingDarkness = 1.23f;
    public float endingDarkness = 0.1f;

    private Material theSkybox;

    private float currentValue;

    private void Start()
    {
        theSkybox = RenderSettings.skybox;

        theSkybox.SetFloat("_Exposure", startingDarkness);

    }
    public void Button_DarkenTheSky()
    {



        float startExposure = theSkybox.GetFloat("_Exposure");
        Debug.Log("Current Skybox Exposure: " + startExposure);





        StartCoroutine(LerpValueOverTime(startExposure, endingDarkness, HowFastToDarken));

    }


    void OnDestroy()
    {
        theSkybox.SetFloat("_Exposure", startingDarkness);

    }


    IEnumerator LerpValueOverTime(float fromValue, float toValue, float duration)
    {
        float timeElapsed = 0f;

        while (timeElapsed < duration)
        {
            currentValue = Mathf.Lerp(fromValue, toValue, timeElapsed / duration);
            timeElapsed += Time.deltaTime;


            // Set a new exposure value (e.g., to 2.0)
            theSkybox.SetFloat("_Exposure", currentValue);
            Debug.Log("New Skybox Exposure set to " + currentValue);

            yield return null; // Wait for the next frame
        }

        // Ensure the value reaches the exact endValue when the lerp completes
        currentValue = toValue;
        Debug.Log("Lerp finished. Final value: " + currentValue);
    }



}
