using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo1 : MonoBehaviour
{
    [SerializeField]
    public float spd = 2f;

    [SerializeField]
    private float vida = 50;

    private Transform target1;
    private int wavepointIndex1 = 0;

    /*[SerializeField]
    private float tempo = 60f;

    [SerializeField]
    private float maisVida = 60f;

    [SerializeField]
    private float ganharVida = 50f;*/

    void Start()
    {
        target1 = Waypoint1.waypoints1[0];
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
        Vector3 dir = target1.position - transform.position;
        transform.Translate(dir.normalized * spd * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target1.position) <= 0.4f)
        {
            Destroy(gameObject);
        }

        /*maisVida -= Time.deltaTime;
        if (maisVida <= 0)
        {
            GanharMaisVida();
            maisVida = tempo;
        }*/
    }

    /*void GanharMaisVida()
    {
        vida = vida + ganharVida;
    }*/
}
