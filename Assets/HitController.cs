using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitController : MonoBehaviour
{
    public GameObject Player;
    public Text text;
    
    void Update() {
        if (!Player.GetComponent<PlayerMovement>().alive) {
            text.text = Player.name + " hit!";
        }   
    }
}
