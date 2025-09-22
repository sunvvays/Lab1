using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    /// <summary>
    /// Консольное приложение: меню для вызова методов репозитория фильмов.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Точка входа консольного приложения.
        /// </summary>
        public static void Main()
        {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;
            var repo = new FilmRepository();
            bool running = true;

            while (running)
            {
                Console.WriteLine();
                Console.WriteLine("Меню:");
                Console.WriteLine("1. Добавить фильм");
                Console.WriteLine("2. Показать все фильмы");
                Console.WriteLine("3. Обновить фильм");
                Console.WriteLine("4. Удалить фильм");
                Console.WriteLine("5. Группировать по жанрам");
                Console.WriteLine("6. Поиск по году");
                Console.WriteLine("7. Выход");
                Console.Write("Выбор (1-7): ");

                string? choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Название: ");
                        var title = Console.ReadLine() ?? "";
                        Console.Write("Жанр: ");
                        var genre = Console.ReadLine() ?? "";
                        Console.Write("Год: ");
                        if (!int.TryParse(Console.ReadLine(), out var year))
                        {
                            Console.WriteLine("Ошибка: год должен быть целым числом.");
                            break;
                        }
                        try
                        {
                            repo.AddFilm(title, genre, year);
                            Console.WriteLine("Фильм добавлен.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Ошибка: " + ex.Message);
                        }
                        break;

                    case "2":
                        var films = repo.GetAllFilms();
                        if (films.Count == 0) { Console.WriteLine("Список пуст."); break; }
                        foreach (var f in films)
                            Console.WriteLine($"{f.Id}. {f.Title} ({f.Year}) — {f.Genre}");
                        break;

                    case "3":
                        Console.Write("Id фильма: ");
                        if (!int.TryParse(Console.ReadLine(), out var updId))
                        {
                            Console.WriteLine("Ошибка: Id должен быть числом.");
                            break;
                        }
                        Console.Write("Новое название: ");
                        var newTitle = Console.ReadLine() ?? "";
                        Console.Write("Новый жанр: ");
                        var newGenre = Console.ReadLine() ?? "";
                        Console.Write("Новый год: ");
                        if (!int.TryParse(Console.ReadLine(), out var newYear))
                        {
                            Console.WriteLine("Ошибка: год должен быть числом.");
                            break;
                        }
                        try
                        {
                            repo.UpdateFilm(updId, newTitle, newGenre, newYear);
                            Console.WriteLine("Фильм обновлён.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Ошибка: " + ex.Message);
                        }
                        break;

                    case "4":
                        Console.Write("Id фильма для удаления: ");
                        if (!int.TryParse(Console.ReadLine(), out var delId))
                        {
                            Console.WriteLine("Ошибка: Id должен быть числом.");
                            break;
                        }
                        Console.WriteLine(repo.DeleteFilm(delId) ? "Удалён." : "Фильм не найден.");
                        break;

                    case "5":
                        var groups = repo.GroupByGenre();
                        if (groups.Count == 0) { Console.WriteLine("Список пуст."); break; }
                        foreach (var kv in groups)
                        {
                            Console.WriteLine($"Жанр: {kv.Key} (шт: {kv.Value.Count})");
                            foreach (var f in kv.Value)
                                Console.WriteLine($"   {f.Id}. {f.Title} ({f.Year})");
                        }
                        break;

                    case "6":
                        Console.Write("Год для поиска: ");
                        if (!int.TryParse(Console.ReadLine(), out var y))
                        {
                            Console.WriteLine("Ошибка: год должен быть числом.");
                            break;
                        }
                        var found = repo.SearchByYear(y);
                        if (found.Count == 0) Console.WriteLine("Ничего не найдено.");
                        else foreach (var f in found) Console.WriteLine($"{f.Id}. {f.Title} — {f.Genre}");
                        break;

                    case "7":
                        running = false;
                        Console.WriteLine("Выход...");
                        break;

                    default:
                        Console.WriteLine("Неверный выбор. Введите 1-7.");
                        break;
                }
            }
        }
    }
}