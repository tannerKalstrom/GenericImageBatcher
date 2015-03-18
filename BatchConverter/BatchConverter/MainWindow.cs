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

namespace BatchConverter
{

    public partial class MainWindow : Form
    {
        private string ChoosenDirectory = "";
        private string OutputDirectory {get { return ChoosenDirectory + @"\OUTPUT\";}}
        private string PBR_Metalic { get { return ChoosenDirectory + @"\PBR_Metallic"; } }
        private string Output_PBR_Metalic { get { return OutputDirectory + @"\PBR_Metallic.zip"; } }
        private string PBR_Specular { get { return ChoosenDirectory + @"\PBR_Specular"; } }
        private string Output_PBR_Specular { get { return OutputDirectory + @"\PBR_Specular.zip"; } }
        private string Output_Web { get { return OutputDirectory + @"\Web\"; } }

        public List<string> Catagory { get; set; }
        public List<string> Material { get; set; }
        public List<string> Resolution { get; set; }
        public List<string>     TType       { get; set; }
        public List<string> EExtensions { get; set; }



        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_ChooseActiveDirectory_Click(object sender, EventArgs e)
        {
            //
            // This event handler was created by double-clicking the window in the designer.
            // It runs on the program's startup routine.
            //
            Output.AppendText("Opening Folder Browser\n");
            using (FolderBrowserDialog br = new FolderBrowserDialog())
            {
                br.SelectedPath = @"E:\GameTextures\marble_brokenMonuments Example\marble_BrokenMonument Plain View - Copy";
                DialogResult result = br.ShowDialog();
                
                if (result == DialogResult.OK)
                {
                    Catagory = new List<string>();
                    Material = new List<string>();
                    Resolution = new List<string>();
                    TType = new List<string>();
                    EExtensions = new List<string>();
                    Catagory_Echo.Text = string.Empty;
                    Res_Echo.Text = string.Empty;
                    Material_Echo.Text = string.Empty;
                    Type_Echo.Text = string.Empty;
                    ChoosenDirectory = br.SelectedPath;
                    Output.AppendText("Active Directory Set to:" + ChoosenDirectory+"\n");

                    text_ActiveDirectory.Text = ChoosenDirectory;
                    var Files = Directory.GetFiles(PBR_Metalic);
                    Output.AppendText("Attempting to parse files in directory" + "\n");
                    foreach (var file in Files)
                    {
                        try
                        {
                            string name = Path.GetFileName(file);
                            if (!EExtensions.Contains(Path.GetExtension(file))) EExtensions.Add(Path.GetExtension(file));
                            var bits = name.Split('_');
                            if (bits.Length == 4)
                            {
                                
                                if(!Catagory.Contains(bits[0])) Catagory.Add(bits[0]);
                                if (!Material.Contains(bits[1])) Material.Add(bits[1]);
                                if (!Resolution.Contains(bits[2])) Resolution.Add(bits[2]);
                                if (!TType.Contains(bits[3].Substring(0, bits[3].IndexOf(Path.GetExtension(file))))) TType.Add(bits[3].Substring(0, bits[3].IndexOf(Path.GetExtension(file)))); 
                            }
                        }


                        catch (Exception ee)
                        {
                            Output.AppendText("Failed Parsing files" + "\n");
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
                            Output.AppendText("Failed Parsing files" + "\n");

                        }

                    }
                    Output.AppendText("Completed parsing files in directory" + "\n");


                    Catagory_Echo.Text = string.Join(", ",Catagory);
                    Res_Echo.Text = string.Join(", ", Resolution); ;
                    Material_Echo.Text = string.Join(", ", Material); ;
                    Type_Echo.Text = string.Join(", ", TType); ;
                    Extensions_Echo.Text = string.Join(", ", EExtensions); ; 
                    
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           Directory.CreateDirectory(OutputDirectory);
           if (File.Exists(Output_PBR_Metalic))
           {
               Output.AppendText(Output_PBR_Metalic + " already exists, and is being overwritten! \n");
               File.Delete(Output_PBR_Metalic);
           }
           Output.AppendText("Zip Started For: " + Output_PBR_Metalic + " \n");
           ZipFile.CreateFromDirectory(PBR_Metalic, Output_PBR_Metalic);
           Output.AppendText("zip finished! \n");

           if (File.Exists(Output_PBR_Specular))
           {
               Output.AppendText(Output_PBR_Specular + " already exists, and is being overwritten! \n");
               File.Delete(Output_PBR_Specular);
           }
           Output.AppendText("Zip Started For: " + Output_PBR_Specular + " \n");

           ZipFile.CreateFromDirectory(PBR_Specular, Output_PBR_Specular);
           Output.AppendText("zip finished! \n");

           Directory.CreateDirectory(Output_Web);
           Output.AppendText("Starting Downscaling for Web folder \n");

           foreach (var file in Directory.GetFiles(PBR_Specular))
           {
               try
               {
                   if (file.EndsWith(".tga"))
                   {
                       var filename = Path.GetFileNameWithoutExtension(file);
                       filename += ".jpg";
                       MagickImage image = new MagickImage(file);
                       image.Scale(512, 512);
                       image.Write(Output_Web + filename);
                       Output.AppendText("Completed: " + filename+" \n");

                   }
               }
               catch (Exception ee)
               {

               }
               
           }

        }

       

     
    }
}
