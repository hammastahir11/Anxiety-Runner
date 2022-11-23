using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnxietyObjects : MonoBehaviour
{
    List<int> IndexArray=new List<int>();
     [SerializeField] Sprite speaker;
    [SerializeField] Sprite sensation;
    [SerializeField] Sprite ccamear;
    
    [SerializeField] List<GameObject> anxietyObjects;
//    [SerializeField] List<RawImage> safebubbleImages;

    [SerializeField] Transform PlayerTransform;

    [SerializeField] Transform SkeltonTransform;
    float timer = 500f;

    float yAxixSpawn;
    float currentflag=9;
    int TotalBubleInstansiate=0;
    int PreviousFlag=9;

    DateTime time;
    ComplexityFlags complexityFlags;
  
    private void Start()
    {
        time = DateTime.UtcNow;
        yAxixSpawn = PlayerTransform.position.y;
        complexityFlags = FindObjectOfType<ComplexityFlags>();
    }

    public Transform getSkeltonTransform()
    {
        Transform tr = SkeltonTransform;
        return tr;
    }



    private void Update()
    {
        //Here by increasing or decreaseing the value of timer we can handle the spawning of the enemy in game.
        if (complexityFlags.flag_count > currentflag)
        {
            timer -= 100f;
            currentflag = complexityFlags.flag_count;
        }
        if (complexityFlags.flag_count < currentflag)
        {
            timer += 100f;
            currentflag = complexityFlags.flag_count;
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
        
        if(PreviousFlag!=complexityFlags.flag_count){
            GenerateRandomIndexForSafeEenmy(9-complexityFlags.flag_count);
        }
        
        if(IndexArray.Contains(TotalBubleInstansiate%10)){
           // Debug.Log("The index number generated now is : "+TotalBubleInstansiate%10);
            int location = rnd.Next(0, 7);
             anxietyObjects[chooseAnxietyObjectFromList].transform.position = new Vector3(PlayerTransform.position.x+13.8061f, yAxixSpawn + location, PlayerTransform.position.z);
            GameObject enemy1= Instantiate(anxietyObjects[chooseAnxietyObjectFromList]);
            SpriteRenderer enemy = enemy1.GetComponent<SpriteRenderer>();
             if (enemy.sprite.name.Equals("camera"))
             {
                
                 enemy.sprite = ccamear;
                
             }
             else if (enemy.sprite.name.Equals("people"))
             {
               
                 enemy.sprite = sensation;
                
             }
             else if (enemy.sprite.name.Equals("speaker"))
             {
                 enemy.sprite = speaker;

             }
        }
        else{
            int location = rnd.Next(0, 7);
            anxietyObjects[chooseAnxietyObjectFromList].transform.position = new Vector3(PlayerTransform.position.x+13.8061f, yAxixSpawn + location, PlayerTransform.position.z);
            Instantiate(anxietyObjects[chooseAnxietyObjectFromList]);
        }





        TotalBubleInstansiate++;
    }


    

    public void GenerateRandomIndexForSafeEenmy(int number){
        IndexArray.Clear();
        String val="";
        //Debug.Log("=====================================================: ");
        for(int i=0;i<number; ){
            
             System.Random rnd = new System.Random();
            int chooseAnxietyObjectFromList = rnd.Next(0,10);
           if(IndexArray.Contains(chooseAnxietyObjectFromList)){
            //continue;
           }
            val+=chooseAnxietyObjectFromList.ToString();
            IndexArray.Add(chooseAnxietyObjectFromList);
            i++;
            
        }

       // Debug.Log("The new array generated is : "+val);
        //Debug.Log("=====================================================: ");
      
        PreviousFlag=complexityFlags.flag_count;
    }



}
