using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassBehaviour : MonoBehaviour
{    public int exp;
    public int currentLvl=1;
 
   public ScriptableClass MyClass ;

    public  ScriptableClass getClass()
    {return MyClass;}
}
