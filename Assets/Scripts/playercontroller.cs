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
    private bool isAttacking;
    private bool isMoving;

    [SerializeField] private Transform attackHitBox;
    [SerializeField] private float attackRadius = 0.45f;

    void Awake()
    {
        characterRigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update(){
        Run();
        Jump();
        if(Input.GetButtonDown("Fire1") && groundsensor.isGrounded && !isAttacking) Attack();
    }

       void FixedUpdate(){
        characterRigidbody.velocity = new Vector2(horizontalInput * characterSpeed, characterRigidbody.velocity.y); 
    }

    void Run(){
        
        if(isAttacking && !isMoving) horizontalInput=0; // If attack = no move
        else horizontalInput = Input.GetAxis("Horizontal");
        
        if(horizontalInput!=0) isMoving=true;
        else isMoving=false;

        if(horizontalInput == 0){
            anim.SetBool("IsRunning",false);
        }
        else if(horizontalInput < 0){
            transform.rotation = Quaternion.Euler( 0, 180, 0);
            anim.SetBool("IsRunning",true); 
        }else if(horizontalInput > 0){
            transform.rotation = Quaternion.Euler( 0, 0, 0);
            anim.SetBool("IsRunning",true);
        }
    }

    void Jump(){
        if(Input.GetButtonDown("Jump") && groundsensor.isGrounded && !isAttacking){
            characterRigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            anim.SetBool("IsJumping",true);
        }
    }

    void Attack(){
        StartCoroutine(AttackAnimation());
        if (isMoving) anim.SetBool("IsRunning",true);
        anim.SetTrigger("IsAttacking");

    }

    IEnumerator AttackAnimation(){
        isAttacking=true;

        yield return new WaitForSeconds(0.2f);
        
        Collider2D[] collider = Physics2D.OverlapCircleAll(attackHitBox.position, attackRadius);
        foreach (Collider2D obj in collider){
            if(obj.gameObject.CompareTag("Mimik")) {
                Rigidbody2D enemyRigidbody = obj.GetComponent<Rigidbody2D>();
                enemyRigidbody.AddForce(transform.right + transform.up * 2, ForceMode2D.Impulse);

                Mimik mimik= obj.GetComponent<Mimik>();
                mimik.TakeDamage();
            };
        }

        yield return new WaitForSeconds(0.4f);
        isAttacking=false;
        // if(isMoving) anim.SetBool("IsRunning",false);
    }

    void TakeDamage(){
        healtPoints-=1;
        if(healtPoints<=0) Die();
        else anim.SetTrigger("IsHurt");
    }

    void Die(){
        anim.SetTrigger("IsDead");
        Destroy(gameObject, 0.35f);
    }

    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.layer==3){
            TakeDamage();
        } 
    }

    void OnDrawGizmos(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackHitBox.position, attackRadius);
    }
}
