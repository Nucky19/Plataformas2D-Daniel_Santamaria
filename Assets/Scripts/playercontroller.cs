using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    private Rigidbody2D characterRigidbody;
    public static Animator anim;
    private float horizontalInput;
    [SerializeField]private float jumpForce = 6.5f; 
    [SerializeField]private float characterSpeed = 4.5f;
    [SerializeField]private int healtPoints = 3;



    void Awake()
    {
        characterRigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Run();
        Jump();
    }


    void Run(){
        horizontalInput = Input.GetAxis("Horizontal");

         if(horizontalInput < 0){
            transform.rotation = Quaternion.Euler( 0, 180, 0);
            anim.SetBool("IsRunning",true);
         }else if(horizontalInput > 0){
            transform.rotation = Quaternion.Euler( 0, 0, 0);
            anim.SetBool("IsRunning",true);
         }else{
            anim.SetBool("IsRunning",false);
         }
    }

    void Jump(){
        if(Input.GetButtonDown("Jump") && groundsensor.isGrounded){
            characterRigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            anim.SetBool("IsJumping",true);
        }
    }

    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag=="Enemy"){
            TakeDamage();
        } 
    }

    void TakeDamage(){
        healtPoints-=1;
        if(healtPoints==0) Die();
        anim.SetTrigger("IsHurt");
    }

    void Die(){
            anim.SetBool("IsDead",true);
            Destroy(gameObject, 0.35f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        characterRigidbody.velocity = new Vector2(horizontalInput * characterSpeed, characterRigidbody.velocity.y); 
    }
}
