using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{ Camera cam;
  Tiles current, prevcurrent;
 public static CameraScript instance;
  public EntityBehaviour currentGO;
  public GameObject currentSelected;
    public GameObject button;
 
    void Start()
    {
        cam = Camera.main;
    }
     private void Awake() {
     if (instance !=null)
     {
      Debug.LogWarning("more than 1 entity manager at the time!");
     } 
     instance=this;
    }

    // Update is called once per frame
    void Update()
    {

      
       
     
       Ray ray = cam.ScreenPointToRay(Input.mousePosition);
       RaycastHit hit;
       if (Physics.Raycast(ray,out hit, 100))
       {
          if (hit.transform.GetComponent<Tiles>()!=null)
          { prevcurrent=current;
            hit.transform.GetComponent<Tiles>().targetedbymouse=true;
         current = hit.transform.GetComponent<Tiles>();
        if (prevcurrent!=current)
        {
          prevcurrent.targetedbymouse=false;  
        }
          }
        else if (hit.transform.GetComponent<EntityBehaviour>()!=null)
        {
          
          currentGO= hit.transform.gameObject.GetComponent<EntityBehaviour>();
          if (Input.GetMouseButtonUp(0))
          {
            currentSelected=hit.transform.gameObject;
           
          }   
    
        }
      
        
      
       }

    }
 
    public void activarBoton(){
      button.SetActive(true);
    }
    public void desactivarBoton(){
      button.SetActive(false);
    }
}
