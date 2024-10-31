using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosão : MonoBehaviour
{
    private Transform alvo;

    [SerializeField]
    private float delay = 2f;

    [SerializeField]
    private float raioExplosao = 3f;

    [SerializeField]
    public int dano = 200;

    [SerializeField]
    private GameObject efeitoExplosao;

    private float kaboom;
    bool explodiu = false;

    private void Seguir(Transform _alvo)
    {
        alvo = _alvo;
    }

    void Start()
    {
        kaboom = delay;
    }

    void Update()
    {
        kaboom -= Time.deltaTime;
        if (kaboom <= 0f && !explodiu)
        {
            Explodir();
            explodiu = true;
        }
    }

    private void Explodir()
    {
        //Efeito
        GameObject efeitoExplo = (GameObject)Instantiate(efeitoExplosao, transform.position, transform.rotation);
        Destroy(efeitoExplo, 1f);

        Collider[] colisores = Physics.OverlapSphere(transform.position, raioExplosao);
        foreach (Collider col in colisores) 
        {
            if (col.tag == "Inimigo")
            {
                Danificar(col.transform);
            }
        }

        //Remover objeto
        Destroy(gameObject);
    }
    void Danificar(Transform inimigo)
    {
        Inimigo ini = inimigo.GetComponent<Inimigo>();
        if (ini != null)
        {
            ini.LevarDano(dano);
        }

        Inimigo1 ini1 = inimigo.GetComponent<Inimigo1>();
        if (ini1 != null)
        {
            ini1.LevarDano(dano);
        }

        Inimigo2 ini2 = inimigo.GetComponent<Inimigo2>();
        if (ini2 != null)
        {
            ini2.LevarDano(dano);
        }

        Inimigo3 ini3 = inimigo.GetComponent<Inimigo3>();
        if (ini3 != null)
        {
            ini3.LevarDano(dano);
        }

        Inimigo4 ini4 = inimigo.GetComponent<Inimigo4>();
        if (ini4 != null)
        {
            ini4.LevarDano(dano);
        }

        Inimigo5 ini5 = inimigo.GetComponent<Inimigo5>();
        if (ini5 != null)
        {
            ini5.LevarDano(dano);
        }

        Inimigo6 ini6 = inimigo.GetComponent<Inimigo6>();
        if (ini6 != null)
        {
            ini6.LevarDano(dano);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, raioExplosao);
    }
}
