using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[CreateAssetMenu(fileName ="New ScriptableAbility",menuName ="Scriptable/New Ability")]
public class ScriptableAbility : ScriptableObject
{   public List<Ability> abilities;
     public void Reset() {
        abilities= new List<Ability>();
        abilities.Add(new Ability(CharacterAbility.Strength,10));
        abilities.Add(new Ability(CharacterAbility.Dexterity,10));
        abilities.Add(new Ability(CharacterAbility.Constitution,10));
        abilities.Add(new Ability(CharacterAbility.Inteligence,10));
        abilities.Add(new Ability(CharacterAbility.Wisdom,10));
        abilities.Add(new Ability(CharacterAbility.Charisma,10));
    }
    public void changeAbilityScore(int num, CharacterAbility index){
    Ability a = abilities[(int)index];
    a.AbilityScore+=num;
    }
   
}



public enum CharacterAbility
{   Strength,
    Dexterity,
    Constitution,
    Inteligence,
    Wisdom,
    Charisma
    
}
[Serializable]
public class Ability{
    public int AbilityScore;
    public CharacterAbility ability;
    
    public Ability(CharacterAbility cha,int AbilityScore){
        ability=cha;
        this.AbilityScore=AbilityScore;
    }
    public int getModifier(){
        int mod = (AbilityScore-10);
        mod += (mod<0) ? -1:0;
    return mod/2;
   }
}