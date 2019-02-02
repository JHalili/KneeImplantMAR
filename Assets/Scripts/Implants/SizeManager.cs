using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeManager : MonoBehaviour
{
    public void onSizeUp()
    {
        Debug.Log("Increasing object size");
        this.transform.localScale += new Vector3(1, 1, 1);

    }

    public void onSizeDown()
    {
        if (transform.localScale.x > 1 && transform.localScale.y > 1 && transform.localScale.z > 1)
        {
            Debug.Log("Decreasing object size");
            this.transform.localScale -= new Vector3(1, 1, 1);
           
        }
        
    }
}
