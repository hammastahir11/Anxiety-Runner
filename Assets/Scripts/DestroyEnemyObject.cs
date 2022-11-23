using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Her in this script different funciton are performed related to Radar, Enemy Destroy, Enemy effect on player
//Flags handle the radar system and game complexity of the game in this script
//Bubble handle the effect of enemy on the players
//Trigger condition with tag enemy handle the destroy property of the enemy
public class DestroyEnemyObject : MonoBehaviour
{

    int bubble=0;
    int notBubble = 0;
    ComplexityFlags flags;

    //set the position of the safe bubble which is behind the player
    [SerializeField]public Transform changeSafeBubblePosition;
    
    private void Start()
    {
       flags = FindObjectOfType<ComplexityFlags>();
       
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
       //Destroy all the enemy game objects
        if (other.gameObject.tag.Equals("enemy"))
        {

            SpriteRenderer enemy = other.gameObject.GetComponent<SpriteRenderer>();
            if (!enemy.sprite.name.Contains("safe"))
            {
                
                notBubble++;
                FindObjectOfType<PlayerMovement>().Hurt();
                Destroy(other.gameObject);
                if (notBubble == 4)
                {
                    flags.AddFlag();
                    notBubble = 0;
                }
            }
            if (enemy.sprite.name.Contains("safe"))
            {
                bubble++;
                
            //    
            //disable the collider of the enemy so that enemy pass from the player and latter it will be destroyed behind the playr in Follow player Script
            //when enemy reached the player then the follow position is changed to the object behind the player 

            //bubble is varible used to count the setting of redar flags 
            other.gameObject.GetComponent<CircleCollider2D>().enabled=false;
              // cc.enabled=false;
            other.gameObject.GetComponent<FollowPlayer>().positon= changeSafeBubblePosition.position;
               
             other.gameObject.GetComponent<FollowPlayer>().check=true;  
                if (bubble == 10)
                {
                    flags.RemoveFlag();
                    bubble = 0;
                }
            }
        }
    }
}
