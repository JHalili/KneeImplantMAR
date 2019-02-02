using UnityEngine;

public class SphereCommands : MonoBehaviour
{
    private bool SelectedObjectToMove = false;
    // Called by GazeGestureManager when the user performs a Select gesture
    void OnSelect()
    {
        // If the sphere has no Rigidbody component, add one to enable physics.
        SelectedObjectToMove = !SelectedObjectToMove;
    }

    private void Update()
    {
        if (SelectedObjectToMove)
        {
            // Grab the mesh renderer that's on the same object as this script.s
            //WorldCursor cursor = this.gameObject.GetComponent<WorldCursor>();
            //this.gameObject.transform.position = cursor.transform.position;
            //this.gameObject.transform.rotation = cursor.transform.rotation;

            
            Vector3 gazeDirection = Camera.main.transform.forward;
            //Vector3 myPos = this.transform.position;
            Debug.Log("The gaze direction is: ");
            Debug.Log(gazeDirection.ToString("F2"));
            //Vector3 intersectionPt = new Vector3(myPos.x * gazeDirection.x, myPos.y * gazeDirection.y, myPos.z * gazeDirection.z);
            //this.transform.position -= intersectionPt;

        }
    }
    void OnObjectHoldStarted()
    {
        // If the sphere has no Rigidbody component, add one to enable physics.
        if (!this.GetComponent<Rigidbody>())
        {
            var rigidbody = this.gameObject.AddComponent<Rigidbody>();
            rigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;
        }
    }
}