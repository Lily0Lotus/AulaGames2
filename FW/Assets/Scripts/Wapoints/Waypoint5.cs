using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint5 : MonoBehaviour
{
    public static Transform[] waypoints5;

    void Awake()
    {
        waypoints5 = new Transform[transform.childCount];
        for (int i = 0; i < waypoints5.Length; i++)
        {
            waypoints5[i] = transform.GetChild(i);
        }
    }
}
