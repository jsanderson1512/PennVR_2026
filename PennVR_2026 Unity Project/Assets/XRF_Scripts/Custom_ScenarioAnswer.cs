using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Custom_ScenarioAnswer : MonoBehaviour
{
    private Custom_ScenarioController controller;

    public int[] PersonalityTypeWeighting;

    // Start is called before the first frame update
    void Start()
    {
        controller = FindObjectOfType<Custom_ScenarioController>();
        Debug.Log("I found the controller on this object: " +  controller.gameObject.name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RegisterAnswer()
    {
        controller.RegisterAnswer(PersonalityTypeWeighting);

    }
}
