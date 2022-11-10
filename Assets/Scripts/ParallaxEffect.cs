using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//The parallax effect of the game is handled in this script. All the background parallax effect is handled in this script

public class ParallaxEffect : MonoBehaviour
{












    [SerializeField] bool infiniteHorizontal = true;
    [SerializeField] bool infiniteVertical = false;

    [SerializeField] Vector2 parallaxBackgroundMultiplier;
    [SerializeField] Vector2 textureScaleOffset;
    [SerializeField] Transform cameraTransform;
    Vector3 lastCameraPosition;
    float textureUnitSizeX;
    float textureUnitSizeY;


    private void Start()
    {
        cameraTransform = Camera.main.transform;
        lastCameraPosition = cameraTransform.position;
        textureUnitSizeX = (GetComponent<SpriteRenderer>().sprite.texture.width / GetComponent<SpriteRenderer>().sprite.pixelsPerUnit) * textureScaleOffset.x;
        textureUnitSizeY = (GetComponent<SpriteRenderer>().sprite.texture.height / GetComponent<SpriteRenderer>().sprite.pixelsPerUnit) * textureScaleOffset.y;
    }

    private void FixedUpdate()
    {
        // move the background with camera
        Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;
        transform.position += new Vector3(deltaMovement.x * parallaxBackgroundMultiplier.x, deltaMovement.y * parallaxBackgroundMultiplier.y);
        lastCameraPosition = cameraTransform.position;

        // if it reaches a certain range, change (or recenter) its position
        if (infiniteHorizontal)
        {
            if (Mathf.Abs(cameraTransform.position.x - transform.position.x) >= textureUnitSizeX)
            {
                float offsetPositionX = ((cameraTransform.position.x - transform.position.x) % textureUnitSizeX);
                transform.position = new Vector2(cameraTransform.position.x , transform.position.y);
            }
        }

        if (infiniteVertical)
        {
            if (Mathf.Abs(cameraTransform.position.y - transform.position.y) >= textureUnitSizeY)
            {
                float offsetPositionY = (cameraTransform.position.y - transform.position.y) % textureUnitSizeY;
                transform.position = new Vector2(transform.position.x, cameraTransform.position.y + offsetPositionY);
            }
        }

    }




}




































//private Transform CameraTransform;
//    private Vector3 lastCameraTransform;
//    [SerializeField] private Vector2 parallaxEffectMultiplier;
//    private float textureSizeX;



//    private void Start()
//    {
//        CameraTransform = Camera.main.transform;
//        lastCameraTransform = CameraTransform.position;
//        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
//        Texture2D texture = sprite.texture;
//        textureSizeX = texture.width / sprite.pixelsPerUnit;

//    }

//    private void LateUpdate()
//    {
//        Vector3 deltaMovement = CameraTransform.position - lastCameraTransform ;

//        transform.position += new Vector3(deltaMovement.x*parallaxEffectMultiplier.x,deltaMovement.y*parallaxEffectMultiplier.y);
//        lastCameraTransform = CameraTransform.position;


//        if (Mathf.Abs(CameraTransform.position.x - transform.position.x) >= textureSizeX)
//        {
//            float offsetPositionX = (CameraTransform.position.x - transform.position.x) % textureSizeX;
           
//            transform.position = new Vector3(CameraTransform.position.x, transform.position.y);
//        }
//    }




