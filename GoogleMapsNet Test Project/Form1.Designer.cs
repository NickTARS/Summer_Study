namespace GoogleMapsNet_Test_Project
{
    partial class Form1
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
            this.buttonClose = new System.Windows.Forms.Button();
            this.groupBoxInfo = new System.Windows.Forms.GroupBox();
            this.buttonCalculateElevation = new System.Windows.Forms.Button();
            this.buttonCalculateDistance = new System.Windows.Forms.Button();
            this.buttonClearRoutes = new System.Windows.Forms.Button();
            this.buttonAddRoute = new System.Windows.Forms.Button();
            this.textBoxDestination = new System.Windows.Forms.TextBox();
            this.labelDestination = new System.Windows.Forms.Label();
            this.textBoxOrigin = new System.Windows.Forms.TextBox();
            this.labelOrigin = new System.Windows.Forms.Label();
            this.checkBoxShowCenter = new System.Windows.Forms.CheckBox();
            this.buttonClearMarkers = new System.Windows.Forms.Button();
            this.checkBoxShowGrid = new System.Windows.Forms.CheckBox();
            this.buttonFindAddresses = new System.Windows.Forms.Button();
            this.buttonGoToLocation = new System.Windows.Forms.Button();
            this.dataGridViewDetails = new System.Windows.Forms.DataGridView();
            this.buttonAddMarker = new System.Windows.Forms.Button();
            this.numericUpDownZoom = new System.Windows.Forms.NumericUpDown();
            this.radioButtonHybridTerrain = new System.Windows.Forms.RadioButton();
            this.radioButtonHybridSatellite = new System.Windows.Forms.RadioButton();
            this.radioButtonTerrain = new System.Windows.Forms.RadioButton();
            this.radioButtonSatellite = new System.Windows.Forms.RadioButton();
            this.radioButtonRoadmap = new System.Windows.Forms.RadioButton();
            this.labelZoom = new System.Windows.Forms.Label();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.textBoxLat = new System.Windows.Forms.TextBox();
            this.labelLat = new System.Windows.Forms.Label();
            this.textBoxLong = new System.Windows.Forms.TextBox();
            this.labelLong = new System.Windows.Forms.Label();
            this.groupBoxInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownZoom)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonClose
            // 
            this.buttonClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClose.Location = new System.Drawing.Point(326, 506);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(93, 28);
            this.buttonClose.TabIndex = 0;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // groupBoxInfo
            // 
            this.groupBoxInfo.Controls.Add(this.buttonCalculateElevation);
            this.groupBoxInfo.Controls.Add(this.buttonCalculateDistance);
            this.groupBoxInfo.Controls.Add(this.buttonClearRoutes);
            this.groupBoxInfo.Controls.Add(this.buttonAddRoute);
            this.groupBoxInfo.Controls.Add(this.textBoxDestination);
            this.groupBoxInfo.Controls.Add(this.labelDestination);
            this.groupBoxInfo.Controls.Add(this.textBoxOrigin);
            this.groupBoxInfo.Controls.Add(this.labelOrigin);
            this.groupBoxInfo.Controls.Add(this.checkBoxShowCenter);
            this.groupBoxInfo.Controls.Add(this.buttonClearMarkers);
            this.groupBoxInfo.Controls.Add(this.buttonClose);
            this.groupBoxInfo.Controls.Add(this.checkBoxShowGrid);
            this.groupBoxInfo.Controls.Add(this.buttonFindAddresses);
            this.groupBoxInfo.Controls.Add(this.buttonGoToLocation);
            this.groupBoxInfo.Controls.Add(this.dataGridViewDetails);
            this.groupBoxInfo.Controls.Add(this.buttonAddMarker);
            this.groupBoxInfo.Controls.Add(this.numericUpDownZoom);
            this.groupBoxInfo.Controls.Add(this.radioButtonHybridTerrain);
            this.groupBoxInfo.Controls.Add(this.radioButtonHybridSatellite);
            this.groupBoxInfo.Controls.Add(this.radioButtonTerrain);
            this.groupBoxInfo.Controls.Add(this.radioButtonSatellite);
            this.groupBoxInfo.Controls.Add(this.radioButtonRoadmap);
            this.groupBoxInfo.Controls.Add(this.labelZoom);
            this.groupBoxInfo.Controls.Add(this.buttonRefresh);
            this.groupBoxInfo.Controls.Add(this.textBoxLat);
            this.groupBoxInfo.Controls.Add(this.labelLat);
            this.groupBoxInfo.Controls.Add(this.textBoxLong);
            this.groupBoxInfo.Controls.Add(this.labelLong);
            this.groupBoxInfo.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBoxInfo.Location = new System.Drawing.Point(527, 0);
            this.groupBoxInfo.Name = "groupBoxInfo";
            this.groupBoxInfo.Size = new System.Drawing.Size(425, 546);
            this.groupBoxInfo.TabIndex = 2;
            this.groupBoxInfo.TabStop = false;
            this.groupBoxInfo.Text = "GoogleMapsNet params";
            // 
            // buttonCalculateElevation
            // 
            this.buttonCalculateElevation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCalculateElevation.Location = new System.Drawing.Point(248, 226);
            this.buttonCalculateElevation.Name = "buttonCalculateElevation";
            this.buttonCalculateElevation.Size = new System.Drawing.Size(140, 28);
            this.buttonCalculateElevation.TabIndex = 30;
            this.buttonCalculateElevation.Text = "Elevation";
            this.buttonCalculateElevation.UseVisualStyleBackColor = true;
            this.buttonCalculateElevation.Click += new System.EventHandler(this.buttonCalculateElevation_Click);
            // 
            // buttonCalculateDistance
            // 
            this.buttonCalculateDistance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCalculateDistance.Location = new System.Drawing.Point(248, 194);
            this.buttonCalculateDistance.Name = "buttonCalculateDistance";
            this.buttonCalculateDistance.Size = new System.Drawing.Size(140, 28);
            this.buttonCalculateDistance.TabIndex = 29;
            this.buttonCalculateDistance.Text = "Distance";
            this.buttonCalculateDistance.UseVisualStyleBackColor = true;
            this.buttonCalculateDistance.Click += new System.EventHandler(this.buttonCalculateDistance_Click);
            // 
            // buttonClearRoutes
            // 
            this.buttonClearRoutes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClearRoutes.Location = new System.Drawing.Point(38, 506);
            this.buttonClearRoutes.Name = "buttonClearRoutes";
            this.buttonClearRoutes.Size = new System.Drawing.Size(140, 28);
            this.buttonClearRoutes.TabIndex = 29;
            this.buttonClearRoutes.Text = "Clear routes...";
            this.buttonClearRoutes.UseVisualStyleBackColor = true;
            this.buttonClearRoutes.Click += new System.EventHandler(this.buttonClearRoutes_Click);
            // 
            // buttonAddRoute
            // 
            this.buttonAddRoute.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAddRoute.Location = new System.Drawing.Point(248, 161);
            this.buttonAddRoute.Name = "buttonAddRoute";
            this.buttonAddRoute.Size = new System.Drawing.Size(140, 28);
            this.buttonAddRoute.TabIndex = 28;
            this.buttonAddRoute.Text = "Direction";
            this.buttonAddRoute.UseVisualStyleBackColor = true;
            this.buttonAddRoute.Click += new System.EventHandler(this.buttonAddRoute_Click);
            // 
            // textBoxDestination
            // 
            this.textBoxDestination.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxDestination.Location = new System.Drawing.Point(98, 210);
            this.textBoxDestination.Name = "textBoxDestination";
            this.textBoxDestination.Size = new System.Drawing.Size(144, 20);
            this.textBoxDestination.TabIndex = 27;
            this.textBoxDestination.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelDestination
            // 
            this.labelDestination.AutoSize = true;
            this.labelDestination.Location = new System.Drawing.Point(54, 212);
            this.labelDestination.Name = "labelDestination";
            this.labelDestination.Size = new System.Drawing.Size(34, 12);
            this.labelDestination.TabIndex = 26;
            this.labelDestination.Text = "Dest:";
            // 
            // textBoxOrigin
            // 
            this.textBoxOrigin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxOrigin.Location = new System.Drawing.Point(97, 186);
            this.textBoxOrigin.Name = "textBoxOrigin";
            this.textBoxOrigin.Size = new System.Drawing.Size(145, 20);
            this.textBoxOrigin.TabIndex = 25;
            this.textBoxOrigin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelOrigin
            // 
            this.labelOrigin.AutoSize = true;
            this.labelOrigin.Location = new System.Drawing.Point(48, 189);
            this.labelOrigin.Name = "labelOrigin";
            this.labelOrigin.Size = new System.Drawing.Size(42, 12);
            this.labelOrigin.TabIndex = 24;
            this.labelOrigin.Text = "Origin:";
            // 
            // checkBoxShowCenter
            // 
            this.checkBoxShowCenter.AutoSize = true;
            this.checkBoxShowCenter.Location = new System.Drawing.Point(303, 139);
            this.checkBoxShowCenter.Name = "checkBoxShowCenter";
            this.checkBoxShowCenter.Size = new System.Drawing.Size(95, 16);
            this.checkBoxShowCenter.TabIndex = 22;
            this.checkBoxShowCenter.Text = "Show center";
            this.checkBoxShowCenter.UseVisualStyleBackColor = true;
            this.checkBoxShowCenter.CheckedChanged += new System.EventHandler(this.checkBoxShowCenter_CheckedChanged);
            // 
            // buttonClearMarkers
            // 
            this.buttonClearMarkers.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClearMarkers.Location = new System.Drawing.Point(181, 506);
            this.buttonClearMarkers.Name = "buttonClearMarkers";
            this.buttonClearMarkers.Size = new System.Drawing.Size(140, 28);
            this.buttonClearMarkers.TabIndex = 21;
            this.buttonClearMarkers.Text = "Clear markers...";
            this.buttonClearMarkers.UseVisualStyleBackColor = true;
            this.buttonClearMarkers.Click += new System.EventHandler(this.buttonClearMarkers_Click);
            // 
            // checkBoxShowGrid
            // 
            this.checkBoxShowGrid.AutoSize = true;
            this.checkBoxShowGrid.Location = new System.Drawing.Point(303, 118);
            this.checkBoxShowGrid.Name = "checkBoxShowGrid";
            this.checkBoxShowGrid.Size = new System.Drawing.Size(81, 16);
            this.checkBoxShowGrid.TabIndex = 20;
            this.checkBoxShowGrid.Text = "Show grid";
            this.checkBoxShowGrid.UseVisualStyleBackColor = true;
            this.checkBoxShowGrid.CheckedChanged += new System.EventHandler(this.checkBoxShowGrid_CheckedChanged);
            // 
            // buttonFindAddresses
            // 
            this.buttonFindAddresses.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFindAddresses.Location = new System.Drawing.Point(248, 82);
            this.buttonFindAddresses.Name = "buttonFindAddresses";
            this.buttonFindAddresses.Size = new System.Drawing.Size(140, 28);
            this.buttonFindAddresses.TabIndex = 19;
            this.buttonFindAddresses.Text = "Find addresses";
            this.buttonFindAddresses.UseVisualStyleBackColor = true;
            this.buttonFindAddresses.Click += new System.EventHandler(this.buttonFindAddresses_Click);
            // 
            // buttonGoToLocation
            // 
            this.buttonGoToLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGoToLocation.Location = new System.Drawing.Point(248, 49);
            this.buttonGoToLocation.Name = "buttonGoToLocation";
            this.buttonGoToLocation.Size = new System.Drawing.Size(140, 28);
            this.buttonGoToLocation.TabIndex = 18;
            this.buttonGoToLocation.Text = "Go to location";
            this.buttonGoToLocation.UseVisualStyleBackColor = true;
            this.buttonGoToLocation.Click += new System.EventHandler(this.buttonGoToLocation_Click);
            // 
            // dataGridViewDetails
            // 
            this.dataGridViewDetails.AllowUserToAddRows = false;
            this.dataGridViewDetails.AllowUserToDeleteRows = false;
            this.dataGridViewDetails.AllowUserToOrderColumns = true;
            this.dataGridViewDetails.AllowUserToResizeRows = false;
            this.dataGridViewDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDetails.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewDetails.Location = new System.Drawing.Point(38, 297);
            this.dataGridViewDetails.MultiSelect = false;
            this.dataGridViewDetails.Name = "dataGridViewDetails";
            this.dataGridViewDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewDetails.Size = new System.Drawing.Size(350, 203);
            this.dataGridViewDetails.TabIndex = 17;
            // 
            // buttonAddMarker
            // 
            this.buttonAddMarker.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAddMarker.Location = new System.Drawing.Point(248, 16);
            this.buttonAddMarker.Name = "buttonAddMarker";
            this.buttonAddMarker.Size = new System.Drawing.Size(140, 28);
            this.buttonAddMarker.TabIndex = 13;
            this.buttonAddMarker.Text = "Add marker";
            this.buttonAddMarker.UseVisualStyleBackColor = true;
            this.buttonAddMarker.Click += new System.EventHandler(this.buttonAddMarker_Click);
            // 
            // numericUpDownZoom
            // 
            this.numericUpDownZoom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownZoom.Location = new System.Drawing.Point(98, 74);
            this.numericUpDownZoom.Maximum = new decimal(new int[] {
            17,
            0,
            0,
            0});
            this.numericUpDownZoom.Name = "numericUpDownZoom";
            this.numericUpDownZoom.ReadOnly = true;
            this.numericUpDownZoom.Size = new System.Drawing.Size(144, 20);
            this.numericUpDownZoom.TabIndex = 12;
            this.numericUpDownZoom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // radioButtonHybridTerrain
            // 
            this.radioButtonHybridTerrain.AutoSize = true;
            this.radioButtonHybridTerrain.Location = new System.Drawing.Point(181, 138);
            this.radioButtonHybridTerrain.Name = "radioButtonHybridTerrain";
            this.radioButtonHybridTerrain.Size = new System.Drawing.Size(99, 16);
            this.radioButtonHybridTerrain.TabIndex = 11;
            this.radioButtonHybridTerrain.Text = "HybridTerrain";
            this.radioButtonHybridTerrain.UseVisualStyleBackColor = true;
            // 
            // radioButtonHybridSatellite
            // 
            this.radioButtonHybridSatellite.AutoSize = true;
            this.radioButtonHybridSatellite.Location = new System.Drawing.Point(51, 138);
            this.radioButtonHybridSatellite.Name = "radioButtonHybridSatellite";
            this.radioButtonHybridSatellite.Size = new System.Drawing.Size(103, 16);
            this.radioButtonHybridSatellite.TabIndex = 10;
            this.radioButtonHybridSatellite.Text = "HybridSatellite";
            this.radioButtonHybridSatellite.UseVisualStyleBackColor = true;
            // 
            // radioButtonTerrain
            // 
            this.radioButtonTerrain.AutoSize = true;
            this.radioButtonTerrain.Location = new System.Drawing.Point(220, 117);
            this.radioButtonTerrain.Name = "radioButtonTerrain";
            this.radioButtonTerrain.Size = new System.Drawing.Size(63, 16);
            this.radioButtonTerrain.TabIndex = 9;
            this.radioButtonTerrain.Text = "Terrain";
            this.radioButtonTerrain.UseVisualStyleBackColor = true;
            // 
            // radioButtonSatellite
            // 
            this.radioButtonSatellite.AutoSize = true;
            this.radioButtonSatellite.Location = new System.Drawing.Point(141, 117);
            this.radioButtonSatellite.Name = "radioButtonSatellite";
            this.radioButtonSatellite.Size = new System.Drawing.Size(67, 16);
            this.radioButtonSatellite.TabIndex = 8;
            this.radioButtonSatellite.Text = "Satellite";
            this.radioButtonSatellite.UseVisualStyleBackColor = true;
            // 
            // radioButtonRoadmap
            // 
            this.radioButtonRoadmap.AutoSize = true;
            this.radioButtonRoadmap.Checked = true;
            this.radioButtonRoadmap.Location = new System.Drawing.Point(51, 117);
            this.radioButtonRoadmap.Name = "radioButtonRoadmap";
            this.radioButtonRoadmap.Size = new System.Drawing.Size(77, 16);
            this.radioButtonRoadmap.TabIndex = 7;
            this.radioButtonRoadmap.TabStop = true;
            this.radioButtonRoadmap.Text = "Roadmap";
            this.radioButtonRoadmap.UseVisualStyleBackColor = true;
            // 
            // labelZoom
            // 
            this.labelZoom.AutoSize = true;
            this.labelZoom.Location = new System.Drawing.Point(48, 76);
            this.labelZoom.Name = "labelZoom";
            this.labelZoom.Size = new System.Drawing.Size(42, 12);
            this.labelZoom.TabIndex = 5;
            this.labelZoom.Text = "Zoom:";
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRefresh.Location = new System.Drawing.Point(38, 263);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(350, 28);
            this.buttonRefresh.TabIndex = 4;
            this.buttonRefresh.Text = "GO!";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // textBoxLat
            // 
            this.textBoxLat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxLat.Location = new System.Drawing.Point(98, 49);
            this.textBoxLat.Name = "textBoxLat";
            this.textBoxLat.Size = new System.Drawing.Size(144, 20);
            this.textBoxLat.TabIndex = 3;
            this.textBoxLat.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelLat
            // 
            this.labelLat.AutoSize = true;
            this.labelLat.Location = new System.Drawing.Point(35, 52);
            this.labelLat.Name = "labelLat";
            this.labelLat.Size = new System.Drawing.Size(53, 12);
            this.labelLat.TabIndex = 2;
            this.labelLat.Text = "Latitude:";
            // 
            // textBoxLong
            // 
            this.textBoxLong.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxLong.Location = new System.Drawing.Point(98, 25);
            this.textBoxLong.Name = "textBoxLong";
            this.textBoxLong.Size = new System.Drawing.Size(144, 20);
            this.textBoxLong.TabIndex = 1;
            this.textBoxLong.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelLong
            // 
            this.labelLong.AutoSize = true;
            this.labelLong.Location = new System.Drawing.Point(24, 28);
            this.labelLong.Name = "labelLong";
            this.labelLong.Size = new System.Drawing.Size(64, 12);
            this.labelLong.TabIndex = 0;
            this.labelLong.Text = "Longitude:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(952, 546);
            this.Controls.Add(this.groupBoxInfo);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GoogleMapsNet Test Project";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.groupBoxInfo.ResumeLayout(false);
            this.groupBoxInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownZoom)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.GroupBox groupBoxInfo;
        private System.Windows.Forms.TextBox textBoxLong;
        private System.Windows.Forms.Label labelLong;
        private System.Windows.Forms.TextBox textBoxLat;
        private System.Windows.Forms.Label labelLat;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.Label labelZoom;
        private System.Windows.Forms.RadioButton radioButtonRoadmap;
        private System.Windows.Forms.RadioButton radioButtonHybridSatellite;
        private System.Windows.Forms.RadioButton radioButtonTerrain;
        private System.Windows.Forms.RadioButton radioButtonSatellite;
        private System.Windows.Forms.RadioButton radioButtonHybridTerrain;
        private System.Windows.Forms.NumericUpDown numericUpDownZoom;
        private System.Windows.Forms.Button buttonAddMarker;
        private System.Windows.Forms.DataGridView dataGridViewDetails;
        private System.Windows.Forms.Button buttonGoToLocation;
        private System.Windows.Forms.Button buttonFindAddresses;
        private System.Windows.Forms.CheckBox checkBoxShowGrid;
        private System.Windows.Forms.Button buttonClearMarkers;
        private System.Windows.Forms.CheckBox checkBoxShowCenter;
        private System.Windows.Forms.TextBox textBoxDestination;
        private System.Windows.Forms.Label labelDestination;
        private System.Windows.Forms.TextBox textBoxOrigin;
        private System.Windows.Forms.Label labelOrigin;
        private System.Windows.Forms.Button buttonAddRoute;
        private System.Windows.Forms.Button buttonClearRoutes;
        private System.Windows.Forms.Button buttonCalculateDistance;
        private System.Windows.Forms.Button buttonCalculateElevation;
    }
}

