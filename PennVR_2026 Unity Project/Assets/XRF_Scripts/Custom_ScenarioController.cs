using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Custom_ScenarioController : MonoBehaviour
{
    public int[] OverallPersonalityTypeWeighting;

    public GameObject[] AllScenarios;

    // Start is called before the first frame update
    void Start()
    {
        UpdateScenarios();
    }

    public void RegisterAnswer(int[] answers)
    {
        for (int i = 0; i < OverallPersonalityTypeWeighting.Length; i++)
        {
            OverallPersonalityTypeWeighting[i] += answers[i];
        }

        UpdateScenarios();
    }

    public void UpdateScenarios()
    {
        int biggestNumber = 0;
        int indexOfBiggestNumber = 0;

        for (int i = 0; i < OverallPersonalityTypeWeighting.Length; i++)
        {
            if (OverallPersonalityTypeWeighting[i] > biggestNumber)
            {
                biggestNumber = OverallPersonalityTypeWeighting[i];
                indexOfBiggestNumber = i;

            }
        }

        for (int i = 0; i < AllScenarios.Length; i++)
        {
            if (i == indexOfBiggestNumber)
            {
                AllScenarios[i].SetActive(true);
            }
            else
            {
                AllScenarios[i].SetActive(false);
            }
        }
    }
}
