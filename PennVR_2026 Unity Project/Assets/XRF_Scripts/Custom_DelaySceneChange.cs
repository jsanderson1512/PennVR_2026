using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Custom_DelaySceneChange : MonoBehaviour
{
    public string whatSceneToLoad;
    public int howManySecondsToDelay = 10;



    public void Button_StartTheTimer()
    {
        StartCoroutine(DelaySceneChange());

    }

    private IEnumerator DelaySceneChange()
    {
        yield return new WaitForSeconds(howManySecondsToDelay);

        SceneManager.LoadScene(whatSceneToLoad);


    }

}
