# Zadanie podsumowujące dzień 1

## System szkoleniowy

## Część 1

Należy utworzyć klasę, która reprezentuje dziedzinę pojedynczego szkolenia i to co w ramach systemu można z nim zrobić. (nazwa klasy może być np. Training)

Szkolenie ma następujące właściwości:

- Id - unikalny identyfikator
- Name - nazwa szkolenia
- Participants - lista uczestników

Uczestnik reprezentowany jest przez klasę Participant, która ma następujące właściwości:

- Id - unikalny identyfikator uczestnika
- FirstName - imię
- Lastname - nazwisko
- Email - adres email
- Score - ocena z egzaminu końcowego

Dla każdego szkolenia można wykonać następujące czynności:

- Dodać uczestnika do listy
- Zdefiniować ocenę dla uczestnika
- Uzyskać średnią ze wszystkich ocen
- Uzyskać określoną liczbę najlepszych uczestników na podstawie oceny
- Uzyskać kalkulację kosztów szkolenia

### Szczegóły techniczne

- Klasa powinna zapewnić, że na liście uczestników nie będzie duplikatów
  - Uczestnik identyfikowany jest przez unikalny identyfikator (Id)
- Ocenę można wystawić tylko dla istniejącego uczestnika
  - Jeżeli uczestnik nie istnieje metoda powinna rzucić wyjątek
- Metoda zwracająca listę najlepszych uczestników jako parametr powinna przyjąć liczbę. która ograniczy listę zwróconych danych
- Kalkulacja szkolenia liczona jest poprzez dodanie do siebie wartości
  - Koszt trenera: 1000 PLN
  - Koszt cateringu: 50.50 PLN dla uczestnika
  - Koszt przygotowania i wynajęcia pokoju: 2000 PLN

Na końcu należy napisać testy sprawdzające czy powyższe metody działają poprawnie (min. 1 test na metodę)

## Część 2

Klasa dla szkolenia powinna implementować interfejs ISearchable, który oznacza, że klasa reprezentuje dane możliwe do wyszukania w wyszukiwarce.

Interfejs ISearchable deklaruje poniższe metody jakie musi posiadać klasa implementująca ten interfejs:

- void AddTag(string tag): Umożliwia dodanie tagu do powiązanego obiektu. Obiekt musi w jakiś sposób przechowywać dodane wartości.
- List<string> MatchesToTags(string[] searchTags): Funkcja, która umożliwia uzyskać listę tagów, które są przypisane do obiektu i pasują do zapytania. Funkcja powinna zapewnić, że na liście tagów nie będzie duplikatów.

  Przykład:

  - Szkolenie ma zdefiniowane tagi “programowanie”, “dotnet”
  - Funkcja jest wywołana z parametrem searchTags, który zawiera tagi “obiektowy”, “programowanie”
  - jako rezultat funkcja zwraca listę z elementem “programowanie”

Na końcu należy napisać testy sprawdzające czy powyższe metody działają poprawnie (min. 1 test na metodę)

## Część 3

Nowe wymaganie mówi, że szkolenie może być offline lub online. Dlatego należy utworzyć dwie klasy CourseOffline oraz CourseOnline.

Obie klasy muszą dziedziczyć po klasie Training.

Zmienia się też sposób kalkulacji kosztów

- Dla kursu offline wyliczenie jest takie same jak w klasie Trainigng
- Dla kursu online wyliczenie jest następujące
  - Koszt trenera: 2000 PLN
  - Koszt oprogramowania do wideokonferencji: 200.80 PLN per uczestnik
  - Jeżeli liczba uczestników jest większa niż 10 należy naliczyć rabat 10% od kosztów infrastruktury

Na końcu należy napisać testy sprawdzające czy powyższe metody działają poprawnie (min. 1 test na metodę)
