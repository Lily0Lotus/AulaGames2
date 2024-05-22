using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chao : MonoBehaviour
{
    [SerializeField]
    private float velocidade = 0.6f;

    private Vector3 posicaoInicial;
    private float tamanhoNaCena;

    private void Awake()
    {
        this.posicaoInicial = this.transform.position;
        float tamanhoReal = GetComponent<SpriteRenderer>().size.x;
        float escala = this.transform.localScale.x;
        this.tamanhoNaCena = tamanhoReal * escala;
    }
    // Update is called once per frame
    void Update()
    {
        float deslocamento = Mathf.Repeat(this.velocidade * Time.time, tamanhoNaCena);
        this.transform.Translate(Vector3.left * velocidade * Time.deltaTime);

        this.transform.position = this.posicaoInicial + Vector3.left * deslocamento;
    }
}
