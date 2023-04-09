using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public int whichSceneActive = 0;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (whichSceneActive==0)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                SceneManager.LoadScene("ForestRoom");
                Debug.Log(this.gameObject.name);
            }
        }
        else if (whichSceneActive==1)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                SceneManager.LoadScene("Second");
                Debug.Log(this.gameObject.name);
            }
        }
        else if (whichSceneActive == 2)
        {
            if (collision.gameObject.CompareTag("Third"))
            {
                SceneManager.LoadScene(this.gameObject.name);
                Debug.Log(this.gameObject.name);
            }
        }



        
    }
}
