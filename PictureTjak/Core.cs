using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Windows.Forms;

namespace PictureTjak
{
    public partial class Core : Form
    {
        private int startX = 0;
        private int startY = 0;
        private bool dragging = false;
        private ImageList images = new ImageList();

        private enum UpdateType
        {
            First,
            Last,
            Previous,
            Next
        }

        public Core()
        {
            InitializeComponent();
        }

        private void CoreSizeChangedHandler(object sender, EventArgs e)
        {
            currentPicture.Top = 0;
            currentPicture.Left = 0;
            currentPicture.Size = picturePanel.Size;
        }

        #region General methods

        private void AddWordDocuments(string[] paths)
        {
            images.Clear();

            foreach (var path in paths)
            {
                try
                {
                    using (var zipArchiveStream = File.OpenRead(path))
                    {
                        using (var zipArchive = new ZipArchive(zipArchiveStream))
                        {
                            var imageEntries = zipArchive.Entries.Where(entry => entry.FullName.StartsWith("word/media"));

                            foreach (var imageEntry in imageEntries)
                            {
                                using (var imageEntryStream = imageEntry.Open())
                                {
                                    images.Add(Image.FromStream(imageEntryStream));
                                }
                            }
                        }
                    }
                }
                catch
                {
                    // Just don't add the images
                }
            }

            UpdateImage(UpdateType.First);
        }

        private void UpdateImage(UpdateType updateType)
        {
            switch (updateType)
            {
                case UpdateType.First:
                    images.CurrentIndex = images.MinIndex;
                    break;

                case UpdateType.Last:
                    images.CurrentIndex = images.MaxIndex;
                    break;

                case UpdateType.Previous:
                    if (images.CurrentIndex > images.MinIndex)
                    {
                        images.CurrentIndex--;
                    }
                    break;

                case UpdateType.Next:
                    if (images.CurrentIndex < images.MaxIndex)
                    {
                        images.CurrentIndex++;
                    }
                    break;
            }

            currentPicture.Top = 0;
            currentPicture.Left = 0;

            if (images.Any())
            {
                currentPicture.Image = images.CurrentImage;
            }
            else
            {
                currentPicture.Image = null;
            }

            buttonPreviousPicture.Enabled = (images.CurrentIndex != images.MinIndex);
            buttonNextPicture.Enabled = (images.CurrentIndex != images.MaxIndex);
        }

        #endregion

        #region Importing images

        private void OpenFile(object sender, CancelEventArgs e)
        {
            AddWordDocuments(openWordDocument.FileNames);
        }

        private void CoreDragEnterHandler(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void CoreDragDropHandler(object sender, DragEventArgs e)
        {
            var paths = (string[])e.Data.GetData(DataFormats.FileDrop);

            AddWordDocuments(paths);
        }

        #endregion

        #region Import buttons

        private void OpenWordDocumentHandler(object sender, EventArgs e)
        {
            openWordDocument.ShowDialog();
        }

        private void OpenIssueHandler(object sender, EventArgs e)
        {

        }

        #endregion

        #region Picture navigation

        private void PreviousPictureHandler(object sender, EventArgs e)
        {
            UpdateImage(UpdateType.Previous);
        }

        private void NextPictureHandler(object sender, EventArgs e)
        {
            UpdateImage(UpdateType.Next);
        }

        private void CoreKeyUpHandler(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                UpdateImage(UpdateType.Previous);
            }
            else if (e.KeyCode == Keys.Right)
            {
                UpdateImage(UpdateType.Next);
            }
        }

        #endregion

        #region Picture moving

        private void CurrentPictureMoveHandler(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                var top = e.Y + currentPicture.Top - startY;
                if (top > 0 || picturePanel.Height - currentPicture.Height > 0)
                {
                    top = 0;
                }
                else if (Math.Abs(top) > currentPicture.Height - picturePanel.Height)
                {
                    top = -(currentPicture.Height - picturePanel.Height);
                }

                var left = e.X + currentPicture.Left - startX;
                if (left > 0 || picturePanel.Width - currentPicture.Width > 0)
                {
                    left = 0;
                }
                else if (Math.Abs(left) > currentPicture.Width - picturePanel.Width)
                {
                    left = -(currentPicture.Width - picturePanel.Width);
                }

                currentPicture.Top = top;
                currentPicture.Left = left;
            }
        }

        private void CurrentPictureDownHandler(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                dragging = true;
                startX = e.X;
                startY = e.Y;
            }
        }

        private void CurrentPictureUpHandler(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        #endregion
    }
}
