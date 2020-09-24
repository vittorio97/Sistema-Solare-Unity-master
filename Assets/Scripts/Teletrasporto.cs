using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

/** Classe per il controllo del teletrasporto nei vari pianeti **/

public class Teletrasporto : MonoBehaviour {

	public GameObject navicella;
	public Text info;
	public AudioClip petrolAudioClip;
	public AudioSource petrolAudio;

	private string selezione = "";
	private bool firstSelect = false;
	private Transform myPosition;
	private GameObject pianeta;
	private float xPianeta, yPianeta, zPianeta, scalePianeta, xPosition, yPosition, zPosition, distance;
	private Vector3 myDistanceVector;
	private Dictionary<string, string> dataPlanet;
	private DataBase dataBasePlanet = new DataBase ();
	private string[] namePianeti = {"Sole", "Mercurio", "Venere", "Terra", "Marte", "Giove", "Saturno", "Urano", "Nettuno", "Rifornimento"};

	// Use this for initialization
	void Start () {
		myPosition = navicella.GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		if (GameManager.GetStart()) {
			//Trasformazione dell'imput dell'utente nel nome del pianeta
			if (Input.GetKeyDown (KeyCode.Alpha1)) {
				selezione = "Sole";
				firstSelect = true;
			} else if (Input.GetKeyDown (KeyCode.Alpha2)) {
				selezione = "Mercurio";
				firstSelect = true;
			} else if (Input.GetKeyDown (KeyCode.Alpha3)) {
				selezione = "Venere";
				firstSelect = true;
			} else if (Input.GetKeyDown (KeyCode.Alpha4)) {
				selezione = "Terra";
				firstSelect = true;
			} else if (Input.GetKeyDown (KeyCode.Alpha5)) {
				selezione = "Marte";
				firstSelect = true;
			} else if (Input.GetKeyDown (KeyCode.Alpha6)) {
				selezione = "Giove";
				firstSelect = true;
			} else if (Input.GetKeyDown (KeyCode.Alpha7)) {
				selezione = "Saturno";
				firstSelect = true;
			} else if (Input.GetKeyDown (KeyCode.Alpha8)) {
				selezione = "Urano";
				firstSelect = true;
			} else if (Input.GetKeyDown (KeyCode.Alpha9)) {
				selezione = "Nettuno";
				firstSelect = true;
			} else if (Input.GetKeyDown (KeyCode.R)) {
				selezione = "Rifornimento";
				firstSelect = true;
			}

			//Ricerca del pianeta più vicino
			string foundPlanet = "";
			for (int i = 0; i < namePianeti.Length; i++) {
				float distance = Vector3.Distance(getVectorPlanet(namePianeti[i]), myPosition.position);
				if (distance < getScalePlanet (namePianeti [i]) + 20f) {
					foundPlanet = namePianeti [i];
				}
			}

			if (!firstSelect) {
				selezione = foundPlanet;
			}

			//Se la selezione non è vuota allora mi teletrasporto nel pianeta oppure scrivo le informazioni di esso
			if (!selezione.Equals ("")) {
				pianeta = GameObject.Find (selezione);

				xPianeta = pianeta.GetComponent<Transform> ().position.x;
				yPianeta = pianeta.GetComponent<Transform> ().position.y;
				zPianeta = pianeta.GetComponent<Transform> ().position.z;
				scalePianeta = pianeta.GetComponent<Transform> ().localScale.x;

				//controllo per verificare che la benzina non sia finita e che sia la prima volta che si seleziona il pianeta
				if (!selezione.Equals ("Rifornimento") && GameManager.getPetrol () > 0f && firstSelect) {
					myPosition.position = new Vector3 ((xPianeta + scalePianeta + 1), yPianeta, zPianeta);
					GameManager.decreasePetrol (1f);
					petrolAudio.Stop ();
				} else if (firstSelect && GameManager.getPetrol () >= 0f && selezione.Equals ("Rifornimento")) { //se la benzina è finita e si seleziona il "rifornimento", si può essere teletrasportati
					myPosition.position = new Vector3 (xPianeta - 10, 10, zPianeta - 45);
					petrolAudio.PlayOneShot (petrolAudioClip);
				}

				firstSelect = false;

				if (GameManager.getPetrol () > 0f) { //scrittura delle informazioni sul pianeta nell'interfaccia
					info.text = dataBasePlanet.toString (selezione);
				} else { //se la benzina finisce si visualizza un messaggio informativo
					string text;
					text = "L'unica azione possibile è fare rifornimento [R]";
					info.text = text;
					if (Input.GetKey (KeyCode.R)) {
						selezione = "Rifornimento";
						myPosition.position = new Vector3 (xPianeta - 10, 10, zPianeta - 45);
					}
				}
			} else if (GameManager.getPetrol () == 0f) {
				info.text = "L'unica azione possibile è fare rifornimento [R]";
			} else {
				info.text = "Seleziona una destinazione";
				petrolAudio.Stop();
			}
		}
	}

	private float getScalePlanet (string planet){
		return GameObject.Find (planet).GetComponent<Transform> ().localScale.x;
	}

	private Vector3 getVectorPlanet (string planet){
		return GameObject.Find (planet).GetComponent<Transform> ().position;
	}
}
