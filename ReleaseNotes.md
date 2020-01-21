# Release 1.9.5.1 #
Kleine aanpassing gedaan, zodat wanneer men op Cancel drukt bij Import Date het schermpje verdwijnt. De cancel knop werkte weliswaar wel; het scherm werd echter niet weggehaald omdat er een verkeerde schermnaam vermeld stond. Dat is nu verholpen.

Verder is de grootte van het datagrid gedeelte voor het tonen van de precondities zodanig aangepast dat er geen extra regels meer te zien zijn. Het aantal benodigde regels wordt berekend aan de hand van het aantal records dat er in de datagrid geplaatst wordt.

# Release 1.9.5.2 #
Aanpassingen gedaan voor het opslaan van de naam van het testscript dat uitgevoerd is.
Tabel testruns_selenium met veld testscenario_name uitgebreid.
Tabel testresults_Selenium met veld testscenario_name uitgebreid.

Bij het selecteren van een testrun wordt nu ook de naam van het testscript getoond.

# Release 1.9.5.3 #
Het scherm van de testcases is het dataoverzicht aangepast, zodat er aan de linker kant geen extra zaken meer zichtbaar zijn. Er wordt nu meteen de 1e kolom getoond.

Het ophalen van de Page waarde uit het XML bestand is nu opgelost. De Page waarde wordt nu werkelijk opgehaald.

# Release 1.9.5.4 #
Wanneer er via de DOS-prompt de testruns hebben plaatsgevonden, worden de laatste testruns niet meer in het dropdown menu getoond. Daar is nu een Refresh button toegevoegd, zodat de laatst toegevoegde testruns ook geselecteerd kunnen worden voor het tonen van de testresultaten.

# Release 1.9.6.0 #
Bij het ophalen van de elementen van een site is het nu mogelijk om een keuze te maken uit 12 tag soorten. Hierbij kan men alle tags selecteren of deselecteren.

Wanneer een testscript uitgevoerd gaat worden, bestaat nu ook de mogelijkheid om een standaard url te hebben en via Attachment het laatste deel van de url aan toe te voegen. Hierdoor blijft het systeem zeer flexibel, waardoor er maar 1 script aangemaakt hoeft te worden dat voor meerdere scenarios gebruikt kan worden.

# Release 1.9.6.1 #
Vanaf release 1.9.6.1 is het mogelijk om de connectie met de database via een configuratie bestand aan te passen. Hierdoor wordt het mogelijk gemaakt om de data op te halen of op te slaan op de database die men geconfigureerd heeft.

# Release 1.9.6.2 #
De connectie met de database kan nu ook geconfigureerd worden.

# Release 1.9.6.3 #
Er voor gezorgd dat de elementen uit een html pagina weer in de database opgeslagen kunnen worden. In de database is het veld text op long gezet. Verder wordt er gekeken of de text te lang is. Wanneer dit het geval is, wordt het element niet opgeslagen in de database.

De optie om de elementen te voorzien van een rechthoek is weggehaald omdat dit de performance van het ophalen van de elementen vertraagd.

# Release 1.9.6.4 #
Extra optie "wait" toegevoegd, zodat er gewacht kan worden om een actie uit te kunnen voeren. Het getal dat ingevoerd wordt in de textbox wordt vervolgens vermednigvuldigd met 1.000, zodat het aantal seconden wordt genomen om te wachten.

# Release 1.9.6.5 #
Het wait gedeelte op een andere plek gezet zodat het nog sneller werkt en het wait gedeelte niet in de testresultaten verschijnt.

# Release 1.9.6.6 #
Aanpassingen gedaan aan de tabelnamen van de database vanwege de uniformiteit van de locale en net database. Alle tabelnamen staan nu in kleine letters.

# Release 1.9.6.11
De controle van de gegevens om in te loggen zijn nu op te halen uit de server. De data waarmee gewerkt wordt, kunnen uit de database gehaald worden die men handmatig kan configureren.

# Release 1.9.6.12
De tekst van de HTML elementen wordt nu goed weergegeven. Bij het uitlezen van de gegevens wordt nu gebruik gemaakt van UTF-8:

    HtmlWeb Webget = new HtmlWeb();
    HtmlDocument doc = new HtmlDocument();
    Webget.AutoDetectEncoding = false;
    Webget.OverrideEncoding = Encoding.UTF8;
    doc = Webget.Load(_driver.Url);

# Release 1.9.6.13
De innertext van een HTML node dient nog de Decoded te worden. Dat is nu toegevoegd.

	HttpUtility.HtmlDecode(node.InnerText.Trim())

# Release 1.9.6.14
De datagridview die gebruikt wordt bij het aanmaken van de testcases kan nu gesorteerd worden op iedere kolom.

# Release 1.9.6.18
Het onderscheid tussen inloggen en toegang en de data weer weggehaald. Alles kan nu in 1 database.

	DROP TABLE IF EXISTS `medewerkers`;
	/*!40101 SET @saved_cs_client     = @@character_set_client */;
	/*!40101 SET character_set_client = utf8 */;
	CREATE TABLE `medewerkers` (
	  `Medewerkerscode` varchar(3) NOT NULL DEFAULT '',
	  `Medewerker` varchar(30) DEFAULT NULL,
	  `Password` varchar(255) DEFAULT NULL,
	  `ingelogd` tinyint(1) NOT NULL DEFAULT '0',
	  `Rol` int(11) DEFAULT NULL,
	  `Actief` tinyint(1) NOT NULL DEFAULT '1',
	  `datum_aangemaakt` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
	  `datum_gewijzigd` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
	  `blokked` tinyint(4) NOT NULL DEFAULT '0',
	  `datum_geldigheid` date DEFAULT NULL,
	  PRIMARY KEY (`Medewerkerscode`),
	  KEY `Medewerkerscode` (`Medewerkerscode`)
	) ENGINE=InnoDB DEFAULT CHARSET=utf8;
	/*!40101 SET character_set_client = @saved_cs_client */;

	DROP TABLE IF EXISTS `serials`;
	/*!40101 SET @saved_cs_client     = @@character_set_client */;
	/*!40101 SET character_set_client = utf8 */;
	CREATE TABLE `serials` (
	  `ID` int(11) NOT NULL AUTO_INCREMENT,
	  `SerialKey` varchar(128) CHARACTER SET utf8 NOT NULL,
	  `Name` varchar(128) CHARACTER SET utf8 DEFAULT NULL,
	  `BeginDate` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
	  `EndDate` date DEFAULT NULL,
	  `MachineNumber` varchar(45) CHARACTER SET utf8 DEFAULT '',
	  `UpdateDate` datetime DEFAULT NULL,
	  PRIMARY KEY (`ID`)
	) ENGINE=MyISAM AUTO_INCREMENT=1001 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
	/*!40101 SET character_set_client = @saved_cs_client */;

	(506,'abd7d99ed3a90c33ab528cb7939905993d55446c626106047c70c5744009d3b1e5038664908670e6cb983b091ae2616101d8893d9a0d53eb111395edd189c83e','Brain Engel','2019-05-12 13:36:44','2025-12-31','','2025-11-30 14:48:24')

# Release 1.9.6.18
Wanneer de elementen zijn opgehaald kan men deze sorteren met het gevolg dat wanneer men de gegevens in een testscript plaatst ook daar de sortering plaats vindt. Nu is het zodanig aangepast dat er weer op id gesorteerd wordt.

# Release 1.9.6.23
Mogelijheid ingebouwd om variabelen op te slaan en voor een volgende stap in het testproces te kunnen gebruiken. 
De volgende actiewoorden zijn toegevoegd aan de actiewoordenlijst: set_value voor het opslaan van de waarde en 
get_value voor het ophalen van de waarde.
Tevens is de mogelijkheid toegevoegd om bij gebruik van iframe ook daar waardes in te kunnen vullen.

# Release 1.9.7.03
De sorteervolgorde op de index gezet bij het toevoegen van de geselecteerde elementen bij het lezen van een pagina.

# Release 1.9.7.4
Wanneer als action 'checkbox' gekozen wordt en er is nog geen waarde ingevuld, dan wordt de waarde 'false' ingevuld.

# Release 1.9.7.5
Nieuw actie toegevoegd: scroll.
Hiermee kan men naar de bovenkant en onderkant van de pagina gaan. Tevens kan men ook de opties down en up kiezen, die 1000 pixels naar beneden of naar boven gaan.

# Release 1.9.7.7
- Bij het ophalen van de elementen van een site, wanneer er ingelogd dient te worden, wordt nu in de plaats van de _driver.Url, de _driver.PageSource gebruikt.
- De layout van de elementen pagina aangepast voor kleinere schermen
- De layout van de test executie aangepast voor kleinere schermen
- Aanpassing gedaan om de login knop zowel bij het gebruik van een id alsook bij gebruik van name te laten werken.
- Selected Record nummering aangepast, zodanig dat het nummer getoond wordt en wijzigd wanneer er een rij de focus heeft.

	 		private void AddDataGrid_GotFocus(object sender, RoutedEventArgs e)
			{
				intRow = AddDataGrid.Items.IndexOf(AddDataGrid.CurrentItem);

				LabelTestRecord.Content = intRow + 1;
			}

- Wanneer een inlog procedure gesaved is, wordt de dropdown optie opnieuw gevuld met data in het ElementGetSet scherm

# Release 1.9.7.8
- Er voor gezorgd dat het login gedeelte op de SCHMEITSNAS.SYNOLOGY.ME server plaatsvindt en alle andere data kan van een andere server gehaald worden. De aanroep van de database voor het verwerken van de data kan geconfigureerd worden.

# Release 1.9.7.9
- Aanpassingen gedaan om er voor te zorgen dat de data voor het inloggen bij de toepassingen vanaf de geconfigureerde server kan verlopen
- Anapassingen gedaan om naar een login pagina te gaan, wanneer dat nodig mocht zijn 
- Aanpassingen gedaan om, voordat men de elementen gaat ophalen, nog een actie uit te voeren.

# Release 1.9.7.10
- Er kunnen nu regelnummer toegevoegd worden in het testcase gedeelte
- Gebruiker kan nu bij de elementen aangegeven of de tekst gecontroleer dient te worden.
- Mogelijk gemaakt om makkelijker van connectiestring te wijzigen. 

# Release 2.0.0.0
Het inlog gedeelte bij het opstarten is er niet meer. In de App.xaml staat nu niet meer StartupUri="Login.xaml". Dat is aangepast in StartupUri="MainWindow.xaml"

# Release 2.0.1.0
Het binnen halen van de data vanuit een site wordt nu makkelijker gemaakt. De knoppen die geklikt moeten worden kunnen nu worden opgeslagen. Ook worden deze knoppen meegegeven wanneer men het inloggen wil meenemen in het testscenario.

# Release 2.0.2.0
De volgorde bij het inloggen kan aangepast worden.

# Release 2.0.3.0
Bij de elementen kunnen alle teksten aan of uit gezet worden om te controleren op text.

# Release 2.0.3.1
Bij de elementen ervoor gezorgd dat de waarden van een input veld ook getoond worden.

# Release 2.0.4.0
Bij het ophalen van de elementen zijn nu vele mogelijkheden ingebouwd om naar de juiste pagina te gaan, inclusief het drukken van knoppen, selecteren van waarden etc.

# Release 2.0.4.5
Query voor het inserten van een login optie aangepast:

    var queryU = "INSERT INTO `autotest`.`login_code` " + "(`login_url`, " + "`login_attribute_username`, ";
    queryU += "`login_attribute_password`, " + "`login_attribute_button`, " + "`login_tagname_user`, ";
    queryU += "`login_tagname_password`, " + "`login_tagname_button`, " + "`login_user_value`, ";
    queryU += "`login_attribute_extra1`, `login_attribute_extra2`, `login_attribute_extra3`, ";
    queryU += " `login_tagname_extra1`, `login_tagname_extra2`, `login_tagname_extra3`,";
    queryU += "`login_description_extra1`, `login_description_extra2`, `login_description_extra3`, ";
    queryU += "`login_password_value`, ";
    queryU += "`login_action1`, `login_action2`, `login_action3`, `login_action4`, `login_action5`, `login_action6`, ";
    queryU += "`login_order1`, `login_order2`, `login_order3`, `login_order4`, `login_order5`, `login_order6`) ";
    queryU += " VALUES ('";
    queryU += MySqlHelper.EscapeString(TextBoxURLSave.Text) + "', " + "'";
    queryU += MySqlHelper.EscapeString(UserAttribute.Text) + "', " + "'";
    queryU += MySqlHelper.EscapeString(PasswordAtrribute.Text) + "', " + "'";
    queryU += MySqlHelper.EscapeString(ButtonAttribute.Text) + "', " + "'";
    queryU += MySqlHelper.EscapeString(UserTag.Text) + "', " + "'";
    queryU += MySqlHelper.EscapeString(PasswordTag.Text) + "', " + "'";
    queryU += MySqlHelper.EscapeString(ButtonTag.Text) + "', " + "'";
    queryU += MySqlHelper.EscapeString(UserText.Text) + "', " + "'";
    queryU += MySqlHelper.EscapeString(ButtonAttributeExtra1.Text) + "', " + "'";
    queryU += MySqlHelper.EscapeString(ButtonAttributeExtra2.Text) + "', " + "'";
    queryU += MySqlHelper.EscapeString(ButtonAttributeExtra3.Text) + "', " + "'";
    queryU += MySqlHelper.EscapeString(ButtonTagnameExtra1.Text) + "', " + "'";
    queryU += MySqlHelper.EscapeString(ButtonTagnameExtra2.Text) + "', " + "'";
    queryU += MySqlHelper.EscapeString(ButtonTagnameExtra3.Text) + "', " + "'";
    queryU += MySqlHelper.EscapeString(DescriptionExtra1.Text) + "', " + "'";
    queryU += MySqlHelper.EscapeString(DescriptionExtra2.Text) + "', " + "'";
    queryU += MySqlHelper.EscapeString(DescriptionExtra3.Text) + "', " + "'";
    queryU += MySqlHelper.EscapeString(PasswordText.Password) + "', '";
    queryU += MySqlHelper.EscapeString(ComboBoxAction1.Text) + "', '";
    queryU += MySqlHelper.EscapeString(ComboBoxAction2.Text) + "', '";
    queryU += MySqlHelper.EscapeString(ComboBoxAction3.Text) + "', '";
    queryU += MySqlHelper.EscapeString(ComboBoxAction4.Text) + "', '";
    queryU += MySqlHelper.EscapeString(ComboBoxAction5.Text) + "', '";
    queryU += MySqlHelper.EscapeString(ComboBoxAction6.Text) + "', '";
    queryU += MySqlHelper.EscapeString(Order1.Text) + "', '";
    queryU += MySqlHelper.EscapeString(Order2.Text) + "', '";
    queryU += MySqlHelper.EscapeString(Order3.Text) + "', '";
    queryU += MySqlHelper.EscapeString(Order4.Text) + "', '";
    queryU += MySqlHelper.EscapeString(Order5.Text) + "', '";
    queryU += MySqlHelper.EscapeString(Order6.Text) + "');";

De velden die beschikbaar zijn voor het inloggen niet meer zichtbaar gemaakt wanneer er geen gebruik gemaakt wordt van het inloggen.

# Release 2.0.4.6
Aanpassingen gedaan om eerst in te loggen en dan naar de juiste pagina te gaan bij het ophalen van de elementen.

# Release 2.0.4.7
Voor het selecteren van de tekst bij de gevonden elementen zijn de volgende extra regels toegevoegd. Nu worden de checkboxen voor het controleren van de tekst niet meer leeggemaakt wanneer er op check all geklikt wordt. 

	if (kolom.DisplayIndex == 8 || kolom.DisplayIndex == 1)
	{
	    var isChecked = cellContent1.IsChecked;
	    var flag = true;
	    var check1 = "checktext";
	    if (kolom.DisplayIndex == 1)
	    {
	        check1 = " selenium_check";
	    }
	    var wel = !((isChecked.GetValueOrDefault() == flag) & isChecked.HasValue);
	    ElementsFromDatabase.UpdateAllCheckbox8(cellContent.Text, wel, check1);
	}
DataGridElements_CurrentCellChanged in ElementsGetSet.xaml.cs regel 2094.

# Release 2.0.4.8
Elementen zoeken aangepast zodat er geen foutmeldingen meer komen voor het zoeken naar de waarden van een input veld
Switch naar andere url ingebouwd
Verplicht van het vullen van de element naam wanneer dat niet nodig is.

# Release 2.0.4.9
Geen error melding meer wanneer een element of een attribute leeggelaten worden.
Het element mag alleen maar leeggelaten worden wanneer er bepaalde acties uitgevoerd worden. Deze zijn

- click
- sendkeys
- select
- value
- checkbox
- move_to
- scroll

# Release 2.0.4.10
- De datagrid met de test resultaten aangepast om meer gegevens te tonen.
- Het machinenummer toegevoegd aan teststappen.
- Verwerking van de elementen rechtstreeks via de database laten doen, waardoor het veel sneller is.
- Wanneer er naar een andere url gesprongen dient te worden wordt automatisch de juiste stap uitgevoerd.
- Het verwerken van het al of niet selecteren van een element om te controleren of tekst volledig gerefactored. 

# Release 2.0.5.5
- Naar andere pagina kunnen gaan bij het ophalen van de elementen.

# Release 2.0.5.6
- Bij het aanpassen van de Test Scripts kan nu een testnr. geselecteerd worden, 
  zodat de gegevens van het geselecteerde testnr getoond worden.

# Release 2.0.5.7
- Login gedeelte voor het zoeken naar elementen aangepast zodat er ook om naam gezocht en opgeslagen kan worden.
- Wanneer de URL aangepast wordt, dan wordt nu de TextBoxURLSave tekst niet meer aangepast.

# Release 2.0.5.8
- Indien testscenario niet bestaan in directory, dan wordt het aangemaakt wanneer het in de database staat.

# Release 2.0.5.9
- Etra buttons alleen toevoegen wanneer inclusief Login Included geselecteerd is.

# Release 2.0.5.10
- Juiste pagians bij het laden van de elementen.

# Release 2.0.5.11
- Extra opties niet in scenario zetten als order = "0".

# Release 2.0.5.12
- Extra opties niet in scenario zetten als order = "".

# Release 2.0.5.13
- Test resultaten aangevuld met de testscenario naam.

# Release 2.0.5.14
- Na scripts run worden de totaal data opgeslagen in de tabel testscriptstotal, inclusief testscript id en name.
- De geselecteerde test scripts worden nu op de juiste manier in de tabel testscript_detail geplaatst.

# Release 2.0.5.15
- Individuele selectie van de elementen voor zowel de selectie alsook voor de controle van de tekst aangepast.

# Release 2.0.5.16
- Wanneer de elementen vanuit de database worden geladen, kan men deze nu ook in een test script zetten.

# Release 2.0.5.17
- Add to test steps wordt nu actief of niet bij het selecteren van een element.

# Release 2.0.5.18
- Save testresults even if there is no Load Scripts selected

# Release 2.0.5.19
- Geen gegevens meer opslaan wanneer er geen bestandsnaam aanwezig is.