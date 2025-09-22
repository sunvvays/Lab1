using System;

namespace Domain
{
    /// <summary>
    /// Модель фильма: уникальный Id, название, жанр и год выпуска.
    /// </summary>
    public class Film
    {
        /// <summary>
        /// Уникальный идентификатор фильма внутри приложения.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название фильма.
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Жанр фильма (например, драма, комедия).
        /// </summary>
        public string Genre { get; set; } = string.Empty;

        /// <summary>
        /// Год выпуска фильма (целое число).
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// Удобное строковое представление фильма для списков/логов.
        /// </summary>
        public override string ToString() => $"{Title} ({Year}) — {Genre}";
    }
}