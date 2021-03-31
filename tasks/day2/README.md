# Zadanie podsumowujące dzień 2

## System szkoleniowy

## Część 1

Utwórz klasę JokesService, która będzie miała metodę

- SaveNewJokesIntoFile - metoda zapisuje nowe żarty w określonym pliku
  - Paramtery wejściowe dla metody to
    - ścieżka do pliku
    - liczba żartów jakie powinny być zapisane
  - Sposób działania:
    - metoda pobiera żart z wykorzystaniem zewnętrznego API w ilości jaka została wskazana przez parametr wejściowy
    - pobrane żarty zapisywane są w pliku, którego ścieżka jest podana jako parametr wejściowy

### Szczegóły techniczne:

Adres API: https://api.chucknorris.io/

Format danych w pliku

Pierwszy wiersz to nazwy kolumn, kolejne to dane

Przykład:

```
Numer;Data utworzenia;Treść
1;[wartość z pola created_at];[wartość z pola value]
2;[wartość z pola created_at];[wartość z pola value]
```

## Część 2

Utwórz klasę BooksService, która będzie miała metodę:

- AddNewBooks
  - Parametry wejściowe:
    - ścieżka do pliku z danymi książek
  - Sposób działania:
    - metoda odczytuje dane z pliku
    - następnie dane książek wysyła do zewnętrznego API

Następnie napisz test, który wykorzysta klasę BooksService i wykona następujące czynności

- Uruchomi metodę z testowymi parametrami wejściowymi
- Zweryfikuje czy API zwraca nowo dodane dane

### Szczegóły techniczne:

Adres API: https://is-mjd-books.azurewebsites.net/books

Format danych w pliku jest w formacie JSON

Przykład:

```
[
    {
        "isbn": "0132350882ID",
        "title": "Clean Code",
        "author": "Robert C. Martin",
        "publishedAt": "2008-08-01T00:00:00"
    },
    {
        "isbn": "0134494164ID",
        "title": "Clean Architecture",
        "author": "Robert C. Martin",
        "publishedAt": "2017-09-01T00:00:00"
    }
]
```
