using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Inimigo4 : MonoBehaviour
{
    [SerializeField]
    public float spd = 2f;

    [SerializeField]
    private float vida = 50;

    private Transform target4;
    private int wavepointIndex4 = 0;

    void Start()
    {
        target4 = Waypoint4.waypoints4[0];
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
        Vector3 dir = target4.position - transform.position;
        transform.Translate(dir.normalized * spd * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target4.position) <= 0.4f)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("GameOver");
        }
    }
}
