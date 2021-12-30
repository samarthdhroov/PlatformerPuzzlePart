using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorPanel : MonoBehaviour
{

    [SerializeField]
    private GameObject _elevatorBulb;

    private int requiredCoins = 8;

    private Elevator _elevator;

    private bool _elevatorCalled;

    private void Start()
    {

        if(GameObject.Find("Elevator").GetComponent<Elevator>() != null)
        {
            _elevator = GameObject.Find("Elevator").GetComponent<Elevator>();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E) && other.GetComponent<Player>().GetCoins() >= requiredCoins)
            {

                if(_elevatorCalled == true)
                {
                    _elevatorBulb.GetComponent<MeshRenderer>().material.color = Color.red;
                }
                else
                {
                    _elevatorBulb.GetComponent<MeshRenderer>().material.color = Color.green;
                    _elevatorCalled = true;
                }
                _elevator.callElevator();
            }
        }
    }

}
