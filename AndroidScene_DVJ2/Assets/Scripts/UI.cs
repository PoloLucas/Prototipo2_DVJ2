using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour{
    [SerializeField]private TextMeshProUGUI scoreValue;
    [SerializeField]private TextMeshProUGUI failuresValue;
    private Player player;

    public void Start(){
        scoreValue.GetComponent<TextMeshProUGUI>(); //obtiene el Texto del objeto
        failuresValue.GetComponent<TextMeshProUGUI>(); //obtiene el Texto del objeto
        player=GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    public void Update(){
        scoreValue.text=player.score.ToString(); //actualiza la puntuación del Jugador
        failuresValue.text=player.failures.ToString()+"/"+player.maxFailures.ToString(); //actualiza la puntuación del Jugador
    }
}