using System;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using ThinkGeo.MapSuite.Core;
using ThinkGeo.MapSuite.DesktopEdition;


namespace  EditingRectangles
{
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();
        }

        private void TestForm_Load(object sender, EventArgs e)
        {
            // Set the full extent and the background color
            winformsMap1.CurrentExtent = new RectangleShape(-155, 70, 78, -65);
            winformsMap1.BackgroundOverlay.BackgroundBrush = new GeoSolidBrush(GeoColor.GeographicColors.ShallowOcean);

            WorldMapKitWmsDesktopOverlay worldMapKitDesktopOverlay = new WorldMapKitWmsDesktopOverlay();
            winformsMap1.Overlays.Add(worldMapKitDesktopOverlay);

            winformsMap1.EditOverlay = new CustomEditInteractiveOverlay();

            Feature rectangle = new Feature(new RectangleShape(-48, 0, 52, -40));
            // Set the value of column "Edit" to "rectangle", so this shape will be editing by custom way.
            rectangle.ColumnValues.Add("Edit", "rectangle");
            winformsMap1.EditOverlay.EditShapesLayer.InternalFeatures.Add(rectangle);

            Feature polygon = new Feature(new PolygonShape("POLYGON((-120 49,-66 44,-81 26,-97 24,-119 33,-125 40,-120 49))"));
            // Set the value of column "Edit" to "polygon" not "rectangle" so this shape will be editing by original way.
            polygon.ColumnValues.Add("Edit", "polygon");
            winformsMap1.EditOverlay.EditShapesLayer.InternalFeatures.Add(polygon);

            winformsMap1.EditOverlay.EditShapesLayer.Open();
            winformsMap1.EditOverlay.EditShapesLayer.Columns.Add(new FeatureSourceColumn("Edit"));
            winformsMap1.EditOverlay.EditShapesLayer.Close();
            winformsMap1.EditOverlay.EditShapesLayer.ZoomLevelSet.ZoomLevel01.DefaultTextStyle = new TextStyle("Edit", new GeoFont("Arial", 18), new GeoSolidBrush(GeoColor.StandardColors.Black));
            winformsMap1.EditOverlay.EditShapesLayer.ZoomLevelSet.ZoomLevel01.ApplyUntilZoomLevel = ApplyUntilZoomLevel.Level20;
            winformsMap1.EditOverlay.CalculateAllControlPoints();

            // Draw the map image on the screen
            winformsMap1.Refresh();
        }

      
        private void winformsMap1_MouseMove(object sender, MouseEventArgs e)
        {
            //Displays the X and Y in screen coordinates.
            statusStrip1.Items["toolStripStatusLabelScreen"].Text = "X:" + e.X + " Y:" + e.Y;

            //Gets the PointShape in world coordinates from screen coordinates.
            PointShape pointShape = ExtentHelper.ToWorldCoordinate(winformsMap1.CurrentExtent, new ScreenPointF(e.X, e.Y), winformsMap1.Width, winformsMap1.Height);

            //Displays world coordinates.
            statusStrip1.Items["toolStripStatusLabelWorld"].Text = "(world) X:" + Math.Round(pointShape.X, 4) + " Y:" + Math.Round(pointShape.Y, 4);
        }
        
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
