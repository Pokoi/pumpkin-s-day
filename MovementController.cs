///
/// Created by Jesus 'Pokoidev' Villar, jesusferminvillar@gmail.com (www.pokoidev.com) 
/// On 26th October 2018
/// Copyright © 2018 Pokoidev. Creative Commons License:
/// Attribution 4.0 International (CC BY 4.0)
/// 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour {

    #region Declaración de parámetros

    ///public

    /// <summary>
    /// Velocidad de movimiento del enemigo 
    /// </summary>
    public float mov_speed;    

    /// <summary>
    /// La distancia a la que muere el jugador
    /// </summary>
    public float min_distance_to_player;

    /// <summary>
    /// La distancia a partir de la cual deja de seguir al jugador
    /// </summary>
    public float max_distance_to_player;

    /// <summary>
    /// Distancia mínima a los objectivos
    /// </summary>
    public float min_distance_to_objective;

    ///end public
    
    ///private
        
    ///<summary>
    ///¿Está siguiendo al jugador?
    /// </summary>    
    bool following_Target;

    /// <summary>
    /// Posición inicial de este objeto
    /// </summary>
    Vector3 initial_position;
    /// <summary>
    /// Dirección a seguir en el movimiento
    /// </summary>
    Vector3 direction;

    /// <summary>
    /// Transform de este objeto
    /// </summary>
    Transform my_transform;

    ///end private

    #endregion

    #region Métodos públicos

    /// <summary>
    /// Método llamado desde EnemyView que envía al enemigo al siguiente checkpoint 
    /// </summary>
    /// <param name="target_position">Target position.</param>
    public void MoveToCheckPoint(Vector3 target_position)
    {
        Move(new Vector3(target_position.x, target_position.y, my_transform.position.z));
    }

    /// <summary>
    /// Método llamado desde EnemyView que manda seguir al jugador
    /// </summary>
    public void FollowPlayer()
    {
        following_Target = true;
       Move(GameManager.Instance.player.transform.position);

    }

    /// <summary>
    /// Método que envía al enemigo a su waiting point inicial
    /// </summary>
    public void BackToWaitingPoint()
    {

        Move(initial_position);

    }

    #endregion

    #region Métodos privados

    /// <summary>
    /// Inicialización de miembros
    /// </summary>
    private void Start()
    {
        ///Establecemos el transform de este objeto
        my_transform = transform;

        ///Establecemos como posición inical la posición de este objeto
        ///en el primer frame
        initial_position = my_transform.position;

        ///Si el enemigo es de los que tienen ruta
        if (my_transform.GetComponent<EnemyView>().type == EnemyView.Type.searcher)
        {
            ///Establecemos qué debe hacer el enemigo
            my_transform.GetComponent<EnemyView>().WhatToDo();
        }
        else
        {
            ///Si no, establecemos como dirección la posición inicial
            direction = initial_position;
        }

    }

    private void Update()
    {
        ///Si ha llegado a su objetivo
        if (Vector3.Distance(my_transform.position, direction) <= min_distance_to_objective)
        {
            ///Si el enemigo es de los que tienen ruta
            if (my_transform.GetComponent<EnemyView>().type == EnemyView.Type.searcher)
            {
                ///Establecemos qué debe hacer el enemigo
                my_transform.GetComponent<EnemyView>().WhatToDo();
            }

        }

        else
        {       

            ///Si está siguiendo al jugador
            if (following_Target)
            {
                ///Se establece la dirección como la posición del jugador
                direction = GameManager.Instance.player.transform.position;

                ///Si llega hasta el jugador
                if (Vector3.Distance(my_transform.position, direction) <= min_distance_to_player)
                {
                    ///Se resetea el estado de seguimiento
                    following_Target = false;
                    ///Y se mata al personaje del jugador
                    GameManager.Instance.player.GetComponent<PlayerStateManagement>().Dead();

                    ///Establecemos qué debe hacer el enemigo
                    my_transform.GetComponent<EnemyView>().WhatToDo();
                }

                ///Si el jugador se aleja mucho
                else if (Vector3.Distance(my_transform.position, direction) >= max_distance_to_player)
                {
                    ///Se resetea el estado de seguimiento
                    following_Target = false;

                    ///Establecemos qué debe hacer el enemigo
                    my_transform.GetComponent<EnemyView>().WhatToDo();
                }
            }

            ///Se mueve al destino objetivo
            Move(direction);
        }

    }

    /// <summary>
    /// Método que controla el movimiento recibiendo un vector que toma como dirección
    /// </summary>
    /// <param name="vector">Vector.</param>
    private void Move(Vector3 vector)
    {
        direction = vector;
        transform.position = Vector3.MoveTowards(my_transform.position, direction, mov_speed * Time.deltaTime);
    }

    #endregion

}
