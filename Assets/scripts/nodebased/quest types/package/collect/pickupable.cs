using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupable : MonoBehaviour
{
    public string matchingQuest;
    [HideInInspector] public collectQ PCQ;
    // Start is called before the first frame update
    void Start()
    {}
    // Update is called once per frame
    void Update()
    {}
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && PCQ.reposition == false)
        {
            PCQ.amount--;
            Debug.Log(PCQ.amount);
            Destroy(this.gameObject);
        }
    }
}
