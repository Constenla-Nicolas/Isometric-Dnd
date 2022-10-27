using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionSurge : ScriptableFeature
{   public bool needRest;
   public override void run(GameObject parent){
    parent.GetComponent<EntityBehaviour>().actionAvailable=true;
    needRest=true;
   }
 
}
