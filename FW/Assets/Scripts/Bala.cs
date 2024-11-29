using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    private Transform alvo;

    [SerializeField]
    private float vel = 70f;

    [SerializeField]
    private int dano = 25;

    [SerializeField]
    private float raioExplosao = 0f;

    public void Seguir(Transform _alvo)
    { 
        alvo = _alvo;
    }
    void Update()
    {
        if (alvo == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = alvo.position - transform.position;
        float distNesteFrame = vel * Time.deltaTime;

        if(dir.magnitude <= distNesteFrame)
        {
            atingirAlvo();
        }

        transform.Translate(dir.normalized * distNesteFrame, Space.World);
    }

    private void atingirAlvo()
    {
        if (raioExplosao > 0f)
        {
            Explodir();
        } else
        {
            Danificar(alvo);
        }

        Destroy(gameObject);
    }

    void Explodir()
    {
        //pega todos os colisores que estão dentro da esfera
        Collider[] colisores = Physics.OverlapSphere(transform.position, raioExplosao);
        foreach (Collider col in colisores)
        {
            if (col.tag == "Inimigo")
            {
                Danificar(col.transform);
            }
        }
    }

    void Danificar(Transform inimigo)
    {
        Inimigo ini = inimigo.GetComponent<Inimigo>();
        if (ini != null)
        {
            ini.LevarDano(dano);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, raioExplosao);
    }
}
