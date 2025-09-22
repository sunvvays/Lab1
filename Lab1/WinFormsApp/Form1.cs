using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Domain;

namespace WinFormsApp
{
    /// <summary>
    /// Главная форма WinForms-приложения для управления фильмами.
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// Репозиторий фильмов (общая логика Domain).
        /// </summary>
        private readonly FilmRepository _repo = new();

        public Form1()
        {
            InitializeComponent();
            RefreshFilmList();
        }

        /// <summary>
        /// Перечитывает фильмы из репозитория и показывает их в ListBox.
        /// </summary>
        private void RefreshFilmList()
        {
            listBoxFilms.Items.Clear();
            foreach (var film in _repo.GetAllFilms())
                listBoxFilms.Items.Add(film);
        }

        private void listBoxFilms_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (listBoxFilms.SelectedItem is Film f)
            {
                textBoxTitle.Text = f.Title;
                textBoxGenre.Text = f.Genre;
                textBoxYear.Text = f.Year.ToString();
            }
        }

        private void buttonAdd_Click(object? sender, EventArgs e)
        {
            var title = textBoxTitle.Text;
            var genre = textBoxGenre.Text;
            if (!int.TryParse(textBoxYear.Text, out var year))
            {
                MessageBox.Show("Год выпуска должен быть числом.", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                _repo.AddFilm(title, genre, year);
                MessageBox.Show("Фильм добавлен.", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshFilmList();
                textBoxTitle.Clear();
                textBoxGenre.Clear();
                textBoxYear.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonUpdate_Click(object? sender, EventArgs e)
        {
            if (listBoxFilms.SelectedItem is not Film selected)
            {
                MessageBox.Show("Сначала выберите фильм в списке.", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(textBoxYear.Text, out var newYear))
            {
                MessageBox.Show("Год выпуска должен быть числом.", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                _repo.UpdateFilm(selected.Id, textBoxTitle.Text, textBoxGenre.Text, newYear);
                MessageBox.Show("Данные фильма обновлены.", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshFilmList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonDelete_Click(object? sender, EventArgs e)
        {
            if (listBoxFilms.SelectedItem is not Film selected)
            {
                MessageBox.Show("Выберите фильм для удаления.", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_repo.DeleteFilm(selected.Id))
            {
                MessageBox.Show("Фильм удалён.", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshFilmList();
                textBoxTitle.Clear();
                textBoxGenre.Clear();
                textBoxYear.Clear();
            }
            else
            {
                MessageBox.Show("Фильм не найден.", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSearchYear_Click(object? sender, EventArgs e)
        {
            if (!int.TryParse(textBoxSearchYear.Text, out var year))
            {
                MessageBox.Show("Введите корректный год для поиска.", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<Film> found = _repo.SearchByYear(year);
            if (found.Count == 0)
            {
                MessageBox.Show("Фильмы за указанный год не найдены.", "Результат",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string msg = $"Найденные фильмы ({year}):\n";
            foreach (var f in found) msg += $"- {f.Title} ({f.Year}) — {f.Genre}\n";
            MessageBox.Show(msg, "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonGroupByGenre_Click(object? sender, EventArgs e)
        {
            var groups = _repo.GroupByGenre();
            if (groups.Count == 0)
            {
                MessageBox.Show("Список фильмов пуст.", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string msg = "Фильмы по жанрам:\n";
            foreach (var kv in groups)
            {
                msg += kv.Key + ":\n";
                foreach (var f in kv.Value)
                    msg += $"   • {f.Title} ({f.Year})\n";
            }

            MessageBox.Show(msg, "Группировка", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}