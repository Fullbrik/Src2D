using System;
using Eto.Forms;
using Eto.Drawing;

namespace Src2D.Editor.Tools.MapEditor
{
    [Tool("Map Editor", Ext = ".srcmap")]
    public partial class MapEditor : Form
    {
        public bool HasPendingChanges
        {
            get => hasPendingChanges;
            set
            {
                hasPendingChanges = value;

                Title = "Map Editor - " + FileName;
                if (hasPendingChanges) Title += "*";
            }
        }
        private bool hasPendingChanges;

        public string FileName { get; }

        public MapEditor(string fileName)
        {
            InitializeComponent();

            FileName = fileName;

            Load += MapEditor_Load;
        }

        private void MapEditor_Load(object sender, EventArgs e)
        {
            HasPendingChanges = false;
            ContentBrowser.Refresh(true, true);
        }
    }
}
