using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class bala : MonoBehaviour
{
    [Range(1, 10)]
    [SerializeField]
    private float velocidade = 10f;

    [Range(1, 10)]
    [SerializeField]
    private float tempoVida = 3f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, tempoVida);
    }

    private void FixedUpdate()
    {
        rb.velocity = transform.right * velocidade;

        Vector3 mouse = Input.mousePosition;
        
        Vector3 cordTela = Camera.main.WorldToScreenPoint(transform.localPosition);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
