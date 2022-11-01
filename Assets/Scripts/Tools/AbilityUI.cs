using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityUI : MonoBehaviour
{
   [SerializeField] TMPro.TextMeshProUGUI abilityScore;
   [SerializeField] TMPro.TextMeshProUGUI abilityMod;

   internal void Set(Ability ability){
    abilityScore.text= ability.AbilityScore.ToString();
    abilityMod.text= ability.getModifier().ToString();
   }
  
}
