using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextInput : MonoBehaviour
{
    public InputField inputField;

    GameController controller;

    void Awake()
    {
        controller = GetComponent<GameController>();
        inputField.onEndEdit.AddListener(AcceptStringInput);
    }

    void AcceptStringInput(string userInput)
    {
        // turning all capitals to lowercase letters 
        userInput = userInput.ToLower(); 
        controller.LogStringwithReturn(userInput);

        // parising our inputs by looking for space which will break words in array to new string
        char[] delimiterCharacter = { ' ' };
        string[] seperatedInputWords = userInput.Split(delimiterCharacter);

        for (int i = 0; i < controller.inputActions.Length; i++)
        {
            InputAction inputAction = controller.inputActions[i];
            if (inputAction.keyWord == seperatedInputWords[0])
            {
                inputAction.RespondToInput(controller, seperatedInputWords);
            }
        }
        


        InputComplete();
    }

    void InputComplete()
    {
        controller.DisplayLoggedText();
        inputField.ActivateInputField();
        inputField.text = null;
    }
}
