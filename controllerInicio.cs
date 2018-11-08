///
/// Created by Jesus 'Pokoidev' Villar, jesusferminvillar@gmail.com (www.pokoidev.com) 
/// On 26th October 2018
/// Copyright © 2018 Pokoidev. Creative Commons License:
/// Attribution 4.0 International (CC BY 4.0)
/// 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class controllerInicio : MonoBehaviour {

    #region Declaración de parámetros

    ///public

    /// <summary>
    /// Lista de las imágenes por mostrar
    /// </summary>
    public List<GameObject> imagenes;

    ///end public
   
    ///private

    /// <summary>
    /// Índice actual de imágenes
    /// </summary>
    byte index;

    ///end private


    #endregion

    #region Métodos privados

    ///<summary>
    ///Inicialización de miembros
    /// </summary>
    private void Start()
    {
        ///Asignamos el valor inical al índice de las imágenes
        index = 0;

        ///Hacemos activa la primera imagen
        imagenes[index].SetActive(true);

        Debug.Log(imagenes.Count);
    }

    private void Update()
    {
        ///Si el jugador presiona cualquier tecla
        if (Input.anyKeyDown)
        {
            
            ///Si se ha llegado al total de las imágenes
            if (index == (imagenes.Count - 1))
            {
                ///Se carga la siguiente escena
                SceneManager.LoadScene("Tutorial");
            }

            else
            {
                ///Se aumenta en uno el índice
                index++;

                ///Se muestra la imagen de ese índice
                imagenes[index].SetActive(true);
            }
           
        }  
    }
    #endregion
}
