using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cano : MonoBehaviour
{
    [SerializeField]
    private float velocidade = 0.6f;

    [SerializeField]
    private float variacaoY;

    private Vector3 posicaoFrango;

    private bool ponto;

    private scriptUI scriptUI;
    private void Awake()
    {
        this.transform.Translate(Vector3.up * Random.Range(-variacaoY, variacaoY));
    }

    private void Start()
    {
        this.posicaoFrango = GameObject.FindObjectOfType<Bird>().transform.position;
        this.scriptUI = GameObject.FindObjectOfType<scriptUI>();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.left * velocidade * Time.deltaTime);

        if (!this.ponto && this.transform.position.x < posicaoFrango.x)
        {
            this.ponto = true;
            this.scriptUI.adicionarPonto();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Finish")
        {
            this.destruir();
        }
    }

    void destruir()
    {
        GameObject.Destroy(this.gameObject);
    }
}
