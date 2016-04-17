using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {
    public GameObject object;
    public float speed;
    void start()
    {
        RigidBody rb = objectGetComponent<RigidBody>
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }
}
