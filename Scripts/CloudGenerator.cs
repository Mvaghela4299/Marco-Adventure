using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudGenerator : MonoBehaviour
{
    [SerializeField] GameObject[] clouds;
    [SerializeField] float spawnInterval;
    [SerializeField] GameObject endPoint;

    Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        preWarm();
        Invoke("AttemptSpawn", spawnInterval);
    }
    void spawnCloud(Vector3 startPos)
    {
        //Debug.Log("1");
        int randomIndex = UnityEngine.Random.Range(0, 4);
        GameObject cloud = Instantiate(clouds[randomIndex]);

        float startY = UnityEngine.Random.Range(startPos.y - 1f, startPos.y + 1f);

        cloud.transform.position = new Vector3(startPos.x, startY, startPos.z);

        float scale = UnityEngine.Random.Range(0.2f, 0.5f);
        cloud.transform.localScale = new Vector2(scale, scale);

        float speed = UnityEngine.Random.Range(0.3f, 1f);
        cloud.GetComponent<CloudScroll>().startFloating(speed, endPoint.transform.position.x);
    }
    void AttemptSpawn()
    {
        spawnCloud(startPos);

        Invoke("AttemptSpawn", spawnInterval);
    }
    void preWarm()
    {
        for (int i = 0; i < 4; i++)
        {
            Vector3 spawnPos = startPos + Vector3.left * (i * 1);
            spawnCloud(spawnPos);
        }   
    }
}