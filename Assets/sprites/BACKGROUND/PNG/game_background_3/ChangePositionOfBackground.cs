using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePositionOfBackground : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Change Pos of back : " + collision.gameObject.name);
        if (collision.gameObject.tag == "Background")
        {

        collision.gameObject.transform.position = Scroll.Instance.initialPosition;
        }
    }

}
