using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Inimigo5 : MonoBehaviour
{
    [SerializeField]
    public float spd = 2f;

    [SerializeField]
    private float vida = 50;

    private Transform target5;
    private int wavepointIndex5 = 0;

    void Start()
    {
        target5 = Waypoint5.waypoints5[0];
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
        Vector3 dir = target5.position - transform.position;
        transform.Translate(dir.normalized * spd * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target5.position) <= 0.4f)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("GameOver");
        }
    }
}
