using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo6 : MonoBehaviour
{
    [SerializeField]
    public float spd = 2f;

    private Transform target6;
    private int wavepointIndex6 = 0;

    void Start()
    {
        target6 = Waypoint6.waypoints6[0];
    }

    void Update()
    {
        //Faz o inimigo se mover
        Vector3 dir = target6.position - transform.position;
        transform.Translate(dir.normalized * spd * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target6.position) <= 0.4f)
        {
            Destroy(gameObject);
        };
    }
}
