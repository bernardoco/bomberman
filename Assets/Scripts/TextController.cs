using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
    public float offset = 0.15f;
    public GameObject Player;
    public Text text;

    private Vector3 offsetY = new Vector3(0, 0.15f, 0);

    void Update() {
        text.transform.position = Player.transform.position + offsetY;

        if (!Player.GetComponent<PlayerMovement>().alive) {
            text.text = "DEAD";
        }
    }
}
