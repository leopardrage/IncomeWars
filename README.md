# IncomeWars

Income Wars è un semplice gioco di strategia multiplayer (locale) per due giocatori. Il progretto è stato sviluppato con Unity3D.

## Regole

Ogni giocatore deve proteggere la propria base e cercare allo stesso tempo di distruggere quella avversaria.
Per raggiungere lo scopo, il giocatore dovrà inviare ondate di caccia che partiranno automaticamente dalla propria base verso quella nemica.
Per inviare caccia, il giocatore di sinistra (verde) ha a disposizione i tasti **Q**, **W**, **E**, **R**, **T**. Il giocatore di destra (rosso) i tasti **Y**, **U**, **I**, **O**, **P**.
Ogni caccia attaccherà eventuali caccia nemici che avrà a portata di tiro, così come, ovviamente, la base nemica.

Inviare caccia, tuttavia, ha un costo, indicato nella corrispondente icona, che verrà sottratto dal denaro del giocatore al momento dell'acquisto.
Ogni 5 secondi, il denaro verrà incrementato del valore dell'**income** del giocatore (da qui il nome del gioco), che a sua volta potrà essere aumentato con l'acquisto di caccia.
L'HUD del gioco presenta i dati relativi ad ogni unità: costo, aumento dell'income e tasto da premere per l'acquisto.

## Note tecniche:
1. Il danno visibile sulle basi è stato realizzato con un semplice **surface shader** che visualizza progressivamente una texture di "crettatura" in base al danno subito.
2. Le icone sono state realizzate tramite **rendertexture**, ciascuna renderizzata da una telecamera dedicata. L'idea è ovviamente ottimizzabile, ma è un modo pratico per avere un'icona che si aggiorna automaticamente, qualora il prefab dei caccia cambiasse.
