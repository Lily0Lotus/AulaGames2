using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torre : MonoBehaviour
{
    private Transform alvo;
    [SerializeField]
    public float alcance = 20f;

    public string tagInimigo = "Inimigo";
    private void Start()
    {
        InvokeRepeating("atualizarTorre", 0f, 0.5f);
    }

    //verifica se há algum inimigo no alcance
    void atualizarTorre()
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
        
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, alcance);
    }
}
