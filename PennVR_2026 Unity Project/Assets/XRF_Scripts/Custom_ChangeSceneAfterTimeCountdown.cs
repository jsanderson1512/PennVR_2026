using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Custom_ChangeSceneAfterTimeCountdown : MonoBehaviour
{
    public TMP_Text theTextBox;
    public int howManySeconds;
    public string whatSceneToLoad;

    private bool isRunning = false;


    // Update is called once per frame
    void Update()
    {
        if(!isRunning)
        {
            StartCoroutine(CountTimer());
            isRunning = true;
        }
    }
    private IEnumerator CountTimer()
    {
        //every one second, i will update the timer...
        yield return new WaitForSeconds(1);

        howManySeconds--;
        theTextBox.text = "00:" + howManySeconds.ToString();

        if (howManySeconds < 0)
        {
            SceneManager.LoadScene(whatSceneToLoad);
        }
        else
        {
            StartCoroutine (CountTimer());
        }

    }
}
