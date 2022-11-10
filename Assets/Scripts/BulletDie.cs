using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDie : MonoBehaviour
{

    [Header("Particle Effects")]
  
    [SerializeField] ParticleSystem particleEffect;

    [Header("Image for Die")]
    public float dieTime;


    [SerializeField] Sprite speaker;
    [SerializeField] Sprite sensation;
    [SerializeField] Sprite ccamear;
    

    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
       
        StartCoroutine(Timer());
        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("enemy"))
        {
            SpriteRenderer enemy = other.gameObject.GetComponent<SpriteRenderer>();
            if (enemy.sprite.name.Equals("camera"))
            {
                HitParticel(other.gameObject);
                enemy.sprite = ccamear;
                Destroy(gameObject);
            }
            else if (enemy.sprite.name.Equals("people"))
            {
                HitParticel(other.gameObject);
                enemy.sprite = sensation;
                Destroy(gameObject);
            }
            else if (enemy.sprite.name.Equals("speaker"))
            {
                enemy.sprite = speaker;

                HitParticel(other.gameObject);
                Destroy(gameObject);
            }
            audioSource.PlayOneShot(PlayerMovement.Instance.SafeguardBubble_S) ;

        }
    }


    public void HitParticel(GameObject position)
    {
        ParticleSystem Instace = Instantiate(particleEffect, position.transform.position, Quaternion.identity);
        Destroy(Instace.gameObject, Instace.main.duration + Instace.main.startLifetime.constantMax);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        GameObject collisionGameObject= other.gameObject;
        if (collisionGameObject.name!="Player")
        {
           // Die();
        }


    }

    IEnumerator Timer(){
        yield return new WaitForSeconds(dieTime);
        Die();
    }

     void Die(){
        Destroy(gameObject);
            
    }
}
