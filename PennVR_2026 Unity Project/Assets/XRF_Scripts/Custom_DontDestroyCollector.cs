using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Custom_DontDestroyCollector : MonoBehaviour
{
    public static Custom_DontDestroyCollector instance;


    public string[] thingsToPickUpTags;
    public string[] thingsAffectedByPickUpsTag;
    public bool[] alreadyPickedUp;

    private List<GameObject> thingsToPickUp = new List<GameObject>();
    private List<GameObject> thingsAffectedByPickUps = new List<GameObject>();


    //this is a script that will follow you scene-to-scene. to check for if you have collected 
    //certain items.
    //it needs to check for tagged items
    //it needs to remember bool values for if you have itmes
    //it needs to turn certain things off if you have items


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            instance.CheckforStuff();
            Destroy(this.gameObject);
        }


        DontDestroyOnLoad(this.gameObject);

        //StartCoroutine(waitForSomeTime(5));
    }


    private void Start()
    {
        CheckforStuff();
    }
    private void CheckforStuff()
    {
        //this happens at the start of a scene

        Debug.Log("hello i am checking for stuff");
        int pickUpsFound = 0;
        int pickUpsAffectedFound = 0;

        thingsToPickUp = new List<GameObject>();
        thingsAffectedByPickUps = new List<GameObject>();

        for (int i = 0; i < thingsToPickUpTags.Length; i++)
        {
            GameObject g = GameObject.FindGameObjectWithTag(thingsToPickUpTags[i]);
            if (g != null)
            {
                thingsToPickUp.Add(g);
                pickUpsFound++;
            }
            else
            {
                thingsToPickUp.Add(null);
            }
        }

        for (int i = 0; i < thingsAffectedByPickUpsTag.Length; i++)
        {
            GameObject g = GameObject.FindGameObjectWithTag(thingsAffectedByPickUpsTag[i]);
            if (g != null)
            {
                thingsAffectedByPickUps.Add(g);
                pickUpsAffectedFound++;
            }
            else
            {
                thingsAffectedByPickUps.Add(null);
            }
        }

        Debug.Log("i found this many pickups: " + pickUpsFound);
        Debug.Log("i found this many affected pickups: " + pickUpsAffectedFound);


        for (int i = 0; i < alreadyPickedUp.Length; i++)
        {
            if (alreadyPickedUp[i] == true)
            {
                //turn off associated things in other scenes
                if (thingsAffectedByPickUps[i] != null)
                {
                    thingsAffectedByPickUps[i].SetActive(false);
                }
                //turn off already picked up stuff
                if (thingsToPickUp[i] != null)
                {
                    thingsToPickUp[i].SetActive(false);
                }
            }
        }

    }


    private void Update()
    {
        for (int i = 0; i < alreadyPickedUp.Length; i++)
        {
            if (alreadyPickedUp[i] == false)
            {
                //Debug.Log("hey looking for item: " + i);

                if (thingsToPickUp[i]!=null)
                {
                    //Debug.Log("hey i found this thing to pick up its name is:" + thingsToPickUp[i].name);
                    if (thingsToPickUp[i].activeSelf == false)
                    {
                        alreadyPickedUp[i] = true;
                        CheckforStuff();
                    }
                }
            }
        }
    }

    IEnumerator waitForSomeTime(int howLong)
    {
        yield return new WaitForSeconds(howLong);
        //some stuff happens after Howlong seconds
    }
}
