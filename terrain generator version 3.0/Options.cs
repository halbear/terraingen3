using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace terrain_generator_version_3._0
{
    public partial class Options : Form
    {
        private GameMenu menu;
        public string OptionsFileName = "settings.txt";
        public string[] OptionsSaved = new string[] { "90", "45", "1", "0", "1", "0", "0", "true", "true", "true", "1", "9", "1", "3", "6", "5", "0", "6", "5", "4", "3", "2", "1", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20" };

        public Options(GameMenu parent)
        {
            InitializeComponent();
            menu = parent;
            if (File.Exists("DefaultSettings.txt") == false)
            {
                StreamWriter SW = new StreamWriter("DefaultSettings.txt");
                SW.Close();
            }
            else
            {

                File.Delete("DefaultSettings.txt");
                StreamWriter SW = new StreamWriter("DefaultSettings.txt");
                SW.Close();
            }
            StreamWriter streamWriter = new StreamWriter("DefaultSettings.txt");
            for (int i = 0; i < OptionsSaved.Length; i++)
            {
                streamWriter.WriteLine(OptionsSaved[i]);
            }
            streamWriter.Close();
        }


        private void button4_Click(object sender, EventArgs e)
        {
            FileExistCheck(1);
            this.Close();
        }

        private void Options_Load(object sender, EventArgs e)
        {

        }
        private void FileExistCheck(int x)
        {
            OptionsFileName = Settingfileinput.Text + ".txt";
            menu.SettingsFileName = this.OptionsFileName;
            string temp = OptionsFileName.ToUpper();
            if (temp != "DEFAULTSETTINGS.TXT" )
            {
                if (File.Exists(OptionsFileName) == false)
                {
                    StreamWriter SW = new StreamWriter(OptionsFileName);
                    SW.Close();
                }
                else
                {

                    File.Delete(OptionsFileName);
                    if (x == 0) MessageBox.Show("File already exists, overwriting existing file.");
                    else MessageBox.Show("Settings file saved.");
                    StreamWriter SW = new StreamWriter(OptionsFileName);
                    SW.Close();
                }
                StreamWriter streamWriter = new StreamWriter(OptionsFileName);
                for (int i = 0; i < OptionsSaved.Length; i++)
                {
                    streamWriter.WriteLine(OptionsSaved[i]);
                }
                streamWriter.Close();
            }
            else MessageBox.Show("you cant overwrite the default settings save!");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            FileExistCheck(0);
        }
        private void WorldLengthInput_TextChanged(object sender, EventArgs e)
        {
            OptionsSaved[0] = WorldLengthInput.Text;
        }

        private void WorldHeightInput_TextChanged(object sender, EventArgs e)
        {
            OptionsSaved[1] = WorldHeightInput.Text;
        }

        private void BiomeInput_TextChanged(object sender, EventArgs e)
        {
            OptionsSaved[2] = BiomeInput.Text;
        }

        private void HeightModifierInput_TextChanged(object sender, EventArgs e)
        {
            OptionsSaved[3] = HeightModifierInput.Text;
        }

        private void SmoothnessInput_TextChanged(object sender, EventArgs e)
        {
            OptionsSaved[4] = SmoothnessInput.Text;
        }

        private void InclineRateInput_TextChanged(object sender, EventArgs e)
        {
            OptionsSaved[5] = InclineRateInput.Text;
        }

        private void HeightChangerInput_TextChanged(object sender, EventArgs e)
        {
            OptionsSaved[6] = HeightChangerInput.Text;
        }

        private void TreeGenerationToggle_Click(object sender, EventArgs e)
        {
            if (TreeGenerationToggle.Text == "True")
            {
                TreeGenerationToggle.Text = "False";
                OptionsSaved[7] = "false";
            }
            else if (TreeGenerationToggle.Text == "False")
            {
                TreeGenerationToggle.Text = "True";
                OptionsSaved[7] = "true";
            }
        }

        private void FoliageGenerationInput_Click(object sender, EventArgs e)
        {
            if (FoliageGenerationInput.Text == "True")
            {
                FoliageGenerationInput.Text = "False";
                OptionsSaved[8] = "false";
            }
            else if (FoliageGenerationInput.Text == "False")
            {
                FoliageGenerationInput.Text = "True";
                OptionsSaved[8] = "true";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (button5.Text == "True")
            {
                button5.Text = "False";
                OptionsSaved[9] = "false";
            }
            else if (button5.Text == "False")
            {
                button5.Text = "True";
                OptionsSaved[9] = "true";
            }
        }

        private void TreeSatInput_TextChanged(object sender, EventArgs e)
        {
            OptionsSaved[10] = TreeSatInput.Text;
        }

        private void FoliageSatInput_TextChanged(object sender, EventArgs e)
        {
            OptionsSaved[11] = FoliageSatInput.Text;
        }

        private void FeatureSatInput_TextChanged(object sender, EventArgs e)
        {
            OptionsSaved[12] = FeatureSatInput.Text;
        }

        private void MaxTreeHeightInput_TextChanged(object sender, EventArgs e)
        {
            OptionsSaved[13] = MaxTreeHeightInput.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            OptionsSaved[14] = textBox2.Text;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            OptionsSaved[15] = textBox1.Text;
        }

        private void AirInput_TextChanged(object sender, EventArgs e)
        {
            OptionsSaved[16] = AirInput.Text;
        }

        private void GrassSideInput_TextChanged(object sender, EventArgs e)
        {
            OptionsSaved[17] = GrassSideInput.Text;
        }

        private void DirtInput_TextChanged(object sender, EventArgs e)
        {
            OptionsSaved[18] = DirtInput.Text;
        }

        private void LightStoneInput_TextChanged(object sender, EventArgs e)
        {
            OptionsSaved[19] = LightStoneInput.Text;
        }

        private void CobbleStoneInput_TextChanged(object sender, EventArgs e)
        {
            OptionsSaved[20] = CobbleStoneInput.Text;
        }

        private void MiddleStoneInput_TextChanged(object sender, EventArgs e)
        {
            OptionsSaved[21] = MiddleStoneInput.Text;
        }

        private void DeepStoneInput_TextChanged(object sender, EventArgs e)
        {
            OptionsSaved[22] = DeepStoneInput.Text;
        }

        private void CaveStoneInput_TextChanged(object sender, EventArgs e)
        {
            OptionsSaved[23] = CaveStoneInput.Text;
        }

        private void Ore1Input_TextChanged(object sender, EventArgs e)
        {
            OptionsSaved[24] = Ore1Input.Text;
        }

        private void Ore2Input_TextChanged(object sender, EventArgs e)
        {
            OptionsSaved[25] = Ore2Input.Text;
        }

        private void GrassTopInput_TextChanged(object sender, EventArgs e)
        {
            OptionsSaved[26] = GrassTopInput.Text;
        }

        private void GrassMedInput_TextChanged(object sender, EventArgs e)
        {
            OptionsSaved[27] = GrassMedInput.Text;
        }

        private void GrassTallInput_TextChanged(object sender, EventArgs e)
        {
            OptionsSaved[28] = GrassTallInput.Text;
        }

        private void LogBlockInput_TextChanged(object sender, EventArgs e)
        {
            OptionsSaved[29] = LogBlockInput.Text;
        }

        private void LogTopInput_TextChanged(object sender, EventArgs e)
        {
            OptionsSaved[30] = LogTopInput.Text;
        }

        private void SpruceLogInput_TextChanged(object sender, EventArgs e)
        {
            OptionsSaved[31] = SpruceLogInput.Text;
        }

        private void Leaves1Input_TextChanged(object sender, EventArgs e)
        {
            OptionsSaved[32] = Leaves1Input.Text;
        }

        private void Leaves2Input_TextChanged(object sender, EventArgs e)
        {
            OptionsSaved[33] = Leaves2Input.Text;
        }

        private void SpruceLeavesInput_TextChanged(object sender, EventArgs e)
        {
            OptionsSaved[34] = SpruceLeavesInput.Text;
        }

        private void FlowerInput_TextChanged(object sender, EventArgs e)
        {
            OptionsSaved[35] = FlowerInput.Text;
        }

        private void WaterInput_TextChanged(object sender, EventArgs e)
        {
            OptionsSaved[36] = WaterInput.Text;
        }
        private void LoadSettings()
        {
            WorldLengthInput.Text = OptionsSaved[0];
            WorldHeightInput.Text = OptionsSaved[1];
            BiomeInput.Text = OptionsSaved[2];
            HeightModifierInput.Text = OptionsSaved[3];
            SmoothnessInput.Text = OptionsSaved[4];
            InclineRateInput.Text = OptionsSaved[5];
            HeightChangerInput.Text = OptionsSaved[6];
            if (OptionsSaved[7] == "true")
            {
                TreeGenerationToggle.Text = "True";
                TreeGenerationToggle.Update();
            }
            else if (OptionsSaved[7] == "false")
            {
                TreeGenerationToggle.Text = "False";
                TreeGenerationToggle.Update();
            }
            if (OptionsSaved[8] == "true")
            {
                FoliageGenerationInput.Text = "True";
                FoliageGenerationInput.Update();
            }
            else if (OptionsSaved[8] == "false")
            {
                FoliageGenerationInput.Text = "False";
                FoliageGenerationInput.Update();
            }
            if (OptionsSaved[9] == "true")
            {
                button5.Text = "True";
                button5.Update();
            }
            else if (OptionsSaved[9] == "false")
            {
                button5.Text = "False";
                button5.Update();
            }
            TreeSatInput.Text = OptionsSaved[10];
            FoliageSatInput.Text = OptionsSaved[11];
            FeatureSatInput.Text = OptionsSaved[12];
            MaxTreeHeightInput.Text = OptionsSaved[13];
            textBox2.Text = OptionsSaved[14];
            textBox1.Text = OptionsSaved[15];
            AirInput.Text = OptionsSaved[16];
            GrassSideInput.Text = OptionsSaved[17];
            DirtInput.Text = OptionsSaved[18];
            LightStoneInput.Text = OptionsSaved[19];
            CobbleStoneInput.Text = OptionsSaved[20];
            MiddleStoneInput.Text = OptionsSaved[21];
            DeepStoneInput.Text = OptionsSaved[22];
            CaveStoneInput.Text = OptionsSaved[23];
            Ore1Input.Text = OptionsSaved[24];
            Ore2Input.Text = OptionsSaved[25];
            GrassTopInput.Text = OptionsSaved[26];
            GrassMedInput.Text = OptionsSaved[27];
            GrassTallInput.Text = OptionsSaved[28];
            LogBlockInput.Text = OptionsSaved[29];
            LogTopInput.Text = OptionsSaved[30];
            SpruceLogInput.Text = OptionsSaved[31];
            Leaves1Input.Text = OptionsSaved[32];
            Leaves2Input.Text = OptionsSaved[33];
            SpruceLeavesInput.Text = OptionsSaved[34];
            FlowerInput.Text = OptionsSaved[35];
            WaterInput.Text = OptionsSaved[36];

            Update();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OptionsFileName = Settingfileinput.Text + ".txt";
            if (File.Exists(OptionsFileName) == true)
            {
                StreamReader sr = new StreamReader(OptionsFileName);
                OptionsSaved = File.ReadAllLines(OptionsFileName);
                sr.Close();
            }
            LoadSettings();
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            if (File.Exists("DefaultSettings.txt") == true)
            {
                StreamReader sr = new StreamReader("DefaultSettings.txt");
                OptionsSaved = File.ReadAllLines("DefaultSettings.txt");
                sr.Close();
            }
            LoadSettings();
        }
    }
}
