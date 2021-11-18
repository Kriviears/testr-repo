using UnityEngine.SceneManagement;
using UnityEngine;
using System;

public class CollisionHandler : MonoBehaviour
{

    [SerializeField] float levelLoadDelay = 2f;

    void OnCollisionEnter(Collision other) 
    {  
        switch (other.gameObject.tag)
        {   
            case "Respawn":
            case "Friendly":
                Debug.Log("Friendly!");
                break;

            case "Finish":
                Success();
                break;

            default:
                Crash();
                break;
        }
    }

    private void Success()
    {
        GetComponent<Movement>().enabled = false;
        Invoke("FinishLevel", levelLoadDelay);
    }

    void Crash(){
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", levelLoadDelay);
    }

    void ReloadLevel(){
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    void FinishLevel(){
        Debug.Log("we have "+ SceneManager.sceneCountInBuildSettings +" levels");
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int targetLevel = currentSceneIndex + 1;
        if(targetLevel == SceneManager.sceneCountInBuildSettings){
            targetLevel = 0;
        }
        SceneManager.LoadScene(targetLevel);
    }
}