using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kooking : MonoBehaviour
{
    private paternQ hub;
    private bool interactable;
    // Start is called before the first frame update
    void Start()
    {
        hub = GameObject.Find("tasksQ").GetComponent<paternQ>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && interactable == true)
        {
            //interact
            hub.interactions.Add(this.gameObject);
            hub.CheckOrder();
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
