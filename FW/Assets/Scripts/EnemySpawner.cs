using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public Transform spawnPoint;

    public Transform inimigoPrefab;

    //Quantidade de inimigos que podem spawnarem por vez
    [SerializeField]
    private int numMinInimigos = 1;
    [SerializeField]
    private int numMaxInimigos = 3;
    private int numSpawn = 0;

    //Timer para cada grupo spawnar
    [SerializeField]
    private int timerGerarMin = 3;
    [SerializeField]
    private int timerGerarMax = 6;
    private int timer = 0;

    //Timer para as sombras começarem a vir
    [SerializeField]
    private int timerMin = 3;
    [SerializeField]
    private int timerMax = 6;
    private float cont = 0;

    [SerializeField]
    private float tempo = 60f;

    [SerializeField]
    private int aumentarQuantIni = 2;

    [SerializeField]
    private float tempoTaxa = 60f;

    private void Awake()
    {
        timer = Random.Range(timerGerarMin, timerGerarMax);
        cont = Random.Range(timerMin, timerMax);
    }

    private void Update ()
    {
        if (cont <= 0f)
        {
            cont = Random.Range(timerMin, timerMax);
            StartCoroutine(sumonarOnda());
            cont = timer;
        }
        cont -= Time.deltaTime;

        tempoTaxa -= Time.deltaTime;
        if (tempoTaxa <= 0f)
        {
            AumentarTaxaIni();
        }
    }

    void AumentarTaxaIni()
    {
        numMaxInimigos = numMaxInimigos + aumentarQuantIni;
        numMinInimigos = numMinInimigos + aumentarQuantIni;
        tempoTaxa = tempo;
    }

    IEnumerator sumonarOnda ()
    {
        numSpawn = Random.Range(numMinInimigos, numMaxInimigos);
        for (int i = 0; i < numSpawn; i++)
        {
            sumonarinimigo();
            yield return new WaitForSeconds(0.5f);
        }
    }

    void sumonarinimigo() 
    {
        Instantiate(inimigoPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
