using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ImageMagick;
using System.IO;
using System.IO.Compression;
using System.Threading;
using FORMS = System.Windows.Forms;
namespace BatchConverter
{

    public partial class MainWindow : Form
    {
        private bool Halt_Bool = false;
        private string ChoosenDirectory = "";
        private string OutputDirectory {get { return ChoosenDirectory + @"\OUTPUT\";}}
        private string WebDirectory { get { return ChoosenDirectory + @"\WEB\"; } }
        private string PBR_Metalic { get { return ChoosenDirectory + @"\PBR_Metallic"; } }
        private string PBR_Specular { get { return ChoosenDirectory + @"\PBR_Specular"; } }
        private string Substance { get { return ChoosenDirectory + @"\Substance"; } }

        private bool has_PBR_Metalic { get; set; }
        private bool has_PBR_Specular { get; set; }
        private bool has_Substance { get; set; }
        private bool has_WebDirectory { get; set; }
        private int WebSize = 1024;

        private string Output_PBR_Metalic { get { return OutputDirectory + @"\" + Cat + "_" + Mat + "_PBR_Metallic.zip"; } }
        private string Output_PBR_Specular { get { return OutputDirectory + @"\" + Cat +"_" + Mat + "_PBR_Specular.zip"; } }
        private string Output_Substance { get { return OutputDirectory + @"\" + Catagory.ElementAt(0) + "_" + Material.ElementAt(0) + @"_Substance.zip"; } }
        private string Output_Web { get { return OutputDirectory + @"\WEB\"; } }

        public List<string> Catagory { get; set; }
        public string Cat {get;set;}
        public List<string> Material { get; set; }
        public string Mat {get;set;}
        public List<string> Resolution { get; set; }
        public string Rat {get;set;}
        public List<string>     TType       { get; set; }
        public string Tat {get;set;}
        public List<string> EExtensions { get; set; }
        public string Eat {get;set;}
        public Color GoodColor = Color.LightGreen;
        public Color BadColor = Color.LightPink;


       
        public MainWindow()
        {
            InitializeComponent();
        }
        
        public void DebuggingOutput(string output, bool force_output = false){
            if (checkBox2.Checked || force_output)
                Output.BeginInvoke(new MethodInvoker(() =>
                {
                    Output.AppendText(output + "\n");
                }));
        }
        private void Batch_Process_Click(object sender, EventArgs e)
        {
            if (!Eligable_For_Batching) return;
            if (!LOCKBUTTONS)
            {
                Halt_Bool = false;
                LOCKBUTTONS = true;
                Task t = Task.Factory.StartNew(() =>
              {

                  try
                  {
                      int Progresss = 0;
                      Progress_Output.BeginInvoke(new MethodInvoker(() =>
                       {
                           Progress_Output.Text = Progresss.ToString();
                       }));
                      foreach (var directory in Directory.GetDirectories(ChoosenDirectory))
                      {
                          if (Halt_Bool) return;
                          try
                          {
                              ChoosenDirectory = directory;

                              SetActiveDirectory();
                              ProcessCurrentDirectory();
                              Progresss += 1;
                              Progress_Output.BeginInvoke(new MethodInvoker(() =>
                              {
                                  Progress_Output.Text = Progresss.ToString();
                              }));
                          }
                          catch (Exception eee)
                          {
                              Output.BeginInvoke(new MethodInvoker(() =>
                              {
                                  DebuggingOutput("Ouch! Something went wrong");
                              }));
                          }
                      }
                      Progress_Output.BeginInvoke(new MethodInvoker(() =>
                      {
                          Progress_Output.Text =Progresss+ " !! Complete";
                      }));
                  }
                  catch (Exception ee)
                  {
                      Output.BeginInvoke(new MethodInvoker(() =>
                      {
                          DebuggingOutput("Ouch! Something went wrong");
                      }));
                  }
                  LOCKBUTTONS = false;
              });
            }
                  
        }
      

        private void button1_Click(object sender, EventArgs e)
        {
            if (!LOCKBUTTONS && Eligable_For_Processing)
            {
                Halt_Bool = false;
                LOCKBUTTONS = true;
                Task t = Task.Factory.StartNew(() =>
              {
                  bool run = true;
                  if (string.IsNullOrEmpty(ChoosenDirectory) || !Directory.Exists(ChoosenDirectory))
                  {
                      run = false;
                      DebuggingOutput("Choose a valid Directory First!");
                      FlashControlToColor(button_ChooseActiveDirectory, BadColor);
                  }
                  if (run)
                  {
                      ProcessCurrentDirectory();
                  }
              });
                LOCKBUTTONS = false;
            }
        }

        private void ProcessCurrentDirectory()
        {
            if (!Eligable_For_Processing) return;
            DebuggingOutput("Start Batcher: " + ChoosenDirectory);
            Directory.CreateDirectory(OutputDirectory);
            if (Halt_Bool) return;
            DebuggingOutput("Begin Zipping");          
            Zip_Files();
            if (Halt_Bool) return;
            DebuggingOutput("Shrinking");
            DownscaleForWeb();
            if (Halt_Bool) return;
            DebuggingOutput("Compositing");
            CompositePNGs();
            DebuggingOutput("Complete Batching!");
            FlashControlToColor(Output, Color.LightGreen);
            if (Halt_Bool) return;
        }

        private void CompositePNGs()
        {
            if (has_WebDirectory)
            {
                string background = string.Empty;
                List<string> png_files = new List<string>();
                foreach (var file in Directory.GetFiles(WebDirectory))
                {
                    var filename = Path.GetFileNameWithoutExtension(file);
                    var extension = Path.GetExtension(file);
                    if (extension == ".png")
                    {
                        if (filename == "background")
                        {
                            background = file;
                        }
                        else
                        {
                            png_files.Add(file);
                        }
                    }
                }

                if (!string.IsNullOrEmpty(background) && png_files.Count > 0)
                {
                    MagickImage bottom_layer = new MagickImage(background);

                    foreach (var png in png_files)
                    {
                        MagickImage top_layer = new MagickImage(png);
                        MagickImage Composite = new MagickImage(background);
                        Composite.Composite(top_layer, CompositeOperator.Atop);
                        Composite.Write(Output_Web + Path.GetFileNameWithoutExtension(png) + "_Large_Preview.png");
                        top_layer.Scale(1024, 1024);
                        top_layer.Write(Output_Web + Path.GetFileNameWithoutExtension(png) + "_Small_Preview.png");
                    }
                }
            }
        }

       
        

        private void ResetFlashingChooseDirectory()
        {
        }
        


        private void DownscaleForWeb()
        {
            if(!string.IsNullOrEmpty(ChoosenDirectory))
                Directory.CreateDirectory(Output_Web);
            if (has_PBR_Specular)
            {
                foreach (var file in Directory.GetFiles(PBR_Specular))
                {
                    try
                    {
                        if (file.EndsWith(".tga"))
                        {
                            var filename = Path.GetFileNameWithoutExtension(file);
                            filename += ".jpg";
                            MagickImage image = new MagickImage(file);
                            image.Scale(WebSize, WebSize);
                            image.Write(Output_Web + filename);
                        }
                    }
                    catch (Exception ee)
                    {

                    }

                }
            }
        }

        private void Zip_Files()
        {

            if (!string.IsNullOrEmpty(Cat) && !string.IsNullOrEmpty(Mat))
            {
               if(has_PBR_Specular) Zip_PBR_Specular();
               if(has_PBR_Metalic) Zip_PBR_Metalic();
               if(has_Substance) Zip_Substance();
            }
            else
            {
                FlashControlToColor(Output, BadColor);
            }
        }

        private void Zip_Substance()
        {
            if (File.Exists(Output_Substance) && overwrite.Checked)
            {
                File.Delete(Output_Substance);
                DebuggingOutput("Removing old Substance zip");
            }
            if (!File.Exists(Output_Substance))
            {
                DebuggingOutput("Creating new Substance zip");
                ZipFile.CreateFromDirectory(Substance, Output_Substance);
            }
        }

        private void Zip_PBR_Metalic()
        {
            if (File.Exists(Output_PBR_Specular) && overwrite.Checked)
            {
                File.Delete(Output_PBR_Specular);
                DebuggingOutput("Removing old PBR_Specular zip");
            }
            if (!File.Exists(Output_PBR_Specular))
            {
                DebuggingOutput("Creating new PBR_Metallic zip");
                ZipFile.CreateFromDirectory(PBR_Specular, Output_PBR_Specular);
            }
        }

        private void Zip_PBR_Specular()
        {
            if (File.Exists(Output_PBR_Metalic) && overwrite.Checked)
            {
                File.Delete(Output_PBR_Metalic);
                DebuggingOutput("Removing old PBR_Metallic zip");
            }
            if (!File.Exists(Output_PBR_Metalic))
            {
                DebuggingOutput("Creating new PBR_Metallic zip");
                ZipFile.CreateFromDirectory(PBR_Metalic, Output_PBR_Metalic);
            }
        }

        private void Copy_SubstanceFiles()
        {
            if (Directory.Exists(Substance))
            {
                //Now Create all of the directories
                foreach (string dirPath in Directory.GetDirectories(Substance, "*",
                    SearchOption.AllDirectories))
                    Directory.CreateDirectory(dirPath.Replace(Substance, Output_Substance));

                //Copy all the files & Replaces any files with the same name
                foreach (string newPath in Directory.GetFiles(Substance, "*.*",
                    SearchOption.AllDirectories))
                    File.Copy(newPath, newPath.Replace(Substance, Output_Substance), true);
            }
        }

        private void ResetFlashingOutput()
        {
            FlashingOutput = false;
        }

        public bool FlashingOutput { get; set; }
        private void FlashControlToColor(Control activeControl, Color eventColour)
        {
            if (!checkBox1.Checked) return;
            uint intervals = 100;
            var origin_color = activeControl.BackColor;
            var colorFader = new ColorFader(eventColour, origin_color, intervals);
            Task t = Task.Factory.StartNew(() =>
            {
                foreach (var color in colorFader.Fade())
                {
                    SetControlBackColor(activeControl, color);
                    System.Threading.Thread.Sleep(10);
                }
            });
        }

        private void SetControlBackColor(Control activeControl,Color color)
        {
            if (activeControl.InvokeRequired)
                activeControl.Invoke((MethodInvoker)delegate { activeControl.BackColor = color; });
            else
                activeControl.BackColor = color;
        }
        private void button_ChooseActiveDirectory_Click(object sender, EventArgs e)
        {
            //
            // This event handler was created by double-clicking the window in the designer.
            // It runs on the program's startup routine.
            //
            var dialog = new System.Windows.Forms.FolderBrowserDialog();
            if(!string.IsNullOrEmpty(ChoosenDirectory))
                dialog.SelectedPath = ChoosenDirectory;
            System.Windows.Forms.DialogResult result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                if (dialog.SelectedPath != ChoosenDirectory)
                {
                    ChoosenDirectory = dialog.SelectedPath;
                    SetActiveDirectory();
                }
            }
            else
            {
                ChoosenDirectory = string.Empty;
            }
           
            DebuggingOutput("Completed parsing files in directory");
        }

        private void SetActiveDirectory()
        {
            Check_For_Folders();
            Process_Eligability();
            if (Eligable_For_Processing)
            {
                ScanChosenDirectory();
            }
        }

        private void Process_Eligability()
        {
            Eligable_For_Processing = false;
            Eligable_For_Batching = false;

            if (has_PBR_Metalic || has_PBR_Specular || has_Substance || has_WebDirectory)
            {
                Eligable_For_Processing = true;
            }
            else if(sum_subs > 0)
            {
                Eligable_For_Batching = true;
            }
        }

        private void Check_For_Folders()
        {
            has_PBR_Metalic= Directory.Exists(PBR_Metalic);
            has_PBR_Metalic = Directory.Exists(PBR_Specular);
            has_Substance = Directory.Exists(Substance);
            has_WebDirectory = Directory.Exists(WebDirectory);
            sum_subs = Directory.GetDirectories(ChoosenDirectory).Count();
            SubDirectories_Output.BeginInvoke(new MethodInvoker(() =>
            {
                SubDirectories_Output.Text = sum_subs.ToString();
            }));
            text_ActiveDirectory.BeginInvoke(new MethodInvoker(() =>
            {
                text_ActiveDirectory.Text = ChoosenDirectory;
            }));
        }

        private bool ScanChosenDirectory()
        {
            try
            {
                Catagory = new List<string>();
                Material = new List<string>();
                Resolution = new List<string>();
                TType = new List<string>();
                EExtensions = new List<string>();
               
                var Files = Directory.GetFiles(PBR_Metalic);
                foreach (var file in Files)
                {
                    try
                    {
                        string name = Path.GetFileName(file);
                        if (!EExtensions.Contains(Path.GetExtension(file))) EExtensions.Add(Path.GetExtension(file));
                        var bits = name.Split('_');
                        if (bits.Length == 4)
                        {
                            if (!Catagory.Contains(bits[0])) Catagory.Add(bits[0]);
                            if (!Material.Contains(bits[1])) Material.Add(bits[1]);
                            if (!Resolution.Contains(bits[2])) Resolution.Add(bits[2]);
                            if (!TType.Contains(bits[3].Substring(0, bits[3].IndexOf(Path.GetExtension(file))))) TType.Add(bits[3].Substring(0, bits[3].IndexOf(Path.GetExtension(file))));
                        }
                    }
                    catch (Exception ee)
                    {
                        Output.BeginInvoke(new MethodInvoker(() =>
                        {
                            DebuggingOutput("Failed Parsing files");
                        }));
                    }
                }
                Files = Directory.GetFiles(PBR_Specular);
                foreach (var file in Files)
                {
                    try
                    {
                        string name = Path.GetFileName(file);
                        if (!EExtensions.Contains(Path.GetExtension(file))) EExtensions.Add(Path.GetExtension(file));
                        var bits = name.Split('_');
                        if (bits.Length == 4)
                        {
                            if (!Catagory.Contains(bits[0])) Catagory.Add(bits[0]);
                            if (!Material.Contains(bits[1])) Material.Add(bits[1]);
                            if (!Resolution.Contains(bits[2])) Resolution.Add(bits[2]);
                            if (!TType.Contains(bits[3].Substring(0, bits[3].IndexOf(Path.GetExtension(file))))) TType.Add(bits[3].Substring(0, bits[3].IndexOf(Path.GetExtension(file))));
                        }
                    }
                    catch (Exception ee)
                    {
                        Output.BeginInvoke(new MethodInvoker(() =>
                        {
                            DebuggingOutput("Failed Parsing files" );
                        }));
                    }
                }
            }
            catch (Exception ee)
            {
                FlashControlToColor(Output, BadColor);
            }
           return VerifyParsedValues();
        }


        //Checks the files and returns if it looks like its probably the right type of folder.
        private bool VerifyParsedValues()
        {
            FilesLookCorrect = true;
            if (Catagory.Count == 1)
            {
                Cat = Catagory.ElementAt(0);
                DebuggingOutput(string.Format("Catagory : {0} Valid : {1}", Cat,true));
            }
            else
            {
                DebuggingOutput(string.Format("Catagories : {0} Valid : {1}", string.Join(", ", Catagory),false));
                FilesLookCorrect = false;
            }
            if (Resolution.Count == 1)
            {
                Rat = Resolution.ElementAt(0);
                DebuggingOutput(string.Format("Resolution : {0} Valid : {1}", Rat,true));
            }
            else
            {
                DebuggingOutput(string.Format("Resolutions : {0} Valid : {1}", string.Join(", ", Resolution), false));
                FilesLookCorrect = false;
            }
            if (Material.Count == 1)
            {
                Mat = Material.ElementAt(0);
                DebuggingOutput(string.Format("Material : {0} Valid : {1}", Mat,true));
            }
            else
            {
                DebuggingOutput(string.Format("Material : {0} Valid : {1}", string.Join(", ", Material), false));
                FilesLookCorrect = false;
            }
            if (TType.Count >0)
            {
                Tat = TType.ElementAt(0);
                DebuggingOutput(string.Format("Type : {0} Valid : {1}", Tat,true));
            }
            else
            {
                FilesLookCorrect = false;
            }
            if (EExtensions.Count > 0)
            {
                Eat = EExtensions.ElementAt(0);
                DebuggingOutput(string.Format("Extension : {0} Valid : {1}", Eat ,true));
            }
            else
            {
                FilesLookCorrect = false;
                DebuggingOutput(string.Format("Extensions : {0} Valid : {1}", string.Join(", ", EExtensions), false));
            }
            return FilesLookCorrect;
        }
                
    
public  bool FilesLookCorrect { get; set; }

    private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
    {

    }



    public int sum_subs { get; set; }

    public bool LOCKBUTTONS { get; set; }

    private void checkBox2_CheckedChanged(object sender, EventArgs e)
    {
        DebuggingOutput("Debugging Outputs: " + checkBox2.Checked,true);
    }

    private void checkBox1_CheckedChanged(object sender, EventArgs e)
    {
        DebuggingOutput("UI Effects: " + checkBox1.Checked, true);
    }

    private void overwrite_CheckedChanged_1(object sender, EventArgs e)
    {
        DebuggingOutput("Overwrite Outputs: " + overwrite.Checked, true);
    }

    private void textBox1_Validating(object sender, CancelEventArgs e)
    {

    }

    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        if (int.TryParse(textBox1.Text, out WebSize))
        {
            DebuggingOutput("WebSize set to: " + WebSize);
        }
        else
        {
            WebSize = 1024;
        }
    }

    private void Exit_Click(object sender, EventArgs e)
    {
        Application.Exit();
    }

    private void Halt_Click(object sender, EventArgs e)
    {
        DebuggingOutput("Halting!");
        Halt_Bool = true;
        LOCKBUTTONS = false;
    }


    public bool Eligable_For_Processing { get; set; }

    public bool Eligable_For_Batching { get; set; }
    }

    public class ColorFader
    {
        private readonly Color _From;
        private readonly Color _To;

        private readonly double _StepR;
        private readonly double _StepG;
        private readonly double _StepB;

        private readonly uint _Steps;

        public ColorFader(Color from, Color to, uint steps)
        {
            if (steps == 0)
                throw new ArgumentException("steps must be a positive number");

            _From = from;
            _To = to;
            _Steps = steps;

            _StepR = Math.Floor((double)(_To.R - _From.R)) / _Steps;
            _StepG = Math.Floor((double)(_To.G - _From.G)) / _Steps;
            _StepB = Math.Floor((double)(_To.B - _From.B)) / _Steps;
        }

        public IEnumerable<Color> Fade()
        {
            for (uint i = 0; i < _Steps; ++i)
            {
                yield return Color.FromArgb((int)(_From.R + i * _StepR), (int)(_From.G + i * _StepG), (int)(_From.B + i * _StepB));
            }
            yield return _To; // make sure we always return the exact target color last
        }
    }
}

