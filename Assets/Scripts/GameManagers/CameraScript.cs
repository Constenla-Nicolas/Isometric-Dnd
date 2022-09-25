using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{ Camera cam;
  Tiles current, prevcurrent;
  public GameObject currentGO;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    { prevcurrent=current;
    //  Vector3 mousepos= Input.mousePosition;
    //  mousepos.z=10;
    //  mousepos = cam.ScreenToWorldPoint(mousepos);
       Ray ray = cam.ScreenPointToRay(Input.mousePosition);
       RaycastHit hit;
       if (Physics.Raycast(ray,out hit, 100))
       {
    try
    {
         hit.transform.GetComponent<Tiles>().targetedbymouse=true;
         current = hit.transform.GetComponent<Tiles>();
        if (prevcurrent!=current)
        {prevcurrent.targetedbymouse=false;
            
        }
    }
    catch (System.NullReferenceException)
    {
      currentGO= hit.transform.gameObject;
       
    }
      
       }


      
    }
}
