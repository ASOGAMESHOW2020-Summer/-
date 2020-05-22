using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystem;
using UnityEngine.UI;

public class EventController : MonoBehaviour
{
    //Singleton
    private static EventController eventController = new EventController();

    //EventScripts
    public DoorLock doorLock;

    public static EventController getInstance()
    {
        return eventController;
    }

    private EventController()
    {
        doorLock = new DoorLock();
    }

    public void main(GameObject selectedGameObject)
    {
        switch(selectedGameObject.name)
        {
            case "DoorLock":
                doorLock.main();
                break;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
