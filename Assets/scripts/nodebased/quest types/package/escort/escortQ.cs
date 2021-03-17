using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class escortQ : MonoBehaviour
{

    public GameObject player, endpos, escort;
    public string QuestID;
    public string QuestInfo;
    public string startinfo;
    public Vector3 escortpos, finishpos;
    [HideInInspector] public int amount;
    [HideInInspector] public bool complete;
    public QuestUI UI;
    // Start is called before the first frame update
    void Awake()
    {

       endpos = Instantiate(endpos, finishpos, Quaternion.identity);
       escort = Instantiate(escort, escortpos, Quaternion.identity);
        UI.titel.text = QuestID;
        UI.info.text = QuestInfo;
        startinfo = QuestInfo;
        UI.Qcomplete.text = "incomplete";
    }

    // Update is called once per frame
    void Update()
    {

        float dis = Vector3.Distance(player.transform.position, escort.transform.position);
        amount = (int)dis;
        if (amount > 15)
        {
            QuestInfo = "stay within 15 feet";
            UI.info.text = QuestInfo;
        }
        else
        {
            UI.info.text = startinfo;
        }
        UI.progress.text = amount.ToString();

        float Dis = Vector3.Distance(endpos.transform.position, escort.transform.position);
        if (Dis < 2)
        {
            complete = true;
        }
        if (complete == true)
        {
            UI.Qcomplete.text = "complete";
        }
    }
}
