using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/** Classe per il controllo delle varie componenti dell'interfaccia e la benzina **/

public class UI : MonoBehaviour {

	public Image arrowHorizontal, arrowVertical, pointerSpeed, pointerPetrol;
	public Text numberVertical;
	public Sprite arrow, line;
	public AudioClip errorAudioClip;
	public AudioSource errorAudio;
	public AudioClip petrolAudioClip;
	public AudioSource petrolAudio;
	public GameObject navicella;

	private Transform move;

	// Use this for initialization
	void Start () {
		move = navicella.GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		if (GameManager.GetStart()) {
			//Controllo che la navicella abbia ancora benzina per andare
			if (GameManager.getPetrol() > 0) {
				//Gestione dell'interfaccia per la velocità e la direzione

				if (Input.GetAxis ("Horizontal") > 0) { //Gestione della freccia per indicare la direzione destra e sinistra che si sta andando
					arrowHorizontal.overrideSprite = arrow;
					arrowHorizontal.GetComponent<RectTransform> ().localRotation = Quaternion.Euler (0f, 0f, 0f);
				} else if (Input.GetAxis ("Horizontal") < 0) {
					arrowHorizontal.overrideSprite = arrow;
					arrowHorizontal.GetComponent<RectTransform> ().localRotation = Quaternion.Euler (0f, 0f, 180f);
				} else {
					arrowHorizontal.overrideSprite = line;
					arrowHorizontal.GetComponent<RectTransform> ().localRotation = Quaternion.Euler (0f, 0f, 0f);
				}

				if (Input.GetKey(KeyCode.E)) { //Gestione della freccia per indicare la direzione su e giù che si sta andando
					arrowVertical.overrideSprite = arrow;
					arrowVertical.GetComponent<RectTransform> ().localRotation = Quaternion.Euler (0f, 0f, 90f);
				} else if (Input.GetKey(KeyCode.Q)) {
					arrowVertical.overrideSprite = arrow;
					arrowVertical.GetComponent<RectTransform> ().localRotation = Quaternion.Euler (0f, 0f, 270f);
				} else {
					arrowVertical.overrideSprite = line;
					arrowVertical.GetComponent<RectTransform> ().localRotation = Quaternion.Euler (0f, 0f, 0f);
				}
				numberVertical.text = "" + (int)move.position.y; //Numero dell'altezza in cui ci si trova lungo l'asse y

				//Gestione della lancetta che indica la velocità di avanzamento della telecamera
				float speedVertical;
				if (Input.GetKey (KeyCode.LeftShift)) {
					speedVertical = Input.GetAxis ("Vertical");
				} else {
					speedVertical = (Input.GetAxis ("Vertical")/5)*4;
				}
				pointerSpeed.GetComponent<RectTransform> ().localRotation = Quaternion.Euler (0f, 0f, (95f + Mathf.Abs (speedVertical) * -265f)); //Gestione della lancetta

				//Gestione della benzina
				//Caricamento della benzia che ci si trova nell'intorno del rifornimento
				if (GameManager.getPetrol() <= 125 && move.position.x > 540 && move.position.x < 660 && move.position.z > 540 && move.position.z < 660 && move.position.y > 0 && move.position.y < 40) {
					GameManager.decreasePetrol(-0.2f);
					petrolAudio.PlayOneShot (petrolAudioClip);
				} else if(GameManager.getPetrol() > 125){
					petrolAudio.Stop ();
				}

				//Consumo della benzina quando ci si muove
				if (Input.GetAxis ("Horizontal") != 0 || Input.GetAxis ("Vertical") != 0 || Input.GetKey (KeyCode.E) || Input.GetKey (KeyCode.Q)) {
					GameManager.decreasePetrol(0.02f);
				}
				//Gestione della lancetta della benzina
				pointerPetrol.GetComponent<RectTransform> ().localRotation = Quaternion.Euler (0f, 0f, (61 - GameManager.getPetrol()));

			} else { //Quando la benzina finisce tutte le funzioni del movimento si bloccano e ci si può solo teletrasportare nel rifornimento
				pointerSpeed.GetComponent<RectTransform> ().localRotation = Quaternion.Euler (0f, 0f, 95f); //Lancetta della velocità messa a 0

				//Se ci si trova nelle zone del rifornimento con il teletrasporto la benzina si alza
				if (GameManager.getPetrol() <= 125 && move.position.x > 540 && move.position.x < 660 && move.position.z > 540 && move.position.z < 660 && move.position.y > 0 && move.position.y < 40) {
					GameManager.decreasePetrol(-0.2f);
					petrolAudio.PlayOneShot (petrolAudioClip);
				}

				//Suono di errore se si clicca un qualsiasi bottone che non sia [R] per il rifornimento
				if (Input.anyKeyDown && !Input.GetKey(KeyCode.R)) {
					errorAudio.PlayOneShot (errorAudioClip);
				}
			}
		}
	}
}
