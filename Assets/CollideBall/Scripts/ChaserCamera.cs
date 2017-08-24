using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaserCamera : MonoBehaviour
{
    [SerializeField]
    Transform Target;
    Vector3 Offset;
	void Start ()
    {
        Offset = transform.position - Target.position;
	}
	void LateUpdate ()
    {
        transform.position = Target.position + Offset;
	}
}
