using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint1 : MonoBehaviour
{
    public static Transform[] waypoints1;

    void Awake()
    {
        waypoints1 = new Transform[transform.childCount];
        for (int i = 0; i < waypoints1.Length; i++)
        {
            waypoints1[i] = transform.GetChild(i);
        }
    }
}
