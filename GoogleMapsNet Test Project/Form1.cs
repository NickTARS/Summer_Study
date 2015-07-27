using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GoogleMaps;


namespace GoogleMapsNet_Test_Project
{
    public partial class Form1 : Form
    {
        private GoogleMapsNet googleMapsNet1 = null;

        public Form1()
        {
            InitializeComponent();

            googleMapsNet1 = new GoogleMapsNet();
            googleMapsNet1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            googleMapsNet1.Latitude = 0;
            googleMapsNet1.Location = new System.Drawing.Point(12, 12);
            googleMapsNet1.Longitude = 0;
            googleMapsNet1.Name = "googleMapsNet1";
            googleMapsNet1.ShowGrid = false;
            googleMapsNet1.Size = new System.Drawing.Size(1024, 768);
            googleMapsNet1.TabIndex = 1;
            googleMapsNet1.LongitudeChanged += new System.EventHandler(this.googleMapsNet1_LongitudeChanged);
            googleMapsNet1.LatitudeChanged += new System.EventHandler(this.googleMapsNet1_LatitudeChanged);
            googleMapsNet1.ZoomChanged += new System.EventHandler(this.googleMapsNet1_ZoomChanged);
            googleMapsNet1.Dock = DockStyle.Left;
            this.Controls.Add(googleMapsNet1);

            textBoxLong.Text = "21.896328";
            textBoxLat.Text = "43.31938";
            numericUpDownZoom.Value = 8;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            // Check params
            if (textBoxLong.Text.Trim() != "")
            {
                if (textBoxLat.Text.Trim() != "")
                {
                    MapType mapType = MapType.MapTypeRoadmap;
                    if (radioButtonSatellite.Checked == true)
                    {
                        mapType = MapType.MapTypeSatellite;
                    }
                    else if (radioButtonTerrain.Checked == true)
                    {
                        mapType = MapType.MapTypeTerrain;
                    }
                    else if (radioButtonHybridSatellite.Checked == true)
                    {
                        mapType = MapType.MapTypeHybridSatellite;
                    }
                    else if (radioButtonHybridTerrain.Checked == true)
                    {
                        mapType = MapType.MapTypeHybridTerrain;
                    }

                    // Show map
                    googleMapsNet1.ShowMap(mapType, Convert.ToDouble(textBoxLong.Text.Trim()), Convert.ToDouble(textBoxLat.Text.Trim()), Convert.ToDouble(numericUpDownZoom.Value));
                }
                else
                {
                    MessageBox.Show("You have to enter the latitude !!!", "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("You have to enter the longitude !!!", "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonAddMarker_Click(object sender, EventArgs e)
        {
            // Check params
            if (textBoxLong.Text.Trim() != "")
            {
                if (textBoxLat.Text.Trim() != "")
                {
                    // Add marker
                    googleMapsNet1.AddMarker(Convert.ToDouble(textBoxLong.Text.Trim()), Convert.ToDouble(textBoxLat.Text.Trim()), Convert.ToDouble(numericUpDownZoom.Value));
                }
                else
                {
                    MessageBox.Show("You have to enter the latitude !!!", "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("You have to enter the longitude !!!", "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void buttonGoToLocation_Click(object sender, EventArgs e)
        {
            if ((dataGridViewDetails.SelectedRows != null) && (dataGridViewDetails.SelectedRows.Count > 0))
            {
                int iRow = dataGridViewDetails.SelectedCells[0].RowIndex;
                DataTable table = (DataTable)dataGridViewDetails.DataSource;
                textBoxLong.Text = table.Rows[iRow]["Longitude"].ToString().Trim();
                textBoxLat.Text = table.Rows[iRow]["Latitude"].ToString().Trim();

                MapType mapType = MapType.MapTypeRoadmap;
                if (radioButtonSatellite.Checked == true)
                {
                    mapType = MapType.MapTypeSatellite;
                }
                else if (radioButtonTerrain.Checked == true)
                {
                    mapType = MapType.MapTypeTerrain;
                }
                else if (radioButtonHybridSatellite.Checked == true)
                {
                    mapType = MapType.MapTypeHybridSatellite;
                }
                else if (radioButtonHybridTerrain.Checked == true)
                {
                    mapType = MapType.MapTypeHybridTerrain;
                }

                // Show map
                googleMapsNet1.ShowMap(mapType, Convert.ToDouble(textBoxLong.Text.Trim()), Convert.ToDouble(textBoxLat.Text.Trim()), Convert.ToDouble(numericUpDownZoom.Value));
            }
        }

        private void buttonFindAddresses_Click(object sender, EventArgs e)
        {
            // Check params
            if (textBoxLong.Text.Trim() != "")
            {
                if (textBoxLat.Text.Trim() != "")
                {
                    // Show addresses based on location
                    DataTable table = googleMapsNet1.LongitudeLatitudeToAddress(Convert.ToDouble(textBoxLong.Text.Trim()), Convert.ToDouble(textBoxLat.Text.Trim()));
                    dataGridViewDetails.DataSource = table;
                }
                else
                {
                    MessageBox.Show("You have to enter the latitude !!!", "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("You have to enter the longitude !!!", "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkBoxShowGrid_CheckedChanged(object sender, EventArgs e)
        {
            googleMapsNet1.ShowGrid = checkBoxShowGrid.Checked;
            googleMapsNet1.Refresh();
        }

        private void buttonClearMarkers_Click(object sender, EventArgs e)
        {
            googleMapsNet1.ClearMarkers();
        }

        private void googleMapsNet1_LongitudeChanged(object sender, EventArgs e)
        {
            textBoxLong.Text = googleMapsNet1.Longitude.ToString();
        }

        private void googleMapsNet1_LatitudeChanged(object sender, EventArgs e)
        {
            textBoxLat.Text = googleMapsNet1.Latitude.ToString();
        }

        private void googleMapsNet1_ZoomChanged(object sender, EventArgs e)
        {
            numericUpDownZoom.Value = Convert.ToDecimal(googleMapsNet1.Zoom.ToString());
        }

        private void checkBoxShowCenter_CheckedChanged(object sender, EventArgs e)
        {
            googleMapsNet1.ShowCenter = checkBoxShowCenter.Checked;
            googleMapsNet1.Refresh();
        }

        private void buttonAddRoute_Click(object sender, EventArgs e)
        {
            // Check params
            if (textBoxOrigin.Text.Trim() != "")
            {
                if (textBoxDestination.Text.Trim() != "")
                {
                    // Add route
                    DataTable table = googleMapsNet1.AddRoute(textBoxOrigin.Text.Trim(), textBoxDestination.Text.Trim());
                    dataGridViewDetails.DataSource = table;
                }
                else
                {
                    MessageBox.Show("You have to enter the destination !!!", "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("You have to enter the origin !!!", "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonClearRoutes_Click(object sender, EventArgs e)
        {
            googleMapsNet1.ClearRoutes();
        }

        private void buttonCalculateDistance_Click(object sender, EventArgs e)
        {
            // Check params
            if (textBoxOrigin.Text.Trim() != "")
            {
                if (textBoxDestination.Text.Trim() != "")
                {
                    // Calculate distance
                    DataTable table = googleMapsNet1.CalculateDistance(textBoxOrigin.Text.Trim(), textBoxDestination.Text.Trim());
                    dataGridViewDetails.DataSource = table;
                }
                else
                {
                    MessageBox.Show("You have to enter the destination !!!", "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("You have to enter the origin !!!", "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCalculateElevation_Click(object sender, EventArgs e)
        {
            // Check params
            if (textBoxLong.Text.Trim() != "")
            {
                if (textBoxLat.Text.Trim() != "")
                {
                    // Calculate elevation
                    DataTable table = googleMapsNet1.CalculateElevation(Convert.ToDouble(textBoxLat.Text.Trim()), Convert.ToDouble(textBoxLong.Text.Trim()));
                    dataGridViewDetails.DataSource = table;
                }
                else
                {
                    MessageBox.Show("You have to enter the latitude !!!", "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("You have to enter the longitude !!!", "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
