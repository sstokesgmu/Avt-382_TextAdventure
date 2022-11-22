using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text displayText;
    public InputAction[] inputActions;

    [HideInInspector] public RoomNavigation roomNavigation;
    [HideInInspector] public List<string> interactionDescriptionsInRoom = new List<string>();

    List<string> actionLog = new List<string>();
    

   
    void Awake()
    {
        roomNavigation = GetComponent<RoomNavigation>();   
    }

    void Start()
    {
        DisplayRoomText();
        DisplayLoggedText();
        
    }

    public void DisplayLoggedText()
    {
       // joins the list into the string by converting list to array 
        string logAsText = string.Join("\n", actionLog.ToArray());

        displayText.text = logAsText;
    }


    public void DisplayRoomText()
    {
        ClearCollectionsForNewRoom();
        UnpackRoom();

        //converting the list into an array, and joining them to an array where all the items are seperated onto a new line
        string joinedInteractionDescriptions = string.Join("\n", interactionDescriptionsInRoom.ToArray());

        string combinedText = roomNavigation.currentRoom.description + "\n" + joinedInteractionDescriptions;

        LogStringwithReturn(combinedText);
    }

    void ClearCollectionsForNewRoom()
    {
        //removes all the elements from that list 
        interactionDescriptionsInRoom.Clear();
        roomNavigation.ClearExits();

    }

    private void UnpackRoom()
    {
        roomNavigation.UnpackExitsInRoom();
    }

    //Any time we want to add a string to the list call this function  
    public void LogStringwithReturn(string stringToAdd)
    {
        actionLog.Add(stringToAdd + "\n");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
