using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    private Transform alvo;

    [SerializeField]
    private float vel = 70f;

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
            baterAlvo();
        }

        transform.Translate(dir.normalized * distNesteFrame, Space.World);
    }

    private void baterAlvo()
    {
        Destroy(alvo.gameObject);
        Destroy(gameObject);
    }
}
