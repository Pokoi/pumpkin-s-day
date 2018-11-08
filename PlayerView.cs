///
/// Created by Juan 'Jotadev' Mayor, juanmayor96@gmail.com 
/// On 26th October 2018
/// Copyright © 2018 Jotadev. Creative Commons License:
/// Attribution 4.0 International (CC BY 4.0)
/// 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour {

    #region Declaración de parámetros
    /// <summary>
    /// Referencia al objeto light
    /// </summary>
    [SerializeField]
    private new GameObject light;

    /// <summary>
    /// Referencia a la posición del ratón
    /// </summary>
    private Vector3 mouse_Position;

    /// <summary>
    /// Referencia al color del SpriteRenderer del padre
    /// </summary>
    private Color my_Color;
    #endregion
    
    #region Inicialización de miembros
    void Start () {
        
        //Almacenamiento del color inicial del SpriteRenderer
        my_Color = transform.parent.GetComponent<SpriteRenderer>().color;

    }
    #endregion

    #region Miembros privados

    private void Update() {
        LightLookAt();
        ToggleLight();

    }

    /// <summary>
    /// Control de la dirección de la luz
    /// </summary>
    private void LightLookAt()
    {
        //Actualización de la posición del ratón
        mouse_Position = GameManager.Instance.mouse_Position;

        //Actualización de la dirección de la luz
        light.transform.forward = new Vector3(
            mouse_Position.x - light.transform.position.x,
            mouse_Position.y - light.transform.position.y,
            0
            );
    }

    /// <summary>
    /// Encendido o apagado de la luz
    /// </summary>
    private void ToggleLight()
    {
        //Si la luz está encendida y se pulsa espacio
        if(Input.GetKeyDown(KeyCode.Space) && light.activeSelf)
        {
            light.SetActive(false);
            transform.parent.GetComponent<SpriteRenderer>().color = Color.black;
        }
        //Si la luz está apagada y se pulsa espacio
        else if (Input.GetKeyDown(KeyCode.Space) && !light.activeSelf)
        {
            light.SetActive(true);
            transform.parent.GetComponent<SpriteRenderer>().color = my_Color;
        }
    }
    #endregion

    #region Miembros públicos

    /// <summary>
    /// Función publica para apagar la luz
    /// </summary>
    public void TurnOffLight()
    {
        light.SetActive(false);
    }

    #endregion
}
