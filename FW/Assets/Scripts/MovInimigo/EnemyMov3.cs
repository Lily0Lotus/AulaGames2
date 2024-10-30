using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo3 : MonoBehaviour
{
    [SerializeField]
    public float spd = 2f;

    private Transform target3;
    private int wavepointIndex3 = 0;

    void Start()
    {
        target3 = Waypoint3.waypoints3[0];
    }

    void Update()
    {
        //Faz o inimigo se mover
        Vector3 dir = target3.position - transform.position;
        transform.Translate(dir.normalized * spd * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target3.position) <= 0.4f)
        {
            Destroy(gameObject);
        };
    }
}
