

# Regex
## Narzędzia
regex101.com

## Zastosowania

- Sprawdzenie tekstu ze wzorcem
- Wyszukiwanie wzorca w tekście
- Pobieranie fragmentów tekstu
- Zamiana tekstu


## Wyszukiwanie ciągów znaków

~~~ 
lorem
~~~~

## Flagi
Flagi - dodatkowe opcje silnika RegEx, które pozwalają w pewien sposób zmieniać jego sposób działania

|   |   |
|---|---|
| Flaga g  | global   |
| Flaga m  | multi line  |
| Flaga i  | insensitive  |
| Flaga x  | extended  |
| Flaga s  | single line  |
| Flaga u  | unicode  |
| Flaga U  | ungreedy  |

## Klasy znaków

### Zbiory

- zbiór znaków
~~~
[abc]
~~~

 - wykluczenie zbioru
~~~ 
[^abc]
~~~

~~~
b[óou]b
~~~

### Zakresy

#### Cyfry
Zamiast [0123456789] możemy zapisać [0-9]


~~~
[7-9]
~~~

#### Litery
Zamiast [abcdefghijklmnoprstuwxyz] możemy zapisać [a-z]

### Białe znaki

|   |   |
|---|---|
| \  | spacja  |
| \t | tabulacja  |
| \n  | nowa linia   |
| \r  | powrót karetki |


### Skrótowe klasy znaków

|   |   |
|---|---|
| \d  | cyfry  |
| \D  | wszystko poza cyframi |
| \w  | cyfry i litery (jeśli jest włączona flaga Unicode to także znaki narodowe)  |
| \W   | wszystko poza cyframi i literami (jeśli jest włączona flaga Unicode to także znaki narodowe)  |
| \s  | białe znaki  |
| \S   | wszystko poza białymi znakami  |


### Kropka
Specjalny znak, który jest w stanie zastąpić każdy inny, poza znakiem nowej linii.

~~~
.
~~~~




## Alternatywy
~~~
Lorem|Sed
~~~

~~~
Alfa|Beta|Gamma
~~~


## Powtórzenia

Zamiast 
~~~ 
\d\d-\d\d\d 
~~~

możemy zapisać:

~~~
\d{2}-\d{3}
~~~

- Adres IP
~~~
\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}
~~~

~~~
127.0.0.1
192.168.0.1
255.255.255.245
8.8.8.8
~~~


## Grupy

### Przechwytujące

\d{4}-\d{2}-\d{2}

~~~
(\d{4})-(\d{2})-(\d{2})
~~~

- Odwoływanie się do grup
~~~
(\d{4})(-)(\d{2})\2(\d{2})
~~~

### Nie przechwytujące

~~~
(\d{2})(?:-)(\d{3})
~~~


### Nazwane

~~~ 
(?<year>\d{4})-(?<month>\d{2})
~~~

## Kotwice

### Dopasowanie początku tekstu
~~~
^Lorem
~~~

### Dopasowanie końca tekstu
~~~
est$
~~~

## Granice
Wyznaczają granice słowa
~~~
ipsum\b
~~~

