using System;
using System.Collections.Generic;

/** Classe che contiene tutte le informazioni sui pianeti **/

public class DataBase {
	Dictionary<string, string[]> dataBase;

	public DataBase (){
		dataBase = new Dictionary<string, string[]> (); // Dictionary che relaziona il nome del pianeta con l'array di informazioni

		/** Le informazioni dei pianeti sono in un array formato da:
		- 0: Massa
		- 1: Diametro
		- 2: Gravità
		- 3: Giorno solare
		- 4: Inclinazione
		- 5: Densità
		- 6: Velocità di fuga
		- 7: Temperatura**/

		string[] dataSole =  new string[8];
		dataSole[0] = "1,9891 e+30 kg";
		dataSole[1] = "1 392 000 km";
		dataSole[2] = "274 kg/m^3";
		dataSole[3] = "27 giorni 6 ore e 36 minuti";
		dataSole[4] = "7,25°";
		dataSole[5] = "1411 kg/m^3";
		dataSole[6] = "617,54 kg/s";
		dataSole[7] = "5500 °C";
		dataBase.Add("Sole", dataSole); //Sole

		string[] dataMercurio =  new string[8];
		dataMercurio[0] = "3,299619 e+23 kg";
		dataMercurio[1] = "4 879 km";
		dataMercurio[2] = "3,7 kg/m^3";
		dataMercurio[3] = "4222,6 ore";
		dataMercurio[4] = "0,01°";
		dataMercurio[5] = "5427 kg/m^3";
		dataMercurio[6] = "4,3 kg/s";
		dataMercurio[7] = "167 °C";
		dataBase.Add("Mercurio", dataMercurio); //Mercurio

		string[] dataVenere =  new string[8];
		dataVenere[0] = "4,86555 e+24 kg";
		dataVenere[1] = "12 104 km";
		dataVenere[2] = "8,9 kg/m^3";
		dataVenere[3] = "2802 ore";
		dataVenere[4] = "117,4°";
		dataVenere[5] = "5243 kg/m^3";
		dataVenere[6] = "10,4 kg/s";
		dataVenere[7] = "464 °C";
		dataBase.Add("Venere", dataVenere); //Venere

		string[] dataTerra =  new string[8];
		dataTerra[0] = "5,97 e+24 kg";
		dataTerra[1] = "12 104 km";
		dataTerra[2] = "9,8 kg/m^3";
		dataTerra[3] = "24 ore";
		dataTerra[4] = "23,5°";
		dataTerra[5] = "5515 kg/m^3";
		dataTerra[6] = "11,2 kg/s";
		dataTerra[7] = "15 °C";
		dataBase.Add("Terra", dataTerra); //Terra

		string[] dataMarte =  new string[8];
		dataMarte[0] = "6,414765 e+23 kg";
		dataMarte[1] = "6794 km";
		dataMarte[2] = "3,7 kg/m^3";
		dataMarte[3] = "24,7 ore";
		dataMarte[4] = "25,2°";
		dataMarte[5] = "3933 kg/m^3";
		dataMarte[6] = "5 kg/s";
		dataMarte[7] = "-65 °C";
		dataBase.Add("Marte", dataMarte); //Marte

		string[] dataGiove =  new string[8];
		dataGiove[0] = "1,897445 e+27 kg";
		dataGiove[1] = "142 984 km";
		dataGiove[2] = "23,1 kg/m^3";
		dataGiove[3] = "9,9 ore";
		dataGiove[4] = "3,1°";
		dataGiove[5] = "1326 kg/m^3";
		dataGiove[6] = "59,5 kg/s";
		dataGiove[7] = "-110 °C";
		dataBase.Add("Giove", dataGiove); //Giove

		string[] dataSaturno =  new string[8];
		dataSaturno[0] = "5,680992 e+26 kg";
		dataSaturno[1] = "120 536 km";
		dataSaturno[2] = "9 kg/m^3";
		dataSaturno[3] = "10,7 ore";
		dataSaturno[4] = "26,7°";
		dataSaturno[5] = "687 kg/m^3";
		dataSaturno[6] = "35,5 kg/s";
		dataSaturno[7] = "-140 °C";
		dataBase.Add("Saturno", dataSaturno); //Saturno

		string[] dataUrano =  new string[8];
		dataUrano[0] = "8,6565 e+25 kg";
		dataUrano[1] = "51 118 km";
		dataUrano[2] = "8,7 kg/m^3";
		dataUrano[3] = "17,2 ore";
		dataUrano[4] = "97,8°";
		dataUrano[5] = "1270 kg/m^3";
		dataUrano[6] = "21,3 kg/s";
		dataUrano[7] = "-195 °C";
		dataBase.Add("Urano", dataUrano); //Urano

		string[] dataNettuno =  new string[8];
		dataNettuno[0] = "1,027079 e+26 kg";
		dataNettuno[1] = "49 528 km";
		dataNettuno[2] = "11 kg/m^3";
		dataNettuno[3] = "16,1 ore";
		dataNettuno[4] = "28,3°";
		dataNettuno[5] = "1638 kg/m^3";
		dataNettuno[6] = "23,5 kg/s";
		dataNettuno[7] = "-200 °C";
		dataBase.Add("Nettuno", dataNettuno); //Nettuno
	}

	//Funzione toString(nomePianeta) che torna una stringa con le informazioni del pianeta ben scritte
	public string toString (string planet){
		string text;
		if (planet.Equals ("Rifornimento")) {
			text = "Sei nella stazione di servizio\n\nRicorda di fare rifornimeto prima di rimanere a piedi";
		} else {
			string[] dataPlanet = dataBase [planet];
			if (planet.Equals ("Sole")) {
				text = "Sei nelle prossimità del " + planet;
			} else {
				text = "Sei nelle prossimità del pianeta " + planet;
			}
			text += "\n\nMassa: " + dataPlanet [0];
			text += "\nDiametro: " + dataPlanet [1];
			text += "\nGravità: " + dataPlanet [2];
			text += "\nGiorno solare: " + dataPlanet [3];
			text += "\nInclinazione: " + dataPlanet [4];
			text += "\nDensità: " + dataPlanet [5];
			text += "\nVelocità di fuga: " + dataPlanet [6];
			text += "\nTemperatura: " + dataPlanet [7];
		}
		return text;
	}
}