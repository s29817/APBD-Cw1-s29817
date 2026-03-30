# Equipment Rental System

Prosty system konsolowy do zarządzania wypożyczaniem sprzętu na uczelni.
Projekt został wykonany w C# jako część ćwiczeń z przedmiotu APBD.

#### System pozwala na:
* dodawanie użytkowników
* dodawanie sprzętu
* wypożyczanie sprzętu
* zwracanie sprzętu
* sprawdzanie aktywnych i przeterminowanych wypożyczeń
* naliczanie kar za spóźniony zwrot

### Struktura projektu

Projekt został podzielony na kilka katalogów, aby oddzielić różne odpowiedzialności:

1. **Enums:**
Zawiera typy wyliczeniowe używane w projekcie, np. typ użytkownika lub sprzętu.

2. **Models:**
Zawiera klasy reprezentujące główne elementy systemu, np.:

* użytkowników
* sprzęt
* wypożyczenia

3. **Services:**
Tutaj znajduje się logika systemu, np. obsługa wypożyczeń lub zarządzanie użytkownikami.

4. **Exceptions:**
Zawiera własne wyjątki używane w sytuacjach błędnych (np. próba wypożyczenia niedostępnego sprzętu).

5. **Program.cs:** Zawiera prostą część demonstracyjną pokazującą działanie systemu.

### Decyzje projektowe

#### Kohezja, coupling i elementy SOLID:

Podczas pisania projektu starałem się podzielić kod tak, żeby każda klasa miała sensowną odpowiedzialność.
Klasy z folderu Models przechowują głównie dane (np. użytkownik, sprzęt, wypożyczenie), natomiast w Services znajduje się logika operacji, takich jak wypożyczanie lub zwracanie sprzętu.

Dzięki temu klasy nie są zlepkiem różnych metod i łatwiej zrozumieć, za co odpowiada każda część systemu (kohezja).

Starałem się też ograniczyć zależności między klasami (coupling), tak żeby zmiana jednej części kodu nie wymagała modyfikacji wielu innych miejsc.

W projekcie można też zauważyć podstawowe elementy zasad SOLID, głównie podział odpowiedzialności między klasy oraz korzystanie z interfejsów w niektórych miejscach.

_AUTOR: s29817_