﻿using UnityEngine;
//SCRIPT BELONGS ON THE GAME MANAGER
//Contains information about the game
//other fi=unctions can access parts of this information like in game mouse location
//to enable stats in game press "i"

public class GameStats : MonoBehaviour
{
    private Camera cam; //Used for in game mouse locating
    public Vector3 inGameMousePosition = new Vector3(0,0,0); //stores the position of the mouse in game, usefull for player controls
    private bool statsHub = false; //Used to active th statsHub in game

    void Start()
    {
        //establishes a reference to the main camera
        cam = Camera.main;
    }

    //When the "i" key is pressed the status of the stats hub toggles
    void Update()
    {
        if (Input.GetKeyDown("i"))
        {
            statsHub = !statsHub;
        }
    }

    void OnGUI()
    {
        //This block was gathered from Unity documentation and is confusing
        /////////////////////////////////////////////////
        inGameMousePosition = new Vector3();
        Event currentEvent = Event.current;
        Vector2 mousePos = new Vector2();

        // Get the mouse position from Event.
        // Note that the y position from Event is inverted.
        mousePos.x = currentEvent.mousePosition.x;
        mousePos.y = cam.pixelHeight - currentEvent.mousePosition.y;

        inGameMousePosition = cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, cam.nearClipPlane));
        /////////////////////////////////////////////////////

        //Displays stats hub on screen if toggled on
        if (statsHub)
        {
            GUILayout.BeginArea(new Rect(20, 20, 250, 120));
            /*Screen Pixels*/GUILayout.Label("Screen pixels: " + cam.pixelWidth + ":" + cam.pixelHeight);
            /*Mouse Position*/GUILayout.Label("Mouse position: " + mousePos);
            /*In Game Mouse Position*/GUILayout.Label("World position: " + inGameMousePosition.ToString("F3"));
            /*Frame Rate*/GUILayout.Label("Frame rate: " + (int)(1.0f / Time.smoothDeltaTime));
            GUILayout.EndArea();
        }
    }
}
