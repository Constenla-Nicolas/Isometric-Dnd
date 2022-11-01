using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class AbilityPanel : MonoBehaviour
{
   [SerializeField] ScriptableAbility ab;
   [SerializeField] List<AbilityUI> abilityUIs;

   public void updatePanel(List<Ability>abilities){
    for (int i = 0; i < abilityUIs.Count; i++)
    {
     abilityUIs[i].Set(abilities[i]);   
    }
   }
   public void Reset() {
      ab.Reset();
   }

   private void Update() {
    updatePanel(ab.abilities);
   }
   public void plus1(CharacterAbility ability){
    ab.changeAbilityScore(1,ability);
   }
   public void minus1(CharacterAbility ability){
    ab.changeAbilityScore(-1,ability);
   }
   public void SetscriptableAbility(ScriptableAbility ab){
      this.ab=ab;
   }
}
