using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO.Compression;

namespace FileExplorer
{
    public partial class Form1 : Form
    {
        const string startFilePath = @"C:/Users/daniel/Desktop";
        private DirectoryInfo curDir;
        private string selectedFileName;
        private bool textReading;
        private string[] copiedFiles = new string[0];
        private string copiedDir;
        private FileSystemWatcher watcher;

        public Form1()
        {
            InitializeComponent();
            curDir = new DirectoryInfo(startFilePath);
            loadDirectory();
            
        }

        private void loadDirectory()
        {
            if (curDir.Parent == null)
            {
                backButton.Enabled = false;
            }
            else
            {
                backButton.Enabled = true;
            }
            selectedFileName = null;
            openTextButton.Enabled = false;
            saveButton.Enabled = false;
            fileTextBox.Text = string.Empty;
            fileTextBox.Enabled = false;
            fileNameTextBox.Enabled = false;
            fileNameTextBox.Text = string.Empty;
            fileListView.Clear();
            renameButton.Enabled = false;

            filePathTextBox.Text = curDir.FullName;

            FileInfo[] files = curDir.GetFiles();
            DirectoryInfo[] directories = curDir.GetDirectories();

            for (int i = 0; i < directories.Length; i++)
            {
                fileListView.Items.Add(directories[i].Name, 0);
            }

            for (int i = 0; i < files.Length; i++)
            {
                fileListView.Items.Add(files[i].Name, 1);
            }
        }

        private void openTextButton_Click(object sender, EventArgs e)
        {
            openSelectedFile();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            string filePath = Path.Combine(curDir.FullName, selectedFileName);
            if (textReading)
            {
                File.WriteAllText(filePath, fileTextBox.Text);
            }
            else
            {
                File.WriteAllText(filePath, fileTextBox.Text);
            }
        }

        private void renameButton_Click(object sender, EventArgs e)
        {
            string from = Path.Combine(curDir.FullName, selectedFileName);
            string to = Path.Combine(curDir.FullName, fileNameTextBox.Text);
            try
            {
                Directory.Move(from, to);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error!");
            }
            loadDirectory();
        }

        private void openSelectedFile()
        {
            string filePath = Path.Combine(curDir.FullName, selectedFileName);
            if (textReadingCheckBox.Checked)
            {
                fileTextBox.Text = File.ReadAllText(filePath);
                textReading = true;
            }
            else
            {
                byte[] bytes = File.ReadAllBytes(filePath);
                StringBuilder s = new StringBuilder();
                foreach (byte b in bytes)
                {
                    s.Append(b + " ");
                }
                fileTextBox.Text = s.ToString();
                textReading = false;
            }
            fileTextBox.Enabled = true;
            saveButton.Enabled = true;
        }


        private void closeFile()
        {
            fileTextBox.Text = string.Empty;
            fileTextBox.Enabled = false;
            saveButton.Enabled = false;
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            curDir = curDir.Parent;
            loadDirectory();
        }

        private void goButton_Click(object sender, EventArgs e)
        {
            string newPath = filePathTextBox.Text;
            if (File.Exists(newPath))
            {
                Process.Start(newPath);
            }
            else if (Directory.Exists(newPath))
            {
                curDir = new DirectoryInfo(newPath);
                loadDirectory();
            }
            else
            {
                MessageBox.Show("\"" + newPath + "\" not found");
            }
        }

        private void copyButton_Click(object sender, EventArgs e)
        {
            var items = fileListView.SelectedItems;
            copiedFiles = new string[items.Count];
            copiedDir = curDir.FullName;
            for (int i = 0; i < items.Count; i++)
            {
                copiedFiles[i] = items[i].Text;
            }
        }

        private void pasteButton_Click(object sender, EventArgs e)
        {
            foreach (var copiedFile in copiedFiles)
            {
                string from = Path.Combine(copiedDir, copiedFile);
                string to = Path.Combine(curDir.FullName, copiedFile);
                if (File.Exists(from))
                {
                    if (!File.Exists(to) && !Directory.Exists(to))
                    {
                        File.Copy(from, to);
                    }
                }
            }
            loadDirectory();
        }

        private void fileListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            closeFile();
            var items = fileListView.SelectedItems; 
            if (items.Count == 1)
            {
                selectedFileName = items[0].Text;
                if (File.Exists(Path.Combine(curDir.FullName, selectedFileName)))
                {
                    openTextButton.Enabled = true;
                }
                fileNameTextBox.Text = selectedFileName;
                fileNameTextBox.Enabled = true;
                renameButton.Enabled = true;
            }
            else
            {
                selectedFileName = null;
                openTextButton.Enabled = false;
                fileNameTextBox.Text = string.Empty;
                fileNameTextBox.Enabled = false;
                renameButton.Enabled = false;
            }
        }

        private void fileListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (selectedFileName != null)
            {
                string newPath = Path.Combine(curDir.FullName, selectedFileName);
                if (File.Exists(newPath))
                {
                    Process.Start(newPath);
                }
                else if (Directory.Exists(newPath))
                {
                    curDir = new DirectoryInfo(newPath);
                    loadDirectory();
                }
            }
        }

        private void archiveButton_Click(object sender, EventArgs e)
        {
            var items = fileListView.SelectedItems;
            foreach (ListViewItem item in items)
            {
                string fileName = item.Text;
                string archivePath = Path.Combine(curDir.FullName, fileName);
                if (Directory.Exists(archivePath))
                {
                    try
                    {
                        ZipFile.CreateFromDirectory(archivePath, archivePath + ".zip");
                    }
                    catch
                    {
                        MessageBox.Show("Error!");
                    }
                }
            }
            loadDirectory();
        }

        private void extractButton_Click(object sender, EventArgs e)
        {
            var items = fileListView.SelectedItems;
            foreach (ListViewItem item in items)
            {
                string fileName = item.Text;
                string archivePath = Path.Combine(curDir.FullName, fileName);
                string ext = archivePath.Substring(Math.Max(0, archivePath.Length - 4), Math.Min(4, archivePath.Length));
                string folderPath = archivePath.Substring(0, Math.Max(0, archivePath.Length - 4));
                if (File.Exists(archivePath))
                {
                    try
                    {
                        ZipFile.ExtractToDirectory(archivePath, folderPath + " + extracted");
                    }
                    catch
                    {
                        MessageBox.Show("Error!");
                    }
                }
            }
            loadDirectory();
        }

        private void filePathTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string newPath = filePathTextBox.Text;
                if (File.Exists(newPath))
                {
                    Process.Start(newPath);
                }
                else if (Directory.Exists(newPath))
                {
                    curDir = new DirectoryInfo(newPath);
                    loadDirectory();
                }
                else
                {
                    MessageBox.Show("\"" + newPath + "\" not found");
                }
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            var items = fileListView.SelectedItems;
            foreach (ListViewItem item in items)
            {
                string filePath = Path.Combine(curDir.FullName, item.Text);
                if (Directory.Exists(filePath))
                {
                    Directory.Delete(filePath, true);
                }
                else if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
            }
            loadDirectory();
        }

        private void moveButton_Click(object sender, EventArgs e)
        {
            foreach (var copiedFile in copiedFiles)
            {
                string from = Path.Combine(copiedDir, copiedFile);
                string to = Path.Combine(curDir.FullName, copiedFile);
                if (File.Exists(from))
                {
                    if (!File.Exists(to) && !Directory.Exists(to))
                    {
                        File.Move(from, to);
                    }
                }
            }
            loadDirectory();
        }
    }
}
