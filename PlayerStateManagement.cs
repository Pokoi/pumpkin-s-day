///
/// Created by Juan 'Jotadev' Mayor, juanmayor96@gmail.com 
/// On 26th October 2018
/// Copyright © 2018 Jotadev. Creative Commons License:
/// Attribution 4.0 International (CC BY 4.0)
/// 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManagement : MonoBehaviour {

    #region Declaración de miembros

    /// <summary>
    /// Referencia al Animator
    /// </summary>
    private Animator my_Anim;
    
    /// <summary>
    /// Referencia al SpriteRenderer
    /// </summary>
    private SpriteRenderer my_Sprite;

    /// <summary>
    /// Referencia al transform del Spawn
    /// </summary>
    public Transform spawn_Position;

    /// <summary>
    /// Referencia al botón de reinicio
    /// </summary>
    public GameObject restart_Button;
        
    /// <summary>
    /// Almacenamiento de la posición del ratón
    /// </summary>
    private Vector3 mouse_Checker;

    /// <summary>
    /// Enum con las diferenctes direcciones
    /// </summary>
    public enum Direction {Up, Down, Right, Left};
    public Direction my_Direction;

    #endregion

    #region Inicialización de miembros
    void Start () {

        my_Sprite = GetComponent<SpriteRenderer>();
        my_Anim = GetComponent<Animator>();

        //Desactiva el botón de reinicio
        restart_Button.SetActive(false);
	}

    #endregion

    #region Métodos privados

    private void Update () {

        Animate();

    }

    /// <summary>
    /// Método que controla la muerte del personaje. Se llama desde el movimiento del enemigo
    /// </summary>
    public void Dead()
    {
        //Fundido negro
        //Botón Retry
        my_Sprite.enabled = false;
        
        restart_Button.SetActive(true);


    }

    /// <summary>
    /// Método que controla el cambio de estados de las animaciones
    /// </summary>
    private void Animate()
    {
        //Actualiza la posición
        mouse_Checker = GameManager.Instance.mouse_Position - transform.position;
        
        //En caso de estar más a la derecha
        if (mouse_Checker.x > 0)
        {   
            //En caso de estar más arriba
            if (mouse_Checker.y > 0)
            {
                //En caso de estar más a la derecha que por encima
                if (mouse_Checker.x > mouse_Checker.y)
                {
                    //Activar trigger del animator
                    my_Anim.SetTrigger("Right");
                    //Desactiva el flip del SpriteRenderer
                    my_Sprite.flipX = false;
                }
                //En caso de estár más a la derecha que por encima
                else
                {
                    //Activar trigger del Animator
                    my_Anim.SetTrigger("Up");
                }
            }
            //En caso de estar por debajo
            else if (mouse_Checker.y < 0)
            {
                //En caso de estar más por debajo que a la derecha
                if (mouse_Checker.x > mouse_Checker.y)
                {
                    //Activar trigger del Animator
                    my_Anim.SetTrigger("Down");
                }
                //En caso de estar más a la derecha que por debajo
                else
                {
                    //Activar el trigger del Animator
                    my_Anim.SetTrigger("Right");
                    //Desactivar el flip del SpriteRenderer
                    my_Sprite.flipX = false;
                }
            }
        }
        //En caso de estar más a la izquierda que a la derecha
        else if (mouse_Checker.x < 0)
        {
            //En caso de estar por encima
            if (mouse_Checker.y > 0)
            {   
                //En caso de estar más a la izquierda que por encima
                if (mouse_Checker.x < mouse_Checker.y)
                {  
                    //Activar trigger del Animator
                    my_Anim.SetTrigger("Right");
                    //Desactivar el flip del SpriteRenderer
                    my_Sprite.flipX = true;
                }
                //En caso de estar más por encima que a la izquierda
                else
                {
                    //Activar trigger del animator
                    my_Anim.SetTrigger("Up");
                }
            }
            //En caso de estar por debajo
            else if (mouse_Checker.y < 0)
            {
                //En caso de estarmás abajo que a la izquierda
                if (mouse_Checker.x > mouse_Checker.y)
                {
                    //Activar el trigger del Animator
                    my_Anim.SetTrigger("Down");
                }
                //En caso de estar más a la izquierda que por debajo
                else
                {
                    //Activar el trigger del Animator
                    my_Anim.SetTrigger("Right");
                    //Acivar el flip del SpriteRenderer
                    my_Sprite.flipX = true;
                }
            }
        }

    }
    #endregion

    #region Métodos públicos
    /// <summary>
    /// Método que controla el respawn al pulsar la opción de Retry
    /// </summary>
    public void Respawn()
    {
        transform.position = spawn_Position.position;
        my_Sprite.enabled = true;
        restart_Button.SetActive(false);
    }

    #endregion


}


