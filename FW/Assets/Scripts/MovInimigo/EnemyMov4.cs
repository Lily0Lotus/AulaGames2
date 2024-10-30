using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo4 : MonoBehaviour
{
    [SerializeField]
    public float spd = 2f;

    private Transform target4;
    private int wavepointIndex4 = 0;

    void Start()
    {
        target4 = Waypoint4.waypoints4[0];
    }

    void Update()
    {
        //Faz o inimigo se mover
        Vector3 dir = target4.position - transform.position;
        transform.Translate(dir.normalized * spd * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target4.position) <= 0.4f)
        {
            Destroy(gameObject);
        };
    }
}
