using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//[RequireComponent(typeof(MarkerPositionCheck))]
public class KneePartManager : MonoBehaviour
{
    public GameObject tibia;
    public GameObject femur;


    public GameObject muscleLayer;
    public GameObject veins;
    public GameObject arteries;


    public GameObject tibiaImplant;
    public GameObject tibiaPlateImplant;
    public GameObject femurImplant;

    //MarkerPositionCheck posChecker;

    private bool isModelAtRightPos = true;
    private void Start()
    {
       // posChecker= GameObject.FindObjectOfType<MarkerPositionCheck>();
    }

    public void ShowFullKnee(bool visible)
    {
        if (isModelAtRightPos)
        {
            muscleLayer.SetActive(visible);
            veins.SetActive(visible);
            arteries.SetActive(visible);
        }
    }
  
    // Update is called once per frame
    void Update()
    {
        // compute implant positions and possibility for a muscle layer display

       // isModelAtRightPos = posChecker.checkRotation();
        if (!isModelAtRightPos)
        {
            // make sure that the layers are not displayed
            muscleLayer.SetActive(false);
            veins.SetActive(false);
            arteries.SetActive(false);
        }
    }
    
}
