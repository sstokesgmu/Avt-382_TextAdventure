using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "TextAdventure/InputActions/Start")]
public class Start :InputAction
{
    public override void RespondToInput(GameController controller, string[] separatedInputWords)
    {
        //with scriptable objects you want to pass through scene object in the function
        controller.roomNavigation.AttemptToChangeRooms(separatedInputWords[1]);
    }


}
