using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    [SerializeField] GameObject platformPrefab;
    [SerializeField] GameObject firstPlatform;
    [SerializeField] GameObject lastPlatform;

    [SerializeField] List<Vector2> transPosY = new List<Vector2>();
    Vector2 biggestY = new Vector2();

    void Start()
    {
        biggestY.y = firstPlatform.transform.position.y;
        for (int i = 0; i < 20; i++)
        {
            RandomSpawnObject(5);
        }
    }
    void Update()
    {
        print(biggestY);
    }

    void RandomSpawnObject(float radius)
    {
        CheckLastPlatform();
        Vector2 spawnPosition = lastPlatform.transform.position;
        spawnPosition += Random.insideUnitCircle.normalized * radius;

        if (spawnPosition.y < 0)
        {
            spawnPosition *= -1;
        }
        Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
        AddPosToList();
    }
    void AddPosToList()
    {
        transPosY.Add(gameObject.transform.position);
    }
    void CheckLastPlatform()
    {
        for (int i = 0; i < transPosY.Count; i++)
        {
            //if (transPosY[i] > biggestY)
            //{
                
            //}
        }
        if (gameObject.transform.position.x > lastPlatform.transform.position.x)
        {
            lastPlatform = gameObject;
        }
    }
}
