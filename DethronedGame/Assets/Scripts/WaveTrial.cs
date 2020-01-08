using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveTrial : MonoBehaviour
{
    public GameObject Enemy;

    public Transform SpawnPoint;

    GameManager manager = new GameManager();

   
    private float countdown = 10f;

    private static int waveNumber = 1;

    public static int waves = 7; 


    // Start is called before the first frame update
    void Start()
    {
        if (manager == null)
        {
            manager = FindObjectOfType<GameManager>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(countdown <= 0)
        {
            StartCoroutine(SpawnWave());
            countdown = 10f;
        }

        countdown -= Time.deltaTime;

        if(waveNumber >= waves)
        {
            manager.WinLevel();
        }
    }

    IEnumerator SpawnWave()
    {
        waveNumber++;

        for (int i=0; i<waveNumber; i++)
        {
            Instantiate(Enemy, SpawnPoint.position, SpawnPoint.rotation);
            yield return new WaitForSecondsRealtime(0.5f);
        }

  
    }
}
