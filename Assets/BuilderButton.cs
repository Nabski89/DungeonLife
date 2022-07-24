using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuilderButton : MonoBehaviour
{
    public static List<GameObject> ExpansionList = new List<GameObject>();
    public static List<GameObject> DoorBuilderList = new List<GameObject>();
    public static BuilderButton Instance;

    public static bool Activate = false;
    public static bool FixMyBugByRunningItTwice = false;
    void Awake()
    {
        Instance = this;
        ExpansionList.Clear();
        DoorBuilderList.Clear();
    }

    public void AddToRoomList(GameObject AddedThis)
    {
        ExpansionList.Add(AddedThis);
    }
    public void RemoveFromRoomList(GameObject AddedThis)
    {
        ExpansionList.Remove(AddedThis);
    }
    public static void ShowRoomExpansions()
    {

        if (FixMyBugByRunningItTwice == false)
        {
            FixMyBugByRunningItTwice = true;
            ShowRoomExpansions();
        }
        Debug.Log("you pushed the button and it holds " + ExpansionList.Count);
        int Amounti = ExpansionList.Count;
        int Amountj = DoorBuilderList.Count;
        int i = 0;
        int j = 0;

        if (Activate == true)
        {
            while (i < Amounti)
            {
                ExpansionList[i].GetComponent<Expand>().DisableForTheButton();
                i++;
            }
            while (j < Amountj)
            {
                DoorBuilderList[j].SetActive(false);
                j++;
            }

            Activate = false;
        }
        else
        {
            while (i < Amounti)
            {
                ExpansionList[i].GetComponent<Expand>().EnableIfValid();
                i++;
            }
            while (j < Amountj)
            {
                DoorBuilderList[j].SetActive(true);
                j++;
            }
            Activate = true;
        }
    }
}