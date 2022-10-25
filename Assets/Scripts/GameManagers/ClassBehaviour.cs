using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassBehaviour : MonoBehaviour
{    public int exp;
    public int currentLvl=1;
    // public List<ScriptableClass> MyClass = new List<ScriptableClass>();
    public ScriptableClass MyClass;
    public void addClass(ScriptableClass clas){
         
        MyClass=clas;
        
    }
   

    void Update()
    {   
        
    }

    public void checkExp(){
        int i=2;
        bool err=false;
           do
           {  i++;
             if (exp>MyClass.getExpXLvl()[i])
             {
               MyClass.AddLvl(i);

             }
             else{err=false;}
           } while (err);
        

    }
}
