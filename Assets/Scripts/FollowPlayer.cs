using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
 Transform player;
    public Vector3 positon;
    [SerializeField] float moveSpeed=2f;
    public bool check=false;
    Transform destroyPosition;
    private void Start()
    {
        player = FindObjectOfType<AnxietyObjects>().getSkeltonTransform();
        destroyPosition=FindObjectOfType<DestroyEnemyObject>().changeSafeBubblePosition;
    }
    // Update is called once per frame
    void Update()
    {

        //Here enemy follow the playerer with the speed of 2f by vector2.movetowards method
       if(check!=true){
        positon = new Vector3(player.position.x, player.position.y + 3);

       }
       if(destroyPosition.position.x==transform.position.x || destroyPosition.position.y==transform.position.y){
              Destroy(gameObject);
       }
        // int minorChangeInPosition = rnd.Next(1,4);
        // Debug.Log("THE MINOR CHANGE VALUE IS : "+minorChangeInPosition);
        transform.position = Vector2.MoveTowards(transform.position, positon, moveSpeed * Time.deltaTime);
    }
}
