using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField]
    private float _Power;
    public float Power
    {
        get { return _Power; }
        set { _Power = value; }
    }
    float Timer = 0;
    private void Update()
    {
        Timer += Time.deltaTime;
        if(Timer > 0.5)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        Vector3 dif = other.transform.position - transform.position;
        rb.AddForce(Power * (2.5f - dif.magnitude)* dif.normalized);
    }
}
