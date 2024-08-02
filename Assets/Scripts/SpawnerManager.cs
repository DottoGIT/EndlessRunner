using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    public bool isSimulated;

    [SerializeField] Transform Spawner;

    [SerializeField] List<GameObject> shortTraps;
    [SerializeField] List<GameObject> longTraps;
    [SerializeField] List<GameObject> coins;

    [SerializeField] float baseShortTrapInterval;
    [SerializeField] float baseLongTrapInterval;
    [SerializeField] float baseCoinTrapInterval;

    [SerializeField] int howManyShorts;
    [SerializeField] int howManyLongs;
    [SerializeField] int howManyCoins;

    float realShortTrapInterval;
    float realLongTrapInterval;
    float realCoinTrapInterval;

    int shortSpawned = 0;
    int longSpawned = 0;
    int coinsSpawned = 0;

    float shortsTimer = 0;
    float longsTimer = 0;
    float coinsTimer = 0;

    GameManager gameManag;

    void Start()
    {
        gameManag = FindObjectOfType<GameManager>();
        shortsTimer = baseShortTrapInterval;
        UpdateTimers();
    }

    void Update()
    {
        if(shortsTimer != 0)
        {
            shortsTimer -= Time.deltaTime;
            if(shortsTimer <= 0)
            {
                SpawnTrap(1);
                shortsTimer = realShortTrapInterval;
                shortSpawned++;
                if(shortSpawned >= howManyShorts)
                {
                    shortSpawned = 0;
                    shortsTimer = 0;
                    longsTimer = realLongTrapInterval;
                }
            }
        }
        else if(longsTimer != 0)
        {
            longsTimer -= Time.deltaTime;
            if (longsTimer <= 0)
            {
                SpawnTrap(2);
                longsTimer = realLongTrapInterval;
                longSpawned++;
                if (longSpawned >= howManyLongs)
                {
                    longSpawned = 0;
                    longsTimer = 0;
                    coinsTimer = realCoinTrapInterval;
                }
            }
        }
        else if(coinsTimer != 0)
        {
            coinsTimer -= Time.deltaTime;
            if (coinsTimer <= 0)
            {
                SpawnTrap(3);
                coinsTimer = realCoinTrapInterval;
                coinsSpawned++;
                if (coinsSpawned >= howManyCoins)
                {
                    coinsSpawned = 0;
                    coinsTimer = 0;
                    shortsTimer = realCoinTrapInterval;
                    if(!isSimulated)
                        gameManag.IncreaseSpeed();
                }
            }

        }
    }

    void SpawnTrap(int index)
    {
        /*
        index meaning
        1. Shorts
        2. Longs
        3. Coins
         */

        GameObject whatToSpawn = null;

        switch(index)
        {
            case 1:
                whatToSpawn = shortTraps[Random.Range(0,shortTraps.Count)];
                break;
            case 2:
                whatToSpawn = longTraps[Random.Range(0, longTraps.Count)];
                break;
            case 3:
                whatToSpawn = coins[Random.Range(0, coins.Count)];
                break;

        }
        Instantiate(whatToSpawn, Spawner.transform.position, Quaternion.identity);
    }

    public void UpdateTimers()
    {
        if(!isSimulated)
        {
            realShortTrapInterval = baseShortTrapInterval / gameManag.gameSpeedMultioplier;
            realLongTrapInterval = baseLongTrapInterval / gameManag.gameSpeedMultioplier;
            realCoinTrapInterval = baseCoinTrapInterval / gameManag.gameSpeedMultioplier;
        }
        else
        {
            realShortTrapInterval = baseShortTrapInterval;
            realLongTrapInterval = baseLongTrapInterval;
            realCoinTrapInterval = baseCoinTrapInterval;
        }
    }

}
