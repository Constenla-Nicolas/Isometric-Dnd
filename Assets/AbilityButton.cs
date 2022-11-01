using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class AbilityButton : MonoBehaviour,IPointerClickHandler
{      [SerializeField] CharacterAbility enumab;
       [SerializeField] bool negative;
    AbilityPanel ap;
    void Start()
    {
        ap = GetComponentInParent<AbilityPanel>();
    }
     public void OnPointerClick(PointerEventData ed){
    if (negative ==false)
    {  ap.plus1(enumab);
        
    }
    else
    {
        ap.minus1(enumab);
    }
   }
    // Update is called once per frame
    void Update()
    {
        
    }
}
