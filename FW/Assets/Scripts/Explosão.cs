using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosão : MonoBehaviour
{
    [SerializeField]
    private float delay = 3f;

    [SerializeField]
    private float raio = 5f;

    [SerializeField]
    private GameObject efeitoExplosao;

    private float kaboom;
    bool explodiu = false;

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

    public void DestruirInimigo()
    {
        Destroy(GameObject.FindWithTag("Inimigo"));
    }
    void Explodir()
    {
        //Efeito
        Instantiate(efeitoExplosao, transform.position, transform.rotation);

        //Pega os inimigos na área
        Collider[] colisores = Physics.OverlapSphere(transform.position, raio);
        foreach (Collider sombrasNaArea in colisores)
        {
            Explodivel dest = sombrasNaArea.GetComponent<Explodivel>();
            if (dest != null) 
            { 
                dest.Destruir();
            }
        }

        //Remover objeto
        Destroy(gameObject);
    }
}
