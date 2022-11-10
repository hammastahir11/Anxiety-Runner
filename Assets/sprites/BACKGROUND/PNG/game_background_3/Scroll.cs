using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{


    public static Scroll Instance;

    [SerializeField] GameObject[] MapObjects;
    [SerializeField] Sprite[] MapSprites;
    [Range(-2f,2f)]
    [SerializeField] float speed = 0.5f;
     public Vector3 initialPosition;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        initialPosition = new Vector3(22.35f, 1.32f, -4.07f);
        Debug.Log(initialPosition); 
    }
    private void Update()
    {
        MapObjects[0].transform.position = new Vector2(MapObjects[0].transform.position.x + speed, MapObjects[0].transform.position.y);
        MapObjects[1].transform.position = new Vector2(MapObjects[1].transform.position.x + speed, MapObjects[1].transform.position.y);

        //Debug.Log(MapObjects[0].transform.position);
        if (MapObjects[0].transform.position.x < -30.62f) 
        {
            MapObjects[0].transform.position = initialPosition;
        }
        if (MapObjects[1].transform.position.x < -30.62f)
        {
            MapObjects[1].transform.position = initialPosition;
        }
       
    }

   

    //private void OnCollisionEnter2D(Collision2D collision)
    //{

    //    Debug.Log("Scroll : " + collision.gameObject.name);
    //    collision.gameObject.transform.position = initialPosition;

    //}


}
