using UnityEngine;

public class Rotator : MonoBehaviour {

    public float tumble;
    private void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.angularVelocity = Random.insideUnitSphere * tumble;
    }
}
