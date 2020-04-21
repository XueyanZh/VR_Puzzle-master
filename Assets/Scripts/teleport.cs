using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleport : MonoBehaviour
{
    public Transform Destination;
    public GameObject CharToMove;
    public GameObject panel;
    GameObject blackshift;
    // Start is called before the first frame update
    void OnMouseDown()
    {
        blackshift = Instantiate(panel);
        Destroy(blackshift, 2);

        CharToMove.transform.position = Destination.position;
    }
}
