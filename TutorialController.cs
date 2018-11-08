///
/// Created by Juan 'Jotadev' Mayor, juanmayor96@gmail.com 
/// On 26th October 2018
/// Copyright © 2018 Jotadev. Creative Commons License:
/// Attribution 4.0 International (CC BY 4.0)
/// 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialController : MonoBehaviour {

    #region Declaración de parámetros

    [SerializeField]
    /// <summary>
    /// Referencia al texto del tutorial
    /// </summary>
    private Text tutorialText;

    /// <summary>
    /// Almacenamiento de los waypoints del tutorial
    /// </summary>
    private CircleCollider2D[] waypoints;

    /// <summary>
    /// Lleva el recuento de los waypoints pisados
    /// </summary>
    private byte waypointsCounter;

    /// <summary>
    /// Almacenamiento de los textos del tutorial
    /// </summary>
    private readonly string[] tutorialTexts =
    {
        "Welcome to the tutorial!\n\nYou can only move if you have your candle ON.\nPress 'SPACE' to turn it ON and move forward to your cursor pressing 'W'. Get all the waypoints.",
         "Remember, it's Halloween and the kids would be walking through the street, be aware of them! .",
        "You can either turn off your candle pressing 'SPACE' to hide yourself from the kids.",
        "If they find you they will go for you, you have to run away from them and turn off your candle to hide yourself.\nGood luck!"
    };


    #endregion

    #region Inicialización de miembros
    void Start () {

        //Contador de waypoints alcanzados a 0
        waypointsCounter = 0;

        //Fill del array de waypoints con los hijos
        waypoints = GetComponentsInChildren<CircleCollider2D>();

        //Desactivar los waypoints
        for (byte i = 0; i < waypoints.Length; i++)
        {
            waypoints[i].gameObject.SetActive(false);
        }

        //Activar el primer waypoint 
        waypoints[waypointsCounter].gameObject.SetActive(true);

        //Cambio del texto del tutorial al del primer texto del array de textos
        tutorialText.text = tutorialTexts[waypointsCounter];
    }

    #endregion

    /// <summary>
    /// Aumenta en 1 el contador de waypoints
    /// </summary>
    public void WaypointTrodden()
    {
        //Desactiva el waypoint alcanzado
        waypoints[waypointsCounter].gameObject.SetActive(false);

        //Aumenta en 1 el contador de waypoints
        waypointsCounter++;
        
        //Condición que evita el OutOfBounds
        if (waypointsCounter < waypoints.Length)
        {
            //Activa el siguiente waypoint
            waypoints[waypointsCounter].gameObject.SetActive(true);

            //Actualiza el texto
            tutorialText.text = tutorialTexts[waypointsCounter];
        }

        //Condición de todos lo waypoints alcanzados
        if (waypointsCounter == waypoints.Length)
        {
            //Activa el animator de la cámara para que salte la animación en la siguiente escena
            GameObject.Find("CM vcam1").gameObject.GetComponent<Animator>().enabled = true;

            //Carga la siguiente escena
            SceneManager.LoadScene("Level");
        }
    }

}
