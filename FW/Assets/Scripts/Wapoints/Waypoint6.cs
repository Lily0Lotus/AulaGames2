using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint6 : MonoBehaviour
{
    public static Transform[] waypoints6;

    void Awake()
    {
        waypoints6 = new Transform[transform.childCount];
        for (int i = 0; i < waypoints6.Length; i++)
        {
            waypoints6[i] = transform.GetChild(i);
        }
    }
}
