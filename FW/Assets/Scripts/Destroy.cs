using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    [SerializeField]
    private float duracao = 2f;
    // Update is called once per frame
    void Update()
    {
        duracao -= Time.deltaTime;
        if (duracao <= 0)
        {
            Destroy(gameObject);
        }
    }
}
