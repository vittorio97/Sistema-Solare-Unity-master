# Sistema Solare in Unity
Questo software è stato creato per un progetto universitario in merito all'insegnamento di Web Design and User Experience nel corso di laurea in Informatica dell'Università degli Studi di Udine.

La consegna del progetto è la creazione di un sistema solare e di eventuali aggiunte per creare un gioco base con l'utilizzo di Unity.

## Idea
L'idea del gioco è la creazione di un sistema solare proporzionato con quello reale sia nelle dimensioni dei pianeti e sia nelle distanze e velocità di questi. In più c'è l'aggiunta di un controllo del tempo, per velocizzare il moto di rivoluzione e di rotazione di tutti i pianeti, e di un controllo dello spazio, per diminuire l'allontananza dei pianeti mantenedo la loro scala e la loro velocità reale.

Il progetto verte sulla creazione di un computer di bordo, immaginando di essere all'interno di una "navicella" e guardare l'universo dal parabrezza.

Infatti, è stata progettata un'interfaccia per il controllo della velocità, della direzione e della benzina che si consuma con l'utilizzo della "navicella". &#200; possibile ricaricare questa "navicella" in prossimità del distributore di benzina.

Quando ci si avvicina ad un pineta, ci vengono date delle informazioni generali sul pianeta.

## Script
Elenco dei vari script sviluppati per la creazione del progetto.

### GameManager.cs
Script che gestisce il tempo, lo spazio, la benzina e il controllo della pagina iniziale.

#### Metodi pubblici
- void ChangeTime (float speedTime) -> Metodo per cambiare il tempo con lo slider
- void ChangeDistance (float distance) -> Metodo per cambiare la distanza con lo slider
- bool GetStart() -> Metodo che ritorna True se il gioco è iniziato altrimenti False
- void SetStart(bool startSet) -> Metodo che viene chiamato al click del tasto "START" per settare la variabile a true quando inizia il gioco
- void decreasePetrol (float decremento) -> Metodo per settare un decremento della benzina (con il decremento negativo diventa incremento)
- float getPetrol () -> Metodo che restituisce il livello della benzina

### FirstPersonController.cs
Script per il controllo in prima persona della telecamera.

### Teletrasporto.cs
Script per il controllo del teletrasporto nei vari pianeti, nel Sole e nella stazione di rifornimento.

### UI.cs
Script per il controllo delle varie componenti dell'interfaccia e della benzina.

### Spin.cs
Script per il controllo del periodo di rotazione dei pianeti, calcolato su quante ore servono per fare un giro completo.

Se il tempo è messo a 1, la rotazione è reale (es: un periodo di rotazione della Terra avviene in 24 ore reali).

### TurnAround.cs
Script per il controllo della rotazione dei pianeti attorno al Sole a seconda del semiasse maggiore e minore in unità astronomiche, oppure del semiasse maggiore e dell'eccentricità del pianeta.

Tutte le misure sono reali e se il tempo è messo a 1 la rotazione è reale (es: un giro completo della Terra attorno al Sole avviene in 1 anno reale).

### DataBase.cs
Script che contiene tutte le informazioni sui pianeti.

Le informazioni sono ordinate in una struttura dati Dictionary con il nome del pianeta come chiave e un array di informazioni come valore. Questo array ha ad ogni cella i seguenti valori:
- [0] Massa
- [1] Diametro
- [2] Gravità
- [3] Giorno solare
- [4] Inclinazione
- [5] Densità
- [6] Velocità di fuga
- [7] Temperatura

## Dati vari
Scala:
- Sole -> 218
- Mercurio -> 0,76
- Venere -> 1,9
- Terra -> 2
- Marte -> 1,06
- Giove -> 22,42
- Saturno -> 18,90
- Urano -> 8
- Nettuno -> 7,76

Inclinazione asse x:
- Sole -> 7,25°
- Mercurio -> 0°
- Venere -> 177°
- Terra -> 23°
- Marte -> 25°
- Giove -> 3°
- Saturno -> 26°
- Urano -> 97°
- Nettuno -> 28°

Rotazione attorno al proprio asse (ore):
- Sole -> 24
- Mercurio -> 4222.6
- Venere -> 2802
- Terra -> 24
- Marte -> 24.7
- Giove -> 9.9
- Saturno -> 10.7
- Urano -> 17.2
- Nettuno -> 16.1

Rivoluzione (UA - Eccentricità orbitale - anni):
- Mercurio -> 0.38 - 0.2056 - 0.24
- Venere -> 0.723 - 0.00678 - 0.615
- Terra -> 1 - 0.01671 - 1
- Marte -> 1.524 - 0.09339 - 1.88
- Giove -> 5.2029 - 0.0484 - 11.86
- Saturno -> 9.537 - 0.0539 - 29.447
- Urano -> 19.189 - 0.04726 - 84.017
- Nettuno -> 30 - 0.00859 - 164.79

Valori del tachimetro:
- Velocità 0 -> Rotazione asse Z lancetta 95
- Velocità max -> Rotazione asse Z lancetta -265

Valori della benzina:
- Benzina 0 -> Rotazione asse Z lancetta 61
- Benzina max -> Rotazione asse Z lancetta -64)

Altri dati:
- 1 UA = 1172.864 scala Unity
- 1 anno = 3.165*10^7 secondi
- 1 scala propria = 12756 km

## Osservazioni
- Il progetto si è basato in modo più consistente sugli scipt piuttosto che sulle texture, che sono state fornite in classe o sono state ricuperate negli assest di Unity.
- A causa di un bag di Unity, che sarà risolto nella versione 5.3.6 di Unity e ad oggi (10 giugno 2016) la versione è la 5.3.4, il parametro "Plane Distance" dei canvas è stato settato a 2, causando così una sovrapposizione dei pianeti se troppo vicini, altrimenti per i pianeti molto lontani si notava un tremolio dell'interfaccia.
