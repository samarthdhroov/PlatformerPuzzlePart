using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePad : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Box")
        {
            float distance = Vector3.Distance(transform.position, other.transform.position);

            if(distance < 0.05f)
            {
                Rigidbody boxBody = other.GetComponent<Rigidbody>();

                MeshRenderer PressureMesh = GetComponentInChildren<MeshRenderer>();

                if(boxBody != null)
                {
                    boxBody.isKinematic = true;
                }

                if(PressureMesh != null)
                {
                    PressureMesh.material.color = Color.blue;
                }
                
                Destroy(this);
            }
        }
    }

}
