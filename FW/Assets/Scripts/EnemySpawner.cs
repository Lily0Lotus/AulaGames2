using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public Transform spawnPoint;

    public Transform inimigoPrefab;

    [SerializeField]
    public float timerOnda = 5f;

    [SerializeField]
    private float contador = 2f;

    public Text Temporizador;

    private int inimigoIndex = 0;

    private void Update ()
    {
        if (contador <= 0f)
        {
            StartCoroutine(sumonarOnda());
            contador = timerOnda;
        }
        contador -= Time.deltaTime;

        Temporizador.text = Mathf.Round(contador).ToString();
    }

    IEnumerator sumonarOnda ()
    {
        inimigoIndex++;
        for (int i = 0; i < inimigoIndex; i++)
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
