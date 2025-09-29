namespace WinFormsApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Очистка используемых ресурсов.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            labelFilms = new Label();
            labelTitle = new Label();
            textBoxTitle = new TextBox();
            labelGenre = new Label();
            textBoxGenre = new TextBox();
            labelYear = new Label();
            textBoxYear = new TextBox();
            buttonAdd = new Button();
            buttonUpdate = new Button();
            buttonDelete = new Button();
            labelSearchYear = new Label();
            textBoxSearchYear = new TextBox();
            buttonSearchYear = new Button();
            buttonGroupByGenre = new Button();
            dataGridViewFilms = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridViewFilms).BeginInit();
            SuspendLayout();
            // 
            // labelFilms
            // 
            labelFilms.AutoSize = true;
            labelFilms.Location = new Point(10, 10);
            labelFilms.Name = "labelFilms";
            labelFilms.Size = new Size(105, 15);
            labelFilms.TabIndex = 0;
            labelFilms.Text = "Список фильмов:";
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Location = new Point(418, 9);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(62, 15);
            labelTitle.TabIndex = 2;
            labelTitle.Text = "Название:";
            // 
            // textBoxTitle
            // 
            textBoxTitle.Location = new Point(416, 30);
            textBoxTitle.Name = "textBoxTitle";
            textBoxTitle.Size = new Size(300, 23);
            textBoxTitle.TabIndex = 3;
            // 
            // labelGenre
            // 
            labelGenre.AutoSize = true;
            labelGenre.Location = new Point(419, 62);
            labelGenre.Name = "labelGenre";
            labelGenre.Size = new Size(41, 15);
            labelGenre.TabIndex = 4;
            labelGenre.Text = "Жанр:";
            // 
            // textBoxGenre
            // 
            textBoxGenre.Location = new Point(418, 80);
            textBoxGenre.Name = "textBoxGenre";
            textBoxGenre.Size = new Size(300, 23);
            textBoxGenre.TabIndex = 5;
            // 
            // labelYear
            // 
            labelYear.AutoSize = true;
            labelYear.Location = new Point(416, 106);
            labelYear.Name = "labelYear";
            labelYear.Size = new Size(78, 15);
            labelYear.TabIndex = 6;
            labelYear.Text = "Год выпуска:";
            labelYear.Click += labelYear_Click;
            // 
            // textBoxYear
            // 
            textBoxYear.Location = new Point(416, 124);
            textBoxYear.Name = "textBoxYear";
            textBoxYear.Size = new Size(100, 23);
            textBoxYear.TabIndex = 7;
            // 
            // buttonAdd
            // 
            buttonAdd.Location = new Point(416, 170);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(85, 26);
            buttonAdd.TabIndex = 8;
            buttonAdd.Text = "Добавить";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // buttonUpdate
            // 
            buttonUpdate.Location = new Point(527, 170);
            buttonUpdate.Name = "buttonUpdate";
            buttonUpdate.Size = new Size(85, 26);
            buttonUpdate.TabIndex = 9;
            buttonUpdate.Text = "Обновить";
            buttonUpdate.UseVisualStyleBackColor = true;
            buttonUpdate.Click += buttonUpdate_Click;
            // 
            // buttonDelete
            // 
            buttonDelete.Location = new Point(633, 170);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(85, 26);
            buttonDelete.TabIndex = 10;
            buttonDelete.Text = "Удалить";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // labelSearchYear
            // 
            labelSearchYear.AutoSize = true;
            labelSearchYear.Location = new Point(416, 210);
            labelSearchYear.Name = "labelSearchYear";
            labelSearchYear.Size = new Size(89, 15);
            labelSearchYear.TabIndex = 11;
            labelSearchYear.Text = "Поиск по году:";
            labelSearchYear.Click += labelSearchYear_Click;
            // 
            // textBoxSearchYear
            // 
            textBoxSearchYear.Location = new Point(517, 210);
            textBoxSearchYear.Name = "textBoxSearchYear";
            textBoxSearchYear.Size = new Size(85, 23);
            textBoxSearchYear.TabIndex = 12;
            // 
            // buttonSearchYear
            // 
            buttonSearchYear.Location = new Point(608, 207);
            buttonSearchYear.Name = "buttonSearchYear";
            buttonSearchYear.Size = new Size(110, 26);
            buttonSearchYear.TabIndex = 13;
            buttonSearchYear.Text = "Найти";
            buttonSearchYear.UseVisualStyleBackColor = true;
            buttonSearchYear.Click += buttonSearchYear_Click;
            // 
            // buttonGroupByGenre
            // 
            buttonGroupByGenre.Location = new Point(419, 239);
            buttonGroupByGenre.Name = "buttonGroupByGenre";
            buttonGroupByGenre.Size = new Size(200, 29);
            buttonGroupByGenre.TabIndex = 14;
            buttonGroupByGenre.Text = "Группировать по жанрам";
            buttonGroupByGenre.UseVisualStyleBackColor = true;
            buttonGroupByGenre.Click += buttonGroupByGenre_Click;
            // 
            // dataGridViewFilms
            // 
            dataGridViewFilms.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewFilms.Location = new Point(10, 30);
            dataGridViewFilms.Name = "dataGridViewFilms";
            dataGridViewFilms.Size = new Size(400, 299);
            dataGridViewFilms.TabIndex = 15;
            // 
            // Form1
            // 
            ClientSize = new Size(728, 341);
            Controls.Add(dataGridViewFilms);
            Controls.Add(buttonGroupByGenre);
            Controls.Add(buttonSearchYear);
            Controls.Add(textBoxSearchYear);
            Controls.Add(labelSearchYear);
            Controls.Add(buttonDelete);
            Controls.Add(buttonUpdate);
            Controls.Add(buttonAdd);
            Controls.Add(textBoxYear);
            Controls.Add(labelYear);
            Controls.Add(textBoxGenre);
            Controls.Add(labelGenre);
            Controls.Add(textBoxTitle);
            Controls.Add(labelTitle);
            Controls.Add(labelFilms);
            Name = "Form1";
            Text = "Фильмы";
            ((System.ComponentModel.ISupportInitialize)dataGridViewFilms).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label labelFilms;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.Label labelGenre;
        private System.Windows.Forms.TextBox textBoxGenre;
        private System.Windows.Forms.Label labelYear;
        private System.Windows.Forms.TextBox textBoxYear;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Label labelSearchYear;
        private System.Windows.Forms.TextBox textBoxSearchYear;
        private System.Windows.Forms.Button buttonSearchYear;
        private System.Windows.Forms.Button buttonGroupByGenre;
        private DataGridView dataGridViewFilms;
    }
}