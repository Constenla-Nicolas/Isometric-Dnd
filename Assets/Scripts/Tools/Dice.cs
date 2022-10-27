using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
   public static int melee(){
      return UnityEngine.Random.Range(1,0);
   }
    public static int rollD10(){
        return UnityEngine.Random.Range(1,11);
     }
     public static int rollD6(){
        return UnityEngine.Random.Range(1,7);
     } 
     public static int rollD4(){
        return UnityEngine.Random.Range(1,5);
     } 
     public static int rollD3(){
        return UnityEngine.Random.Range(1,4);
     } 
     public static int rollD12(){
        return UnityEngine.Random.Range(1,13);
     } 
     public static int rollD20(){
        return UnityEngine.Random.Range(1,21);
     } 
     public static int rollD100(){
        return UnityEngine.Random.Range(1,101);
     } 
     public static int rollD8(){
        return UnityEngine.Random.Range(1,9);
     } 

}
