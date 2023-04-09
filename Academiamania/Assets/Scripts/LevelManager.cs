using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public int whichSceneActive = 0;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
            if (collision.gameObject.CompareTag("Player"))
            {
                SceneManager.LoadScene(this.gameObject.name);
                Debug.Log(this.gameObject.name);
            }
        
        



        
    }
}
