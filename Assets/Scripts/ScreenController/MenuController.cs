using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public void exit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
