using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
      private float speed=5;
      public Animator animator;
      

      private bool movingRight = true;

      public Transform groundDetection;

      void Update()
      {
      transform.Translate(Vector2.right*speed*Time.deltaTime);
      RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position,Vector2.down,1f);
      if(groundInfo.collider == false)
      {
        if(movingRight==true)
        {
          transform.eulerAngles = new Vector3(0,-180,0);
          movingRight=false;
        } else {
          transform.eulerAngles = new Vector3(0,0,0);
          movingRight=true;
        }
      }
      animator.SetFloat("Speed", 10f);
      }


      private void OnCollisionEnter2D(Collision2D collision)
      {
       if(collision.gameObject.GetComponent<PlayerController>()!= null)
       {
        PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
        playerController.KillPlayer();  
        //Destroy(gameObject); 
       }
      }



    
}
