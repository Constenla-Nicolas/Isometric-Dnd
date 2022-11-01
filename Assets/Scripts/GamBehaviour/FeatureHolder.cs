using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeatureHolder : MonoBehaviour
{   public List<IFeature> features = new List<IFeature>();
    
    enum abilityState
    {   ready,
        active,
        
    }
    abilityState state= abilityState.ready;
    // Start is called before the first frame update
    private void Start() {
    features.AddRange(new Fighter().LoadLvl1()); 
     
    }
    public KeyCode key;
    // Update is called once per frame
    void Update()
    {  if (Input.GetKeyDown(key))
    {
        features[0].run(gameObject);
    }
        
    }
}
