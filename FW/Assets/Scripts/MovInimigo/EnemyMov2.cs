using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo2 : MonoBehaviour
{
    [SerializeField]
    public float spd = 2f;

    private Transform target2;
    private int wavepointIndex2 = 0;

    void Start()
    {
        target2 = Waypoint2.waypoints2[0];
    }

    void Update()
    {
        //Faz o inimigo se mover
        Vector3 dir = target2.position - transform.position;
        transform.Translate(dir.normalized * spd * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target2.position) <= 0.4f)
        {
            Destroy(gameObject);
        };
    }
}
