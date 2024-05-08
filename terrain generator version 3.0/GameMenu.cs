using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace terrain_generator_version_3._0
{
    public partial class GameMenu : Form
    {
        public bool Generate = false;
        public string SettingsFileName = "settings.txt";
        public string WorldDataFile = "world.txt";
        
        public GameMenu()
        {
            InitializeComponent();
        }

        private void OptionsBtn_Click(object sender, EventArgs e)
        {
            var settings = new Options(this);
            settings.Show();
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void LoadBtn_Click(object sender, EventArgs e)
        {
            Generate = false;
            var TerrainLoad = new Terrain(SettingsFileName, Generate, WorldDataFile);
            TerrainLoad.Show();
        }

        private void createBtn_Click(object sender, EventArgs e)
        {
            Generate = true;
            var TerrainCreate = new Terrain(SettingsFileName, Generate, WorldDataFile);
            TerrainCreate.Show();
        }

        private void WorldName_TextChanged(object sender, EventArgs e)
        {
            WorldDataFile = WorldName.Text;
        }
    }
}
