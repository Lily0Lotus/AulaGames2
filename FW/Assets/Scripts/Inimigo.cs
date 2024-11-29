using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Inimigo : MonoBehaviour
{
    [SerializeField]
    private float spd = 2f;

    [SerializeField]
    private float vida = 50;

    [SerializeField]
    private int variacaoZ;

    private void Awake()
    {
        this.transform.Translate(Vector3.forward * Random.Range(-variacaoZ, variacaoZ));
    }

    public void LevarDano(int quantidade)
    {
        vida -= quantidade;
        if (vida <= 0)
        {
            Morra();
        }
    }

    void Morra()
    {
        Destroy(gameObject);
    }

    void Update()
    {
        //Faz o inimigo se mover
        this.transform.Translate(Vector3.left * spd * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Finish")
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
