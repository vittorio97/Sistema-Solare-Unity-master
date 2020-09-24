using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/** Classe che gestisce il tempo, lo spazio, la benzina e il controllo della pagina di inizio **/

public class GameManager : MonoBehaviour {

	public float gloabalSpeed = 1;
	public float gloabalDistance = 1;
	public Slider changeTimeSlider;
	public Slider changeDistanceSlider;
	public Text changeTimeText;
	public Text changeDistanceText;
	public GameObject startScreen;

	private static bool start = false;
	private float upSpeedTime, downSpeedTime, upDistance, downDistance;
	private static float petrolLevel = 125;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//Controlla se è stato cliccato lo start per far iniziare il gioco
		if (start) {
			//Aumento del tempo di 10 in 10 cliccando i tasti + e -
			upSpeedTime = (Input.GetKey (KeyCode.Plus) && !Input.GetKey(KeyCode.RightShift) && !Input.GetKey(KeyCode.LeftShift)) ? 10f : 0f;
			downSpeedTime = (Input.GetKey (KeyCode.Minus) && !Input.GetKey(KeyCode.RightShift) && !Input.GetKey(KeyCode.LeftShift)) ? -10f : 0f;

			//Controllo per verificare che il valore sia 1 e qundi aggiungere 10-1 per non moltiplicare per 11 ma per 10
			if (changeTimeSlider.value == 1 && upSpeedTime != 0f) {
				changeTimeSlider.value += upSpeedTime - 1;
			} else { //altrimenti si incrementa o decrementa di 10
				changeTimeSlider.value += (upSpeedTime != 0f) ? upSpeedTime : downSpeedTime;
			}
			if (changeTimeSlider.value == 1) { //Se la velocità è uguale a 1 viene scritto "Tempo reale"
				changeTimeText.text = "[+ / -] Controllo tempo: Tempo reale";
			} else {
				changeTimeText.text = "[+ / -] Controllo tempo: " + changeTimeSlider.value + " volte più veloce";
			}

			//Diminuzione della distanza di 10 in 10 cliccando i tasti "Shift +" e "Shift -"
			if(Input.GetKey(KeyCode.RightShift) || Input.GetKey(KeyCode.LeftShift)){
				if(Input.GetKey (KeyCode.Plus)){
					upDistance = 10f;
					downDistance = 0f;
				} else if(Input.GetKey (KeyCode.Minus)){
					downDistance = -10f;
					upDistance = 0f;
				}else {
					upDistance = 0f;
					downDistance = 0f;
				}

			}

			//Controllo per verificare che il valore sia 1 e qundi aggiungere 10-1 per non moltiplicare per 11 ma per 10
			if (changeDistanceSlider.value == 1 && upDistance != 0f) {
				changeDistanceSlider.value += upDistance - 1;
			} else { //altrimenti si incrementa o decrementa di 10
				changeDistanceSlider.value += (upDistance != 0f) ? upDistance : downDistance;
			}
			if (changeDistanceSlider.value == 1) { //Se la velocità è uguale a 1 viene scritto "Tempo reale"
				changeDistanceText.text = "[Shift + / Shift -] Controllo distanza: Distanza reale";
			} else {
				changeDistanceText.text = "[Shift + / Shift -] Controllo distanza: " + changeDistanceSlider.value + " volte più vicini";
			}
		}

		if(Input.GetKey(KeyCode.Escape)){ //Gestione del tasto "esc" per mettere in pausa il gioco
			SetStart (false);
			startScreen.SetActive (true);
		}
	}

	//Metodo per campiare il tempo
	public void ChangeTime (float speedTime){
		gloabalSpeed = speedTime;
	}

	//Metodo per cambiare la distanza
	public void ChangeDistance (float distance){
		gloabalDistance = distance;
	}

	//Metodo che ritorna vero o falso se il gioco è iniziato o meno
	public static bool GetStart(){
		return start;
	}

	//Metodo che viene chiamato al click del tasto "START" per settare la variabile a true quando inizia il gioco
	public void SetStart(bool startSet){
		start = startSet;
	}

	//Metodo per settare un decremento della benzina (con il decremento negativo diventa incremento)
	public static void decreasePetrol (float decremento){
		petrolLevel -= decremento;
	}

	//Metodo che torna il livello della benzina
	public static float getPetrol (){
		return petrolLevel;
	}
}
