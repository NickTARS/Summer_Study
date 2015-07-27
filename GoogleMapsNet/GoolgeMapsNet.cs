using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Collections;
using System.Threading;


namespace GoogleMaps
{
    public partial class GoogleMapsNet : UserControl
    {
        private double m_Longitude = 0;
        private double m_Latitude = 0;
        private double m_Zoom = 0;
        private MapType m_MapType = MapType.MapTypeRoadmap;
        private ArrayList m_Tiles = new ArrayList();
        private ArrayList m_Markers = new ArrayList();
        private Rectangle m_rcViewport = new Rectangle();
        private bool m_bShowGrid = false;
        private bool m_bShowCenter = false;
        private Point m_ptStart = new Point();
        private Point m_ptEnd = new Point();
        private bool m_bMoving = false;
        private bool m_bDownload = false;
        private Thread m_DownloadThread_0 = null;
        private Thread m_DownloadThread_1 = null;
        private Thread m_DownloadThread_2 = null;
        private Thread m_DownloadThread_3 = null;
        private Thread m_ControlThread = null;
        private bool m_bRunning = false;
        private double m_LongitudeKoef = 0;
        private double m_LatitudeKoef = 0;
        private Point m_ptMapCenter = new Point();
        private Rectangle m_rcWorld = new Rectangle();
        private Rectangle m_rcTileBounds = new Rectangle();
        private ArrayList m_DownloadQue = new ArrayList();
        private ArrayList m_Routes = new ArrayList();

        public event EventHandler LongitudeChanged;
        public event EventHandler LatitudeChanged;
        public event EventHandler ZoomChanged;

        public double Longitude
        {
            set
            {
                m_Longitude = value;
            }
            get
            {
                return m_Longitude;
            }
        }

        public double Latitude
        {
            set
            {
                m_Latitude = value;
            }
            get
            {
                return m_Latitude;
            }
        }

        public double Zoom
        {
            set
            {
                m_Zoom = value;
            }
            get
            {
                return m_Zoom;
            }
        }

        public bool ShowGrid
        {
            set
            {
                m_bShowGrid = value;
            }
            get
            {
                return m_bShowGrid;
            }
        }

        public bool ShowCenter
        {
            set
            {
                m_bShowCenter = value;
            }
            get
            {
                return m_bShowCenter;
            }
        }

        public MapType MapType
        {
            get
            {
                return m_MapType;
            }
        }

        public ArrayList Markers
        {
            get
            {
                return m_Markers;
            }
        }

        public ArrayList Routes
        {
            get
            {
                return m_Routes;
            }
        }

        public Rectangle Viewport
        {
            get
            {
                return m_rcViewport;
            }
        }

        public Point MapCenter
        {
            get
            {
                return m_ptMapCenter;
            }
        }

        public GoogleMapsNet()
        {
            InitializeComponent();

            this.Disposed += new EventHandler(Dispose);

            m_bRunning = true;
            m_DownloadThread_0 = new Thread(new ParameterizedThreadStart(DownloadThreadProc));
            m_DownloadThread_0.Start(0);
            m_DownloadThread_1 = new Thread(new ParameterizedThreadStart(DownloadThreadProc));
            m_DownloadThread_1.Start(1);
            m_DownloadThread_2 = new Thread(new ParameterizedThreadStart(DownloadThreadProc));
            m_DownloadThread_2.Start(2);
            m_DownloadThread_3 = new Thread(new ParameterizedThreadStart(DownloadThreadProc));
            m_DownloadThread_3.Start(3);
            m_ControlThread = new Thread(new ThreadStart(ControlThreadProc));
            m_ControlThread.Start();
        }

        public void Dispose(object sender, EventArgs e)
        {
            // Stop all working threads
            m_bRunning = false;
            if (m_ControlThread.IsAlive == true)
            {
                m_ControlThread.Abort();
            }
            if (m_DownloadThread_0.IsAlive == true)
            {
                m_DownloadThread_0.Abort();
            }
            if (m_DownloadThread_1.IsAlive == true)
            {
                m_DownloadThread_1.Abort();
            }
            if (m_DownloadThread_2.IsAlive == true)
            {
                m_DownloadThread_2.Abort();
            }
            if (m_DownloadThread_3.IsAlive == true)
            {
                m_DownloadThread_3.Abort();
            }

            // Clear old tiles
            foreach (GoogleMapsTile tile in m_Tiles)
            {
                tile.Dispose();
            }
            m_Tiles.Clear();

            // Clear markers
            foreach (GoogleMapsMarker marker in m_Markers)
            {
                marker.Dispose();
            }
            m_Markers.Clear();
        }

        private void ClearAll()
        {
            // Clear old tiles
            foreach (GoogleMapsTile tile in m_Tiles)
            {
                tile.Dispose();
            }
            m_Tiles.Clear();
        }

        private string BuildURL(MapType mapType, int serverId)
        {
            string url = "";

            // Build URL
            url = "http://mts";
            url += serverId.ToString();
            url += ".googleapis.com/vt?lyrs=";
            switch (mapType)
            {
                case MapType.MapTypeRoadmap:
                    {
                        url += "m";
                    }
                    break;

                case MapType.MapTypeTerrain:
                    {
                        url += "t";
                    }
                    break;

                case MapType.MapTypeHybridTerrain:
                    {
                        url += "p";
                    }
                    break;

                case MapType.MapTypeSatellite:
                    {
                        url += "s";
                    }
                    break;

                case MapType.MapTypeHybridSatellite:
                    {
                        url += "y";
                    }
                    break;
            }

            return url;
        }

        private void DownloadMap(MapType mapType, double longitude, double latitude, double zoom)
        {
            // Calculate map params
            m_MapType = mapType;
            m_Longitude = longitude;
            m_Latitude = latitude;
            m_Zoom = zoom;
            m_ptMapCenter = GoogleMapsNet.LatLongToPixel(latitude, longitude, zoom);
            m_rcViewport = new Rectangle(m_ptMapCenter.X - this.ClientRectangle.Width / 2, m_ptMapCenter.Y - this.ClientRectangle.Height / 2, this.ClientRectangle.Width, this.ClientRectangle.Height);
            Point pt1 = GoogleMapsNet.LatLongToPixel(latitude, longitude, zoom);
            Point pt2 = GoogleMapsNet.LatLongToPixel(latitude + 1, longitude + 1, zoom);
            if ((pt2.X - pt1.X) == 0)
            {
                m_LongitudeKoef = 0.0;
            }
            else
            {
                m_LongitudeKoef = Math.Abs(1.0 / (pt2.X - pt1.X));
            }
            if ((pt2.Y - pt1.Y) == 0)
            {
                m_LatitudeKoef = 0.0;
            }
            else
            {
                m_LatitudeKoef = Math.Abs(1.0 / (pt2.Y - pt1.Y));
            }
            int startx = m_rcViewport.Left / 256;
            int endx = m_rcViewport.Right / 256;
            int starty = m_rcViewport.Top / 256;
            int endy = m_rcViewport.Bottom / 256;
            m_rcTileBounds = new Rectangle(startx, starty, endx - startx, endy - starty);
            m_rcWorld = new Rectangle(m_rcTileBounds.Left * 256, m_rcTileBounds.Top * 256, (m_rcTileBounds.Right - m_rcTileBounds.Left + 1) * 256, (m_rcTileBounds.Bottom - m_rcTileBounds.Top + 1) * 256);

            // Download map tiles
            m_bDownload = true;
            int serverId = 0;
            for (int y = starty; y <= endy; y++)
            {
                for (int x = startx; x <= endx; x++)
                {
                    // Add new download info
                    DownloadInfo di = new DownloadInfo();
                    di.serverId = serverId;
                    di.url = BuildURL(mapType, serverId);
                    di.x = x;
                    di.y = y;
                    di.z = Convert.ToInt32(zoom);
                    di.bComplete = false;
                    di.time = DateTime.Now;
                    m_DownloadQue.Add(di);
                    serverId = (serverId + 1) % 4;
                }
            }
        }

        public void ShowMap(MapType mapType, double longitude, double latitude, double zoom)
        {
            // Clear all
            ClearAll();

            // Download map
            DownloadMap(mapType, longitude, latitude, zoom);

            // Update markers and routes
            UpdateAll();
        }

        private void UpdateAll()
        {
            // Update markers
            foreach (GoogleMapsMarker marker in m_Markers)
            {
                marker.Update(m_Zoom);
            }

            // Update routes
            foreach (GoogleMapsRoute route in m_Routes)
            {
                route.Update(m_Zoom);
            }
        }

        private void GoogleMapsNet_Paint(object sender, PaintEventArgs e)
        {
            // Draw map
            DrawMap(e.Graphics);
        }

        private void DrawMap(Graphics g)
        {
            // Draw tiles
            ArrayList tiles = new ArrayList(m_Tiles.ToArray());
            foreach (GoogleMapsTile tile in tiles)
            {
                tile.DrawTile(g, m_rcViewport, m_bShowGrid);
            }
            tiles.Clear();

            // Draw routes
            ArrayList routes = new ArrayList(m_Routes.ToArray());
            foreach (GoogleMapsRoute route in routes)
            {
                route.DrawRoute(g, m_rcViewport);
            }
            routes.Clear();

            // Draw markers
            ArrayList markers = new ArrayList(m_Markers.ToArray());
            foreach (GoogleMapsMarker marker in markers)
            {
                marker.DrawMarker(g, m_rcViewport);
            }
            markers.Clear();

            if (m_bShowCenter == true)
            {
                Rectangle rcTarget = new Rectangle(this.ClientRectangle.Width / 2 - 5, this.ClientRectangle.Height / 2 - 5, 10, 10);
                g.DrawRectangle(new Pen(Color.Red), rcTarget);
                g.DrawLine(new Pen(Color.Red), new Point(this.ClientRectangle.Width / 2, this.ClientRectangle.Height / 2 - 10), new Point(this.ClientRectangle.Width / 2, this.ClientRectangle.Height / 2 + 10));
                g.DrawLine(new Pen(Color.Red), new Point(this.ClientRectangle.Width / 2 - 10, this.ClientRectangle.Height / 2), new Point(this.ClientRectangle.Width / 2 + 10, this.ClientRectangle.Height / 2));
            }
        }

        public static Bitmap DownloadImage(string url)
        {
            Bitmap bitmap = null;

            Stream stream = GoogleMapsNet.DownloadResource(url);
            if (stream != null)
            {
                bitmap = new Bitmap(stream);
                stream.Close();
                stream.Dispose();
            }

            return bitmap;
        }

        public static DataTable DownloadXML(string url)
        {
            DataTable table = null;

            Stream stream = GoogleMapsNet.DownloadResource(url);
            DataSet ds = new DataSet();
            ds.ReadXml(stream);
            table = new DataTable();
            table.Columns.Add("Location");
            table.Columns.Add("Longitude");
            table.Columns.Add("Latitude");
            int iRow = 0;
            foreach (DataRow dr in ds.Tables["result"].Rows)
            {
                List<Object> objData = new List<Object>();
                objData.Add(dr[1].ToString().Trim());
                objData.Add(ds.Tables["location"].Rows[iRow][1].ToString().Trim());
                objData.Add(ds.Tables["location"].Rows[iRow][0].ToString().Trim());
                table.Rows.Add(objData.ToArray());
                iRow++;
            }
            ds.Dispose();
            stream.Close();
            stream.Dispose();

            return table;
        }

        public DataTable DownloadXML2(string url)
        {
            DataTable table = null;

            Stream stream = GoogleMapsNet.DownloadResource(url);
            DataSet ds = new DataSet();
            ds.ReadXml(stream);
            table = new DataTable();
            table.Columns.Add("Step");
            table.Columns.Add("Duration");
            table.Columns.Add("Distance");
            int iRow = 0;
            foreach (DataRow dr in ds.Tables["step"].Rows)
            {
                List<Object> objData = new List<Object>();
                objData.Add(dr[2].ToString().Trim());
                objData.Add(ds.Tables["duration"].Rows[iRow][1].ToString().Trim());
                objData.Add(ds.Tables["distance"].Rows[iRow][1].ToString().Trim());
                table.Rows.Add(objData.ToArray());
                iRow++;
            }
            AddMarker(Convert.ToDouble(ds.Tables["start_location"].Rows[ds.Tables["start_location"].Rows.Count - 1][1].ToString().Trim()), Convert.ToDouble(ds.Tables["start_location"].Rows[ds.Tables["start_location"].Rows.Count - 1][0].ToString().Trim()), m_Zoom);
            AddMarker(Convert.ToDouble(ds.Tables["end_location"].Rows[ds.Tables["end_location"].Rows.Count - 1][1].ToString().Trim()), Convert.ToDouble(ds.Tables["end_location"].Rows[ds.Tables["end_location"].Rows.Count - 1][0].ToString().Trim()), m_Zoom);
            ArrayList polyline = DecodePolyline(ds.Tables["overview_polyline"].Rows[0][0].ToString().Trim());
            GoogleMapsRoute route = new GoogleMapsRoute(polyline, m_Zoom);
            m_Routes.Add(route);
            ds.Dispose();
            stream.Close();
            stream.Dispose();

            // Update screen
            UpdateScreen();

            return table;
        }

        public DataTable DownloadXML3(string url)
        {
            DataTable table = null;

            Stream stream = GoogleMapsNet.DownloadResource(url);
            DataSet ds = new DataSet();
            ds.ReadXml(stream);
            table = new DataTable();
            table.Columns.Add("Duration");
            table.Columns.Add("Distance");
            List<Object> objData = new List<Object>();
            objData.Add(ds.Tables["duration"].Rows[0][1].ToString().Trim());
            objData.Add(ds.Tables["distance"].Rows[0][1].ToString().Trim());
            table.Rows.Add(objData.ToArray());
            ds.Dispose();
            stream.Close();
            stream.Dispose();

            return table;
        }

        public DataTable DownloadXML4(string url)
        {
            DataTable table = null;

            Stream stream = GoogleMapsNet.DownloadResource(url);
            DataSet ds = new DataSet();
            ds.ReadXml(stream);
            table = new DataTable();
            table.Columns.Add("Elevation");
            table.Columns.Add("Resolution");
            List<Object> objData = new List<Object>();
            objData.Add(ds.Tables["result"].Rows[0][1].ToString().Trim());
            objData.Add(ds.Tables["result"].Rows[0][2].ToString().Trim());
            table.Rows.Add(objData.ToArray());
            ds.Dispose();
            stream.Close();
            stream.Dispose();

            return table;
        }

        public static Stream DownloadResource(string url)
        {
            MemoryStream stream = null;

            try
            {
                WebClient client = new WebClient();
                client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
                byte[] data = client.DownloadData(url);
                stream = new MemoryStream(data);
                client.Dispose();
            }
            catch (WebException e)
            {
            }

            return stream;
        }

        public void AddMarker(double longitude, double latitude, double zoom)
        {
            // Add new marker
            GoogleMapsMarker marker = new GoogleMapsMarker(longitude, latitude, zoom);
            m_Markers.Add(marker);

            // Update screen
            UpdateScreen();
        }

        public void ClearMarkers()
        {
            // Clear markers
            foreach (GoogleMapsMarker marker in m_Markers)
            {
                marker.Dispose();
            }
            m_Markers.Clear();

            // Update screen
            UpdateScreen();
        }

        public void DownloadThreadProc(object param)
        {
            int serverId = (int)param;

            while (m_bRunning == true)
            {
                if (m_bDownload == true)
                {
                    bool bRefresh = false;
                    for (int i=0; i<m_DownloadQue.Count; i++)
                    {
                        DownloadInfo di = (DownloadInfo)m_DownloadQue[i];
                        if ((di.serverId == serverId) && (di.bComplete == false))
                        {
                            string url = di.url;
                            url += "&x=" + di.x.ToString().Trim();
                            url += "&y=" + di.y.ToString().Trim();
                            url += "&z=" + di.z.ToString().Trim();
                            Bitmap map = GoogleMapsNet.DownloadImage(url);
                            Point ptTile = new Point(di.x, di.y);
                            GoogleMapsTile tile = new GoogleMapsTile(map, ptTile, url);
                            m_Tiles.Add(tile);

                            di.bComplete = true;
                            m_DownloadQue[i] = di;
                            bRefresh = true;
                        }
                    }

                    if (bRefresh == true)
                    {
                        // Update screen
                        UpdateScreen();
                    }
                }

                Thread.Sleep(10);
            }
        }

        public void ControlThreadProc()
        {
            while (m_bRunning == true)
            {
                // Check threads execution
                bool bRestart_0 = false;
                bool bRestart_1 = false;
                bool bRestart_2 = false;
                bool bRestart_3 = false;
                bool bDownloadFinished = true;
                foreach (DownloadInfo di in m_DownloadQue)
                {
                    if (di.bComplete == false)
                    {
                        bDownloadFinished = false;
                        TimeSpan ts = DateTime.Now.Subtract(di.time);
                        if (ts.Seconds > 10)
                        {
                            if (di.serverId == 0)
                            {
                                bRestart_0 = true;
                            }
                            if (di.serverId == 1)
                            {
                                bRestart_1 = true;
                            }
                            if (di.serverId == 2)
                            {
                                bRestart_2 = true;
                            }
                            if (di.serverId == 3)
                            {
                                bRestart_3 = true;
                            }
                        }
                    }
                }
                m_bDownload = !bDownloadFinished;

                if (bRestart_0 == true)
                {
                    RestartThread(0);
                }
                if (bRestart_1 == true)
                {
                    RestartThread(1);
                }
                if (bRestart_2 == true)
                {
                    RestartThread(2);
                }
                if (bRestart_3 == true)
                {
                    RestartThread(3);
                }

                // Check for download finished
                if (m_bDownload == false)
                {
                    if (m_DownloadQue.Count > 0)
                    {
                        m_DownloadQue.Clear();

                        // Update screen
                        UpdateScreen();
                    }
                }

                Thread.Sleep(100);
            }
        }

        public void RestartThread(int serverId)
        {
            // Abort thread
            switch (serverId)
            {
                case 0:
                    {
                        m_DownloadThread_0.Abort();
                    }
                    break;

                case 1:
                    {
                        m_DownloadThread_1.Abort();
                    }
                    break;

                case 2:
                    {
                        m_DownloadThread_2.Abort();
                    }
                    break;

                case 3:
                    {
                        m_DownloadThread_3.Abort();
                    }
                    break;
            }

            // Reset timings
            for (int i = 0; i < m_DownloadQue.Count; i++)
            {
                DownloadInfo di = (DownloadInfo)m_DownloadQue[i];
                if (di.serverId == serverId)
                {
                    di.time = DateTime.Now;
                    m_DownloadQue[i] = di;
                }
            }

            // Start thread
            switch (serverId)
            {
                case 0:
                    {
                        m_DownloadThread_0 = new Thread(new ParameterizedThreadStart(DownloadThreadProc));
                        m_DownloadThread_0.Start(0);
                    }
                    break;

                case 1:
                    {
                        m_DownloadThread_1 = new Thread(new ParameterizedThreadStart(DownloadThreadProc));
                        m_DownloadThread_1.Start(1);
                    }
                    break;

                case 2:
                    {
                        m_DownloadThread_2 = new Thread(new ParameterizedThreadStart(DownloadThreadProc));
                        m_DownloadThread_2.Start(2);
                    }
                    break;

                case 3:
                    {
                        m_DownloadThread_3 = new Thread(new ParameterizedThreadStart(DownloadThreadProc));
                        m_DownloadThread_3.Start(3);
                    }
                    break;
            }
        }

        public void UpdateScreen()
        {
            if (this.InvokeRequired == true)
            {
                this.Invoke(new MethodInvoker(UpdateScreen));
            }
            else
            {
                // Update screen
                Refresh();
            }
        }

        public DataTable AddressToLongitudeLatitude(string address)
        {
            DataTable table = null;

            // Get latitude-longitude for address
            string url = "http://maps.googleapis.com/maps/api/geocode/xml?address=";
            url += address;
            url += "&sensor=false";
            table = GoogleMapsNet.DownloadXML(url);

            return table;
        }

        public DataTable LongitudeLatitudeToAddress(double longitude, double latitude)
        {
            DataTable table = null;

            // Get addess for latitude-longitude
            string url = "http://maps.googleapis.com/maps/api/geocode/xml?latlng=";
            url += latitude.ToString().Trim();
            url += ",";
            url += longitude.ToString().Trim();
            url += "&sensor=false";
            table = GoogleMapsNet.DownloadXML(url);

            return table;
        }

        public DataTable AddRoute(string origin, string destination)
        {
            DataTable table = null;

            // Get directions from origin to destination
            string url = "http://maps.googleapis.com/maps/api/directions/xml?";
            url += "origin=" + origin;
            url += "&destination=" + destination;
            url += "&sensor=false";
            table = DownloadXML2(url);

            return table;
        }

        public void ClearRoutes()
        {
            // Clear routes
            m_Routes.Clear();

            // Update screen
            UpdateScreen();
        }

        public DataTable CalculateDistance(string origin, string destination)
        {
            DataTable table = null;

            // Calculate distance from origin to destination
            string url = "http://maps.googleapis.com/maps/api/distancematrix/xml?";
            url += "origins=" + origin;
            url += "&destinations=" + destination;
            url += "&mode=driving";
            url += "&sensor=false";
            table = DownloadXML3(url);

            return table;
        }

        public DataTable CalculateElevation(double latitude, double longitude)
        {
            DataTable table = null;

            // Calculate elevation of the location
            string url = "http://maps.googleapis.com/maps/api/elevation/xml?";
            url += "locations=" + latitude.ToString() + "," + longitude.ToString();
            url += "&sensor=false";
            table = DownloadXML4(url);

            return table;
        }

        private void UpdateMap()
        {
            // Update viewport
            Size szOffset = new Size(m_ptEnd.X - m_ptStart.X, m_ptEnd.Y - m_ptStart.Y);
            m_rcViewport.Offset(-szOffset.Width, -szOffset.Height);

            // Update longitude and latitude
            m_Longitude += (-szOffset.Width * m_LongitudeKoef);
            m_Latitude += (szOffset.Height * m_LatitudeKoef);

            // Remove invisible tiles
            ArrayList tiles = new ArrayList();
            foreach (GoogleMapsTile tile in m_Tiles)
            {
                if (tile.IsVisible(m_rcViewport) == true)
                {
                    tiles.Add(tile);
                }
                else
                {
                    tile.Dispose();
                }
            }
            m_Tiles.Clear();
            m_Tiles = new ArrayList(tiles.ToArray());

            // Download new tiles
            int startx2 = m_rcViewport.Left / 256;
            int endx2 = m_rcViewport.Right / 256;
            int starty2 = m_rcViewport.Top / 256;
            int endy2 = m_rcViewport.Bottom / 256;
            m_rcTileBounds = new Rectangle(startx2, starty2, endx2 - startx2 + 1, endy2 - starty2 + 1);
            m_rcWorld = new Rectangle(m_rcTileBounds.Left * 256, m_rcTileBounds.Top * 256, (m_rcTileBounds.Right - m_rcTileBounds.Left + 1) * 256, (m_rcTileBounds.Bottom - m_rcTileBounds.Top + 1) * 256);
            int serverId = 0;
            for (int y = starty2; y <= endy2; y++)
            {
                for (int x = startx2; x <= endx2; x++)
                {
                    bool bExists = false;
                    foreach (GoogleMapsTile tile in m_Tiles)
                    {
                        if (tile.Match(x, y) == true)
                        {
                            bExists = true;
                            break;
                        }
                    }
                    foreach (DownloadInfo di in m_DownloadQue)
                    {
                        if ((di.x == x) && (di.y == y))
                        {
                            bExists = true;
                            break;
                        }
                    }
                    if (bExists == false)
                    {
                        // Add new download info
                        DownloadInfo di = new DownloadInfo();
                        di.serverId = serverId;
                        di.url = BuildURL(m_MapType, serverId);
                        di.x = x;
                        di.y = y;
                        di.z = Convert.ToInt32(m_Zoom);
                        di.bComplete = false;
                        di.time = DateTime.Now;
                        m_DownloadQue.Add(di);
                        serverId = (serverId + 1) % 4;
                    }
                }
            }

            // Update screen
            UpdateScreen();
        }

        private void GoogleMapsNet_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Cursor = Cursors.Hand;

                m_ptStart = e.Location;
                m_ptEnd = e.Location;
            }
            else
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void GoogleMapsNet_MouseUp(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Default;

            if (m_bMoving == true)
            {
                m_bMoving = false;

                m_ptEnd = e.Location;
            }
        }

        private void GoogleMapsNet_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Cursor = Cursors.Hand;

                m_bMoving = true;

                m_ptEnd = e.Location;

                // Update map
                UpdateMap();

                m_ptStart = m_ptEnd;

                // Raise events
                if (this.LongitudeChanged != null)
                {
                    this.LongitudeChanged(this, e);
                }
                if (this.LatitudeChanged != null)
                {
                    this.LatitudeChanged(this, e);
                }
            }
            else
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void GoogleMapsNet_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // Zoom-in map
                Size szOffset = new Size(m_ptMapCenter.X - (m_rcViewport.Left + e.Location.X), m_ptMapCenter.Y - (m_rcViewport.Top + e.Location.Y));
                m_Longitude += (-szOffset.Width * m_LongitudeKoef);
                m_Latitude += (szOffset.Height * m_LatitudeKoef);
                m_Zoom = Math.Min(17, m_Zoom + 1);
            }
            else
            {
                // Zoom-out map
                Size szOffset = new Size(m_ptMapCenter.X - (m_rcViewport.Left + e.Location.X), m_ptMapCenter.Y - (m_rcViewport.Top + e.Location.Y));
                m_Longitude += (-szOffset.Width * m_LongitudeKoef);
                m_Latitude += (szOffset.Height * m_LatitudeKoef);
                m_Zoom = Math.Max(0, m_Zoom - 1);
            }

            // Show map
            ShowMap(m_MapType, m_Longitude, m_Latitude, m_Zoom);

            // Raise events
            if (this.LongitudeChanged != null)
            {
                this.LongitudeChanged(this, e);
            }
            if (this.LatitudeChanged != null)
            {
                this.LatitudeChanged(this, e);
            }
            if (this.ZoomChanged != null)
            {
                this.ZoomChanged(this, e);
            }
        }

        public static Point LatLongToPixel(double latitude, double longitude, double zoom)
        {
            Point point = new Point();

            double centerPoint = Math.Pow(2, zoom + 7);
            double totalPixels = 2 * centerPoint;
            double pixelsPerLngDegree = totalPixels / 360;
            double pixelsPerLngRadian = totalPixels / (2 * Math.PI);
            double siny = Math.Min(Math.Max(Math.Sin(latitude * (Math.PI / 180)), -0.9999), 0.9999);
            point = new Point((int)Math.Round(centerPoint + longitude * pixelsPerLngDegree), (int)Math.Round(centerPoint - 0.5 * Math.Log((1 + siny) / (1 - siny)) * pixelsPerLngRadian));

            return point;
        }

        public Bitmap GetMap()
        {
            Bitmap bitmap = new Bitmap(m_rcViewport.Right - m_rcViewport.Left, m_rcViewport.Bottom - m_rcViewport.Top);

            Graphics g = Graphics.FromImage(bitmap);
            DrawMap(g);

            return bitmap;
        }

        public ArrayList DecodePolyline(string encoded)
        {
            ArrayList polyline = new ArrayList();

            int len = encoded.Length;
            int index = 0;
            double lat = 0;
            double lng = 0;
            while (index < len)
            {
                int b;
                int shift = 0;
                int result = 0;
                do
                {
                    b = Convert.ToInt32((int)encoded[index++] - 63);
                    result |= ((b & 0x1f) << shift);
                    shift += 5;
                } while (b >= 0x20);
                int dlat = ((Convert.ToBoolean(result & 1)) ? (int)~(result >> 1) : (int)(result >> 1));
                lat += dlat;

                shift = 0;
                result = 0;
                do
                {
                    b = Convert.ToInt32((int)encoded[index++] - 63);
                    result |= ((b & 0x1f) << shift);
                    shift += 5;
                } while (b >= 0x20);
                int dlng = ((Convert.ToBoolean(result & 1)) ? (int)~(result >> 1) : (int)(result >> 1));
                lng += dlng;

                PointF point = new PointF((float)(lat * Math.Pow(10, -5)), (float)(lng * Math.Pow(10, -5)));
                polyline.Add(point);
            }

            return polyline;
        }
    }

    public enum MapType
    {
        MapTypeRoadmap = 0,
        MapTypeSatellite = 1,
        MapTypeTerrain = 2,
        MapTypeHybridTerrain = 3,
        MapTypeHybridSatellite = 4
    }

    public struct DownloadInfo
    {
        public int serverId;
        public string url;
        public int x;
        public int y;
        public int z;
        public bool bComplete;
        public DateTime time;
    }

    public class GoogleMapsTile
    {
        private Bitmap m_map = null;
        private Point m_position = new Point();
        private Point m_tile = new Point();
        private string m_url = null;

        public GoogleMapsTile(Bitmap map, Point tile, string url)
        {
            m_map = map;
            m_position = new Point(tile.X * 256, tile.Y * 256);
            m_tile = tile;
            m_url = url;
        }

        public void Dispose()
        {
            if (m_map != null)
            {
                m_map.Dispose();
                m_map = null;
            }
        }

        public void DrawTile(Graphics g, Rectangle viewport, bool bShowGrid)
        {
            if (m_map != null)
            {
                Rectangle rcTile = new Rectangle(m_position.X, m_position.Y, m_map.Width, m_map.Height);
                if (viewport.IntersectsWith(rcTile) == true)
                {
                    Point ptTile = new Point(rcTile.Left - viewport.Left, rcTile.Top - viewport.Top);
                    g.DrawImageUnscaled(m_map, ptTile.X, ptTile.Y);

                    if (bShowGrid == true)
                    {
                        g.DrawRectangle(new Pen(Color.Gray), ptTile.X, ptTile.Y, m_map.Width, m_map.Height);
                    }
                }
            }
        }

        public bool IsEmpty()
        {
            return (m_map == null);
        }

        public bool IsVisible(Rectangle viewport)
        {
            bool bVisible = false;

            Rectangle rcTile = new Rectangle(m_position.X, m_position.Y, m_map.Width, m_map.Height);
            if (viewport.IntersectsWith(rcTile) == true)
            {
                bVisible = true;
            }

            return bVisible;
        }

        public bool Match(int x, int y)
        {
            bool bMatch = false;

            if ((m_tile.X == x) && (m_tile.Y == y))
            {
                bMatch = true;
            }

            return bMatch;
        }
    }

    public class GoogleMapsMarker
    {
        private double m_longitude = 0;
        private double m_latitude = 0;
        private double m_zoom = 0;
        private Bitmap m_marker = null;
        private Bitmap m_marker_shadow = null;
        private Point m_position = new Point();

        public GoogleMapsMarker(double longitude, double latitude, double zoom)
        {
            m_longitude = longitude;
            m_latitude = latitude;
            m_zoom = zoom;
            m_position = GoogleMapsNet.LatLongToPixel(latitude, longitude, zoom); 
            m_marker = GoogleMapsNet.DownloadImage("http://www.google.com/mapfiles/marker.png");
            m_marker_shadow = GoogleMapsNet.DownloadImage("http://www.google.com/mapfiles/shadow50.png");
        }

        public void Dispose()
        {
            if (m_marker != null)
            {
                m_marker.Dispose();
                m_marker = null;
            }

            if (m_marker_shadow != null)
            {
                m_marker_shadow.Dispose();
                m_marker_shadow = null;
            }
        }

        public void DrawMarker(Graphics g, Rectangle viewport)
        {
            if ((m_marker != null) && (m_marker_shadow != null))
            {
                Rectangle rcMarker = new Rectangle(m_position.X, m_position.Y, m_marker.Width, m_marker.Height);
                if (viewport.IntersectsWith(rcMarker) == true)
                {
                    Point ptMarker = new Point(rcMarker.Left - viewport.Left, rcMarker.Top - viewport.Top);
                    g.DrawImageUnscaled(m_marker_shadow, ptMarker.X - m_marker.Width / 2, ptMarker.Y - m_marker_shadow.Height);
                    g.DrawImageUnscaled(m_marker, ptMarker.X - m_marker.Width / 2, ptMarker.Y - m_marker.Height);
                }
            }
        }

        public void Update(double zoom)
        {
            // Update marker
            m_zoom = zoom;
            m_position = GoogleMaps.GoogleMapsNet.LatLongToPixel(m_latitude, m_longitude, zoom); 
        }
    }

    public class GoogleMapsRoute
    {
        private ArrayList m_polyline = null;
        private double m_zoom = 0;

        public GoogleMapsRoute(ArrayList polyline, double zoom)
        {
            m_polyline = new ArrayList(polyline.ToArray());
            m_zoom = zoom;
        }

        public void DrawRoute(Graphics g, Rectangle viewport)
        {
            if (m_polyline != null)
            {
                Point[] points = new Point[m_polyline.Count];
                int index = 0;
                foreach (PointF point in m_polyline)
                {
                    Point pt = GoogleMapsNet.LatLongToPixel(point.X, point.Y, m_zoom);
                    Point pt2 = new Point(pt.X - viewport.Left, pt.Y - viewport.Top);
                    points[index++] = pt2;
                }
                System.Drawing.Drawing2D.SmoothingMode smoothingMode = g.SmoothingMode;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                g.DrawLines(new Pen(new SolidBrush(Color.FromArgb(128, Color.Blue)), 5), points);
                g.SmoothingMode = smoothingMode;
            }
        }

        public void Update(double zoom)
        {
            // Update zoom level
            m_zoom = zoom;
        }
    }
}
