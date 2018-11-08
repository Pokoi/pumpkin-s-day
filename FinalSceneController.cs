///
/// Created by Jesus 'Pokoidev' Villar, jesusferminvillar@gmail.com (www.pokoidev.com) 
/// On 26th October 2018
/// Copyright © 2018 Pokoidev. Creative Commons License:
/// Attribution 4.0 International (CC BY 4.0)
/// 


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalSceneController : MonoBehaviour {

    #region Declaración de parámetros

    ///public

    /// <summary>
    /// GameObject del player
    /// </summary>
    public GameObject player;

    ///end public

    #endregion

    #region Métodos privados

    /// <summary>
    /// En el primer frame
    /// </summary>
    void Start () {
        ///Iniciamos la animación final
        ///Esta animación la posee el jugador
        player.transform.GetComponent<Animator>().SetTrigger("final_cinematic");
		
	}

    #endregion
}
