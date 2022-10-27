using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class SecondWind : ScriptableFeature
{   
    public override void run(GameObject parent)
    {   Debug.Log("previous healt "+parent.GetComponent<EntityBehaviour>().currentHealth);
        parent.GetComponent<EntityBehaviour>().currentHealth+=Dice.rollD10()+parent.GetComponent<ClassBehaviour>().currentLvl;
        Debug.Log("actual healt "+parent.GetComponent<EntityBehaviour>().currentHealth);
    }
}
