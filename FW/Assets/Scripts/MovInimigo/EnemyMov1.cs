using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo1 : MonoBehaviour
{
    [SerializeField]
    public float spd = 2f;

    private Transform target1;
    private int wavepointIndex1 = 0;

    void Start()
    {
        target1 = Waypoint1.waypoints1[0];
    }

    void Update()
    {
        //Faz o inimigo se mover
        Vector3 dir = target1.position - transform.position;
        transform.Translate(dir.normalized * spd * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target1.position) <= 0.4f)
        {
            Destroy(gameObject);
        };
    }
}
