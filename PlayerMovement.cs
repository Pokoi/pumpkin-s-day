///
/// Created by Juan 'Jotadev' Mayor, juanmayor96@gmail.com 
/// On 26th October 2018
/// Copyright © 2018 Jotadev. Creative Commons License:
/// Attribution 4.0 International (CC BY 4.0)
/// 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    #region Declaración de variables

    /// <summary>
    /// Referencia al transform del objeto
    /// </summary>
    private Transform my_Tr;
    /// <summary>
    /// Referencia al transform del inicio del ray
    /// </summary>
    [SerializeField]
    private Transform ray_Tr;
    /// <summary>
    /// Referencia al transform del objeto padre
    /// </summary>
    [SerializeField]
    private Transform dad_Tr;
    /// <summary>
    /// Velocidad de movimiento
    /// </summary>
    [SerializeField]
    private float movement_Speed;
    /// <summary>
    /// Posición del ratón
    /// </summary>
    private Vector3 mouse_Position;
    /// <summary>
    /// Dirección hacia la que miramos
    /// </summary>
    private Vector2 direction;

    #endregion

    #region Miembros privados

    private void Start () {
        my_Tr = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	private void Update () {

        if (GameManager.Instance.light.activeSelf)
        {
            Movement();
        }

	}

    /// <summary>
    ///Movimiento del jugador mediante Inputs y transform.
    /// </summary>
    private void Movement()
    {
        //Calculamos la dirección
        direction = new Vector2(
            GameManager.Instance.mouse_Position.x - my_Tr.position.x,
            GameManager.Instance.mouse_Position.y - my_Tr.position.y
            );

        //Orientamos el transform del objeto hacia la dirección
        my_Tr.up = direction;

        //Movemos el transform del padre en nuestra dirección
        dad_Tr.position += my_Tr.up * Input.GetAxisRaw("Vertical") * movement_Speed * Time.deltaTime;

    }

    #endregion
    
}
