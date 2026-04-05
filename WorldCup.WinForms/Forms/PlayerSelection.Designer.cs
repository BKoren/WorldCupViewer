using System.Windows.Forms;
using WorldCup.DataLayer.Models;
using WorldCup.WinForms.Controls;

namespace WorldCup.WinForms
{
    partial class PlayerSelection
    {        
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            ClickHandler -= PanelAction;
            ClickHandler = null;

            if (disposing && (components != null))
            {
                panelFavoritePlayers.ControlAdded -= PanelFavoritePlayersAction;
                panelFavoritePlayers.ControlRemoved -= PanelFavoritePlayersAction;

                panelPlayerSelection.ControlAdded -= PanelPlayerSelectionAction;
                panelPlayerSelection.ControlRemoved -= PanelPlayerSelectionAction;

                panelPlayerSelection.DragLeave -= PanelPlayerSelection_DragLeave;
                panelPlayerSelection.DragEnter -= PanelPlayerSelection_DragEnter;
                panelPlayerSelection.DragDrop -= PanelPlayerSelection_DragDrop;

                panelFavoritePlayers.DragLeave -= PanelFavoritePlayers_DragLeave;
                panelFavoritePlayers.DragEnter -= PanelFavoritePlayers_DragEnter;
                panelFavoritePlayers.DragDrop -= PanelFavoritePlayers_DragDrop;

                components?.Dispose();
            }
            
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayerSelection));
            this.layoutOuter = new System.Windows.Forms.TableLayoutPanel();
            this.layoutInner = new System.Windows.Forms.TableLayoutPanel();
            this.layoutFavoritesMarks = new System.Windows.Forms.TableLayoutPanel();
            this.labelEmpty = new System.Windows.Forms.Label();
            this.labelFavoriteMarkImg = new System.Windows.Forms.Label();
            this.labelFavoriteMarkName = new System.Windows.Forms.Label();
            this.labelFavoriteMarkShirtNumber = new System.Windows.Forms.Label();
            this.labelFavoriteMarkPosition = new System.Windows.Forms.Label();
            this.labelFavoriteMarkCapetain = new System.Windows.Forms.Label();
            this.layoutInnerUpperRight = new System.Windows.Forms.TableLayoutPanel();
            this.labelFavorites = new System.Windows.Forms.Label();
            this.btnRemove = new System.Windows.Forms.Button();
            this.layoutBottomRight = new System.Windows.Forms.TableLayoutPanel();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.layoutInnerUpperLeft = new System.Windows.Forms.TableLayoutPanel();
            this.labelFavoriteTeam = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.panelPlayerSelection = new System.Windows.Forms.Panel();
            this.panelFavoritePlayers = new System.Windows.Forms.Panel();
            this.layoutBottomLeft = new System.Windows.Forms.TableLayoutPanel();
            this.btnShowRatings = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.layoutSelectionMarks = new System.Windows.Forms.TableLayoutPanel();
            this.labelSelectionMarkImg = new System.Windows.Forms.Label();
            this.labelSelectionMarkName = new System.Windows.Forms.Label();
            this.labelSelectionMarkShirtNumber = new System.Windows.Forms.Label();
            this.labelSelectionMarkPosition = new System.Windows.Forms.Label();
            this.labelSelectionMarkCapetain = new System.Windows.Forms.Label();
            this.labelTitle = new System.Windows.Forms.Label();
            this.layoutOuter.SuspendLayout();
            this.layoutInner.SuspendLayout();
            this.layoutFavoritesMarks.SuspendLayout();
            this.layoutInnerUpperRight.SuspendLayout();
            this.layoutBottomRight.SuspendLayout();
            this.layoutInnerUpperLeft.SuspendLayout();
            this.layoutBottomLeft.SuspendLayout();
            this.layoutSelectionMarks.SuspendLayout();
            this.SuspendLayout();
            // 
            // layoutOuter
            // 
            this.layoutOuter.ColumnCount = 1;
            this.layoutOuter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutOuter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.layoutOuter.Controls.Add(this.layoutInner, 0, 1);
            this.layoutOuter.Controls.Add(this.labelTitle, 0, 0);
            this.layoutOuter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutOuter.Location = new System.Drawing.Point(0, 0);
            this.layoutOuter.Name = "layoutOuter";
            this.layoutOuter.RowCount = 2;
            this.layoutOuter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.layoutOuter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 95F));
            this.layoutOuter.Size = new System.Drawing.Size(800, 450);
            this.layoutOuter.TabIndex = 0;
            // 
            // layoutInner
            // 
            this.layoutInner.ColumnCount = 2;
            this.layoutInner.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layoutInner.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layoutInner.Controls.Add(this.layoutFavoritesMarks, 1, 1);
            this.layoutInner.Controls.Add(this.layoutInnerUpperRight, 1, 0);
            this.layoutInner.Controls.Add(this.layoutBottomRight, 1, 3);
            this.layoutInner.Controls.Add(this.layoutInnerUpperLeft, 0, 0);
            this.layoutInner.Controls.Add(this.panelPlayerSelection, 0, 2);
            this.layoutInner.Controls.Add(this.panelFavoritePlayers, 1, 2);
            this.layoutInner.Controls.Add(this.layoutBottomLeft, 0, 3);
            this.layoutInner.Controls.Add(this.layoutSelectionMarks, 0, 1);
            this.layoutInner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutInner.Location = new System.Drawing.Point(0, 22);
            this.layoutInner.Margin = new System.Windows.Forms.Padding(0);
            this.layoutInner.Name = "layoutInner";
            this.layoutInner.RowCount = 4;
            this.layoutInner.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.layoutInner.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.layoutInner.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.layoutInner.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.layoutInner.Size = new System.Drawing.Size(800, 428);
            this.layoutInner.TabIndex = 4;
            // 
            // layoutFavoritesMarks
            // 
            this.layoutFavoritesMarks.AutoSize = true;
            this.layoutFavoritesMarks.BackColor = System.Drawing.Color.White;
            this.layoutFavoritesMarks.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Outset;
            this.layoutFavoritesMarks.ColumnCount = 6;
            this.layoutFavoritesMarks.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19F));
            this.layoutFavoritesMarks.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27F));
            this.layoutFavoritesMarks.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14F));
            this.layoutFavoritesMarks.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16F));
            this.layoutFavoritesMarks.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16F));
            this.layoutFavoritesMarks.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.layoutFavoritesMarks.Controls.Add(this.labelEmpty, 5, 0);
            this.layoutFavoritesMarks.Controls.Add(this.labelFavoriteMarkImg, 0, 0);
            this.layoutFavoritesMarks.Controls.Add(this.labelFavoriteMarkName, 1, 0);
            this.layoutFavoritesMarks.Controls.Add(this.labelFavoriteMarkShirtNumber, 2, 0);
            this.layoutFavoritesMarks.Controls.Add(this.labelFavoriteMarkPosition, 3, 0);
            this.layoutFavoritesMarks.Controls.Add(this.labelFavoriteMarkCapetain, 4, 0);
            this.layoutFavoritesMarks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutFavoritesMarks.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.layoutFavoritesMarks.Location = new System.Drawing.Point(415, 42);
            this.layoutFavoritesMarks.Margin = new System.Windows.Forms.Padding(15, 0, 25, 0);
            this.layoutFavoritesMarks.Name = "layoutFavoritesMarks";
            this.layoutFavoritesMarks.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.layoutFavoritesMarks.RowCount = 1;
            this.layoutFavoritesMarks.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutFavoritesMarks.Size = new System.Drawing.Size(360, 21);
            this.layoutFavoritesMarks.TabIndex = 9;
            // 
            // labelEmpty
            // 
            this.labelEmpty.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelEmpty.AutoSize = true;
            this.labelEmpty.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelEmpty.Location = new System.Drawing.Point(340, 2);
            this.labelEmpty.Margin = new System.Windows.Forms.Padding(0);
            this.labelEmpty.Name = "labelEmpty";
            this.labelEmpty.Size = new System.Drawing.Size(0, 17);
            this.labelEmpty.TabIndex = 5;
            // 
            // labelFavoriteMarkImg
            // 
            this.labelFavoriteMarkImg.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelFavoriteMarkImg.AutoSize = true;
            this.labelFavoriteMarkImg.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelFavoriteMarkImg.Location = new System.Drawing.Point(22, 2);
            this.labelFavoriteMarkImg.Margin = new System.Windows.Forms.Padding(0);
            this.labelFavoriteMarkImg.Name = "labelFavoriteMarkImg";
            this.labelFavoriteMarkImg.Size = new System.Drawing.Size(24, 17);
            this.labelFavoriteMarkImg.TabIndex = 0;
            this.labelFavoriteMarkImg.Text = "??";
            // 
            // labelFavoriteMarkName
            // 
            this.labelFavoriteMarkName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelFavoriteMarkName.AutoSize = true;
            this.labelFavoriteMarkName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelFavoriteMarkName.Location = new System.Drawing.Point(103, 2);
            this.labelFavoriteMarkName.Margin = new System.Windows.Forms.Padding(0);
            this.labelFavoriteMarkName.Name = "labelFavoriteMarkName";
            this.labelFavoriteMarkName.Size = new System.Drawing.Size(24, 17);
            this.labelFavoriteMarkName.TabIndex = 1;
            this.labelFavoriteMarkName.Text = "??";
            // 
            // labelFavoriteMarkShirtNumber
            // 
            this.labelFavoriteMarkShirtNumber.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelFavoriteMarkShirtNumber.AutoSize = true;
            this.labelFavoriteMarkShirtNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelFavoriteMarkShirtNumber.Location = new System.Drawing.Point(175, 2);
            this.labelFavoriteMarkShirtNumber.Margin = new System.Windows.Forms.Padding(0);
            this.labelFavoriteMarkShirtNumber.Name = "labelFavoriteMarkShirtNumber";
            this.labelFavoriteMarkShirtNumber.Size = new System.Drawing.Size(24, 17);
            this.labelFavoriteMarkShirtNumber.TabIndex = 2;
            this.labelFavoriteMarkShirtNumber.Text = "??";
            // 
            // labelFavoriteMarkPosition
            // 
            this.labelFavoriteMarkPosition.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelFavoriteMarkPosition.AutoSize = true;
            this.labelFavoriteMarkPosition.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelFavoriteMarkPosition.Location = new System.Drawing.Point(228, 2);
            this.labelFavoriteMarkPosition.Margin = new System.Windows.Forms.Padding(0);
            this.labelFavoriteMarkPosition.Name = "labelFavoriteMarkPosition";
            this.labelFavoriteMarkPosition.Size = new System.Drawing.Size(24, 17);
            this.labelFavoriteMarkPosition.TabIndex = 3;
            this.labelFavoriteMarkPosition.Text = "??";
            // 
            // labelFavoriteMarkCapetain
            // 
            this.labelFavoriteMarkCapetain.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelFavoriteMarkCapetain.AutoSize = true;
            this.labelFavoriteMarkCapetain.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelFavoriteMarkCapetain.Location = new System.Drawing.Point(284, 2);
            this.labelFavoriteMarkCapetain.Margin = new System.Windows.Forms.Padding(0);
            this.labelFavoriteMarkCapetain.Name = "labelFavoriteMarkCapetain";
            this.labelFavoriteMarkCapetain.Size = new System.Drawing.Size(24, 17);
            this.labelFavoriteMarkCapetain.TabIndex = 4;
            this.labelFavoriteMarkCapetain.Text = "??";
            // 
            // layoutInnerUpperRight
            // 
            this.layoutInnerUpperRight.ColumnCount = 2;
            this.layoutInnerUpperRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.layoutInnerUpperRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.layoutInnerUpperRight.Controls.Add(this.labelFavorites, 1, 0);
            this.layoutInnerUpperRight.Controls.Add(this.btnRemove, 0, 0);
            this.layoutInnerUpperRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutInnerUpperRight.Location = new System.Drawing.Point(400, 0);
            this.layoutInnerUpperRight.Margin = new System.Windows.Forms.Padding(0);
            this.layoutInnerUpperRight.Name = "layoutInnerUpperRight";
            this.layoutInnerUpperRight.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.layoutInnerUpperRight.RowCount = 1;
            this.layoutInnerUpperRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutInnerUpperRight.Size = new System.Drawing.Size(400, 42);
            this.layoutInnerUpperRight.TabIndex = 7;
            // 
            // labelFavorites
            // 
            this.labelFavorites.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelFavorites.AutoSize = true;
            this.labelFavorites.Location = new System.Drawing.Point(160, 17);
            this.labelFavorites.Margin = new System.Windows.Forms.Padding(0);
            this.labelFavorites.Name = "labelFavorites";
            this.labelFavorites.Size = new System.Drawing.Size(18, 20);
            this.labelFavorites.TabIndex = 8;
            this.labelFavorites.Text = "?";
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRemove.AutoSize = true;
            this.btnRemove.BackColor = System.Drawing.Color.White;
            this.btnRemove.BackgroundImage = global::WorldCup.WinForms.Properties.Resources.right_arrow_icon;
            this.btnRemove.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRemove.Location = new System.Drawing.Point(10, 0);
            this.btnRemove.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Padding = new System.Windows.Forms.Padding(5);
            this.btnRemove.Size = new System.Drawing.Size(75, 37);
            this.btnRemove.TabIndex = 9;
            this.btnRemove.UseVisualStyleBackColor = false;
            this.btnRemove.Click += new System.EventHandler(this.BtnArrowRight_Click);
            // 
            // layoutBottomRight
            // 
            this.layoutBottomRight.AutoSize = true;
            this.layoutBottomRight.ColumnCount = 2;
            this.layoutBottomRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layoutBottomRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layoutBottomRight.Controls.Add(this.btnExit, 1, 0);
            this.layoutBottomRight.Controls.Add(this.btnBack, 0, 0);
            this.layoutBottomRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutBottomRight.Location = new System.Drawing.Point(403, 387);
            this.layoutBottomRight.Margin = new System.Windows.Forms.Padding(3, 3, 25, 3);
            this.layoutBottomRight.Name = "layoutBottomRight";
            this.layoutBottomRight.RowCount = 1;
            this.layoutBottomRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutBottomRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.layoutBottomRight.Size = new System.Drawing.Size(372, 38);
            this.layoutBottomRight.TabIndex = 0;
            // 
            // btnExit
            // 
            this.btnExit.AutoSize = true;
            this.btnExit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExit.Location = new System.Drawing.Point(193, 7);
            this.btnExit.Margin = new System.Windows.Forms.Padding(7);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(172, 24);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "?";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // btnBack
            // 
            this.btnBack.AutoSize = true;
            this.btnBack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnBack.Location = new System.Drawing.Point(7, 7);
            this.btnBack.Margin = new System.Windows.Forms.Padding(7);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(172, 24);
            this.btnBack.TabIndex = 4;
            this.btnBack.Text = "?";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.BtnBack_Click);
            // 
            // layoutInnerUpperLeft
            // 
            this.layoutInnerUpperLeft.ColumnCount = 2;
            this.layoutInnerUpperLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60.00252F));
            this.layoutInnerUpperLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 39.99748F));
            this.layoutInnerUpperLeft.Controls.Add(this.labelFavoriteTeam, 0, 0);
            this.layoutInnerUpperLeft.Controls.Add(this.btnAdd, 1, 0);
            this.layoutInnerUpperLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutInnerUpperLeft.Location = new System.Drawing.Point(0, 0);
            this.layoutInnerUpperLeft.Margin = new System.Windows.Forms.Padding(0);
            this.layoutInnerUpperLeft.Name = "layoutInnerUpperLeft";
            this.layoutInnerUpperLeft.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.layoutInnerUpperLeft.RowCount = 1;
            this.layoutInnerUpperLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutInnerUpperLeft.Size = new System.Drawing.Size(400, 42);
            this.layoutInnerUpperLeft.TabIndex = 4;
            // 
            // labelFavoriteTeam
            // 
            this.labelFavoriteTeam.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelFavoriteTeam.AutoSize = true;
            this.labelFavoriteTeam.Location = new System.Drawing.Point(25, 17);
            this.labelFavoriteTeam.Margin = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.labelFavoriteTeam.Name = "labelFavoriteTeam";
            this.labelFavoriteTeam.Size = new System.Drawing.Size(18, 20);
            this.labelFavoriteTeam.TabIndex = 2;
            this.labelFavoriteTeam.Text = "?";
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.AutoSize = true;
            this.btnAdd.BackColor = System.Drawing.Color.White;
            this.btnAdd.BackgroundImage = global::WorldCup.WinForms.Properties.Resources.left_arrow_icon;
            this.btnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAdd.Location = new System.Drawing.Point(315, 0);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Padding = new System.Windows.Forms.Padding(5);
            this.btnAdd.Size = new System.Drawing.Size(75, 37);
            this.btnAdd.TabIndex = 10;
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.BtnArrowLeft_Click);
            // 
            // panelPlayerSelection
            // 
            this.panelPlayerSelection.AllowDrop = true;
            this.panelPlayerSelection.AutoScroll = true;
            this.panelPlayerSelection.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelPlayerSelection.BackColor = System.Drawing.Color.White;
            this.panelPlayerSelection.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelPlayerSelection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPlayerSelection.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panelPlayerSelection.Location = new System.Drawing.Point(25, 63);
            this.panelPlayerSelection.Margin = new System.Windows.Forms.Padding(25, 0, 15, 10);
            this.panelPlayerSelection.Name = "panelPlayerSelection";
            this.panelPlayerSelection.Size = new System.Drawing.Size(360, 311);
            this.panelPlayerSelection.TabIndex = 5;
            // 
            // panelFavoritePlayers
            // 
            this.panelFavoritePlayers.AllowDrop = true;
            this.panelFavoritePlayers.BackColor = System.Drawing.Color.White;
            this.panelFavoritePlayers.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelFavoritePlayers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFavoritePlayers.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panelFavoritePlayers.Location = new System.Drawing.Point(415, 63);
            this.panelFavoritePlayers.Margin = new System.Windows.Forms.Padding(15, 0, 25, 10);
            this.panelFavoritePlayers.Name = "panelFavoritePlayers";
            this.panelFavoritePlayers.Size = new System.Drawing.Size(360, 311);
            this.panelFavoritePlayers.TabIndex = 6;
            // 
            // layoutBottomLeft
            // 
            this.layoutBottomLeft.AutoSize = true;
            this.layoutBottomLeft.ColumnCount = 2;
            this.layoutBottomLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.63079F));
            this.layoutBottomLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.3692F));
            this.layoutBottomLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.layoutBottomLeft.Controls.Add(this.btnShowRatings, 1, 0);
            this.layoutBottomLeft.Controls.Add(this.btnSettings, 0, 0);
            this.layoutBottomLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutBottomLeft.Location = new System.Drawing.Point(3, 387);
            this.layoutBottomLeft.Name = "layoutBottomLeft";
            this.layoutBottomLeft.RowCount = 1;
            this.layoutBottomLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutBottomLeft.Size = new System.Drawing.Size(394, 38);
            this.layoutBottomLeft.TabIndex = 1;
            // 
            // btnShowRatings
            // 
            this.btnShowRatings.AutoSize = true;
            this.btnShowRatings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnShowRatings.Location = new System.Drawing.Point(207, 0);
            this.btnShowRatings.Margin = new System.Windows.Forms.Padding(75, 0, 75, 7);
            this.btnShowRatings.Name = "btnShowRatings";
            this.btnShowRatings.Size = new System.Drawing.Size(112, 31);
            this.btnShowRatings.TabIndex = 1;
            this.btnShowRatings.Text = "?";
            this.btnShowRatings.UseVisualStyleBackColor = true;
            this.btnShowRatings.Click += new System.EventHandler(this.BtnShowRatings_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.AutoSize = true;
            this.btnSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSettings.Location = new System.Drawing.Point(25, 7);
            this.btnSettings.Margin = new System.Windows.Forms.Padding(25, 7, 50, 7);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(57, 24);
            this.btnSettings.TabIndex = 3;
            this.btnSettings.Text = "?";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.BtnSettings_Click);
            // 
            // layoutSelectionMarks
            // 
            this.layoutSelectionMarks.BackColor = System.Drawing.Color.White;
            this.layoutSelectionMarks.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Outset;
            this.layoutSelectionMarks.ColumnCount = 6;
            this.layoutSelectionMarks.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19F));
            this.layoutSelectionMarks.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.3F));
            this.layoutSelectionMarks.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14F));
            this.layoutSelectionMarks.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17F));
            this.layoutSelectionMarks.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16F));
            this.layoutSelectionMarks.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.7F));
            this.layoutSelectionMarks.Controls.Add(this.labelSelectionMarkImg, 0, 0);
            this.layoutSelectionMarks.Controls.Add(this.labelSelectionMarkName, 1, 0);
            this.layoutSelectionMarks.Controls.Add(this.labelSelectionMarkShirtNumber, 2, 0);
            this.layoutSelectionMarks.Controls.Add(this.labelSelectionMarkPosition, 3, 0);
            this.layoutSelectionMarks.Controls.Add(this.labelSelectionMarkCapetain, 4, 0);
            this.layoutSelectionMarks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutSelectionMarks.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.layoutSelectionMarks.Location = new System.Drawing.Point(25, 42);
            this.layoutSelectionMarks.Margin = new System.Windows.Forms.Padding(25, 0, 15, 0);
            this.layoutSelectionMarks.Name = "layoutSelectionMarks";
            this.layoutSelectionMarks.RowCount = 1;
            this.layoutSelectionMarks.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutSelectionMarks.Size = new System.Drawing.Size(360, 21);
            this.layoutSelectionMarks.TabIndex = 8;
            // 
            // labelSelectionMarkImg
            // 
            this.labelSelectionMarkImg.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelSelectionMarkImg.AutoSize = true;
            this.labelSelectionMarkImg.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelSelectionMarkImg.Location = new System.Drawing.Point(22, 2);
            this.labelSelectionMarkImg.Margin = new System.Windows.Forms.Padding(0);
            this.labelSelectionMarkImg.Name = "labelSelectionMarkImg";
            this.labelSelectionMarkImg.Size = new System.Drawing.Size(24, 17);
            this.labelSelectionMarkImg.TabIndex = 0;
            this.labelSelectionMarkImg.Text = "??";
            // 
            // labelSelectionMarkName
            // 
            this.labelSelectionMarkName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelSelectionMarkName.AutoSize = true;
            this.labelSelectionMarkName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelSelectionMarkName.Location = new System.Drawing.Point(107, 2);
            this.labelSelectionMarkName.Margin = new System.Windows.Forms.Padding(0);
            this.labelSelectionMarkName.Name = "labelSelectionMarkName";
            this.labelSelectionMarkName.Size = new System.Drawing.Size(24, 17);
            this.labelSelectionMarkName.TabIndex = 1;
            this.labelSelectionMarkName.Text = "??";
            // 
            // labelSelectionMarkShirtNumber
            // 
            this.labelSelectionMarkShirtNumber.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelSelectionMarkShirtNumber.AutoSize = true;
            this.labelSelectionMarkShirtNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelSelectionMarkShirtNumber.Location = new System.Drawing.Point(184, 2);
            this.labelSelectionMarkShirtNumber.Margin = new System.Windows.Forms.Padding(0);
            this.labelSelectionMarkShirtNumber.Name = "labelSelectionMarkShirtNumber";
            this.labelSelectionMarkShirtNumber.Size = new System.Drawing.Size(24, 17);
            this.labelSelectionMarkShirtNumber.TabIndex = 2;
            this.labelSelectionMarkShirtNumber.Text = "??";
            // 
            // labelSelectionMarkPosition
            // 
            this.labelSelectionMarkPosition.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelSelectionMarkPosition.AutoSize = true;
            this.labelSelectionMarkPosition.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelSelectionMarkPosition.Location = new System.Drawing.Point(239, 2);
            this.labelSelectionMarkPosition.Margin = new System.Windows.Forms.Padding(0);
            this.labelSelectionMarkPosition.Name = "labelSelectionMarkPosition";
            this.labelSelectionMarkPosition.Size = new System.Drawing.Size(24, 17);
            this.labelSelectionMarkPosition.TabIndex = 3;
            this.labelSelectionMarkPosition.Text = "??";
            // 
            // labelSelectionMarkCapetain
            // 
            this.labelSelectionMarkCapetain.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelSelectionMarkCapetain.AutoSize = true;
            this.labelSelectionMarkCapetain.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelSelectionMarkCapetain.Location = new System.Drawing.Point(297, 2);
            this.labelSelectionMarkCapetain.Margin = new System.Windows.Forms.Padding(0);
            this.labelSelectionMarkCapetain.Name = "labelSelectionMarkCapetain";
            this.labelSelectionMarkCapetain.Size = new System.Drawing.Size(24, 17);
            this.labelSelectionMarkCapetain.TabIndex = 4;
            this.labelSelectionMarkCapetain.Text = "??";
            // 
            // labelTitle
            // 
            this.labelTitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelTitle.AutoSize = true;
            this.labelTitle.Location = new System.Drawing.Point(391, 10);
            this.labelTitle.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(18, 12);
            this.labelTitle.TabIndex = 5;
            this.labelTitle.Text = "?";
            // 
            // PlayerSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.layoutOuter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "PlayerSelection";
            this.Opacity = 1D;
            this.Text = "";
            this.Load += new System.EventHandler(this.PlayerSelection_Load);
            this.layoutOuter.ResumeLayout(false);
            this.layoutOuter.PerformLayout();
            this.layoutInner.ResumeLayout(false);
            this.layoutInner.PerformLayout();
            this.layoutFavoritesMarks.ResumeLayout(false);
            this.layoutFavoritesMarks.PerformLayout();
            this.layoutInnerUpperRight.ResumeLayout(false);
            this.layoutInnerUpperRight.PerformLayout();
            this.layoutBottomRight.ResumeLayout(false);
            this.layoutBottomRight.PerformLayout();
            this.layoutInnerUpperLeft.ResumeLayout(false);
            this.layoutInnerUpperLeft.PerformLayout();
            this.layoutBottomLeft.ResumeLayout(false);
            this.layoutBottomLeft.PerformLayout();
            this.layoutSelectionMarks.ResumeLayout(false);
            this.layoutSelectionMarks.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        private TableLayoutPanel layoutInnerUpperRight;
        private TableLayoutPanel layoutSelectionMarks;
        private TableLayoutPanel layoutFavoritesMarks;
        private TableLayoutPanel layoutInnerUpperLeft;
        private TableLayoutPanel layoutBottomRight;
        private TableLayoutPanel layoutBottomLeft;
        private TableLayoutPanel layoutOuter;
        private TableLayoutPanel layoutInner;
        private Button btnShowRatings;
        private Button btnSettings;
        private Button btnRemove;
        private Button btnBack;
        private Button btnExit;
        private Button btnAdd;
        private Label labelSelectionMarkShirtNumber;
        private Label labelFavoriteMarkShirtNumber;
        private Label labelSelectionMarkPosition;
        private Label labelSelectionMarkCapetain;
        private Label labelFavoriteMarkCapetain;
        private Label labelFavoriteMarkPosition;
        private Label labelSelectionMarkName;
        private Label labelFavoriteMarkName;
        private Label labelSelectionMarkImg;
        private Panel panelPlayerSelection;
        private Panel panelFavoritePlayers;
        private Label labelFavoriteMarkImg;
        private Label labelFavoriteTeam;
        private Label labelFavorites;
        private Label labelTitle;
        private Label labelEmpty;
    }
}