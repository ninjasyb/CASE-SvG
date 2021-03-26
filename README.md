Het project bestaat uit een Server en een Client.

Om het project te gebruiken dient u eerst de repository te clonen naar een lokale map.
Daarna, om het project te draaien dient u de volgende stappen te doorlopen:

Server:
  1. Open het CursusOverzichtApi.SLN-bestand met Visual Studio 2019.
  2. Open SQL Server Management Studio.
    2.1.1 Kopieer de servernaam naar het klipbord en connect ermee.
    2.1.2 Klik met de rechtermuisknop op Databases, en druk op "new Database"
    2.1.3 Voer als naam "CursusInzicht" in en druk op OK
    2.1.4 Ga terug naar Visual Studio 2019
 
    2.2.1 Open Server Explorer
    2.2.2 Druk op "Connect to DB"
    2.2.3 Plak de Servernaam 
    2.2.4 Selecteer de Database "CursusInzicht"
    2.2.5 Build en run de applicatie
    
Client:
  1. Open de Folder \CASE-SvG\Frontend\CursusInzicht\CursusInzicht met Visual studio Code
  2. Open een nieuwe terminal en typ "NPM install"
  3. Als dit commanda klaar is typ "ng serve"
  4. Ga in je browser naar http://localhost:4200/
