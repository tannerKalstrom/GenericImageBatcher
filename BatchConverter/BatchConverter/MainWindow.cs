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
        private string ChoosenDirectory = "";
        private bool FlashingChooseDirectory = false;
        private string OutputDirectory {get { return ChoosenDirectory + @"\OUTPUT\";}}
        private string WebDirectory { get { return ChoosenDirectory + @"\WEB\"; } }
        private string PBR_Metalic { get { return ChoosenDirectory + @"\PBR_Metallic"; } }
        private string PBR_Specular { get { return ChoosenDirectory + @"\PBR_Specular"; } }
        private string Substance { get { return ChoosenDirectory + @"\Substance"; } }

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
        public Color BadColor = Color.Red;


       
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Batch_Process_Click(object sender, EventArgs e)
        {
            if (!LOCKBUTTONS)
            {
                LOCKBUTTONS = true;
                Task t = Task.Factory.StartNew(() =>
              {
                  var _base = "8";
                  var shaft = "=";
                  var tip = "D";
                  Progress_Output.BeginInvoke(new MethodInvoker(() =>
                   {
                       Progress_Output.Text = _base + shaft + tip;
                   }));
                  foreach (var directory in Directory.GetDirectories(ChoosenDirectory))
                  {
                      ChoosenDirectory = directory;
                      if (ParseChoosenDirectory())
                          ProcessCurrentDirectory();
                      shaft += "=";
                      Progress_Output.BeginInvoke(new MethodInvoker(() =>
                      {
                          Progress_Output.Text = _base + shaft + tip;
                      }));
                  }
                  Progress_Output.BeginInvoke(new MethodInvoker(() =>
                  {
                      Progress_Output.Text = _base + shaft + tip + "~~ Complete";
                  }));
                  LOCKBUTTONS = false;
              });
            }
                  
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!LOCKBUTTONS)
            {
                LOCKBUTTONS = true;
                Task t = Task.Factory.StartNew(() =>
              {
                  bool run = true;
                  if (string.IsNullOrEmpty(ChoosenDirectory) || !Directory.Exists(ChoosenDirectory))
                  {
                      run = false;
                      Output.AppendText("Choose a valid Directory First!\n");
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
          
                  Output.BeginInvoke(new MethodInvoker(()=>{
                      Output.AppendText("Start Batcher: " + ChoosenDirectory + "\n");
                  }));
                  Directory.CreateDirectory(OutputDirectory);
                                    Output.BeginInvoke(new MethodInvoker(()=>{

                  Output.AppendText("Zipping\n");
                                                          }));

                  Zip_Files();
                                                          Output.BeginInvoke(new MethodInvoker(()=>{

                  Output.AppendText("Shrinking\n");
                                                                                }));

                  DownscaleForWeb();
                                                                                Output.BeginInvoke(new MethodInvoker(()=>{

                  Output.AppendText("Compositing\n");
                                                                                                      }));

                  CompositePNGs();
                                                                                                      Output.BeginInvoke(new MethodInvoker(()=>{

                  Output.AppendText("Complete Batching!\n");
                                                                                                      }));

                  FlashControlToColor(Output, Color.LightGreen);
                 
            
        }

        private void CompositePNGs()
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

            if (!string.IsNullOrEmpty(background) && png_files.Count >0)
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

       
        

        private void ResetFlashingChooseDirectory()
        {
            FlashingChooseDirectory = true;
        }
        


        private void DownscaleForWeb()
        {
            if(!string.IsNullOrEmpty(ChoosenDirectory))
                Directory.CreateDirectory(Output_Web);

            foreach (var file in Directory.GetFiles(PBR_Specular))
            {
                try
                {
                    if (file.EndsWith(".tga"))
                    {
                        var filename = Path.GetFileNameWithoutExtension(file);
                        filename += ".jpg";
                        MagickImage image = new MagickImage(file);
                        image.Scale(1024, 1024);
                        image.Write(Output_Web + filename);
                    }
                }
                catch (Exception ee)
                {

                }

            }
        }

        private void Zip_Files()
        {

            if (!string.IsNullOrEmpty(Cat) && !string.IsNullOrEmpty(Mat))
            {
                if (File.Exists(Output_PBR_Metalic))
                {
                    File.Delete(Output_PBR_Metalic);
                }
                ZipFile.CreateFromDirectory(PBR_Metalic, Output_PBR_Metalic);

                if (File.Exists(Output_PBR_Specular))
                {
                    File.Delete(Output_PBR_Specular);
                }

                ZipFile.CreateFromDirectory(PBR_Specular, Output_PBR_Specular);

                if (File.Exists(Output_Substance))
                {
                    File.Delete(Output_Substance);
                }

                ZipFile.CreateFromDirectory(Substance, Output_Substance);
            }
            else
            {
                FlashControlToColor(_Catagory, BadColor);
                FlashControlToColor(_Material, BadColor);
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
                ChoosenDirectory = dialog.SelectedPath;
                ParseChoosenDirectory();
            }
            else
            {
                ChoosenDirectory = string.Empty;
            }
            if (string.IsNullOrEmpty(ChoosenDirectory) && ParseChoosenDirectory())
            {
                Output.AppendText("Directory looks good to process singly" + "\n");
            }
            else if (sum_subs > 0)
            {
                Output.AppendText("Folder eligable to try Recursive Batching" + "\n");
            }
            Output.AppendText("Completed parsing files in directory" + "\n");
        }

        private bool ParseChoosenDirectory()
        {
            try
            {
                Catagory = new List<string>();
                Material = new List<string>();
                Resolution = new List<string>();
                TType = new List<string>();
                EExtensions = new List<string>();
                Catagory_Echo.BeginInvoke(new MethodInvoker(() =>
                        {
                Catagory_Echo.Text = string.Empty;
                        }));

                Res_Echo.BeginInvoke(new MethodInvoker(() =>
                        {
                Res_Echo.Text = string.Empty;
                                                    }));

                Material_Echo.BeginInvoke(new MethodInvoker(() =>
                        {
                Material_Echo.Text = string.Empty;
                                                    }));

                Type_Echo.BeginInvoke(new MethodInvoker(() =>
                        {
                Type_Echo.Text = string.Empty;
                        }));
                sum_subs = Directory.GetDirectories(ChoosenDirectory).Count();

                SubDirectories_Output.BeginInvoke(new MethodInvoker(()=>{
                    SubDirectories_Output.Text = sum_subs.ToString();
                }));
                text_ActiveDirectory.BeginInvoke(new MethodInvoker(() =>
                {
                    text_ActiveDirectory.Text = ChoosenDirectory;
                }));
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
                            Output.AppendText("Failed Parsing files" + "\n");
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
                            Output.AppendText("Failed Parsing files" + "\n");
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
                Catagory_Echo.BeginInvoke(new MethodInvoker(() =>
                {
                Catagory_Echo.Text = Cat;
                }));
                FlashControlToColor(_Catagory, GoodColor);
            }
            else
            {
                Catagory_Echo.BeginInvoke(new MethodInvoker(() =>
                {
                Catagory_Echo.Text = string.Join(", ", Catagory);
                    }));
                FilesLookCorrect = false;
                FlashControlToColor(_Catagory, BadColor);
            }
            if (Resolution.Count == 1)
            {
                Rat = Resolution.ElementAt(0);
                Res_Echo.BeginInvoke(new MethodInvoker(() =>
                {
                Res_Echo.Text = Rat;
                    }));
                FlashControlToColor(_Res, GoodColor);
            }
            else
            {
                Res_Echo.BeginInvoke(new MethodInvoker(() =>
                {
                Res_Echo.Text = string.Join(", ", Resolution);
                    }));
                FilesLookCorrect = false;
                FlashControlToColor(_Res, BadColor);
            }
            if (Material.Count == 1)
            {
                Mat = Material.ElementAt(0);
                Material_Echo.BeginInvoke(new MethodInvoker(() =>
                {
                Material_Echo.Text = Mat;
                    }));
                FlashControlToColor(_Material, GoodColor);
            }
            else
            {
                Material_Echo.BeginInvoke(new MethodInvoker(() =>
                {
                Material_Echo.Text = string.Join(", ", Material);
                    }));
                FilesLookCorrect = false;
                FlashControlToColor(_Material, BadColor);
            }
            if (TType.Count >0)
            {
                Tat = TType.ElementAt(0);
                Type_Echo.BeginInvoke(new MethodInvoker(() =>
                {
                Type_Echo.Text = string.Join(", ", TType);
                    }));
                FlashControlToColor(_Type, GoodColor);
            }
            else
            {
                FilesLookCorrect = false;
                FlashControlToColor(_Type, BadColor);
            }
            if (EExtensions.Count > 0)
            {
                Eat = EExtensions.ElementAt(0);
                Extensions_Echo.BeginInvoke(new MethodInvoker(() =>
                {
                Extensions_Echo.Text = string.Join(", ", EExtensions);
                }));
                FlashControlToColor(_Extensions, GoodColor);
            }
            else
            {
                FilesLookCorrect = false;
                FlashControlToColor(_Extensions, BadColor);
            }
            return FilesLookCorrect;
        }
                
    
public  bool FilesLookCorrect { get; set; }

    private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
    {

    }



    public int sum_subs { get; set; }

    public bool LOCKBUTTONS { get; set; }
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

