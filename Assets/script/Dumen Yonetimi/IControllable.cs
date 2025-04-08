using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IControllable 
{
    void OnControlStart(GameObject controller);
    void OnControlEnd();
    Transform GetControlPoint(); // Kamera icin
}
