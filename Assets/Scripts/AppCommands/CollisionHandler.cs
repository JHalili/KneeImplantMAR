using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    AudioSource saw;
    private void Start()
    {
        saw = GameObject.FindObjectOfType<AudioSource>();
    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        Debug.Log("Detected collision between " + gameObject.name + " and " + collisionInfo.collider.name);
        Debug.Log("There are " + collisionInfo.contacts.Length + " point(s) of contacts");
        Debug.Log("Their relative velocity is " + collisionInfo.relativeVelocity);
        Debug.Log("Collision has happened1!!1");
        if (collisionInfo.collider.name.Equals("FemurImplantMesh"))
        {
            Debug.Log("Found femur implant mesh");
            saw.Play();
        }
        
    }

    void OnCollisionStay(Collision collisionInfo)
    {
        if (collisionInfo.collider.name.Equals("FemurImplantMesh"))
        {
            print(gameObject.name + " and " + collisionInfo.collider.name + " are still colliding");
        }
    }

    void OnCollisionExit(Collision collisionInfo)
    {
        if (collisionInfo.collider.name.Equals("FemurImplantMesh"))
        {
            print(gameObject.name + " and " + collisionInfo.collider.name + " are no longer colliding");
        }
    }
}
