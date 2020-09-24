using UnityEngine;
using System.Collections;

/** Classe per il controllo della rotazione attorno al sole dei pianeti a seconda del semiasse maggiore o minore in unità astronomiche,
oppure con il semiasse maggiore e l'eccentricità del pianeta.

Tutte le misure sono reali e se il tempo è messo a 1 la rotazione è reale (es: un giro completo attorno al sole della terra avviene in 1 anno reale)**/

public class TurnAround : MonoBehaviour {

	public Vector3 sun = new Vector3(0, 0, 0);
	public float semiAsseMaggioreUA;
	public float semiAsseMinoreUA;
	public float eccentricita;
	public float anniXRotazione = 1;

	private float angle;
	private Vector3 center = new Vector3(0, 0, 0);
	GameManager managerTransform;

	// Use this for initialization
	void Start () {
		semiAsseMaggioreUA = semiAsseMaggioreUA * (11728.64f/10f);
		semiAsseMinoreUA = semiAsseMinoreUA * (11728.64f/10f);

		if(semiAsseMinoreUA == 0 && eccentricita != 0){ // Calcolo del semiasse minore con l'eccentricità
			semiAsseMinoreUA = semiAsseMaggioreUA * Mathf.Sqrt (1-Mathf.Pow(eccentricita, 2));
		}

		if (Mathf.Max (semiAsseMaggioreUA, semiAsseMinoreUA) == semiAsseMaggioreUA) {
			center = new Vector3 (Mathf.Max(semiAsseMaggioreUA,semiAsseMinoreUA)/2, 0, 0); //Calcolo del centro dell'ellisse
		} else {
			center = new Vector3 (0, 0, Mathf.Max(semiAsseMaggioreUA,semiAsseMinoreUA)/2); //Calcolo del centro dell'ellisse
		}

		managerTransform = GameObject.Find ("GameManager").GetComponent<GameManager>();
	}

	// Update is called once per frame
	void Update () {
		//Calcolo della velocità angolare
		angle += (anniXRotazione / (3.165f * Mathf.Pow(10,7))) * managerTransform.gloabalSpeed * Time.deltaTime;

		//Calcolo delle cordinate del pianeta
		float x = (semiAsseMaggioreUA * Mathf.Cos(angle)) / managerTransform.gloabalDistance;
		float z = (semiAsseMinoreUA * Mathf.Sin(angle)) / managerTransform.gloabalDistance;

		transform.position = center + new Vector3(x, 0, z);
	}
}
