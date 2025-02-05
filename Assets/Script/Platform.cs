using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private float angle;
    [SerializeField] private float usePower;


    private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(angle, 100, 0) * usePower, ForceMode.Force);  
    }
}
