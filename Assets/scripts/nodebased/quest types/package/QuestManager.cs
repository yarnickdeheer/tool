using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public List<GameObject> quests;


    public int currentQ = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        if (quests[currentQ].GetComponent<gotoQ>() != null) {
            if (quests[currentQ].GetComponent<gotoQ>().complete == true)
            {
                currentQ++;
                NextActiveQuest();
            }
        }
        else if (quests[currentQ].GetComponent<collectQ>() != null)
        {
            if (quests[currentQ].GetComponent<collectQ>().complete == true )
            {
                currentQ++;
                NextActiveQuest();
            }
        }
        else if (quests[currentQ].GetComponent<escortQ>() != null)
        {
            if (quests[currentQ].GetComponent<escortQ>().complete == true)
            {
                currentQ++;
                NextActiveQuest();
            }
        }
        else if (quests[currentQ].GetComponent<paternQ>() != null)
        {
            if (quests[currentQ].GetComponent<paternQ>().complete == true)
            {
                currentQ++;
                NextActiveQuest();
            }
        }

        else if (quests[currentQ].GetComponent<TradeQ>() != null)
        {
            if (quests[currentQ].GetComponent<TradeQ>().complete == true)
            {
                currentQ++;
                NextActiveQuest();
            }
        }
    }

    void NextActiveQuest()
    {
        Destroy(quests[currentQ - 1]);
        quests[currentQ].SetActive(true);
    }

    void GenerateQuests()
    {
        // auto gen quest that the user can manipulate in playmode
    }
}
