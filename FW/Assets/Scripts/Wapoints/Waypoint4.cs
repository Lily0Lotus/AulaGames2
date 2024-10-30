using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint4 : MonoBehaviour
{
    public static Transform[] waypoints4;

    void Awake()
    {
        waypoints4 = new Transform[transform.childCount];
        for (int i = 0; i < waypoints4.Length; i++)
        {
            waypoints4[i] = transform.GetChild(i);
        }
    }
}
