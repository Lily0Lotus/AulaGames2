                                                                                                                                        using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cano : MonoBehaviour
{
    [SerializeField]
    private float velocidade = 0.6f;

    [SerializeField]
    private float variacaoY;
    private void Awake()
    {
        this.transform.Translate(Vector3.up * Random.Range(-variacaoY, variacaoY));
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.left * velocidade * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        this.destruir();
    }

    void destruir()
    {
        GameObject.Destroy(this.gameObject);
    }
}
