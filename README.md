#### Kohezja

Każda klasa ma jedną wyraźną odpowiedzialność. LoanService obsługuje tylko wypożyczenia i zwroty, EquipmentService zarządza wyłącznie sprzętem, a ReportService odpowiada za raportowanie.

#### Coupling

Warstwa Program.cs korzysta z interfejsów (IUserService, IEquipmentService, ILoanService, IReportService), więc logika użycia systemu nie zależy bezpośrednio od szczegółów implementacyjnych serwisów.

#### Odpowiedzialności klas
* Klasy domenowe przechowują stan i proste zachowania związane z własnym obiektem.
* Reguła naliczania kary została wydzielona do IPenaltyPolicy i PenaltyPolicy, dzięki czemu łatwo zmienić sposób liczenia bez modyfikacji LoanService.
* Limity wypożyczeń są zapisane w klasach użytkowników (Student, Employee) w jednym, czytelnym miejscu.