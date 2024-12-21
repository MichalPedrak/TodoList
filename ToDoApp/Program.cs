// WyswietlListe(List<string> lista, List<bool> statusy)
// Wyświetla listę wszystkich zadań wraz z ich statusami ("Wykonane" lub "Niewykonane"). Jeśli lista jest pusta, wyświetla komunikat.
//
//     DodajZadanie(List<string> lista, List<bool> statusy, string opis)
// Dodaje nowe zadanie do listy z domyślnym statusem "Niewykonane".
//
//     UsunZadanie(List<string> lista, List<bool> statusy, int indeks)
// Usuwa zadanie z listy na podstawie podanego numeru.
//
//     OznaczJakoWykonane(List<bool> statusy, int indeks)
// Oznacza zadanie jako "Wykonane".
//
//     WyswietlMenu()
// Wyświetla menu użytkownika.


class Program
{
    
    static void WyswietlMenu()
    {
        Console.WriteLine("\n\n");
        Console.WriteLine("Menu:");
        Console.WriteLine("1. Wyświetl listę zadań");
        Console.WriteLine("2. Dodaj zadanie");
        Console.WriteLine("3. Usuń zadanie");
        Console.WriteLine("4. Oznacz zadanie jako wykonane");
        Console.WriteLine("5. Zakończ program");
    }

    static void Main()
    {

        bool programDziala = true;
        
        List<string> lista = new List<string>();
        List<bool> statusy = new List<bool>();
        
        while (programDziala)
        {

            Program.WyswietlMenu();

            Console.Write("Wybierz jedna z dostepnych opcji: ");

            string opcja = Console.ReadLine();


            string input;
            switch (opcja)
            {
                case "1":
                    Console.WriteLine("Wybrales wyswietl liste");

                    WyswietlListe(lista, statusy);
                    break;
                case "2":
                    // Console.WriteLine("Wybrales dodaj zadanie");
                    
                    Console.Write("Podaj opis zadania: ");
                    string opis = Console.ReadLine();
                    DodajZadanie(lista, statusy, opis);
       
                    break;
                case "3":

                    Console.Write("Podaj numer zadania do usunięcia: ");
                    input = Console.ReadLine();
                    
                    if (int.TryParse(input, out int index))
                    {
                        UsunZadanie(lista, statusy, index - 1);
                    }
                    else
                    {
                        Console.WriteLine("Niepoprawny numer.");
                    }
                    
                    break;
                case "4":

                    Console.Write("Podaj numer zadania do oznaczenia jako wykonane: ");
                    
                    input = Console.ReadLine();
                    
                    // sprawdza czy input to int, czyli ktos wpisal numer zadania i zwraca wynik tego int jako zmienna indeks
                    if (int.TryParse(input, out int indeks) && indeks >= 0 && indeks <= lista.Count)
                    {
                        OznaczJakoWykonane(statusy, indeks - 1);
                    }
                    else
                    {
                        Console.WriteLine("Niepoprawny numer.");
                    }
                 
                    break;
                case "5":
                    Console.WriteLine("Do zobaczenia!");
                    programDziala = false;
                    break;

                default:
                    Console.WriteLine("Zly numer akcji, sprobuj ponownie");
                    break;
            }



        }

    }

    static void WyswietlListe(List<string> lista, List<bool> statusy)
    {
       
        Console.WriteLine("Lista zadan:");
        
        if (lista.Count == 0)
        {
            Console.WriteLine("Brak zadań na liście.");
        }
        else
        {
            for (int i = 0; i < lista.Count; i++)
            {
                string status = statusy[i] ? "[Wykonane]" : "[Niewykonane]";
                Console.WriteLine($"{i + 1}. {lista[i]} {status}");
                
            }
        }
    }
    

    static void DodajZadanie(List<string> lista, List<bool> statusy, string opis)
    {

        lista.Add(opis);
        statusy.Add(false);
        Console.WriteLine("Zadanie zostało dodane!");
    }
    
    static void UsunZadanie(List<string> lista, List<bool> statusy, int indeks)
    {
    
        lista.RemoveAt(indeks);
        statusy.RemoveAt(indeks);
        Console.WriteLine("Zadanie zostało usunięte.");

    }

    static void OznaczJakoWykonane(List<bool> statusy, int indeks)
    {
        if (indeks >= 0 && indeks < statusy.Count)
        {
            statusy[indeks] = true;
            Console.WriteLine("Zadanie zostało oznaczone jako wykonane.");
        }
        else
        {
            Console.WriteLine("Niepoprawny numer zadania.");
        }
    }

}