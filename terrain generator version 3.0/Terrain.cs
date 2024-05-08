using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using terrain_generator_version_3._0.Properties;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;

namespace terrain_generator_version_3._0
{
    public partial class Terrain : Form
    {
        bool up, down, left, right;
        public string OptionsFileName = "settings.txt";
        public string[] OptionsSaved = new string[37];
        public bool Generate = false;
        public string WorldDataFile = "world.txt";
        private Bitmap[] BlockImg = {
            Resources.sky, Resources.stone1,
            Resources.stone2, Resources.stone3,
            Resources.stone4, Resources.dirt,
            Resources.grasside, Resources.BGrock,
            Resources.ore1, Resources.ore2,
            Resources.grasstop, Resources.grassmed, 
            Resources.grasstall, Resources.log,
            Resources.logtop, Resources.sprucelog,
            Resources.leaves, Resources.leaves2,
            Resources.spruceleaves, Resources.flower,
            Resources.water,
        };
        BlockRender[] Blocks = new BlockRender[0];
        int BlockGenX = 0;
        int BlockGenY = 0;
        int BlockType = 0;
        int offsetx = 0;
        int offsety = 0;
        int temp = 0;
        int TreeChance = 0;
        public string Loadedleveldata = "";
        public string leveldata = "";
        public Random rnd = new Random();
        int TreeBuild = 0;
        public Terrain(string SettingsFileName, bool generate, string worldDataFile)
        {
            DoubleBuffered = true;
            InitializeComponent();
            OptionsFileName = SettingsFileName;
            Generate = generate;

            if (File.Exists(OptionsFileName) == true)
            {
                StreamReader sr = new StreamReader(OptionsFileName);
                OptionsSaved = File.ReadAllLines(OptionsFileName);
                sr.Close();
            }
            WorldDataFile = worldDataFile;
            if (Generate == true)
            {
                if (File.Exists(WorldDataFile) == false)
                {
                    StreamWriter SW = new StreamWriter(WorldDataFile);
                    SW.Close();
                }
                else
                {

                    File.Delete(WorldDataFile);
                    MessageBox.Show("World already exists, overwriting existing world.");
                    StreamWriter SW = new StreamWriter(WorldDataFile);
                    SW.Close();
                }
                GenerateWorld(Convert.ToInt32(OptionsSaved[1]), Convert.ToInt32(OptionsSaved[0]), 5);
            }
            else
            {
                CreateData();
                LoadWorld(Convert.ToInt32(OptionsSaved[1]), Convert.ToInt32(OptionsSaved[0]), 5);
            }
        }
        public void CreateData()
        {
            WorldName.Text = WorldDataFile;
            WorldName.Update();
            if (File.Exists("GeneratedData.txt") == false)
            {
                StreamWriter SW = new StreamWriter("GeneratedData.txt");
                SW.Close();
            }
            else
            {
                File.Delete("GeneratedData.txt");
                StreamWriter SW = new StreamWriter("GeneratedData.txt");
                SW.Close();
            }
            StreamReader SR = new StreamReader(WorldDataFile);
                Loadedleveldata = SR.ReadLine();

            SR.Close();
        }
        public void GenerateWorld(int WorldHeight, int WorldLength, int chunks)
        {

            int[] intOptions = new int[37];
            for (int i = 0; i < 37; i++)
            {
                Int32.TryParse(OptionsSaved[i], out intOptions[i]);
            }
            int MaxTreeHeight = intOptions[13] + 3;
            int Gradient = 0;
            int QuickRandom = 0;
            int BaseHeight = (WorldHeight / 7) * 3 + intOptions[3];
            int TerrainHeight = (WorldHeight / 3);
            for (int l = 0; l < chunks; l++)
            {
                for (int i = 0; i <= WorldLength; i++)
                {
                    if (TreeBuild == 0)
                    {
                        TreeChance = rnd.Next(0, 10);
                        QuickRandom = rnd.Next(0, 6);
                        if (QuickRandom == 3) intOptions[6] = rnd.Next(1, 4);
                        switch (intOptions[6])
                        {
                            case int x when (intOptions[6] == 1 && Gradient > WorldHeight / 10):
                                Gradient--;
                                Gradient += (intOptions[5] * -1);
                                break;

                            case int x when (intOptions[6] == 1 && Gradient <= WorldHeight / 10):
                                intOptions[6] = 3;
                                break;

                            case int x when (intOptions[6] == 3 && Gradient + 5 < WorldHeight - 3):
                                Gradient++;
                                Gradient += intOptions[5];
                                break;

                            case int x when (intOptions[6] == 3 && Gradient + 5 > WorldHeight - 3):
                                intOptions[6] = 1;
                                break;

                            default:
                                //empty
                                break;
                        }
                        intOptions[3] = rnd.Next((intOptions[4] * -1), intOptions[4]);
                    }
                    TerrainHeight = BaseHeight + Gradient + intOptions[3];
                    for (int j = WorldHeight; j >= 0; j--)
                    {
                        switch (TerrainHeight)
                        {
                            case int x when (TerrainHeight < 10 && TerrainHeight > 0):
                                BlockType = intOptions[19];
                                break;

                            case int x when (TerrainHeight >= 10 && TerrainHeight < 15):
                                BlockType = intOptions[20];
                                break;

                            case int x when TerrainHeight >= 15:
                                BlockType = intOptions[21];
                                break;

                            case int x when (TerrainHeight >= -1 && TerrainHeight <= 0):
                                BlockType = intOptions[18];
                                break;

                            case int x when (TerrainHeight < -1 && TerrainHeight >= -2):
                                BlockType = intOptions[17];
                                break;

                            default:
                                BlockType = intOptions[16];
                                break;
                        }
                        //BuildBlock(BlockType, BlockGenY, BlockGenX, Blocks);
                        if (TerrainHeight > -3) TerrainHeight--;
                        leveldata = leveldata + "," + Convert.ToString(BlockType);
                        if (BlockType == intOptions[17])
                        {
                            if (TreeBuild <= 0)
                            {
                                if (TreeChance < intOptions[10] && OptionsSaved[7] == "true")
                                {
                                    TreeBuild = 3;
                                }
                                else
                                if (OptionsSaved[8] == "true")
                                {
                                    if (j > 0)
                                    {
                                        FoliageBuilder(i + j);
                                        j--;
                                    }
                                }
                                else TreeBuild = 0;
                            }
                            else if (OptionsSaved[7] == "true")
                            {
                                intOptions[13] = rnd.Next(1, MaxTreeHeight);
                                if (j > intOptions[13] + 3)
                                {
                                    TreeBuilder(intOptions[13], i + j);
                                    j -= intOptions[13] + 3;
                                }
                                TreeBuild--;
                            }
                            else if (TreeBuild > 0 && OptionsSaved[7] == "true")
                            {
                                TreeBuild--;
                            }
                        }
                    }
                }
                StreamWriter sw = new StreamWriter(WorldDataFile + ".txt");
                sw.WriteLine(leveldata);
                sw.Close();
                WorldDataFile += Convert.ToString(l);
                
            }
        
            LoadWorld(WorldHeight, WorldLength, chunks);
        }
        private void FoliageBuilder(int i)
        {
            int temp = rnd.Next(0, 6);
            switch (temp)
            {
                case 0:
                    leveldata += "," + OptionsSaved[27];
                    break;
                case 1:
                    leveldata += "," + OptionsSaved[28];
                    break;
                case 2:
                    leveldata += "," + OptionsSaved[35];
                    break;
                case 3:
                    leveldata += "," + OptionsSaved[26];
                    break;
                case 4:
                    leveldata += "," + OptionsSaved[33];
                    break;
                default:
                    leveldata += "," + OptionsSaved[16];
                    break;
            }

        }
        private void TreeBuilder(int TreeHeight, int i)
        {
            int temp = rnd.Next(0, 2);
            if (TreeBuild == 3 || TreeBuild == 1)
            {
                for (int k = 0; k < TreeHeight + 3; k++)
                {
                    switch (k)
                    {
                        case 0:
                            FoliageBuilder(i);
                            break;
                        case int x when (k == TreeHeight):
                            leveldata += "," + OptionsSaved[33];
                            break;
                        case int x when (k == TreeHeight + 1):
                            if (temp == 0)
                            {
                                leveldata += "," + OptionsSaved[16];
                            }
                            else
                            {
                                leveldata += "," + OptionsSaved[33];
                            }
                            break;
                        default:
                            leveldata += "," + OptionsSaved[16];
                            break;
                    }
                }
            }
            if (TreeBuild == 2)
            {
                for (int k = 0; k < TreeHeight + 3; k++)
                {
                    if (k < TreeHeight)
                        leveldata += "," + OptionsSaved[29];
                    else
                        leveldata += "," + OptionsSaved[33];
                }
            }
        }

        public void LoadWorld(int WorldHeight, int WorldLength, int chunks)
        {
            temp++;
            WorldName.Text = WorldDataFile + Convert.ToString(temp);
            WorldName.Update();
            int block = 0;
            string[] temparr = new string[WorldDataFile.Length];
            for (int i = 0; i < WorldDataFile.Length; i++)
            {
                temparr[i] = Convert.ToString(WorldDataFile[i]);
            }
            int temp2 = WorldDataFile.Length;
            WorldDataFile = "";
            for (int i = 0; i < temp2 - chunks; i++)
            {
                WorldDataFile += Convert.ToString(temparr[i]);
            }
            for (int c = 0; c < chunks; c++)
            {
                StreamReader SR = new StreamReader(WorldDataFile + ".txt");
                string Loadedleveldata = (Convert.ToString(SR.ReadLine()) + "#####");
                SR.Close();
                string[] BlocksToBeLoaded = new string[Loadedleveldata.Length];
                for (int i = 0; i < Loadedleveldata.Length; i++)
                {
                    if (Loadedleveldata[i] == ',')
                    {
                        if (Loadedleveldata[i + 2] != ',')
                        {
                            BlocksToBeLoaded[i + 1] = Convert.ToString(Loadedleveldata[i + 1] + Convert.ToString(Loadedleveldata[i + 2]));
                            //BlocksToBeLoaded[i + 2] = ",#";
                            BlocksToBeLoaded[i] = Convert.ToString(Loadedleveldata[i]);

                        }
                        else
                        {
                            BlocksToBeLoaded[i + 1] = Convert.ToString(Loadedleveldata[i + 1]);
                            BlocksToBeLoaded[i] = Convert.ToString(Loadedleveldata[i]);
                        }

                    }
                }
                StreamWriter sw = new StreamWriter("GeneratedData.txt", true);
                for (int i = 0; i < BlocksToBeLoaded.Length; i++)
                {
                    sw.Write(BlocksToBeLoaded[i]);
                }
                sw.Close();
                int GenX = 0;
                int GenY = WorldHeight + 1;
                Array.Resize(ref Blocks, BlocksToBeLoaded.Length);
                int temp14553 = BlocksToBeLoaded.Length;
                for (int i = 0; i < BlocksToBeLoaded.Length - 7; i++)
                {
                    BlockGenY = (GenY * 16) - 16;
                    BlockGenX = (((GenX * 16) /*+ ((WorldLength * 16) * c))- (temp14553*/));
                    if (BlocksToBeLoaded[i] == ",")
                    {
                        if (BlocksToBeLoaded[i + 1] != "," && BlocksToBeLoaded[i + 1] != ",#")
                        {
                            Int32.TryParse(BlocksToBeLoaded[i + 1], out BlockType);
                            GenY--;
                        }
                    }
                    Buildblock(BlockType, BlockGenY, BlockGenX, i);
                    if (GenY <= 0)
                    {
                        GenY = WorldHeight + 1;
                        GenX++;
                    }
                }
                WorldDataFile += c;
                

            }
            
        }
        private void Buildblock(int blocktype, int BlockGenY, int BlockGenX, int block)
        {
            if (blocktype < BlockImg.Length)
            {
                PointF BlockPos = new PointF(BlockGenX, BlockGenY);
                Blocks[block] = new BlockRender(0, BlockPos, BlockImg[blocktype]);
            }
        }
        private void Terrain_Load(object sender, EventArgs e)
        {

        }

        private void KeyDownEvent(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
            {
                up = true;
            }
            if (e.KeyCode == Keys.S)
            {
                down = true;
            }
            if (e.KeyCode == Keys.A)
            {
                left = true;
            }
            if (e.KeyCode == Keys.D)
            {
                right = true;
            }
        }

        private void SlowDownMovementTick(object sender, EventArgs e)
        {
            if (offsetx != 0)
            {
                if (offsetx < 0) offsetx++;
                else offsetx--;
            }
            if (offsety != 0)
            {
                if (offsety < 0) offsety++;
                else offsety--;
            }
            if (offsetx > 15) offsetx = 15;
            if (offsety > 15) offsety = 15;
            if (offsetx < -15) offsetx = -15;
            if (offsety < -15) offsety= -15;
        }

        private void KeyUpEvent(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
            {
                up = false;
            }
            if (e.KeyCode == Keys.S)
            {
                down = false;
            }
            if (e.KeyCode == Keys.A)
            {
                left = false;
            }
            if (e.KeyCode == Keys.D)
            {
                right = false;
            }
        }

        private void PictureBoxOnpaint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < Blocks.Length; i++)
            {
                if (Blocks[i] != null)
                {
                    if (!(Blocks[i].SpriteCenter.X < -60 || Blocks[i].SpriteCenter.X > GameWindow.Width + 60 || Blocks[i].SpriteCenter.Y < -60 || Blocks[i].SpriteCenter.Y > GameWindow.Height + 60))
                    {
                        Blocks[i].Draw(e.Graphics);
                    }
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (down) offsety -= 1;
            if (up) offsety += 1;
            if (left) offsetx += 1;
            if (right) offsetx -= 1;
            for (int i = 0; i < Blocks.Length; i++)
            {
                if (Blocks[i] != null)
                {
                    Blocks[i].SpriteCenter.X = Blocks[i].SpriteCenter.X + offsetx;
                    Blocks[i].SpriteCenter.Y = Blocks[i].SpriteCenter.Y + offsety;
                }
            }
            GameRenderFrame.Refresh();
        }
    }
}
