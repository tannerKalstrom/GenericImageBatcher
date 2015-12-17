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
using System.Diagnostics;
namespace BatchConverter
{

    public partial class MainWindow : Form
    {
        #region Properties
        private bool Halt_Bool = false;
        private string ChosenDirectory = "";
        public string ChoosenReadme = Application.StartupPath + @"\Include\Readme.txt";
        public string ChoosenScene = Application.StartupPath + @"\Include\3dScene.tbscene";
        public string CleanScreenshots = Application.StartupPath + @"\Include\CleanScreenshots.exe";
        private string OutputDirectory {get { return ChosenDirectory + @"\OUTPUT\";}}
        private string SBRAROutputDirectory { get { return ChosenDirectory + @"\SbrarRenders\"; } }
        private string WebDirectory { get { return ChosenDirectory + @"\WEB"; } }
        private string PBR_Metalic { get { return ChosenDirectory + @"\PBR_Metallic"; } }
        private string PBR_Specular { get { return ChosenDirectory + @"\PBR_Specular"; } }
        private string Substance { get { return ChosenDirectory + @"\Substance"; } }



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

        public bool Eligable_For_Processing { get; set; }
        public bool Eligable_For_Batching { get; set; }

        public bool FilesLookCorrect { get; set; }
        public int sum_subs { get; set; }
        public bool LOCKBUTTONS { get; set; }
        public Dictionary<Control, Color> OgiginColors = new Dictionary<Control, Color>();

        
        #endregion

        public MainWindow()
        {
            InitializeComponent();
            Properties.Settings.Default.Upgrade();
            Label_Readme.Text = Properties.Settings.Default.readmefile;
            Label_TbScene.Text = Properties.Settings.Default.tbScene;
            Label_Substance.Text = Properties.Settings.Default.substancefolder;
            SubstanceDir = Properties.Settings.Default.substancefolder;
            ChosenDirectory = Properties.Settings.Default.LastDirectory;

            Update();

        }

        private void InitializeGTDir_Click(object sender, EventArgs e)
        {
            DebuggingOutput("Starting Creating GT Directory Structures",true);
            InitializeGTDir_Logic();
            DebuggingOutput("Finished Creating GT Directory Structures",true);
            SetActiveDirectory();
        }

        private void InitializeGTDir_Logic()
        {
            if (!string.IsNullOrEmpty(ChosenDirectory))
            {
                CreateDirectoryStructure();
                RenderSBRAR();
                CopyGTFilesIntoDirectory();
            }

        }

        private void RenderSBRAR()
        {
            var files = Directory.GetFiles(ChosenDirectory);
           
           foreach(var file in files)
            {
                var ext = Path.GetExtension(file);
               var name = Path.GetFileNameWithoutExtension(file);
                if (ext == ".sbsar")
                {
                    SubstanceFileGenerationAndZip(file);
                    MoveExistingFilesIntoFinalPositions(SBRAROutputDirectory, name);
                    File.Move(file, Substance + "\\" + Path.GetFileName(file));
                }
            }
           if (Directory.Exists(SBRAROutputDirectory)) Directory.Delete(SBRAROutputDirectory);
        }



        private void MoveExistingFilesIntoFinalPositions(string InputDirectory, string mask)
        {
            foreach (string file in Directory.GetFiles(InputDirectory))
            {
                if (Path.GetExtension(file) == ".tga")
                {
                    SortTGA(file,mask);
                }
            }
        }

        private void SortTGA(string file, string mask)
        {
            var normalized_file_name = file.ToLower();
            var thi = Path.GetFileName(file);
            var corrected_file_path = thi.Substring(thi.LastIndexOf(mask));
            normalized_file_name=Path.GetFileNameWithoutExtension(normalized_file_name);
            if (normalized_file_name.EndsWith("_g") || normalized_file_name.EndsWith("_s") || normalized_file_name.EndsWith("_alb"))
                File.Copy(file, PBR_Specular + "\\" + Path.GetFileName(corrected_file_path));
            else if (normalized_file_name.EndsWith("_basecolor") || normalized_file_name.EndsWith("_roughness") || normalized_file_name.EndsWith("_metallic"))
                File.Copy(file, PBR_Metalic + "\\" + Path.GetFileName(corrected_file_path));
            else
            {
                File.Copy(file, PBR_Metalic + "\\" + Path.GetFileName(corrected_file_path));
                File.Copy(file, PBR_Specular + "\\" + Path.GetFileName(corrected_file_path));
            }
            File.Delete(file);

        }

        private void CopyGTFilesIntoDirectory()
        {
            if (File.Exists(ChoosenReadme))
            {
                File.Copy(ChoosenReadme, PBR_Specular +"\\"+ Path.GetFileName(ChoosenReadme));
                File.Copy(ChoosenReadme, PBR_Metalic + "\\" + Path.GetFileName(ChoosenReadme));
                File.Copy(ChoosenReadme, Substance + "\\" + Path.GetFileName(ChoosenReadme));
            }
            else
            {
                DebuggingOutput("Readme not found");
            }
            if (File.Exists(ChoosenScene))
            {
                File.Copy(ChoosenScene, WebDirectory + "\\" + Path.GetFileName(ChoosenScene));
            }
            else
            {
                DebuggingOutput("tbscene not found");
            }
            if (File.Exists(CleanScreenshots))
            {
                File.Copy(CleanScreenshots, WebDirectory + "\\" + Path.GetFileName(CleanScreenshots));
            }
            else
            {
                DebuggingOutput("Screenshot Cleaner not found");
            }
            MagickImage DarkFile = new MagickImage(new MagickColor("#202020"), 1920, 1080);
            DarkFile.Write(WebDirectory + "\\background.png");
        }
        private void CreateDirectoryStructure()
        {
            if (!Directory.Exists(SBRAROutputDirectory)) Directory.CreateDirectory(SBRAROutputDirectory);
            if (!Directory.Exists(WebDirectory)) Directory.CreateDirectory(WebDirectory);
            if (!Directory.Exists(PBR_Metalic)) Directory.CreateDirectory(PBR_Metalic);
            if (!Directory.Exists(PBR_Specular)) Directory.CreateDirectory(PBR_Specular);
            if (!Directory.Exists(Substance)) Directory.CreateDirectory(Substance);
        }

        #region Core_Functions
        private void InitializeUserSettings()
        {
            overwrite.BeginInvoke(new MethodInvoker(() =>
            {
                overwrite.Checked = Properties.Settings.Default.Overwrite;
            }));
            verbose.BeginInvoke(new MethodInvoker(() =>
            {
                verbose.Checked = Properties.Settings.Default.Verbose;
            }));
            ui.BeginInvoke(new MethodInvoker(() =>
            {
                ui.Checked = Properties.Settings.Default.UI;
            }));
            ChosenDirectory = Properties.Settings.Default.LastDirectory;
            text_ActiveDirectory.BeginInvoke(new MethodInvoker(() =>
            {
                text_ActiveDirectory.Text = ChosenDirectory;
            }));
          //  ChoosenReadme = Properties.Settings.Default.ReadmeFile;
           // ChoosenScene = Properties.Settings.Default.SceneFile;
        }
        
        public void DebuggingOutput(string output, bool force_output = false){
            if (verbose.Checked || force_output)
                Output.BeginInvoke(new MethodInvoker(() =>
                {
                    Output.Text =( output + System.Environment.NewLine.ToString()) + Output.Text;
                }));
        }
        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void MainWindow_Load(object sender, EventArgs e)
        {
            InitializeUserSettings();
        }
        #endregion

        #region ProcessingLogic
        private void Batch_Process_Click(object sender, EventArgs e)
        {
            if (!Eligable_For_Batching)
            {
                DebuggingOutput("Folder doesnt meet requirements for batching",true);
                return;
            }
            if (!LOCKBUTTONS)
            {
                Halt_Bool = false;
                LOCKTHEBUTTONS(true);
                Task t = Task.Factory.StartNew(() =>
              {

                  try
                  {
                      int Progresss = 0;
                      Progress_Output.BeginInvoke(new MethodInvoker(() =>
                       {
                           Progress_Output.Text = Progresss.ToString();
                       }));
                      foreach (var directory in Directory.GetDirectories(ChosenDirectory))
                      {
                          if (Halt_Bool) return;
                          try
                          {
                              ChosenDirectory = directory;

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
                  LOCKTHEBUTTONS(false);
              });
            }
                  
        }

        private void LOCKTHEBUTTONS(bool p)
        {
            LOCKBUTTONS = p;
            if (p)
            {
                button_ChooseActiveDirectory.BeginInvoke(new MethodInvoker(() =>
                {
                    button_ChooseActiveDirectory.Enabled = false;
                }));
                ProcessSingleDirectory.BeginInvoke(new MethodInvoker(() =>
                {
                    ProcessSingleDirectory.Enabled = false;
                }));
                Batch_Process.BeginInvoke(new MethodInvoker(() =>
                {
                    Batch_Process.Enabled = false;
                }));
                Halt.BeginInvoke(new MethodInvoker(() =>
                {
                    Halt.Enabled = true;
                }));
            }
            else
            {
                button_ChooseActiveDirectory.BeginInvoke(new MethodInvoker(() =>
                {
                    button_ChooseActiveDirectory.Enabled = true;
                }));
                ProcessSingleDirectory.BeginInvoke(new MethodInvoker(() =>
                {
                    ProcessSingleDirectory.Enabled = true;
                }));
                Batch_Process.BeginInvoke(new MethodInvoker(() =>
                {
                    Batch_Process.Enabled = true;
                }));
                Halt.BeginInvoke(new MethodInvoker(() =>
                {
                    Halt.Enabled = false;
                }));
            }
        }
      
        private void Process_Single_Directopry_Clicked(object sender, EventArgs e)
        {
            if (!Eligable_For_Processing)
            {
                DebuggingOutput("Folder doesnt meet requirements for processing", true);
                return;
            }
            if (!LOCKBUTTONS)
            {
                Halt_Bool = false;
                LOCKTHEBUTTONS(true);
                Task t = Task.Factory.StartNew(() =>
              {
                  bool run = true;
                  if (string.IsNullOrEmpty(ChosenDirectory) || !Directory.Exists(ChosenDirectory))
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
                LOCKTHEBUTTONS(false);
            }
        }

        private void ProcessCurrentDirectory()
        {
            if (!Eligable_For_Processing) return;
            DebuggingOutput("Start Batcher: " + ChosenDirectory);
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
            DebuggingOutput("Complete Processing GT Directory!");
            FlashControlToColor(Output, Color.LightGreen);
            if (Halt_Bool) return;
        }

        private void Halt_Click(object sender, EventArgs e)
        {
            DebuggingOutput("Halting!");
            Halt_Bool = true;
            LOCKTHEBUTTONS(false);
        }
        #endregion

        #region Compositing Images
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
                      //  MagickImage Composite = new MagickImage(background);
                     //   Composite.Composite(top_layer, CompositeOperator.Atop);
                      //  Composite.Write(Output_Web + Path.GetFileNameWithoutExtension(png) + "_Large_Preview.png");
                        top_layer.Scale(1024, 1024);
                       top_layer.Write(Output_Web + Path.GetFileNameWithoutExtension(png) + "_Small_Preview.png");
                    }
                }
            }
        }
        #endregion

        #region ScaleImage
        private void DownscaleForWeb()
        {
            if(!string.IsNullOrEmpty(ChosenDirectory) && !Directory.Exists(Output_Web))
                Directory.CreateDirectory(Output_Web);
            if (has_PBR_Specular)
            {
                foreach (var file in Directory.GetFiles(PBR_Specular))
                {
                    try
                    {
                        if (file.EndsWith(".tga"))
                        {
                            MagickImage image = new MagickImage(file);
                            var filename = Path.GetFileNameWithoutExtension(file);
                            filename += ".jpg";
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
        #endregion

       
                #region ZIPPING
        private void Zip_Files()
        {

            if (!string.IsNullOrEmpty(Cat) && !string.IsNullOrEmpty(Mat))
            {
               if(has_PBR_Specular) Zip_PBR_Specular();
                DebuggingOutput("Finished Zipping PBR Specular");
                DebuggingOutput("Beginning Zipping PBR Metallic");
                if (has_PBR_Metalic) Zip_PBR_Metalic();
                DebuggingOutput("Finished Zipping PBR Metallic");
                DebuggingOutput("Beginning Zipping Substance");
                if (has_Substance) Zip_Substance();
                DebuggingOutput("Finished Zipping Substance");
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

        private void SubstanceFileGenerationAndZip(string sbsar_path)
        {
            // Start the child process.
            Process p = new Process();
            // Redirect the output stream of the child process.
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.FileName = SubstanceDir;
            p.StartInfo.Arguments = "render --inputs " + sbsar_path + @" --output-path " + SBRAROutputDirectory + " --output-format tga --set-value $outputsize@11,11";
            p.Start();
            // Do not wait for the child process to exit before
            // reading to the end of its redirected stream.
            // p.WaitForExit();
            // Read the output stream first and then wait.
            string output = p.StandardOutput.ReadToEnd();
           
            p.WaitForExit();
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
                DebuggingOutput("Creating new PBR_Specular zip");
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

        #endregion

        #region CopyDirectory
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
        #endregion

        #region FilePicker
        private void button_ChooseActiveDirectory_Click(object sender, EventArgs e)
        {
            if (LOCKBUTTONS) return;
            var dialog = new System.Windows.Forms.FolderBrowserDialog();
            if(!string.IsNullOrEmpty(ChosenDirectory))
                dialog.SelectedPath = ChosenDirectory;
            System.Windows.Forms.DialogResult result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
               
                
                DebuggingOutput("User Picked: " + ChosenDirectory, true);
                if (dialog.SelectedPath != ChosenDirectory)
                {
                    ChosenDirectory = dialog.SelectedPath;
                    Properties.Settings.Default.LastDirectory = ChosenDirectory;
                    Properties.Settings.Default.Save();
                }
                SetActiveDirectory();
                ButtonHint();
            }
            else
            {
                ChosenDirectory = string.Empty;
            }
           
            DebuggingOutput("Completed parsing files in directory");
        }

        private void ButtonHint()
        {
            if (Eligable_For_Batching) FlashControlToColor(Batch_Process, GoodColor);
            else FlashControlToColor(Batch_Process, BadColor);
            if (Eligable_For_Processing) FlashControlToColor(ProcessSingleDirectory, GoodColor);
            else FlashControlToColor(ProcessSingleDirectory, BadColor);

        }

        private void SetActiveDirectory()
        {
            DebuggingOutput("Entering Directory: " + ChosenDirectory, true);
            Check_For_Folders();
            Process_Eligability();
            if (Eligable_For_Processing)
            {
                ScanChosenDirectory();
            }
        }
        #endregion

        #region ScanDirectoriesForStructure
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
            has_PBR_Specular = Directory.Exists(PBR_Specular);
            has_Substance = Directory.Exists(Substance);
            has_WebDirectory = Directory.Exists(WebDirectory);
            sum_subs = Directory.GetDirectories(ChosenDirectory).Count();
            SubDirectories_Output.BeginInvoke(new MethodInvoker(() =>
            {
                SubDirectories_Output.Text = sum_subs.ToString();
            }));
            text_ActiveDirectory.BeginInvoke(new MethodInvoker(() =>
            {
                text_ActiveDirectory.Text = ChosenDirectory;
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
                if (EExtensions.Contains(".tga"))
                {
                    SubstanceMode = true;
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
        #endregion

        #region UI_Options

        private void WebScale_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(WebSizeEntryBox.Text, out WebSize))
            {
                DebuggingOutput("WebSize set to: " + WebSize);
            }
            else
            {
                WebSize = 1024;
            }
        }
        #region Checkboxes
        private void Verbose_Clicked(object sender, EventArgs e)
    {
        Properties.Settings.Default.Verbose = verbose.Checked;
        DebuggingOutput("Debugging Outputs: " + verbose.Checked,true);
        Properties.Settings.Default.Save();
    }

    private void UI_Clicked(object sender, EventArgs e)
    {
        Properties.Settings.Default.UI = ui.Checked;
        DebuggingOutput("UI Effects: " + ui.Checked, true);
        Properties.Settings.Default.Save();

    }

    private void overwrite_CheckedChanged_1(object sender, EventArgs e)
    {
        Properties.Settings.Default.Overwrite = overwrite.Checked;
        DebuggingOutput("Overwrite Outputs: " + overwrite.Checked, true);
        Properties.Settings.Default.Save();

    }
  
    #endregion
    #endregion

    #region UIEffects
    private void FlashControlToColor(Control activeControl, Color eventColour)
    {
        if (!ui.Checked) return;
        uint intervals = 100;
        if (!OgiginColors.ContainsKey(activeControl)) OgiginColors.Add(activeControl, activeControl.BackColor);
        var colorFader = new ColorFader(eventColour, OgiginColors[activeControl], intervals);
        Task t = Task.Factory.StartNew(() =>
        {
            foreach (var color in colorFader.Fade())
            {
                SetControlBackColor(activeControl, color);
                System.Threading.Thread.Sleep(10);
            }
        });
    }

    private void SetControlBackColor(Control activeControl, Color color)
    {
        if (activeControl.InvokeRequired)
            activeControl.Invoke((MethodInvoker)delegate { activeControl.BackColor = color; });
        else
            activeControl.BackColor = color;
    }

    private void Readme_Click(object sender, EventArgs e)
    {
        var dialog = new System.Windows.Forms.OpenFileDialog();
        if (!string.IsNullOrEmpty(ChoosenReadme))
            dialog.InitialDirectory = Path.GetDirectoryName(ChoosenReadme);
        System.Windows.Forms.DialogResult result = dialog.ShowDialog();

        if (result == DialogResult.OK)
        {
            ChoosenReadme = dialog.FileName;
            DebuggingOutput("User Picked: " + ChoosenReadme, true);
         
                Properties.Settings.Default.readmefile = ChoosenReadme;
               Properties.Settings.Default.Save();
            
            Label_Readme.BeginInvoke((MethodInvoker)delegate { Label_Readme.Text = Properties.Settings.Default.readmefile; Update(); });

        }
    }

    private void SelectTBScene_Click(object sender, EventArgs e)
    {
        var dialog = new System.Windows.Forms.OpenFileDialog();
        if (!string.IsNullOrEmpty(ChoosenScene))
            dialog.InitialDirectory = Path.GetDirectoryName(ChoosenScene);
        System.Windows.Forms.DialogResult result = dialog.ShowDialog();

        if (result == DialogResult.OK)
        {
            ChoosenScene = dialog.FileName;
            DebuggingOutput("User Picked: " + ChoosenScene, true);
           
                Properties.Settings.Default.tbScene = ChoosenScene;
                Properties.Settings.Default.Save();

                Label_TbScene.BeginInvoke((MethodInvoker)delegate { Label_TbScene.Text = Properties.Settings.Default.tbScene; Update(); });

        }
    }




    public bool SubstanceMode { get; set; }

    private void panel5_Paint(object sender, PaintEventArgs e)
    {

    }

    private void Substance_Button(object sender, EventArgs e)
    {
        var dialog = new System.Windows.Forms.OpenFileDialog();
        if (!string.IsNullOrEmpty(SubstanceDir))
            dialog.InitialDirectory = Path.GetDirectoryName(SubstanceDir);
        System.Windows.Forms.DialogResult result = dialog.ShowDialog();

        if (result == DialogResult.OK)
        {
            SubstanceDir = dialog.FileName;
            DebuggingOutput("User Picked: " + SubstanceDir, true);

            Properties.Settings.Default.substancefolder = SubstanceDir;
            Properties.Settings.Default.Save();

            Label_Substance.BeginInvoke((MethodInvoker)delegate { Label_Substance.Text = Properties.Settings.Default.substancefolder; Update(); });

        }
    }

    public string SubstanceDir { get; set; }
        

    private void SubstanceScriptButton_Click(object sender, EventArgs e)
    {
        var dialog = new System.Windows.Forms.OpenFileDialog();
        if (!string.IsNullOrEmpty(SubstanceDir))
            dialog.InitialDirectory = Path.GetDirectoryName(SubstanceDir);
        System.Windows.Forms.DialogResult result = dialog.ShowDialog();

        if (result == DialogResult.OK)
        {
            SubstanceDir = dialog.FileName;
            DebuggingOutput("User Picked: " + SubstanceDir, true);

           // Properties.Settings.Default.SubstanceScriptPath = SubstanceDir;
            Properties.Settings.Default.Save();

            Label_Substance.BeginInvoke((MethodInvoker)delegate { Label_Substance.Text = Properties.Settings.Default.substancefolder; Update(); });

        }
    }

        private void ProgressLabel_TextChanged(object sender, EventArgs e)
        {

        }
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
    #endregion


  

