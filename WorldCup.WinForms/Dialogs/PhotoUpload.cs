using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using WorldCup.DataLayer;
using WorldCup.DataLayer.Data;
using WorldCup.DataLayer.Exceptions;
using WorldCup.WinForms.Controls;


namespace WorldCup.WinForms.Dialogs
{
    public partial class PhotoUpload : Form
    {
        private readonly PlayerControl playerControl;

        public static EventHandler RemoveImg;
        public static EventHandler RefreshForm;

        public PhotoUpload(PlayerControl playerControl)
        {
            this.playerControl = playerControl;

            InitializeComponent();

            this.Text = "";
            this.BringToFront();
            this.MinimizeBox = true;
            this.MaximizeBox = false;           
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;

            btnUpload.Text = Resources.BtnUpload;
            labelFormatOption.Text = Resources.TextImageFormat;
            labelPlayerName.Text = playerControl.ColumnContent2;
            labelPlayerName.Font = 
                new Font(new FontFamily("Segoe Print"), 12, FontStyle.Regular);

            pictureBoxUploadedImg.Image = playerControl.ColumnContent1;
            pictureBoxUploadedImg.SizeMode = PictureBoxSizeMode.Zoom;

            btnApply.Text = Resources.BtnApply;
            btnApply.Enabled = false;
            btnApply.Visible = false;
        }
        private void BtnUpload_Click(object sender, EventArgs e)
        {

            layoutMiddle.SetCellPosition(btnUpload, new TableLayoutPanelCellPosition(1, 0));

            btnApply.Enabled = false;
            btnApply.Visible = false;

            labelFormatOption.Text = Resources.TextImageFormat;
            labelFormatOption.ForeColor = Color.Black;

            using (OpenFileDialog explorer = new OpenFileDialog())
            {
                if (explorer.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string SelectedFile = explorer.FileName;

                        string Extension = Path.GetExtension(SelectedFile).ToLower();

                        if (Extension != ".jpg" && Extension != ".jpeg")
                            throw new Exception("Only JPG files are allowed.");

                        pictureBoxUploadedImg.Image?.Dispose();
                        pictureBoxUploadedImg.Image = null;

                        using (Image File = Image.FromFile(explorer.FileName))
                        {
                            pictureBoxUploadedImg.Image = new Bitmap(File);
                        }

                        layoutMiddle.SetCellPosition(btnUpload, new TableLayoutPanelCellPosition(0, 0));

                        btnApply.Enabled = true;
                        btnApply.Visible = true;
                    }
                    catch (Exception error)
                    {
                        DisplayMessage(error);
                    }
                }
            }
        }
        private void BtnApply_Click(object sender, EventArgs e)
        {
            Image imgForSave = (Image)pictureBoxUploadedImg.Image.Clone();

            try
            {
                PhotoUpload.RemoveImg?.Invoke(playerControl, EventArgs.Empty);

                pictureBoxUploadedImg.Image?.Dispose();
                pictureBoxUploadedImg.Image = null;

                playerControl.ColumnContent1?.Dispose();
                playerControl.ColumnContent1 = null;

                ImgHandeler.SaveImg(
                    $"{playerControl.ColumnContent2}",
                    $"{playerControl.ID}",
                    imgForSave
                );

                PhotoUpload.RefreshForm?.Invoke(null, EventArgs.Empty);
                
                pictureBoxUploadedImg.Image = ImgHandeler.Img;

                labelFormatOption.Text = Resources.TextUploadInfo;
                labelFormatOption.ForeColor = Color.Green;

                layoutMiddle.SetCellPosition(btnUpload, new TableLayoutPanelCellPosition(1, 0));

                btnApply.Enabled = false;
                btnApply.Visible = false;

            }
            catch(Exception error)
            { 
                DisplayMessage(error);
            }
        }

        private void DisplayMessage(Exception error)
        {
            labelFormatOption.Text = Resources.TextUpladFailed;
            labelFormatOption.ForeColor = Color.Red;

            PhotoUpload.RefreshForm?.Invoke(null, EventArgs.Empty);
            pictureBoxUploadedImg.Image = ImgHandeler.Img;

            string AdditionalInfo =
                ExceptionProcessor.ProcessException(error);

            MessageBox.Show(
                $"Error while uploading Image!\n" +
                $"{error.Message}\n" +
                AdditionalInfo,
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
        }
    }
}

