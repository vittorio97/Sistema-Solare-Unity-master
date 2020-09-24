using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/** Classe per il controllo in prima persona della telecamera **/

public class FirstPersonController : MonoBehaviour {

	public float speedRotation = 2f, speedTranslation= 2f, maxLookUp = 90f, minLookDown = -90f;

	private float horizontalMouse, verticalMouse, horizontal, vertical, up, down, lancettaRotationX, lancettaRotationY, speedTranslationSet;
	private Transform move;
	private Rigidbody rigid;
	private Vector3 destraSinistra = new Vector3(), avantiIndietro = new Vector3(), su = new Vector3(), giu = new Vector3();

	// Use this for initialization
	void Start () {
		move = GetComponent<Transform>();
		rigid = GetComponent<Rigidbody> ();
	}

	void FixedUpdate () {
		//Controllo che il gioco sia iniziato
		if (GameManager.GetStart()) {
			//Controllo che la navicella abbia ancora benzina per andare
			if (GameManager.getPetrol () > 0) {
				//Rotazione con il mouse
				horizontalMouse += Input.GetAxis ("Mouse X") * speedRotation;
				verticalMouse -= Input.GetAxis ("Mouse Y") * speedRotation;
				verticalMouse = Mathf.Clamp (verticalMouse, minLookDown, maxLookUp);

				//Rotazione della navicella con il mouse
				rigid.transform.localRotation = Quaternion.Euler (verticalMouse, horizontalMouse, 0f);

				//Translazione avanti e indietro, destra e sinistra, su e giù
				horizontal = Input.GetAxis ("Horizontal") * speedTranslationSet;
				vertical = Input.GetAxis ("Vertical") * speedTranslationSet;
				up = Input.GetKey (KeyCode.E) ? 1f : 0f * speedTranslationSet;
				down = Input.GetKey (KeyCode.Q) ? -1f : 0f * speedTranslationSet;
				destraSinistra = move.right * horizontal;
				avantiIndietro = move.forward * vertical;
				su = move.up * up;
				giu = move.up * down;

				//Movimento della navicella con tastiera (W, A, S, D, Q, E)
				rigid.MovePosition (rigid.position + destraSinistra + avantiIndietro + su + giu);

				//Gestione dell'accelerazione con lo shift
				if (Input.GetKey (KeyCode.LeftShift)) {
					speedTranslationSet = speedTranslation + 10f;
				} else {
					speedTranslationSet = speedTranslation;
				}
			}
		}
	}
}
