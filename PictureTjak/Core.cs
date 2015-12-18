using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using PictureTjak.Properties;

namespace PictureTjak
{
    public partial class Core : Form
    {
        private readonly ImageList _images = new ImageList();
        private readonly DragPicture _dragPicture = new DragPicture();

        private enum UpdateType
        {
            First,
            Last,
            Previous,
            Next
        }

        [DllImport("user32")]
        public static extern uint SendMessage(IntPtr hWnd, uint msg, uint wParam, uint lParam);

        private const string OpenCommand = "open";
        private const string RegisterCommand = "register";
        private const string UrlName = "picture-tjak";
        private const string RunAsVerb = "runas";

        public Core(string[] args)
        {
            InitializeComponent();

            if (args.Any(a => a == RegisterCommand))
            {
                try
                {
                    var key = Registry.ClassesRoot.CreateSubKey(UrlName);
                    key.SetValue(string.Empty, "URL:PictureTjak");
                    key.SetValue("URL Protocol", string.Empty);
                    key.Close();

                    key = Registry.ClassesRoot.CreateSubKey($@"{UrlName}\DefaultIcon");
                    key.SetValue(string.Empty, $"{Application.ExecutablePath},1");
                    key.Close();

                    key = Registry.ClassesRoot.CreateSubKey($@"{UrlName}\shell\open\command");
                    key.SetValue(string.Empty, $"\"{Application.ExecutablePath}\" \"{OpenCommand}:%1\"");
                    key.Close();
                }
                catch
                {
                    MessageBox.Show(Resources.Failed_to_register_URL_handler, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (args.Any(a => a.StartsWith(OpenCommand)))
            {
                var url = args.First(a => a.StartsWith(OpenCommand)).Replace($"{OpenCommand}:{UrlName}://", string.Empty);

                try
                {
                    var tempFileName = Path.GetTempFileName();
                    using (var webClient = new WebClient())
                    {
                        webClient.DownloadFile(url, tempFileName);
                    }
                    AddWordDocuments(new[] { tempFileName });
                }
                catch
                {
                    MessageBox.Show(Resources.Failed_to_open_file, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            SendMessage(buttonRegisterUrlHandler.Handle, 0x160C, 0, 0xFFFFFFFF);
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
            _images.Clear();

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
                                    _images.Add(Image.FromStream(imageEntryStream));
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
                    _images.CurrentIndex = _images.MinIndex;
                    break;

                case UpdateType.Last:
                    _images.CurrentIndex = _images.MaxIndex;
                    break;

                case UpdateType.Previous:
                    if (_images.CurrentIndex > _images.MinIndex)
                    {
                        _images.CurrentIndex--;
                    }
                    break;

                case UpdateType.Next:
                    if (_images.CurrentIndex < _images.MaxIndex)
                    {
                        _images.CurrentIndex++;
                    }
                    break;
            }

            currentPicture.Top = 0;
            currentPicture.Left = 0;

            if (_images.HasImage)
            {
                Text = $"{ProductName} ({_images.CurrentIndex + 1}/{_images.Count})";
                currentPicture.Image = _images.CurrentImage;
            }
            else
            {
                Text = ProductName;
                currentPicture.Image = null;
            }

            buttonPreviousPicture.Enabled = (_images.CurrentIndex != _images.MinIndex);
            buttonNextPicture.Enabled = (_images.CurrentIndex != _images.MaxIndex);
            buttonCopyPicture.Enabled = _images.HasImage;
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

        private void CopyPictureHandler(object sender, EventArgs e)
        {
            if (_images.HasImage)
            {
                Clipboard.SetImage(_images.CurrentImage);
            }
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
            if (!_dragPicture.IsDragging)
            {
                return;
            }

            var top = e.Y + currentPicture.Top - _dragPicture.StartY;
            if (top > 0 || picturePanel.Height - currentPicture.Height > 0)
            {
                top = 0;
            }
            else if (Math.Abs(top) > currentPicture.Height - picturePanel.Height)
            {
                top = -(currentPicture.Height - picturePanel.Height);
            }

            var left = e.X + currentPicture.Left - _dragPicture.StartX;
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

        private void CurrentPictureDownHandler(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _dragPicture.Start(e.X, e.Y);
            }
        }

        private void CurrentPictureUpHandler(object sender, MouseEventArgs e)
        {
            _dragPicture.End();
        }

        #endregion

        #region Register URL

        private void RegisterUrlHandler(object sender, EventArgs e)
        {
            var process = new ProcessStartInfo
            {
                FileName = Application.ExecutablePath,
                Arguments = RegisterCommand,
                Verb = RunAsVerb
            };

            Process.Start(process);
        }

        #endregion
    }
}
