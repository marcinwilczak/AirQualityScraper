[PL]

Aplikacja umo�liwia pobieranie danych o stacjach pomiarowych i ich parametrach z API.
Dane te s� nast�pnie wypisywane w konsoli / zapisywane do pliku CSV w odpowiednim formacie.

Funkcjonalno�ci

- pobranie danych za pomoc� zapytania HTTP get o stacjach i parametrach
- wypisanie w odpowiednim formacie sparsowanych danych w konsoli
- zapisanie do pliku CSV odpowiednio sformatowanych
- obs�uga b��d�w komunikacji z API oraz b��d�w przy zapisie danych

Struktura

Projekt zosta� podzielony na odpowiednie foldery, w celu �atwiejszego
nawigowania, zosta�y zachowane zasady SOLID. Kod jest napisany
w spos�b rozszerzalny i mo�na bezproblemowo dodawa� do niego 
nowe funkcjonalno�ci tj. inne dzia�ania na danych pobranych
z API. 

Kod nale�y skompliowa� w �rodowisku Visual Studio Code (wersja 2022),

U�ywana wersja C# 8.0.

[ENG]

The application allows data on measuring stations and their parameters to be retrieved
from the API. This data is then output in the console / saved to a CSV file in the
appropriate format.

Features
- Fetching data using HTTP get requests for stations and parameters
- displaying parsed data in the console in the correct format
- saving data to CSV file with appropriate formatting
- handling communication errors with the API and errors during data saving

Structure

The project is structured into distinct folders for easier navigation, adhering
to SOLID principles. Code is written in an extensible manner allowing seamless addition 
of new functioalites, like performin' other operation on fetched data from API.

The code should be compiled in Visual Studio Code (version 2022)

C# Version Used: 8.0