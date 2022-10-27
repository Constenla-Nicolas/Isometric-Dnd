using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 [CreateAssetMenu]
public class ScriptableClass : ScriptableObject
{  public string Name;
    
   
     public virtual List<ScriptableFeature> loadClassFeatures(){
        return null;
     }
    
  
    public void AddLvl(int num){
        switch (num)
        {   case 2:
            lvl2();
            break;
            case 3:
            lvl3();
            break;
            case 4:
            Lvl4();
            break;
            case 5:
            Lvl5();
            break;
            
             
        }
    }

    public virtual void lvl2(){}
    public virtual void lvl3(){}
    public virtual void Lvl4(){}
    public virtual void Lvl5(){}
}
    
    
