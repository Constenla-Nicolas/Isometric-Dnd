using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityBehaviour : MonoBehaviour
{   public Sprite Icon;
    public int iniciativa,dropExp,maxHealth,currentHealth;
    public bool ismoving,actionAvailable,bonusActionAvailable;
    public Interactable focus;
    public Equipment UnarmedStrike;
    // public TacticMovement tm;
    [SerializeField] private Collider focusCollider;
    void Start()
    {
        // tm = new TacticMovement();
    UnarmedStrike = new Equipment{
        armorClass=0,dmgDice=0,range=5, };
     actionAvailable=true;
     bonusActionAvailable=true;    
    }
    
    // Update is called once per frame
    void Update()
    { 
        
    }
    public void setFocus(Interactable newFocus){
        if (focus!=newFocus)
        { 
            if (focus!=null)
            {  
                 focus.onDefocus();
            }
             focus=newFocus;
            
        }
        newFocus.OnFocus(transform);
        CameraScript.instance.desactivarBoton();
    }
    public void removeFocus(){
        if (focus!=null)
        {
        focus.onDefocus();
        Debug.Log(focus.name);
        focus=null;
         
        }
       
    }
    private void OnTriggerEnter(Collider other) {
         CameraScript.instance.activarBoton();
        // setFocus(other.GetComponent<Interactable>()); 
        focusCollider=other;
          Debug.Log(other.name +", "+other.GetComponent<Interactable>().isFocus+", "+other.GetComponent<Interactable>().hasInteracted);
    }
    private void OnTriggerExit(Collider other) {
        CameraScript.instance.desactivarBoton();
        focusCollider=null;
         removeFocus();
         
    }
    public Collider getFocus(){
        return focusCollider;
    }
    public int getCurrentHealth(){
        return currentHealth;
    }
}
