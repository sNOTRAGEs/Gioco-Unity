using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class changeScene : MonoBehaviour
{
    
       public void play(){
        SceneManager.LoadScene("Livello_1" , LoadSceneMode.Single);
        
        }
}
