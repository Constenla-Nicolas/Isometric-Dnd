using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityBehaviour : MonoBehaviour
{   public int iniciativa;
    public bool ismoving,actionAvailable,bonusActionAvailable;
    public Interactable focus;
    void Start()
    {actionAvailable=true;
     bonusActionAvailable=true;
         
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void setFocus(Interactable newFocus){
        if (focus!=newFocus)
        { Debug.Log("difiere del anterior ="+focus +", "+newFocus);
            if (focus!=null)
            { Debug.Log(focus + " no es nulo");
                 focus.onDefocus();
            }
             focus=newFocus;
            
        }
        newFocus.OnFocus(transform);
    }
    public void removeFocus(){
        focus.onDefocus();
        Debug.Log(focus.name);
        focus=null;
        Debug.Log(focus);
    }
    private void OnTriggerEnter(Collider other) {
      
        setFocus(other.GetComponent<Interactable>());
          Debug.Log(other.name +", "+other.GetComponent<Interactable>().isFocus+", "+other.GetComponent<Interactable>().hasInteracted);
    }
    private void OnTriggerExit(Collider other) {
        removeFocus();
         
    }
}
