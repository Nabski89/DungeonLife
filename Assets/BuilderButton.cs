using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuilderButton : MonoBehaviour
{
    public static List<GameObject> ExpansionList = new List<GameObject>();
    public static BuilderButton Instance;

    public static bool Activate = false;
    void Awake()
    {
        Instance = this;
        ExpansionList.Clear();
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

        Debug.Log("you pushed the button");
        int Amount = ExpansionList.Count;
        int i = 0;

        if (Activate == true)
        {
            while (i < Amount)
            {
                ExpansionList[i].GetComponent<Expand>().DisableForTheButton();
                i++;
            }
            Activate = false;
        }
        else
        {
            while (i < Amount)
            {
                ExpansionList[i].GetComponent<Expand>().EnableIfValid();
                i++;
            }
            Activate = true;
        }
    }
}