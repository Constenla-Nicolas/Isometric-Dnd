using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class Fighter : ScriptableClass
{
     
    public override List<ScriptableFeature> loadClassFeatures()
    {
        return new List<ScriptableFeature>{new SecondWind(),new ActionSurge()};
       
    }
}
