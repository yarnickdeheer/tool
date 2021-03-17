using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gotoQ : MonoBehaviour
{

    public GameObject player;
    public GameObject endp;
    public string QuestID;
    public string QuestInfo;
    [HideInInspector] public bool complete;

    [HideInInspector] public int amount;


    public QuestUI UI;
    // Start is called before the first frame update
    void Awake()
    {
        endp = Instantiate(endp, new Vector3(10, 1, 10), Quaternion.identity);
        
        UI.titel.text = QuestID;
        UI.info.text = QuestInfo;
        UI.Qcomplete.text = "incomplete";
    }

    // Update is called once per frame
    void Update()
    {
        float dis = Vector3.Distance(player.transform.position,endp.transform.position);
        amount = (int)dis;

        if (amount < 2)
        {
            complete = true;
        }

        UI.progress.text = amount.ToString();
        if (complete == true)
        {
            UI.Qcomplete.text = "complete";
        }


    }
}
