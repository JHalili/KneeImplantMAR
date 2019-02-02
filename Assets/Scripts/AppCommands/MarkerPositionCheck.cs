using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkerPositionCheck : MonoBehaviour
{

    public GameObject femurImgTarget;
    public GameObject tibiaImgTarget;

  
    // Update is called once per frame
    void Update()
    {
        if (femurImgTarget && tibiaImgTarget)
        {
            float dist = Vector3.Distance(femurImgTarget.transform.position, tibiaImgTarget.transform.position);
            
            if ((dist > 10) && checkRotation())
            {
                print("The bones are in distance and rotation is the same");
            }
        }
    }


    public bool checkRotation()
    {
        if ((checkOriantationInOneAxis(femurImgTarget.transform.eulerAngles.x, tibiaImgTarget.transform.eulerAngles.x)) &&
            (checkOriantationInOneAxis(femurImgTarget.transform.eulerAngles.y, tibiaImgTarget.transform.eulerAngles.y)) &&
            (checkOriantationInOneAxis(femurImgTarget.transform.eulerAngles.z, tibiaImgTarget.transform.eulerAngles.z)))
            return true;
        else
            return false;
    }

    bool checkOriantationInOneAxis(float femuraxis, float tibiaaxis)
    {
        float angleDifference = 0.1f; //it can be %10 tilted...
        if (femuraxis * (1 + angleDifference) > tibiaaxis && femuraxis * (1 - angleDifference) < tibiaaxis)
            return true;
        else
            return false;
    }
}