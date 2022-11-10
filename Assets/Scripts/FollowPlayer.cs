using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float moveSpeed=2f;


    private void Start()
    {
        player = FindObjectOfType<AnxietyObjects>().getSkeltonTransform();
    }
    // Update is called once per frame
    void Update()
    {

        //Here enemy follow the playerer with the speed of 2f by vector2.movetowards method
        Vector3 positon = new Vector3(player.position.x, player.position.y + 2);
        transform.position = Vector2.MoveTowards(transform.position, positon, moveSpeed * Time.deltaTime);
    }
}
