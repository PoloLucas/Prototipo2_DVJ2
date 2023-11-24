using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI : MonoBehaviour{
    [SerializeField]private TextMeshProUGUI scoreValue;
    [SerializeField]private TextMeshProUGUI failuresValue;
    [SerializeField]private TextMeshProUGUI catText;
    [SerializeField]private RawImage cat;
    [SerializeField]public Texture gatoNormal;
    [SerializeField]public Texture gatoConfiado;
    [SerializeField]public Texture gatoFeliz;
    [SerializeField]public Texture gatoTite;
    public int catState;
    private Player player;

    public void Start(){
        scoreValue.GetComponent<TextMeshProUGUI>(); //obtiene el Texto del objeto
        failuresValue.GetComponent<TextMeshProUGUI>(); //obtiene el Texto del objeto
        catText.GetComponent<TextMeshProUGUI>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        catState = 0;
    }

    public void Update(){
        scoreValue.text = player.score.ToString(); //actualiza la puntuación del Jugador
        failuresValue.text = player.failures.ToString()+"/"+player.maxFailures.ToString(); //actualiza la puntuación del Jugador
        ChangeState();
    }

    void ChangeState(){
        switch(catState){
            case 0:{
                cat.texture = gatoNormal;
                catText.text = "¡Coloca los contenedores en una superficie plana!";
                break;
            }
            case 1:{
                cat.texture = gatoConfiado;
                catText.text = "¡Toca para arrojar la basura!";
                break;
            }
            case 2:{
                cat.texture = gatoFeliz;
                catText.text = "¡Muy bien!";
                break;
            }
            case 3:{
                cat.texture = gatoTite;
                catText.text = "Fallaste...";
                break;
            }
        }
    }
}