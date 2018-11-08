///
/// Created by Jesus 'Pokoidev' Villar, jesusferminvillar@gmail.com (www.pokoidev.com)
/// &
/// Created by Juan 'Jotadev' Mayor, juanmayor96@gmail.com
/// On 26th October 2018
/// Copyright © 2018 Pokoidev & Copyright © 2018 Name Creative Commons License:
/// Attribution 4.0 International (CC BY 4.0)
/// 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    #region Declaración de parámetros

    ///public

    /// <summary>
    /// Gameobject del jugador
    /// </summary>
    public GameObject player;
    /// <summary>
    /// Gameobject de la luz
    /// </summary>
    public new GameObject light;
    
    /// <summary>
    /// Propiedad que devuelve la posición del jugador
    /// </summary>
    public Vector3 player_position{
        get{
            return player.transform.position;            
        }
    }

    /// <summary>
    /// Vector3 que guarda la posición del ratón en coordenadas de mundo
    /// </summary>
    public Vector3 mouse_Position;

    /// <summary>
    /// Referencia a la cámara
    /// </summary>
    public Camera my_Camera;

    ///end public

    #endregion

    #region Singleton

    /// <summary>
    /// Campo privado que referencia a esta instancia
    /// </summary>
    static GameManager instance;

    /// <summary>
    /// Propiedad pública que devuelve una referencia a esta instancia
    /// Pertenece a la clase, no a esta instancia
    /// Proporciona un punto de acceso global a esta instancia
    /// </summary>
    public static GameManager Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        ///Asigna esta instancia al campo instance
        if (instance == null)
            instance = this;
        else
            Destroy(this);  ///Garantiza que sólo haya una instancia de esta clase   
    }

    #endregion

    #region Métodos privados

    private void Update()
    {
        ///Guardamos la posición del ratón
        mouse_Position = Input.mousePosition;
        ///Convertimos la posición del ratón en coordenadas de mundo
        mouse_Position = my_Camera.ScreenToWorldPoint(mouse_Position);
    }

    #endregion
}
