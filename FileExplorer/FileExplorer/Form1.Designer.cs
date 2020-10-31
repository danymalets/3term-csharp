namespace FileExplorer
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.filePathTextBox = new System.Windows.Forms.TextBox();
            this.openTextButton = new System.Windows.Forms.Button();
            this.fileTextBox = new System.Windows.Forms.RichTextBox();
            this.fileNameTextBox = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.goButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.renameButton = new System.Windows.Forms.Button();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.fileListView = new System.Windows.Forms.ListView();
            this.textReadingCheckBox = new System.Windows.Forms.CheckBox();
            this.copyButton = new System.Windows.Forms.Button();
            this.pasteButton = new System.Windows.Forms.Button();
            this.archiveButton = new System.Windows.Forms.Button();
            this.extractButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.moveButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // filePathTextBox
            // 
            this.filePathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filePathTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.filePathTextBox.Location = new System.Drawing.Point(60, 21);
            this.filePathTextBox.Name = "filePathTextBox";
            this.filePathTextBox.Size = new System.Drawing.Size(686, 30);
            this.filePathTextBox.TabIndex = 4;
            this.filePathTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.filePathTextBox_KeyDown);
            // 
            // openTextButton
            // 
            this.openTextButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.openTextButton.Location = new System.Drawing.Point(409, 148);
            this.openTextButton.Name = "openTextButton";
            this.openTextButton.Size = new System.Drawing.Size(104, 38);
            this.openTextButton.TabIndex = 5;
            this.openTextButton.Text = "Open";
            this.openTextButton.UseVisualStyleBackColor = true;
            this.openTextButton.Click += new System.EventHandler(this.openTextButton_Click);
            // 
            // fileTextBox
            // 
            this.fileTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fileTextBox.Enabled = false;
            this.fileTextBox.Location = new System.Drawing.Point(565, 83);
            this.fileTextBox.Name = "fileTextBox";
            this.fileTextBox.Size = new System.Drawing.Size(385, 445);
            this.fileTextBox.TabIndex = 6;
            this.fileTextBox.Text = "";
            // 
            // fileNameTextBox
            // 
            this.fileNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.fileNameTextBox.Enabled = false;
            this.fileNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.fileNameTextBox.Location = new System.Drawing.Point(13, 469);
            this.fileNameTextBox.Name = "fileNameTextBox";
            this.fileNameTextBox.Size = new System.Drawing.Size(200, 30);
            this.fileNameTextBox.TabIndex = 8;
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.Enabled = false;
            this.saveButton.Location = new System.Drawing.Point(409, 104);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(104, 38);
            this.saveButton.TabIndex = 9;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // goButton
            // 
            this.goButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.goButton.Location = new System.Drawing.Point(770, 21);
            this.goButton.Name = "goButton";
            this.goButton.Size = new System.Drawing.Size(104, 38);
            this.goButton.TabIndex = 10;
            this.goButton.Text = "Go";
            this.goButton.UseVisualStyleBackColor = true;
            this.goButton.Click += new System.EventHandler(this.goButton_Click);
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(12, 21);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(38, 38);
            this.backButton.TabIndex = 11;
            this.backButton.Text = "<";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // renameButton
            // 
            this.renameButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.renameButton.Enabled = false;
            this.renameButton.Location = new System.Drawing.Point(245, 467);
            this.renameButton.Name = "renameButton";
            this.renameButton.Size = new System.Drawing.Size(104, 38);
            this.renameButton.TabIndex = 12;
            this.renameButton.Text = "Rename";
            this.renameButton.UseVisualStyleBackColor = true;
            this.renameButton.Click += new System.EventHandler(this.renameButton_Click);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "folder1.png");
            this.imageList.Images.SetKeyName(1, "file.png");
            // 
            // fileListView
            // 
            this.fileListView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.fileListView.HideSelection = false;
            this.fileListView.LargeImageList = this.imageList;
            this.fileListView.Location = new System.Drawing.Point(13, 86);
            this.fileListView.Name = "fileListView";
            this.fileListView.Size = new System.Drawing.Size(306, 355);
            this.fileListView.SmallImageList = this.imageList;
            this.fileListView.TabIndex = 13;
            this.fileListView.UseCompatibleStateImageBehavior = false;
            this.fileListView.View = System.Windows.Forms.View.Tile;
            this.fileListView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.fileListView_ItemSelectionChanged);
            this.fileListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.fileListView_MouseDoubleClick);
            // 
            // textReadingCheckBox
            // 
            this.textReadingCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textReadingCheckBox.Checked = true;
            this.textReadingCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.textReadingCheckBox.Location = new System.Drawing.Point(397, 192);
            this.textReadingCheckBox.Name = "textReadingCheckBox";
            this.textReadingCheckBox.Size = new System.Drawing.Size(129, 24);
            this.textReadingCheckBox.TabIndex = 14;
            this.textReadingCheckBox.Text = "Text Reading";
            this.textReadingCheckBox.UseVisualStyleBackColor = true;
            // 
            // copyButton
            // 
            this.copyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.copyButton.Location = new System.Drawing.Point(409, 232);
            this.copyButton.Name = "copyButton";
            this.copyButton.Size = new System.Drawing.Size(104, 38);
            this.copyButton.TabIndex = 15;
            this.copyButton.Text = "Copy";
            this.copyButton.UseVisualStyleBackColor = true;
            this.copyButton.Click += new System.EventHandler(this.copyButton_Click);
            // 
            // pasteButton
            // 
            this.pasteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.pasteButton.Location = new System.Drawing.Point(409, 276);
            this.pasteButton.Name = "pasteButton";
            this.pasteButton.Size = new System.Drawing.Size(104, 38);
            this.pasteButton.TabIndex = 16;
            this.pasteButton.Text = "Paste";
            this.pasteButton.UseVisualStyleBackColor = true;
            this.pasteButton.Click += new System.EventHandler(this.pasteButton_Click);
            // 
            // archiveButton
            // 
            this.archiveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.archiveButton.Location = new System.Drawing.Point(409, 320);
            this.archiveButton.Name = "archiveButton";
            this.archiveButton.Size = new System.Drawing.Size(104, 38);
            this.archiveButton.TabIndex = 17;
            this.archiveButton.Text = "Archive";
            this.archiveButton.UseVisualStyleBackColor = true;
            this.archiveButton.Click += new System.EventHandler(this.archiveButton_Click);
            // 
            // extractButton
            // 
            this.extractButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.extractButton.Location = new System.Drawing.Point(409, 364);
            this.extractButton.Name = "extractButton";
            this.extractButton.Size = new System.Drawing.Size(104, 38);
            this.extractButton.TabIndex = 18;
            this.extractButton.Text = "Extract";
            this.extractButton.UseVisualStyleBackColor = true;
            this.extractButton.Click += new System.EventHandler(this.extractButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteButton.Location = new System.Drawing.Point(409, 408);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(104, 38);
            this.deleteButton.TabIndex = 19;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // moveButton
            // 
            this.moveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.moveButton.Location = new System.Drawing.Point(409, 452);
            this.moveButton.Name = "moveButton";
            this.moveButton.Size = new System.Drawing.Size(104, 38);
            this.moveButton.TabIndex = 20;
            this.moveButton.Text = "Move";
            this.moveButton.UseVisualStyleBackColor = true;
            this.moveButton.Click += new System.EventHandler(this.moveButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1047, 540);
            this.Controls.Add(this.moveButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.extractButton);
            this.Controls.Add(this.archiveButton);
            this.Controls.Add(this.pasteButton);
            this.Controls.Add(this.copyButton);
            this.Controls.Add(this.textReadingCheckBox);
            this.Controls.Add(this.fileListView);
            this.Controls.Add(this.renameButton);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.goButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.fileNameTextBox);
            this.Controls.Add(this.fileTextBox);
            this.Controls.Add(this.openTextButton);
            this.Controls.Add(this.filePathTextBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TextBox filePathTextBox;
        private System.Windows.Forms.Button openTextButton;
        private System.Windows.Forms.RichTextBox fileTextBox;
        private System.Windows.Forms.TextBox fileNameTextBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button goButton;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Button renameButton;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ListView fileListView;
        private System.Windows.Forms.CheckBox textReadingCheckBox;
        private System.Windows.Forms.Button copyButton;
        private System.Windows.Forms.Button pasteButton;
        private System.Windows.Forms.Button archiveButton;
        private System.Windows.Forms.Button extractButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button moveButton;
    }
}

