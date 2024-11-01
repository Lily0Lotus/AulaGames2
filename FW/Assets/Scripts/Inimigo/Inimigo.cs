using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Inimigo : MonoBehaviour
{
    [SerializeField]
    private float spd = 2f;

    [SerializeField]
    private float vida = 50;

    private Transform target;
    private int wavepointIndex = 0;

    void Start()
    {
        target = Waypoint.waypoints[0];
    }

    public void LevarDano(int quantidade)
    {
        vida -= quantidade;
        if (vida <= 0)
        {
            Morra();
        }
    }

    void Morra()
    {
        Destroy(gameObject);
    }

    void Update()
    {
        //Faz o inimigo se mover
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * spd * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("GameOver");
        };
    }
}
