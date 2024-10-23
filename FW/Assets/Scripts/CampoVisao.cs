using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torre : MonoBehaviour
{
    public Transform alvo;

    [Header("Atributos")]
    [SerializeField]
    public float alcance = 20f;
    [SerializeField]
    public float taxaDisparo = 4f;
    [SerializeField]
    private float cooldown = 0f;

    [Header("campo de setup da unity")]
    [SerializeField]
    private string tagInimigo = "Inimigo";
    public GameObject balaPrefab;
    public Transform pontoDeOrigem;
    private void Start()
    {
        InvokeRepeating("atualizarAlvo", 0f, 0.5f);
    }

    //verifica se há algum inimigo no alcance
    void atualizarAlvo()
    {
        GameObject[] inimigos = GameObject.FindGameObjectsWithTag(tagInimigo);
        float menorDist = Mathf.Infinity;
        GameObject inimigoPerto = null;

        foreach (GameObject inimigo in inimigos)
        {
            float distInimigo = Vector3.Distance(transform.position, inimigo.transform.position);
            if (distInimigo < menorDist)
            {
                menorDist = distInimigo;
                inimigoPerto = inimigo;
            }
        }

        if(inimigoPerto != null && menorDist <= alcance)
        {
            alvo = inimigoPerto.transform;
        }
        else
        {
            alvo = null;
        }
    }

    private void Update()
    {
        if (alvo == null)
            return;

        if (cooldown <= 0f)
        {
            Atirar();
            cooldown = 1f / taxaDisparo;
        }

        cooldown -= Time.deltaTime;
    }

    private void Atirar()
    {
        GameObject balaGO = (GameObject)Instantiate(balaPrefab, pontoDeOrigem.position, pontoDeOrigem.rotation);
        Bala bala = balaGO.GetComponent<Bala>();

        if (bala != null)
        {
            bala.Seguir(alvo);
        }
    }

    //cria uma esfera que haje como o campo de visão
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, alcance);
    }
}
