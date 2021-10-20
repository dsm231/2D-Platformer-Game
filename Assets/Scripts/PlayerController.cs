using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public ScoreController scoreController; 
    public Animator animator;
    private float speed=5;
    private float jump=40;
    //private bool Ground;
    //bool Crouch = false;
    private Rigidbody2D rb2d;
     
    private void Awake()
    {
    Debug.Log("Player controller awake");   
    rb2d= gameObject.GetComponent<Rigidbody2D>(); 
    }

    public void PickUpKey()
    {
    Debug.Log("Player picked up the key"); 
    scoreController.IncreaseScore(10); 
    }

    // private void OnCollisionEnter2D(Collision2D collision)
    // {
    //  Debug.Log("Collision:" + collision.gameObject.name);  
    // }

    private void Update()
    {
        // if (Input.GetKeyDown(KeyCode.LeftControl))
        // {
        //     Crouch = !Crouch;
        //     animator.SetBool("Crouch", Crouch);
        // }

        float vertical = Input.GetAxisRaw("Jump");
        
        float horizontal = Input.GetAxisRaw("Horizontal");
        
        PlayMovementAnimation(horizontal,vertical);
        MoveCharacter(horizontal, vertical);    
    }

    private void MoveCharacter(float horizontal, float vertical)
    {
      //move character horizontally 
      
      
      
      Vector3 position = transform.position;
      position.x = position.x + horizontal * speed * Time.deltaTime;
      transform.position = position;
      
      //move character vertically
      
      
       //if(Ground)
       //{
         if(vertical>0)
         {
        rb2d.AddForce(new Vector2(0f,jump),ForceMode2D.Force);
         }
      // }

    
    }

    private void PlayMovementAnimation(float horizontal, float vertical)
    {
        animator.SetFloat("Speed", Mathf.Abs(horizontal));
         Vector3 scale = transform.localScale;
        if (horizontal < 0)
        {
            scale.x = -1f* Mathf.Abs(scale.x);
            //scale.x=-1;
        }
        else if (horizontal > 0)
        {
            scale.x = Mathf.Abs(scale.x);
            //scale.x = 1;
        }
        transform.localScale = scale;

        //Jump
        if (vertical > 0 )
        {
            animator.SetBool("Jump", true);
        }
        else
        {
            animator.SetBool("Jump", false);
        }

        //crouch
         if(Input.GetKeyDown(KeyCode.LeftControl))
         {
           animator.SetBool("Crouch",true); 
           speed=0; jump=0; 
         }

         if(Input.GetKeyUp(KeyCode.LeftControl))
         {
           animator.SetBool("Crouch",false); 
           speed=5; jump=40; 
         }
      
          


    }

    // public void OnCollisionEnter2D(Collision2D platform)
    // {
    //   if (platform.gameObject.CompareTag("Ground"))
    //   {
    //      Ground = true;
    //   }  
    // }

    //  public void OnCollisionExit2D(Collision2D platform)
    // {
    //   if (platform.gameObject.CompareTag("Ground"))
    //   {
    //      Ground = false;
    //   }  
    // }
}
