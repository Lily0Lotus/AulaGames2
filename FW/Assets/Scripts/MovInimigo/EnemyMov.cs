using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    [SerializeField]
    public float spd = 2f;

    private Transform target;
    private int wavepointIndex = 0;

    void Start()
    {
        target = Waypoint.waypoints[0];
    }

    void Update()
    {
        //Faz o inimigo se mover
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * spd * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            Destroy(gameObject);
        };
    }
}
