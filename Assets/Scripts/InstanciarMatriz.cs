using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class InstanciarMatriz : MonoBehaviour
{
    // Start is called before the first frame update
      public static int cantidad =8;
static  List<GameObject> tiles = new List<GameObject>();
  static List<GameObject> terreno = new List<GameObject>();
  static List<List<GameObject>> matriz = new List<List<GameObject>>();
    [MenuItem("Tools/Instanciar matriz")]
static void Start()
    { GameObject b = GameObject.FindGameObjectWithTag("base");
        for (int j = 0; j < cantidad; j++)
        {
            tiles.Clear();
             for (int i = 0; i < cantidad; i++)
             {
            tiles.Add(Instantiate(b,b.transform.position+new Vector3(i,0,j),b.transform.rotation)as GameObject);
            tiles[i].name="Cubo"+(j)+","+(i);
            tiles[i].tag="Tile";
            tiles[i].isStatic= true;
            terreno.Add(tiles[i]);
             }
             matriz.Add(tiles);
            
        }
        
       Destroy(b);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
