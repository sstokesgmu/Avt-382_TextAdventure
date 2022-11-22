using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TopScreenAnimationManager : MonoBehaviour
{
    [Header("Refrences")]

    public Transform instantiator;
    public Camera cam;
    public Canvas[] Canvases;
    Canvas currentcanvas;

    //Used to keep track of the order number int the RoomNavigation Script
    public int order;

    #region IEnumerators 
    public IEnumerator StartTransition(int value)
    {
        int number = value;
        Debug.Log("MessageRecieved");
        WaitForSeconds wfs = new WaitForSeconds(2);
        Instantiate(number);
        yield return wfs;
    }
    #endregion

    #region Public Unity Functions 

    public void Instantiate(int number)
    {
        Canvases[number].worldCamera = cam;
        Canvases[number].planeDistance = 10.0f;
        currentcanvas = Instantiate(Canvases[number], instantiator.position, Quaternion.identity);
        // executeChange = true;
        Debug.Log(currentcanvas);
    }

    public void DestoryPreviousCanvas(int number)
    {
        var b = currentcanvas;
        order += 1;

        for (int i = 0; i < Canvases.Length; i++)
        {
            if (System.Array.IndexOf(Canvases, currentcanvas) != number)
                Canvas.Destroy(currentcanvas);
            else
                return;
        }
    }

    #endregion
}
