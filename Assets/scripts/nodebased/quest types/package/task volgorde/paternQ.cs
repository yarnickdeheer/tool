using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paternQ : MonoBehaviour
{
    public string QuestID;
    public string QuestInfo;
    public GameObject[] Questobject;
    public int[] volgorde;
    public List<GameObject> interactions;
    private int listpos;
    [HideInInspector] public int amount;

    [HideInInspector] public bool complete;
    public QuestUI UI;



    public bool correct = true;

    public int meals, goodTrashhold;
    private int good, bad, mealspreped;
    public bool goodEnd;
    // Start is called before the first frame update
    void Start()
    {
        UI.titel.text = QuestID;
        UI.info.text = QuestInfo;
        UI.Qcomplete.text = "incomplete";
    }

    // Update is called once per frame
    void Update()
    {

       

        UI.progress.text = amount.ToString();
        if (complete == true)
        {
            UI.Qcomplete.text = "complete";
           
        }

        if (amount == Questobject.Length && complete ==false)
        {
            // complete = true;
            CheckWork();

        }

    }
   
    public void CheckWork()
    {
        if (correct == false)
        {
            bad++;
            mealspreped++;
            //CheckWork();
            correct = true;
            Debug.Log("non correct meal");
        }
        else
        {
            good++;
            mealspreped++;
            Debug.Log("correct meal");
            //CheckWork();
        }


        if (mealspreped != meals)
        {
            
            listpos = 0;
            interactions.Clear();
            amount = listpos;
        }
        else
        {
            complete = true;

            if (good >= goodTrashhold)
            {
                goodEnd = true;
            }
        }


     
    }
    public void CheckOrder()
    {
        // interactable has to be the same as questobject
        if (interactions[listpos] == Questobject[volgorde[listpos]])
        {
            Debug.Log("correct");
            
            listpos++;
          
        }
        else
        {
            //listpos = 0;
          //  interactions.Clear();
            Debug.Log("false");
            correct = false;
            listpos++;

        }


       
        amount = listpos;
    }
}
