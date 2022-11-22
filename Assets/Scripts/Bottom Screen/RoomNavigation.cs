using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomNavigation : MonoBehaviour
{
    public Room currentRoom;

    GameController controller;

    TopScreenAnimationManager Manger;

    Dictionary<string, Room> exitDictionary = new Dictionary<string, Room>();

    //Really important for destroying and creating rooms 
    int order = 0;

    void Awake()
    {
        controller = GetComponent<GameController> ();
        Manger = GameObject.Find("TopScreenManger").GetComponent<TopScreenAnimationManager>();
        StartCoroutine(Manger.StartTransition(order));
    }

    #region Public Unity Functions
    public void UnpackExitsInRoom()
    {
        // go over array in exits in current room and pass them over to GM to display

        for (int i = 0; i < currentRoom.exits.Length; i++)
        {
            exitDictionary.Add(currentRoom.exits[i].keyString, currentRoom.exits[i].valueRoom);
            controller.interactionDescriptionsInRoom.Add(currentRoom.exits[i].exitDescription);
        }
    }


    public void AttemptToChangeRooms(string directionNoun)
    {
        //check to see if that dictionary contains that key
        if (exitDictionary.ContainsKey(directionNoun))
        {
            currentRoom = exitDictionary[directionNoun];

            controller.LogStringwithReturn("You head off to the " + directionNoun);


            order += 1;
            Manger.DestoryPreviousCanvas(order);
            StartCoroutine(Manger.StartTransition(order));
           


            //create a wait for blank seconds 

            controller.DisplayRoomText();
        }
        else
        {
            controller.LogStringwithReturn("There is no path to the " + directionNoun);
        }
    }



    public void ClearExits()
    {
        //empty out dictionary and call for game controller.
        exitDictionary.Clear();
    }

    #endregion
}
