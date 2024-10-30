using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint3 : MonoBehaviour
{
    public static Transform[] waypoints3;

    void Awake()
    {
        waypoints3 = new Transform[transform.childCount];
        for (int i = 0; i < waypoints3.Length; i++)
        {
            waypoints3[i] = transform.GetChild(i);
        }
    }
}
