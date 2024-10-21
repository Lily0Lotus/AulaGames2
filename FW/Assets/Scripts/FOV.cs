using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FOV : MonoBehaviour
{
    public float radius;
    [Range(0, 360)]
    public float angulo;

    public GameObject sombraRef;

    public LayerMask mascaraAlvo;
    public LayerMask mascaraObstruir;

    public bool podeVerSombra;

    private void Start()
    {
        sombraRef = GameObject.FindGameObjectWithTag("Inimigo");
        StartCoroutine(rotinaFOV());
    }

    private IEnumerator rotinaFOV()
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);

        while (true)
        {
            yield return wait;
            checkFOV();
        }
    }

    private void checkFOV()
    {
        Collider[] rangeCheck = Physics.OverlapSphere(transform.position, radius, mascaraAlvo);

        if (rangeCheck.Length != 0)
        { 
            Transform alvo = rangeCheck[0].transform;
            Vector3 direcParaAlvo = (alvo.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, direcParaAlvo) < angulo / 2)
            {
                float distDoAlvo = Vector3.Distance(transform.position, alvo.position);

                //Vê se essas condições falham
                if (!Physics.Raycast(transform.position, direcParaAlvo, distDoAlvo, mascaraObstruir))
                    podeVerSombra = true;
                else
                    podeVerSombra = false;
                
            } else
            { 
                podeVerSombra = false;
            }
        }
        else if (podeVerSombra)
        {
            podeVerSombra = false;
        }
    }
}
