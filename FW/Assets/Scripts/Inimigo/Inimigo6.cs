using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Inimigo6 : MonoBehaviour
{
    [SerializeField]
    public float spd = 2f;

    public float vida = 50;

    private Transform target6;
    private int wavepointIndex6 = 0;

    void Start()
    {
        target6 = Waypoint6.waypoints6[0];
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
        Vector3 dir = target6.position - transform.position;
        transform.Translate(dir.normalized * spd * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target6.position) <= 0.4f)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("GameOver");
        }
    }
}
