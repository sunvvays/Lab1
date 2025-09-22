using System;
using System.Collections.Generic;

namespace Domain
{
    /// <summary>
    /// Хранилище и бизнес-логика для работы со списком фильмов.
    /// Содержит CRUD и бизнес-функции (группировка по жанрам, поиск по году).
    /// </summary>
    public class FilmRepository
    {
        private readonly List<Film> _films = new();
        private int _nextId = 1;

        /// <summary>
        /// Создаёт новый фильм и добавляет в коллекцию.
        /// </summary>
        /// <param name="title">Название фильма. Не может быть пустым.</param>
        /// <param name="genre">Жанр фильма (может быть пустым).</param>
        /// <param name="year">Год выпуска.</param>
        /// <exception cref="ArgumentException">Если <paramref name="title"/> пустое.</exception>
        public void AddFilm(string title, string genre, int year)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Название фильма не может быть пустым.", nameof(title));

            var film = new Film
            {
                Id = _nextId++,
                Title = title.Trim(),
                Genre = string.IsNullOrWhiteSpace(genre) ? string.Empty : genre.Trim(),
                Year = year
            };

            _films.Add(film);
        }

        /// <summary>
        /// Возвращает копию списка всех фильмов.
        /// </summary>
        public List<Film> GetAllFilms() => new(_films);

        /// <summary>
        /// Обновляет данные фильма по Id.
        /// </summary>
        /// <param name="id">Идентификатор существующего фильма.</param>
        /// <param name="newTitle">Новое название (обязательно).</param>
        /// <param name="newGenre">Новый жанр.</param>
        /// <param name="newYear">Новый год.</param>
        /// <exception cref="ArgumentException">Пустое название.</exception>
        /// <exception cref="InvalidOperationException">Фильм с таким Id не найден.</exception>
        public void UpdateFilm(int id, string newTitle, string newGenre, int newYear)
        {
            if (string.IsNullOrWhiteSpace(newTitle))
                throw new ArgumentException("Название фильма не может быть пустым.", nameof(newTitle));

            var film = _films.Find(f => f.Id == id)
                       ?? throw new InvalidOperationException("Фильм с указанным Id не найден.");

            film.Title = newTitle.Trim();
            film.Genre = string.IsNullOrWhiteSpace(newGenre) ? string.Empty : newGenre.Trim();
            film.Year = newYear;
        }

        /// <summary>
        /// Удаляет фильм по Id.
        /// </summary>
        /// <param name="id">Идентификатор фильма.</param>
        /// <returns>true, если удалён; false, если не найден.</returns>
        public bool DeleteFilm(int id)
        {
            var film = _films.Find(f => f.Id == id);
            if (film == null) return false;
            _films.Remove(film);
            return true;
        }

        /// <summary>
        /// Группирует фильмы по жанрам.
        /// Пустой жанр складывается в группу "Не указано".
        /// </summary>
        /// <returns>Словарь: жанр → список фильмов.</returns>
        public Dictionary<string, List<Film>> GroupByGenre()
        {
            var map = new Dictionary<string, List<Film>>(StringComparer.OrdinalIgnoreCase);
            foreach (var film in _films)
            {
                var key = string.IsNullOrWhiteSpace(film.Genre) ? "Не указано" : film.Genre;
                if (!map.TryGetValue(key, out var list))
                {
                    list = new List<Film>();
                    map[key] = list;
                }
                list.Add(film);
            }
            return map;
        }

        /// <summary>
        /// Ищет фильмы по точному году выпуска.
        /// </summary>
        /// <param name="year">Год для поиска.</param>
        /// <returns>Список найденных фильмов (может быть пустым).</returns>
        public List<Film> SearchByYear(int year) => _films.FindAll(f => f.Year == year);
    }
}