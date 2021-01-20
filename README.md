# SONG PLAYER

Piccola applicazione fatta nel mio tempo libero per avere accesso più facile e veloce alle canzoni che mi piacciono.  

---

#### Reminder di come funziona
  
##### Canzoni online
Per le canzoni online funziona salvando un file chiamato *canzoni* nella directory `appdata/LocalLow/NikiIncFaGiochiDaSchifo/Canzoni.txt` contenente nome, artista, lunghezza e link della canzone separate da virgole. (Potrebbe essere un problema ma vabbè).  
Poi carica il file, suddivide le canzoni in base alla riga in cui sono e poi le suddivide di nuovo per ottenere i dati.  
  
##### Canzoni offline
Per le canzoni in locale usa una reference a Windows Media Player per farle partire in un thread diverso così da poterle fermare o fare ripartire a piacimento.  
Non è per niente male e di solito lo uso durante i compiti. Unica pecca è che ti apre 1000 finestre nel brower se usi la modalità online

---

#### Installazione

Fallo partire usando visual studio e troverai un *.exe* nella cartella `debug`
