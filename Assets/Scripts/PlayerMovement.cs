using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement Instance;
    private void Awake()
    {
        Instance = this;
    }

    //Sound
    [Header("Sound")]

    [SerializeField] public AudioClip SafeguardBubble_S;



    public float movePower = 10f;
        public float KickBoardMovePower = 15f;
        public float jumpPower = 20f; //Set Gravity Scale in Rigidbody2D Component to 5

        private Rigidbody2D rb;
        private Animator anim;
        Vector3 movement;
        private float direction = 1;
        bool isJumping = false;
        private bool alive = true;
        private bool isKickboard = false;


        // Start is called before the first frame update
        void Start()
        {
            isShooting=false;
            rb = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
        }

        private void Update()
        {

        // autoRun();
        Restart();
        if (alive)
        {
           //Hurt();
           // Die();
            Attack();
            Jump();
           // KickBoard();
            Run();

        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(gameObject.GetComponent<PlayerMovement>().isActiveAndEnabled==true)
            anim.SetBool("isJump", false);
    }
    void KickBoard()
        {
            if (Input.GetKeyDown(KeyCode.Alpha4) && isKickboard)
            {
                isKickboard = false;
                anim.SetBool("isKickBoard", false);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4) && !isKickboard )
            {
                isKickboard = true;
                anim.SetBool("isKickBoard", true);
            }

        }


        

        //void autoRun()
        //{
        //    if (!isKickboard)
        //    {
        //        Vector3 moveVelocity = Vector3.zero;
        //        anim.SetBool("isRun", false);


            
        //        if (true)
        //        {
        //            direction = 0.51586f;
        //            moveVelocity = Vector3.right;

        //            transform.localScale = new Vector3(direction, 0.51586f, 0.51586f);
        //            if (!anim.GetBool("isJump"))
        //                anim.SetBool("isRun", true);

        //        }
        //        transform.position += moveVelocity * movePower * Time.deltaTime;

        //    }
           
        //}

        





        void Run()
        {
            if (!isKickboard)
            {
                Vector3 moveVelocity = Vector3.zero;
                anim.SetBool("isRun", false);


                if (Input.GetAxisRaw("Horizontal") < 0)
            {//0.51586f
                direction = -0.7f;
                    moveVelocity = Vector3.left;

                    transform.localScale = new Vector3(direction, 0.7f, 0.7f);
                    if (!anim.GetBool("isJump"))
                        anim.SetBool("isRun", true);

                }
                if (Input.GetAxisRaw("Horizontal") > 0 || true)
                {
                    direction = 0.7f;
                moveVelocity = new Vector3(0,0,0);//Vector3.right;

                    transform.localScale = new Vector3(direction, 0.7f, 0.7f);
                    if (!anim.GetBool("isJump"))
                        anim.SetBool("isRun", true);

                }
                transform.position += moveVelocity * movePower * Time.deltaTime;

            }
            if (isKickboard)
            {
                Vector3 moveVelocity = Vector3.zero;
                if (Input.GetAxisRaw("Horizontal") < 0)
                {
                    direction = -0.7f;
                    moveVelocity = Vector3.left;

                    transform.localScale = new Vector3(direction, 0.7f, 0.7f);
                }
                if (Input.GetAxisRaw("Horizontal") > 0)
                {
                    direction =0.7f;
                    moveVelocity = Vector3.right;

                    transform.localScale = new Vector3(direction, 0.7f, 0.7f);
                }
                transform.position += moveVelocity * KickBoardMovePower * Time.deltaTime;
            }
        }



 
    public void Jump(bool jump=false)
        {

            //FOR WEB
            if ((Input.GetButtonDown("Jump") || Input.GetAxisRaw("Vertical") > 0)
            && !anim.GetBool("isJump"))
            {

            if (gameObject.transform.position.y > -2.826012)
            {
               
                return;
            }
            isJumping = true;
                anim.SetBool("isJump", true);
            }

            //FOR MOBILE
            if ((jump)
                && !anim.GetBool("isJump"))
            {
            

            if (gameObject.transform.position.y > -2.826012)
            {
                return;
            }
                isJumping = true;
                anim.SetBool("isJump", true);
            

            }
                if (!isJumping)
                    {
                        return;
                    }

            rb.velocity = Vector2.zero;
      
            Vector2 jumpVelocity = new Vector2(0, jumpPower);
            rb.AddForce(jumpVelocity, ForceMode2D.Impulse);
        
            isJumping = false;
        }


        public float shootSpeed, shootTimer;
        private bool isShooting;
        public Transform shootPosition;
        public GameObject Bullet;

        public void Attack(bool fire=false)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1) && !isShooting)
            {
                anim.SetTrigger("attack");
                StartCoroutine(Shoot());
            }

            else if (fire && !isShooting)
            {
                anim.SetTrigger("attack");
                StartCoroutine(Shoot());
            }
        IEnumerator Shoot(){
                int direction(){
                    if(transform.localScale.x < 0f){
                        return -1;
                    }
                    else{
                        return +1;
                    }
                }
                isShooting=true;
                GameObject newBullet= Instantiate(Bullet, shootPosition.position, Quaternion.identity);
                newBullet.GetComponent<Rigidbody2D>().velocity=new Vector2(shootSpeed*direction()*Time.fixedDeltaTime,0f);
                newBullet.transform.localScale=new Vector2(newBullet.transform.localScale.x * direction(), newBullet.transform.localScale.y);
                
                yield return new WaitForSeconds(shootTimer);
                isShooting= false;
            }
                
        }
        public void Hurt()
        {
            if (true)
            {
                anim.SetTrigger("hurt");
                // if (direction == 1)
                //     rb.AddForce(new Vector2(-5f, 1f), ForceMode2D.Impulse);
                // else
                //     rb.AddForce(new Vector2(5f, 1f), ForceMode2D.Impulse);
            }
        }
        void Die()
        {
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                isKickboard = false;
                anim.SetBool("isKickBoard", false);
                anim.SetTrigger("die");
                alive = false;
            }
        }
        void Restart()
        {
            if (Input.GetKeyDown(KeyCode.Alpha0))
            {
                isKickboard = false;
                anim.SetBool("isKickBoard", false);
                anim.SetTrigger("idle");
                alive = true;
            }
        }
}
