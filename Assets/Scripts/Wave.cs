using UnityEngine;

[System.Serializable]
public class Wave
{

    public GameObject enemy; // the enemy game object.
    public int count; // amount of enemies in the wave.
    public float rate; // our rate time for the enmies, we will divide 1 by rate.


}
