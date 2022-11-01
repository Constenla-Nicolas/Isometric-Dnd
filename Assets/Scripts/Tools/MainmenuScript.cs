using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainmenuScript : MonoBehaviour
{
   public void nextScene(){
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
   }
   public void quitGame(){
    Application.Quit();
   }
   public void goBack(){
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
   }
    
}
