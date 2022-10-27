using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeatureHolder : MonoBehaviour
{   public List<ScriptableFeature> features = new List<ScriptableFeature>();
    // public ScriptableFeature feature;
    enum abilityState
    {   ready,
        active,
        
    }
    abilityState state= abilityState.ready;
    // Start is called before the first frame update
    private void Start() {
    features.AddRange(gameObject.GetComponent<ClassBehaviour>().getClass().loadClassFeatures()); 
    }
    public KeyCode key;
    // Update is called once per frame
    void Update()
    {  if (Input.GetKeyDown(key))
    {
        // feature.run(gameObject);
    }
        
    }
}
