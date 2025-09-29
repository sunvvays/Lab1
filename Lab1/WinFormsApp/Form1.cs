using System;
using System.ComponentModel;          // BindingList, ListSortDirection
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Domain;

namespace WinFormsApp
{
    /// <summary>
    /// Главная форма WinForms-приложения для управления фильмами.
    /// </summary>
    public partial class Form1 : Form
    {
        private readonly FilmRepository _repo = new();

        private BindingList<Film> _films = new();
        private readonly BindingSource _bs = new();

        public Form1()
        {
            InitializeComponent();
            InitGrid();
            RefreshFilmGrid();

            // если обработчики кликов привязаны в дизайнере — оставь как есть
            dataGridViewFilms.SelectionChanged += DataGridViewFilms_SelectionChanged;
        }

        /// <summary>Настройка DataGridView и колонок.</summary>
        private void InitGrid()
        {
            dataGridViewFilms.AutoGenerateColumns = false;
            dataGridViewFilms.Columns.Clear();

            dataGridViewFilms.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(Film.Title),
                HeaderText = "Название",
                Name = "colTitle",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
            dataGridViewFilms.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(Film.Genre),
                HeaderText = "Жанр",
                Name = "colGenre",
                Width = 150
            });
            dataGridViewFilms.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(Film.Year),
                HeaderText = "Год выпуска",
                Name = "colYear",
                Width = 110
            });

            dataGridViewFilms.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewFilms.MultiSelect = false;
            dataGridViewFilms.AllowUserToAddRows = false;
            dataGridViewFilms.ReadOnly = true; // снимай, если хочешь редактировать прямо в гриде
        }

        /// <summary>Перечитать фильмы и показать в гриде.</summary>
        private void RefreshFilmGrid()
        {
            var list = _repo.GetAllFilms();              // List<Film>
            _films = new BindingList<Film>(list);
            _bs.DataSource = _films;
            dataGridViewFilms.DataSource = _bs;

            if (_films.Count > 0)
            {
                dataGridViewFilms.ClearSelection();
                dataGridViewFilms.Rows[0].Selected = true;
            }
            FillEditorsFromSelection();
        }

        private Film? SelectedFilm =>
            dataGridViewFilms.CurrentRow?.DataBoundItem as Film;

        private void DataGridViewFilms_SelectionChanged(object? sender, EventArgs e)
        {
            FillEditorsFromSelection();
        }

        private void FillEditorsFromSelection()
        {
            var f = SelectedFilm;
            if (f == null)
            {
                textBoxTitle.Clear();
                textBoxGenre.Clear();
                textBoxYear.Clear();
                return;
            }

            textBoxTitle.Text = f.Title;
            textBoxGenre.Text = f.Genre;
            textBoxYear.Text = f.Year.ToString();
        }

        private void buttonAdd_Click(object? sender, EventArgs e)
        {
            var title = textBoxTitle.Text.Trim();
            var genre = textBoxGenre.Text.Trim();

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
                RefreshFilmGrid();
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
            var selected = SelectedFilm;
            if (selected is null)
            {
                MessageBox.Show("Сначала выберите фильм в таблице.", "Внимание",
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
                _repo.UpdateFilm(selected.Id, textBoxTitle.Text.Trim(), textBoxGenre.Text.Trim(), newYear);
                MessageBox.Show("Данные фильма обновлены.", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshFilmGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonDelete_Click(object? sender, EventArgs e)
        {
            var selected = SelectedFilm;
            if (selected is null)
            {
                MessageBox.Show("Выберите фильм для удаления.", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_repo.DeleteFilm(selected.Id))
            {
                MessageBox.Show("Фильм удалён.", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshFilmGrid();
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

            // Прокрутить и выделить первую найденную запись
            int idx = _films.IndexOf(found[0]);
            if (idx < 0) // на случай если репозиторий вернул новые экземпляры
            {
                idx = _films.ToList().FindIndex(f => f.Id == found[0].Id);
            }
            if (idx >= 0)
            {
                dataGridViewFilms.ClearSelection();
                dataGridViewFilms.Rows[idx].Selected = true;
                dataGridViewFilms.FirstDisplayedScrollingRowIndex = idx;
            }
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

            // «Мини-группировка» на гриде — сортировка по жанру
            var colGenre = dataGridViewFilms.Columns["colGenre"]; // DataGridViewColumn?
            if (colGenre != null)
                dataGridViewFilms.Sort(colGenre, ListSortDirection.Ascending);
        }

        private void labelYear_Click(object? sender, EventArgs e) { }
        private void labelSearchYear_Click(object? sender, EventArgs e) { }
    }
}
