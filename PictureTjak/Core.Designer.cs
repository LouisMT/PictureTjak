namespace PictureTjak
{
    partial class Core
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.openWordDocument = new System.Windows.Forms.OpenFileDialog();
            this.mainTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.buttonTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.buttonPreviousPicture = new System.Windows.Forms.Button();
            this.buttonOpenWordDocument = new System.Windows.Forms.Button();
            this.buttonOpenIssue = new System.Windows.Forms.Button();
            this.buttonNextPicture = new System.Windows.Forms.Button();
            this.picturePanel = new System.Windows.Forms.Panel();
            this.currentPicture = new System.Windows.Forms.PictureBox();
            this.mainTableLayout.SuspendLayout();
            this.buttonTableLayout.SuspendLayout();
            this.picturePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.currentPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // openWordDocument
            // 
            this.openWordDocument.Filter = "Word documents|*.docx";
            this.openWordDocument.Multiselect = true;
            this.openWordDocument.Title = "Select a Word document";
            this.openWordDocument.FileOk += new System.ComponentModel.CancelEventHandler(this.OpenFile);
            // 
            // mainTableLayout
            // 
            this.mainTableLayout.ColumnCount = 1;
            this.mainTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainTableLayout.Controls.Add(this.buttonTableLayout, 0, 1);
            this.mainTableLayout.Controls.Add(this.picturePanel, 0, 0);
            this.mainTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTableLayout.Location = new System.Drawing.Point(0, 0);
            this.mainTableLayout.Name = "mainTableLayout";
            this.mainTableLayout.RowCount = 2;
            this.mainTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.mainTableLayout.Size = new System.Drawing.Size(734, 461);
            this.mainTableLayout.TabIndex = 1;
            // 
            // buttonTableLayout
            // 
            this.buttonTableLayout.ColumnCount = 4;
            this.buttonTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.buttonTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.buttonTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.buttonTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.buttonTableLayout.Controls.Add(this.buttonPreviousPicture, 0, 0);
            this.buttonTableLayout.Controls.Add(this.buttonOpenWordDocument, 1, 0);
            this.buttonTableLayout.Controls.Add(this.buttonOpenIssue, 2, 0);
            this.buttonTableLayout.Controls.Add(this.buttonNextPicture, 3, 0);
            this.buttonTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonTableLayout.Location = new System.Drawing.Point(0, 432);
            this.buttonTableLayout.Margin = new System.Windows.Forms.Padding(0);
            this.buttonTableLayout.Name = "buttonTableLayout";
            this.buttonTableLayout.RowCount = 1;
            this.buttonTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.buttonTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.buttonTableLayout.Size = new System.Drawing.Size(734, 29);
            this.buttonTableLayout.TabIndex = 0;
            // 
            // buttonPreviousPicture
            // 
            this.buttonPreviousPicture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonPreviousPicture.Enabled = false;
            this.buttonPreviousPicture.Location = new System.Drawing.Point(3, 3);
            this.buttonPreviousPicture.Name = "buttonPreviousPicture";
            this.buttonPreviousPicture.Size = new System.Drawing.Size(177, 23);
            this.buttonPreviousPicture.TabIndex = 0;
            this.buttonPreviousPicture.Text = "<";
            this.buttonPreviousPicture.UseVisualStyleBackColor = true;
            this.buttonPreviousPicture.Click += new System.EventHandler(this.PreviousPictureHandler);
            // 
            // buttonOpenWordDocument
            // 
            this.buttonOpenWordDocument.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonOpenWordDocument.Location = new System.Drawing.Point(186, 3);
            this.buttonOpenWordDocument.Name = "buttonOpenWordDocument";
            this.buttonOpenWordDocument.Size = new System.Drawing.Size(177, 23);
            this.buttonOpenWordDocument.TabIndex = 1;
            this.buttonOpenWordDocument.Text = "Open Word document";
            this.buttonOpenWordDocument.UseVisualStyleBackColor = true;
            this.buttonOpenWordDocument.Click += new System.EventHandler(this.OpenWordDocumentHandler);
            // 
            // buttonOpenIssue
            // 
            this.buttonOpenIssue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonOpenIssue.Enabled = false;
            this.buttonOpenIssue.Location = new System.Drawing.Point(369, 3);
            this.buttonOpenIssue.Name = "buttonOpenIssue";
            this.buttonOpenIssue.Size = new System.Drawing.Size(177, 23);
            this.buttonOpenIssue.TabIndex = 2;
            this.buttonOpenIssue.Text = "Open issue";
            this.buttonOpenIssue.UseVisualStyleBackColor = true;
            this.buttonOpenIssue.Click += new System.EventHandler(this.OpenIssueHandler);
            // 
            // buttonNextPicture
            // 
            this.buttonNextPicture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonNextPicture.Enabled = false;
            this.buttonNextPicture.Location = new System.Drawing.Point(552, 3);
            this.buttonNextPicture.Name = "buttonNextPicture";
            this.buttonNextPicture.Size = new System.Drawing.Size(179, 23);
            this.buttonNextPicture.TabIndex = 3;
            this.buttonNextPicture.Text = ">";
            this.buttonNextPicture.UseVisualStyleBackColor = true;
            this.buttonNextPicture.Click += new System.EventHandler(this.NextPictureHandler);
            // 
            // picturePanel
            // 
            this.picturePanel.Controls.Add(this.currentPicture);
            this.picturePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picturePanel.Location = new System.Drawing.Point(0, 0);
            this.picturePanel.Margin = new System.Windows.Forms.Padding(0);
            this.picturePanel.Name = "picturePanel";
            this.picturePanel.Size = new System.Drawing.Size(734, 432);
            this.picturePanel.TabIndex = 1;
            // 
            // currentPicture
            // 
            this.currentPicture.Location = new System.Drawing.Point(0, 0);
            this.currentPicture.Margin = new System.Windows.Forms.Padding(0);
            this.currentPicture.Name = "currentPicture";
            this.currentPicture.Size = new System.Drawing.Size(734, 432);
            this.currentPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.currentPicture.TabIndex = 2;
            this.currentPicture.TabStop = false;
            this.currentPicture.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CurrentPictureDownHandler);
            this.currentPicture.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CurrentPictureMoveHandler);
            this.currentPicture.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CurrentPictureUpHandler);
            // 
            // Core
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 461);
            this.Controls.Add(this.mainTableLayout);
            this.Name = "Core";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PictureTjak";
            this.SizeChanged += new System.EventHandler(this.CoreSizeChangedHandler);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.CoreDragDropHandler);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.CoreDragEnterHandler);
            this.mainTableLayout.ResumeLayout(false);
            this.buttonTableLayout.ResumeLayout(false);
            this.picturePanel.ResumeLayout(false);
            this.picturePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.currentPicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openWordDocument;
        private System.Windows.Forms.TableLayoutPanel mainTableLayout;
        private System.Windows.Forms.TableLayoutPanel buttonTableLayout;
        private System.Windows.Forms.Button buttonPreviousPicture;
        private System.Windows.Forms.Button buttonOpenWordDocument;
        private System.Windows.Forms.Button buttonOpenIssue;
        private System.Windows.Forms.Button buttonNextPicture;
        private System.Windows.Forms.Panel picturePanel;
        private System.Windows.Forms.PictureBox currentPicture;
    }
}

