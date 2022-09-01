using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RandomlySpawnCards : MonoBehaviour
{

    public Vector3 placementSize;
    public bool visualiser = false;
    public GameObject[] cards;
    


    private void Awake()
    {
        cards = new GameObject[transform.childCount];
        
        for (int i = 0; i < cards.Length; i++)
        {
            cards[i] = transform.GetChild(i).gameObject;
            Vector3 randomPos = new Vector3(UnityEngine.Random.Range(-placementSize.x / 2.0f, placementSize.x / 2), UnityEngine.Random.Range(0,0.001f), UnityEngine.Random.Range(-placementSize.z / 2, placementSize.z / 2));
            cards[i].transform.position = randomPos + transform.position ;
            Vector3 angles = cards[i].transform.eulerAngles;
            angles.z= UnityEngine.Random.Range(-180, 180);
            bool rotate = Convert.ToBoolean(UnityEngine.Random.Range(0, 2));
            if  (rotate)
            { angles.x = -90; }
            cards[i].transform.eulerAngles = angles;
            
        }  
         
        // Place cards in children
    }

    private void OnDrawGizmos() {
        if (visualiser)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawCube(transform.position, placementSize);

        }
    }
}
