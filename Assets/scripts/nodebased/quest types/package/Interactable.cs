using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    private TradeQ hub;
    private bool interactable;

    void Start()
    {
        hub = GameObject.Find("shop").GetComponent<TradeQ>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && interactable == true)
        {
            hub.check();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            interactable = true;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            interactable = false;
        }

    }
}
