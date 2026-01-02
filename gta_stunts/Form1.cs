//#define DEBUG_VIS
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace gta_stunts
{
    public partial class Form1 : Form
    {
        private class TerrainData
        {
            public string model;
            public int angle;
            public float offs;
            public bool special;
        }

        private class ObjectData
        {
            public string model;
            public int angle;
            public float offs;
            public string model2;
            public float offs2;
            public int angle2;
        }

        private class ChangeData
        {
            public string model;
            public bool replace;
        }

        private const int MAP_SIZE = 30;
        private const float ELEM_OFFS = 51.4f; //25.7f;

        private const string file_cfg = "data_cfg.txt";
        private const string file_ter = "data_ter.txt";
        private const string file_obj = "data_obj.txt";
        private const string file_cha = "data_cha.txt";
        private const string sa_file_ide = "CUSTOM.IDE";
        private const string sa_file_ipl = "SAMP.ipl";
        private const string vc_file_ide = "stunts.ide";
        private const string vc_file_ipl = "stunts.ipl";

        private string file_ide;
        private string file_ipl;

        private static char[] file_delimiter = { ',' };

        private Dictionary<string, string> stunts_data = new Dictionary<string, string>();
        private Dictionary<byte, TerrainData> terrain_data = new Dictionary<byte, TerrainData>();
        private Dictionary<byte, ObjectData> object_data = new Dictionary<byte, ObjectData>();
        private Dictionary<string, ChangeData> change_data = new Dictionary<string, ChangeData>();
        private Dictionary<int, string> quaterion = new Dictionary<int, string>()
        {
            {0, "0, 0, 0, 1"},
            {90, "0, 0, 0.7071067691, 0.7071067691"},
            {180, "0, 0, 1, 0"},
            {270, "0, 0, 0.7071067691, -0.7071067691"}
        };

        /*private Dictionary<int, string> euler = new Dictionary<int, string>()
        {
            {0, "0, 0, 0"},
            {90, "0, 0, 90"},
            {180, "0, 0, 180"},
            {270, "0, 0, 270"}
        };*/

        //Teleport
        private float player_x, player_y, player_z;

        //Config
        Control[] cfg_controls;

        public Form1()
        {
            InitializeComponent();
#if DEBUG_VIS
            SetBounds(0, 0, 840, 900);
#endif
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            //
            cfg_controls = new Control[] { tb_fini, tb_x, tb_y, tb_z, tb_road };
            ofd.InitialDirectory = Environment.CurrentDirectory;
            //Check for IDE file
            if (File.Exists(vc_file_ide))
            {
                file_ide = vc_file_ide;
                file_ipl = vc_file_ipl;
                ch_vc.Checked = true;
            }
            else
            {
                file_ide = sa_file_ide;
                file_ipl = sa_file_ipl;
                ch_vc.Checked = false;
            }
            //Data load
            LoadDataCfg();
            LoadDataTer();
            LoadDataObj();
            LoadDataCha();
            LoadIDE();
        }

        //Config file
        private void LoadDataCfg()
        {
            try
            {
                using (StreamReader sr = new StreamReader(file_cfg, Encoding.Default))
                {
                    foreach (Control c in cfg_controls)
                    {
                        if (sr.Peek() < 0) return;
                        c.Text = sr.ReadLine();
                    }
                }
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        private void SaveDataCfg()
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(file_cfg, false, Encoding.Default))
                {
                    foreach (Control c in cfg_controls)
                    {
                        sw.WriteLine(c.Text);
                    }
                }
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        //Terrain data
        private void LoadDataTer()
        {
            try
            {
                using (StreamReader sr = new StreamReader(file_ter, Encoding.Default))
                {
                    while (sr.Peek() > -1)
                    {
                        string line = sr.ReadLine();
                        string[] data = line.Split(file_delimiter);
                        if (data.Length < 4) continue;
                        byte id = Convert.ToByte(data[0].Trim(), 16);
                        TerrainData tmp = new TerrainData();
                        tmp.model = data[1].Trim();
                        tmp.angle = int.Parse(data[2].Trim());
                        tmp.offs = float.Parse(data[3].Trim());
                        if (data.Length > 4) tmp.special = data[4].Trim() != "0";
                        terrain_data.Add(id, tmp);
                    }
                }
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        //Object data
        private void LoadDataObj()
        {
            try
            {
                using (StreamReader sr = new StreamReader(file_obj, Encoding.Default))
                {
                    while (sr.Peek() > -1)
                    {
                        string line = sr.ReadLine();
                        string[] data = line.Split(file_delimiter);
                        if (data.Length < 5) continue;
                        byte id = Convert.ToByte(data[0].Trim(), 16);
                        ObjectData tmp = new ObjectData();
                        tmp.model = data[1].Trim();
                        tmp.angle = int.Parse(data[2].Trim());
                        tmp.offs = float.Parse(data[3].Trim());
                        tmp.offs2 = float.Parse(data[4].Trim());
                        if (data.Length > 5)
                        {
                            tmp.model2 = data[5].Trim();
                            tmp.angle2 = int.Parse(data[6].Trim());
                        }
                        object_data.Add(id, tmp);
                    }
                }
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        //Change data
        private void LoadDataCha()
        {
            try
            {
                using (StreamReader sr = new StreamReader(file_cha, Encoding.Default))
                {
                    while (sr.Peek() > -1)
                    {
                        string line = sr.ReadLine();
                        string[] data = line.Split(file_delimiter);
                        if (data.Length < 3) continue;
                        ChangeData tmp = new ChangeData();
                        tmp.model = data[1].Trim();
                        tmp.replace = data[2].Trim() != "0";
                        change_data.Add(data[0].Trim(), tmp);
                    }
                }
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        //GTA:SA IDE file
        private void LoadIDE()
        {
            try
            {
                bool obj_region = false;
                using (StreamReader sr = new StreamReader(file_ide, Encoding.Default))
                {
                    while (sr.Peek() > -1)
                    {
                        string line = sr.ReadLine();
                        if (line[0] == '#') continue;
                        if (obj_region)
                        {
                            if (line.Trim() == "end") break;
                            string[] data = line.Split(file_delimiter);
                            if (data.Length < 2) continue;
                            stunts_data.Add(data[1].Trim(), data[0].Trim());
                        }
                        else
                        {
                            if (line.Trim() == "objs") obj_region = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        //Generate map
        private void ConvertTRK(string fname)
        {
            string ipl_line_format = ch_vc.Checked ? "{0}, {1}, 0, {2}, {3}, {4}, 1, 1, 1, {5}" : "{0}, {1}, 0, {2}, {3}, {4}, {5}, -1";
            try
            {
                bool finish_found = false;
                float start_x = TryFloat(tb_x.Text, 130.0f);
                float start_y = TryFloat(tb_y.Text, -2900.0f);
                float start_z = TryFloat(tb_z.Text, 300.0f);
                float start_z2 = start_z - TryFloat(tb_road.Text, 0.05f);
                using (StreamWriter sw = new StreamWriter(file_ipl, false, Encoding.Default))
                {
                    using (BinaryReader br = new BinaryReader(new FileStream(fname, FileMode.Open, FileAccess.Read), Encoding.Default))
                    {
                        sw.WriteLine("inst");
                        int map_offset = MAP_SIZE * MAP_SIZE + 1;
                        int obj_offset = map_offset - 2;
                        List<byte> map_data = new List<byte>();
                        //Object data
                        map_data.AddRange(br.ReadBytes(map_offset));
                        //Terrain has mirrored Y axis data
                        Stack<byte[]> tmp = new Stack<byte[]>();
                        for (int i = 0; i < MAP_SIZE; i++)
                        {
                            tmp.Push(br.ReadBytes(MAP_SIZE));
                        }
                        while (tmp.Count > 0)
                        {
                            map_data.AddRange(tmp.Pop());
                        }
                        map_data.Add(br.ReadByte());
                        //Map process
                        for (int i = 0, y = 0; y < MAP_SIZE; y++)
                        {
                            for (int x = 0; x < MAP_SIZE; x++, i++)
                            {
                                byte id = map_data[map_offset + i];
#if DEBUG_VIS
                                byte id2 = id;
#endif
                                TerrainData terr;
                                terrain_data.TryGetValue(id, out terr);
                                id = map_data[i];
                                ObjectData obj;
                                object_data.TryGetValue(id, out obj);
#if DEBUG_VIS
                                AddDebugVisual(x, y, id2, id);
#endif
                                //Terrain
                                if (terr != null)
                                {
                                    bool alt_model = obj != null && terr.special;
                                    string model = terr.model;
                                    if (alt_model)
                                    {
                                        ChangeData ch_tmp;
                                        if (change_data.TryGetValue(obj.model, out ch_tmp))
                                        {
                                            if (alt_model = ch_tmp.replace)
                                            {
                                                model = ch_tmp.model;
                                            }
                                            else
                                            {
                                                obj.model = ch_tmp.model;
                                            }
                                        }
                                    }
                                    string objectid;
                                    if (stunts_data.TryGetValue(model, out objectid))
                                    {
                                        string angles = quaterion[terr.angle];
                                        float offs = terr.offs;
                                        sw.WriteLine(ipl_line_format,
                                            objectid,
                                            model,
                                            start_x + x * ELEM_OFFS,
                                            start_y + y * ELEM_OFFS,
                                            start_z2 + offs,
                                            angles);
                                    }
                                    //Skip object part
                                    if (alt_model) continue;
                                }
                                //Objects
                                if (obj != null)
                                {
                                    float z_offs = terr != null ? terr.offs : 0f;
                                    string model = obj.model;
                                    if (!finish_found && model == tb_fini.Text)
                                    {
                                        finish_found = true;
                                        player_x = start_x + x * ELEM_OFFS;
                                        player_y = start_y + y * ELEM_OFFS;
                                        player_z = start_z + z_offs + 1.0f;
                                        tb_start.Text = string.Format("{0}, {1}, {2}",
                                            player_x, player_y, player_z);
                                    }
                                    string objectid;
                                    if (stunts_data.TryGetValue(model, out objectid))
                                    {
                                        string angles = quaterion[obj.angle];
                                        float offs = obj.offs;
                                        float offs2 = obj.offs2;
                                        sw.WriteLine(ipl_line_format,
                                            objectid,
                                            model,
                                            start_x + x * ELEM_OFFS + offs,
                                            start_y + y * ELEM_OFFS + offs2,
                                            start_z + z_offs,
                                            angles);
                                        model = obj.model2;
                                        if (model != null)
                                        {
                                            if (stunts_data.TryGetValue(model, out objectid))
                                            {
                                                angles = quaterion[obj.angle2];
                                                sw.WriteLine(ipl_line_format,
                                                    objectid,
                                                    model,
                                                    start_x + x * ELEM_OFFS + offs,
                                                    start_y + y * ELEM_OFFS + offs2,
                                                    start_z + z_offs,
                                                    angles);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        int map_edge = 2;
                        int map_edge2 = map_edge - 1;
                        for (int x = -map_edge; x < MAP_SIZE + map_edge; x++)
                        {
                            for (int y = -map_edge; y < MAP_SIZE + map_edge; y++)
                            {
                                bool x_left = x < 0;
                                bool y_bottom = y < 0;
                                bool x_right = x >= MAP_SIZE;
                                bool y_top = y >= MAP_SIZE;
                                if (!x_left && !y_bottom && !x_right && !y_top) continue;
                                string model = "st_terr";
                                string angles = quaterion[0];
                                string objectid;
                                if (stunts_data.TryGetValue(model, out objectid))
                                {
                                    sw.WriteLine(ipl_line_format,
                                        objectid,
                                        model,
                                        start_x + x * ELEM_OFFS,
                                        start_y + y * ELEM_OFFS,
                                        start_z2,
                                        angles);
                                }
                            }
                        }
                        map_edge -= 1;
                        map_edge2 -= 1;
                        for (int x = -map_edge; x < MAP_SIZE + map_edge; x++)
                        {
                            for (int y = -map_edge; y < MAP_SIZE + map_edge; y++)
                            {
                                bool x_left = x == -map_edge;
                                bool y_bottom = y == -map_edge;
                                bool x_right = x == MAP_SIZE + map_edge2;
                                bool y_top = y == MAP_SIZE + map_edge2;
                                if (!x_left && !y_bottom && !x_right && !y_top) continue;
                                string model;
                                string angles = "";
                                string objectid;
                                if ((x_left && (y_bottom || y_top)) || (y_bottom && (x_left || x_right) || (x_right && y_top)))
                                {
                                    if (x_left)
                                    {
                                        if (y_top) angles = quaterion[180];
                                        else angles = quaterion[90];
                                    }
                                    else if (y_bottom) angles = quaterion[0];
                                    else if (x_right) angles = quaterion[270];
                                    model = "st_cfen";
                                }
                                else
                                {
                                    if (x_left) angles = quaterion[90];
                                    else if (y_bottom) angles = quaterion[0];
                                    else if (x_right) angles = quaterion[270];
                                    else angles = quaterion[180];
                                    model = "st_fenc";
                                }
                                if (stunts_data.TryGetValue(model, out objectid))
                                {
                                    sw.WriteLine(ipl_line_format,
                                        objectid,
                                        model,
                                        start_x + x * ELEM_OFFS,
                                        start_y + y * ELEM_OFFS,
                                        start_z,
                                        angles);
                                }
                            }
                        }
                        sw.WriteLine("end");
                    }
                }
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        private float TryFloat(string input, float alt)
        {
            float ret;
            if (float.TryParse(input, out ret)) return ret;
            else return alt;
        }

        private void ShowInfo(string msg)
        {
            MessageBox.Show(msg, Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ShowError(string msg)
        {
            MessageBox.Show(msg, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

#if DEBUG_VIS
        //Reversed Y axis drawing
        private void AddDebugVisual(int x, int y, byte id, byte id2)
        {
            int size = 27;
            Label tmp = new Label();
            tmp.BorderStyle = BorderStyle.FixedSingle;
            tmp.SetBounds(12 + x * size, size + (MAP_SIZE - y) * size, size, size);
            if (id2 != 0) tmp.BackColor = Color.LightYellow;
            else if (id != 0) tmp.BackColor = Color.LightBlue;
            else tmp.BackColor = Color.LightGreen;
            tmp.TextAlign = ContentAlignment.MiddleCenter;
            tmp.Text = id.ToString("X2") + "\n" + id2.ToString("X2");
            Controls.Add(tmp);
        }
#endif

        private void bt_convert_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog() != DialogResult.OK) return;
            ConvertTRK(ofd.FileName);
            ShowInfo("Track converted.");
        }

        private void bt_save_Click(object sender, EventArgs e)
        {
            SaveDataCfg();
            ShowInfo("Settings saved.");
        }

        private void bt_about_Click(object sender, EventArgs e)
        {
            ShowInfo("Program written by Kurtis (2023)\nWritten in C# 2008 Express Edition (.Net 3.5)");
        }
    }
}