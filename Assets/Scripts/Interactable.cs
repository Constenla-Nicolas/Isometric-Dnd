using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    // Start is called before the first frame update
    public float radius=.4f;
   public bool isFocus=false,hasInteracted=false;
    Transform player;
    public void OnFocus(Transform playerTransform) {
        isFocus=true;
        player = playerTransform;
        hasInteracted=false;
    }
    public virtual void interact(){

    }
    public void onDefocus(){
        isFocus=false;
        player=null;
        hasInteracted=false;
    }
    // Update is called once per frame
        void OnDrawGizmosSelected() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position,radius);
    }
    private void Update() {
      
        if (isFocus&&!hasInteracted)
        {       
            if (this.tag=="Item")
            {
                interact();
                    hasInteracted=true;
            }
                 
            if (this.tag=="Entity")
            {
                
            }
             
        }
    }
}
