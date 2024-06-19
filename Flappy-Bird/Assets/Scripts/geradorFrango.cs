using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class geradorFrango : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject modeloFrango;

    [SerializeField]
    private float tempoParaGerar = 1.5f;
    private float cronometro;

    private void Awake()
    {
        this.cronometro = this.tempoParaGerar;
    }
    // Update is called once per frame
    void Update()
    {
        this.cronometro -= Time.deltaTime;
        if (this.cronometro < 0)
        {
            GameObject.Instantiate(this.modeloFrango, this.transform.position, Quaternion.identity);
            this.cronometro = this.tempoParaGerar;
        }
    }
}
