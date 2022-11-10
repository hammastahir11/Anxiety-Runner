using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnxietyObjects : MonoBehaviour
{
    [SerializeField] List<GameObject> anxietyObjects;

    [SerializeField] Transform PlayerTransform;

    [SerializeField] Transform SkeltonTransform;
    float timer = 1000f;

    float yAxixSpawn;
    float currentflag=9;


    DateTime time;
  
    private void Start()
    {
        time = DateTime.UtcNow;
        yAxixSpawn = PlayerTransform.position.y;
    }

    public Transform getSkeltonTransform()
    {
        Transform tr = SkeltonTransform;
        return tr;
    }



    private void Update()
    {
        //Here by increasing or decreaseing the value of timer we can handle the spawning of the enemy in game.
        if (ComplexityFlags.flag_count > currentflag)
        {
            timer -= 100f;
            currentflag = ComplexityFlags.flag_count;
        }
        if (ComplexityFlags.flag_count < currentflag)
        {
            timer += 100f;
            currentflag = ComplexityFlags.flag_count;
        }



       //Spawning the enemy after specfic time interval
        if ((DateTime.UtcNow-time).TotalMilliseconds>timer)
        {
            SpawnAxietyObjects();
        }
    }
    public void SpawnAxietyObjects()
    {
        time = DateTime.UtcNow;
        System.Random rnd = new System.Random();
        int chooseAnxietyObjectFromList = rnd.Next(0,anxietyObjects.Count);

        int location = rnd.Next(0, 7);
        anxietyObjects[chooseAnxietyObjectFromList].transform.position = new Vector3(PlayerTransform.position.x+13.8061f, yAxixSpawn + location, PlayerTransform.position.z);

        Instantiate(anxietyObjects[chooseAnxietyObjectFromList]);
    }

}
