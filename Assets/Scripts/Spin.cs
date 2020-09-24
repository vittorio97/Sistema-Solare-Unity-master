using UnityEngine;
using System.Collections;

/** Classe per il controllo del periodo di rotazione dei pianeti, calcolato su quante ore servono per fare un giro completo.
Se il tempo è messo a 1, la rotazione è reale (es: un periodo di rotazione della terra avviene in 24 ore reali) **/

public class Spin : MonoBehaviour {

	public float oreXRotazione = 24;
	Transform rotation;
	GameManager managerTransform;

	// Use this for initialization
	void Start () {
		rotation = GetComponent<Transform>();
		managerTransform = GameObject.Find ("GameManager").GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
		rotation.Rotate(Vector3.up * (oreXRotazione/3600) * managerTransform.gloabalSpeed * Time.deltaTime, Space.Self);
	}
}
