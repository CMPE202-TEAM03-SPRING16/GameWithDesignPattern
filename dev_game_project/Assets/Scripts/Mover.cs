using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {
    public float speed;
void start()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }
}
