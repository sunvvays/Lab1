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
            this.labelFilms = new System.Windows.Forms.Label();
            this.listBoxFilms = new System.Windows.Forms.ListBox();
            this.labelTitle = new System.Windows.Forms.Label();
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.labelGenre = new System.Windows.Forms.Label();
            this.textBoxGenre = new System.Windows.Forms.TextBox();
            this.labelYear = new System.Windows.Forms.Label();
            this.textBoxYear = new System.Windows.Forms.TextBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.labelSearchYear = new System.Windows.Forms.Label();
            this.textBoxSearchYear = new System.Windows.Forms.TextBox();
            this.buttonSearchYear = new System.Windows.Forms.Button();
            this.buttonGroupByGenre = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelFilms
            // 
            this.labelFilms.AutoSize = true;
            this.labelFilms.Location = new System.Drawing.Point(10, 10);
            this.labelFilms.Name = "labelFilms";
            this.labelFilms.Size = new System.Drawing.Size(105, 15);
            this.labelFilms.TabIndex = 0;
            this.labelFilms.Text = "Список фильмов:";
            // 
            // listBoxFilms
            // 
            this.listBoxFilms.FormattingEnabled = true;
            this.listBoxFilms.ItemHeight = 15;
            this.listBoxFilms.Location = new System.Drawing.Point(10, 30);
            this.listBoxFilms.Name = "listBoxFilms";
            this.listBoxFilms.Size = new System.Drawing.Size(260, 304);
            this.listBoxFilms.TabIndex = 1;
            this.listBoxFilms.SelectedIndexChanged += new System.EventHandler(this.listBoxFilms_SelectedIndexChanged);
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Location = new System.Drawing.Point(280, 10);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(63, 15);
            this.labelTitle.TabIndex = 2;
            this.labelTitle.Text = "Название:";
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Location = new System.Drawing.Point(280, 30);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Size = new System.Drawing.Size(300, 23);
            this.textBoxTitle.TabIndex = 3;
            // 
            // labelGenre
            // 
            this.labelGenre.AutoSize = true;
            this.labelGenre.Location = new System.Drawing.Point(280, 60);
            this.labelGenre.Name = "labelGenre";
            this.labelGenre.Size = new System.Drawing.Size(41, 15);
            this.labelGenre.TabIndex = 4;
            this.labelGenre.Text = "Жанр:";
            // 
            // textBoxGenre
            // 
            this.textBoxGenre.Location = new System.Drawing.Point(280, 80);
            this.textBoxGenre.Name = "textBoxGenre";
            this.textBoxGenre.Size = new System.Drawing.Size(300, 23);
            this.textBoxGenre.TabIndex = 5;
            // 
            // labelYear
            // 
            this.labelYear.AutoSize = true;
            this.labelYear.Location = new System.Drawing.Point(280, 110);
            this.labelYear.Name = "labelYear";
            this.labelYear.Size = new System.Drawing.Size(80, 15);
            this.labelYear.TabIndex = 6;
            this.labelYear.Text = "Год выпуска:";
            // 
            // textBoxYear
            // 
            this.textBoxYear.Location = new System.Drawing.Point(280, 130);
            this.textBoxYear.Name = "textBoxYear";
            this.textBoxYear.Size = new System.Drawing.Size(100, 23);
            this.textBoxYear.TabIndex = 7;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(280, 170);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(85, 26);
            this.buttonAdd.TabIndex = 8;
            this.buttonAdd.Text = "Добавить";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(375, 170);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(85, 26);
            this.buttonUpdate.TabIndex = 9;
            this.buttonUpdate.Text = "Обновить";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(470, 170);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(85, 26);
            this.buttonDelete.TabIndex = 10;
            this.buttonDelete.Text = "Удалить";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // labelSearchYear
            // 
            this.labelSearchYear.AutoSize = true;
            this.labelSearchYear.Location = new System.Drawing.Point(280, 210);
            this.labelSearchYear.Name = "labelSearchYear";
            this.labelSearchYear.Size = new System.Drawing.Size(92, 15);
            this.labelSearchYear.TabIndex = 11;
            this.labelSearchYear.Text = "Поиск по году:";
            // 
            // textBoxSearchYear
            // 
            this.textBoxSearchYear.Location = new System.Drawing.Point(375, 207);
            this.textBoxSearchYear.Name = "textBoxSearchYear";
            this.textBoxSearchYear.Size = new System.Drawing.Size(85, 23);
            this.textBoxSearchYear.TabIndex = 12;
            // 
            // buttonSearchYear
            // 
            this.buttonSearchYear.Location = new System.Drawing.Point(470, 205);
            this.buttonSearchYear.Name = "buttonSearchYear";
            this.buttonSearchYear.Size = new System.Drawing.Size(110, 26);
            this.buttonSearchYear.TabIndex = 13;
            this.buttonSearchYear.Text = "Найти";
            this.buttonSearchYear.UseVisualStyleBackColor = true;
            this.buttonSearchYear.Click += new System.EventHandler(this.buttonSearchYear_Click);
            // 
            // buttonGroupByGenre
            // 
            this.buttonGroupByGenre.Location = new System.Drawing.Point(280, 245);
            this.buttonGroupByGenre.Name = "buttonGroupByGenre";
            this.buttonGroupByGenre.Size = new System.Drawing.Size(200, 26);
            this.buttonGroupByGenre.TabIndex = 14;
            this.buttonGroupByGenre.Text = "Группировать по жанрам";
            this.buttonGroupByGenre.UseVisualStyleBackColor = true;
            this.buttonGroupByGenre.Click += new System.EventHandler(this.buttonGroupByGenre_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(600, 350);
            this.Controls.Add(this.buttonGroupByGenre);
            this.Controls.Add(this.buttonSearchYear);
            this.Controls.Add(this.textBoxSearchYear);
            this.Controls.Add(this.labelSearchYear);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.textBoxYear);
            this.Controls.Add(this.labelYear);
            this.Controls.Add(this.textBoxGenre);
            this.Controls.Add(this.labelGenre);
            this.Controls.Add(this.textBoxTitle);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.listBoxFilms);
            this.Controls.Add(this.labelFilms);
            this.Name = "Form1";
            this.Text = "Фильмы";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label labelFilms;
        private System.Windows.Forms.ListBox listBoxFilms;
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
    }
}