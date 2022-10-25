using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 [CreateAssetMenu]
public class ScriptableClass : ScriptableObject
{  public string Name;
    
   protected List<Ifeature> ClassFeatures = new List<Ifeature>();
     
    List<int> ExpXLvl = new List<int>{
        300,
        900,
        2700,
        6500,
        14000,
        23000,
        34000,
        48000,
        64000,
        85000,
        100000,
        120000,
        140000,
        165000,
        195000,
        225000,
        265000,
        305000,
        355000
        };
    public List<int> getExpXLvl(){
        return ExpXLvl;
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
    
    
