using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI : MonoBehaviour{
    [SerializeField]private TextMeshProUGUI scoreValue;
    [SerializeField]private TextMeshProUGUI failuresValue;
    [SerializeField]private RawImage gato;
    [SerializeField]public Texture gatoNormal;
    [SerializeField]public Texture gatoFeliz;
    [SerializeField]public Texture gatoTite;
    public int catState;
    private Player player;

    public void Start(){
        scoreValue.GetComponent<TextMeshProUGUI>(); //obtiene el Texto del objeto
        failuresValue.GetComponent<TextMeshProUGUI>(); //obtiene el Texto del objeto
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        catState = 0;
    }

    public void Update(){
        scoreValue.text=player.score.ToString(); //actualiza la puntuación del Jugador
        failuresValue.text=player.failures.ToString()+"/"+player.maxFailures.ToString(); //actualiza la puntuación del Jugador
        ChangeExpression();
    }

    void ChangeExpression(){
        switch(catState){
            case 0:{
                gato.texture = gatoNormal;
                break;
            }
            case 1:{
                gato.texture = gatoFeliz;
                break;
            }
            case 2:{
                gato.texture = gatoTite;
                break;
            }
        }
    }
}