using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject startRoadPrefab,roadPrefab,endPlatformPrefab;
    [SerializeField]
    private int amountToSpawn = 10;
    private int beginCount = 0;

    private float blockWidth = 45.72f;
    private Vector3 lastPos;


    void Awake()
    {
        InstantiateLevel();
    }

    void InstantiateLevel() { 
        
        for(int i= beginCount; i < amountToSpawn; i++) {
            GameObject newRoad;
            if (i == 0)
                newRoad = Instantiate(startRoadPrefab,transform);
            else if(i == amountToSpawn - 1) {
                newRoad = Instantiate(endPlatformPrefab);
                newRoad.tag = "EndPlatform";
            }
            else {
                newRoad = Instantiate(roadPrefab);
            }
            newRoad.transform.parent = transform;
            newRoad.transform.position = new Vector3(0, 0, lastPos.z + blockWidth);
            lastPos = newRoad.transform.position;


        }
    }

}
