using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo5 : MonoBehaviour
{
    [SerializeField]
    public float spd = 2f;

    private Transform target5;
    private int wavepointIndex5 = 0;

    void Start()
    {
        target5 = Waypoint5.waypoints5[0];
    }

    void Update()
    {
        //Faz o inimigo se mover
        Vector3 dir = target5.position - transform.position;
        transform.Translate(dir.normalized * spd * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target5.position) <= 0.4f)
        {
            Destroy(gameObject);
        };
    }
}
