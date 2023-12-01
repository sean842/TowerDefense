using UnityEngine;

public class wayPointsScript : MonoBehaviour
{

    // In this script we will put all the "WayPoints" in an array.
    


    public static Transform[] wayPoints; // An array to store waypoints for enemy movement.

    private void Awake() {
        // Retrieve and store all child objects as waypoints.
        wayPoints = new Transform[transform.childCount];

        for (int i = 0; i < wayPoints.Length; i++) {
            // Populate the waypoint array with child objects.
            wayPoints[i] = transform.GetChild(i);
        }
       
    }


}
