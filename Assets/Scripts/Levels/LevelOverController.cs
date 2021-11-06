using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelOverController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
      if(collision.gameObject.GetComponent<PlayerController>() !=null)
      {
        Debug.Log("Level finished by the player");  
         Scene scene = SceneManager.GetActiveScene();
         SceneManager.LoadScene(scene.buildIndex+1);
        LevelManager.Instance.MarkCurrentLevelComplete();

      }  
    }
}
