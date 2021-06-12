using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MIniMap : MonoBehaviour
{
    GameObject Map;
    void Start(){
        Map = GameObject.FindGameObjectWithTag("map");
        Map.SetActive(false);
    }
    void Update(){
        if (Input.GetKeyDown(KeyCode.M)){
            Map.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.M)){
            Map.SetActive(false);
        }
    }
}
