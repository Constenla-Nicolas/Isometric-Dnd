using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class Fighter : IJob
{
     
    public IFeature[] LoadLvl1()
    {
        return new []{new hEAL()};
    }
}



class hEAL : IFeature{
    public virtual void run(GameObject parent){
        Debug.Log("previous healt "+parent.GetComponent<stats>().currentHealth);
        parent.GetComponent<stats>().currentHealth+=Dice.rollD10()+parent.GetComponent<ClassBehaviour>().currentLvl;
        Debug.Log("actual healt "+parent.GetComponent<stats>().currentHealth);
    }
}


// lFeatures.add(new Features() {
           
//             @Override
//             public void run() {
//                 Config.entidadActual.bonusActionDisponible=false;
//               Random r = new Random();
//              int hprecuperada=(r.nextInt(9)+1);
//             //  System.out.println(Config.entidadActual.getHpactual());
//              Config.entidadActual.setHpactual(Config.entidadActual.getHpactual()+hprecuperada);
//             // System.out.println(Config.entidadActual.getHpactual());
//             }

//             @Override
//             public String getName() {
                 
//                 return "Second Wind";
//             }
            
//         });