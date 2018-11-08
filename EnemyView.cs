///
/// Created by Jesus 'Pokoidev' Villar, jesusferminvillar@gmail.com (www.pokoidev.com) 
/// On 26th October 2018
/// Copyright © 2018 Pokoidev. Creative Commons License:
/// Attribution 4.0 International (CC BY 4.0)
/// 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyView : MonoBehaviour {

    #region Declaración de parámetros

    #region Tipos de enemigo
    [Space]
    [Header("Tipos de enemigo")]
    
    /// <summary>
    /// Tipo del enemigo
    /// </summary>    
    public Type type;

    /// <summary>
    /// Tipos
    /// searcher = sigue una ruta 
    /// waiter = espera en un punto concreto    /// 
    /// </summary>    
    public enum Type { searcher, waiter };

    #endregion

    #region Patrulla
    /// <summary>
    /// The route.
    /// </summary>
    public List<CheckPoints> route = new List<CheckPoints>();
    public byte actual_position;

    #endregion

    /// <summary>
    /// El transform de este objeto
    /// </summary>
    Transform my_transform;

    #endregion

    #region Métodos Públicos

    /// <summary>
    /// Método que controla las acciones del enemigo
    /// </summary>
    public void WhatToDo()
    {
        ///Si el enemigo es de los que esperan
        if (type == Type.waiter)
        {
            ///Se traslada al punto inicial
            my_transform.GetComponent<MovementController>().BackToWaitingPoint();
        }

        ///Si el enemigo es de los que siguen una ruta
        else if (type == Type.searcher)
        {
            ///Establecemos el punto siguiente de la ruta
            if (actual_position < (route.Count-1) ) actual_position++;
            else actual_position = 0;

            ///Se traslada al siguiente punto de la ruta
            my_transform.GetComponent<MovementController>().MoveToCheckPoint(route[actual_position].gameObject.transform.position);

        }
    }

    #endregion

    #region Métodos Privados

    /// <summary>
    /// Inicialización de miembros
    /// </summary>
    void Start()
    {
        ///El transform del enemigo
        my_transform = transform;

        ///Establecemos la posición en la ruta
        actual_position = 0;
    }

   
    /// <summary>
    /// Método que controla las colisiones de este objeto
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ///Si colisiona contra el jugador
        if (collision.tag == "Player")
        {
            ///Sigue al jugador
            my_transform.GetComponent<MovementController>().FollowPlayer();
        }
    }

    #endregion

}
