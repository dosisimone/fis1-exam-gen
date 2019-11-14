# Fisica1 exam generator

Questo progetto è un semplice generatore di esami di Fisica T1 del corso del prof. D. Galli (Università di Bologna).

Il programma una volta modifica il sorgente inserendo il numero corretto di liste e il numero degli esercizi che formano ogni lista procederà a generare un esame.

L'esame generato dal programma estrarrà da ogni lista di quesiti/esercizi un quesito/esercizio.

Se a tempo di esecuzione il programma troverà nella sua directory il file "storico_estrazioni_f1.txt", allora, farà in modo di estrarre dalle liste quesiti ed esercizi con una media di estrazioni minore o uguale alla media di estrazioni degli esercizi/quesiti della lista di riferimento.

Il formato del file "storico_estrazioni_f1.txt" è il seguente:
```
numero_quesito_1 | numero_estrazioni_quesito_1 ,
...
numero_quesito_n | numero_estrazioni_quesito_n 
-
numero_esercizio_1 | numero_estrazioni_esercizio_1 ,
...
numero_esercizio_n | numero_estrazioni_esercizio_n 
```
Attualmente il programma non scrive le estrazioni effettuate sul file, è necessario quindi che l'utente provveda ad appuntarsi sul file le estrazioni sul file e riavviare il programma per generare esercitazioni che tengano conto delle estrazioni precedenti.

Questo programma è stato creato solamente per esercitarsi e non assicura la promozione all'esame.
