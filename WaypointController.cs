///
/// Created by Juan 'Jotadev' Mayor, juanmayor96@gmail.com 
/// On 26th October 2018
/// Copyright © 2018 Jotadev. Creative Commons License:
/// Attribution 4.0 International (CC BY 4.0)
/// 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointController : MonoBehaviour {

    /// <summary>
    /// Control de colisiones del waypoint
    /// </summary>
    /// <param name="collision">Objeto con el que colisiona</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Condición que limita el funcionamiento a las colisiones con el tag "Player"
        if(collision.tag == "Player")
        {
            //Llama a la función WaypointTrodden() para actualizar los waypoints y los textos
            GetComponentInParent<TutorialController>().WaypointTrodden();
        }
    }
}
