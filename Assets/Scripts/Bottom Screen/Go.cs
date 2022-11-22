using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "TextAdventure/InputActions/Go")]

public class Go : InputAction
{

    public override void RespondToInput(GameController controller, string[] separatedInputWords)
    {
        //with scriptable objects you want to pass through scene object in the function
        controller.roomNavigation.AttemptToChangeRooms(separatedInputWords[1]);
    }
}
 

