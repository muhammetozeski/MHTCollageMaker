using System.Diagnostics;
//note: THIS PROGRAM NEEDS ImageMagick to run "montage" command and merge images.


//TODO: add more prints for telling what's going on in the background to user.
//TODO: clear code later. i am tired enough today :/
//TODO: add icon and title.

namespace MHTCollageMaker
{
    public partial class Form1 : Form
    {
        //empty means current folder
        /// <summary>
        /// Do not add slash "\" with this variable. add slush to end of this string if you want to put collages to a subfolder.
        /// <br></br>
        /// For example don't do that: <br></br>
        /// PathOfAllCollages + "\filename.jpg"
        /// </summary>
        string PathOfAllCollages = "collages\\";
        string PrefixForCollageFileName = ""; //"collage_";
        string FolderPath;
        List<string> SubFolders = new List<string>();

        //TODO: make this optional
        string ImageExtention = ".jpg";

        public Form1()
        {
            InitializeComponent();
        }

#pragma warning disable IDE1006 // Suppress Naming style warning
        /// <summary>
        /// print something to RichTextBox1.<br></br>I prefered a short name to make it to use easier
        /// </summary>
        void p(object Message)
        {
            const string line = "---------------------------------------";
            richTextBox1.Text = Message.ToString() + "\n" + line + "\n" + richTextBox1.Text;
        }
        /// <summary>
        /// print somethings to RichTextBox1.<br></br>I prefered a short name to make it to use easier
        /// </summary>
        void p(object[] Message)
        {
            foreach (object i in Message)
                p(i);
        }
        /// <summary>
        /// print "first prompt" before every element and then print the element to RichTextBox1.<br></br>I prefered a short name to make it to use easier
        /// </summary>
        void p(object firstPrompt, object[] Message)
        {
            foreach (object i in Message)
                p(firstPrompt.ToString() + i.ToString());
        }
        /// <summary>
        /// print dictionary (as default) keys or values to RichTextBox1.<br></br>I prefered a short name to make it to use easier
        /// </summary>
        /// <param name="keys"><br></br>if true it will write keys <br></br>if false it will write values of the dictionary</param>
        void p<t, t2>(Dictionary<t, t2> Dict, bool keys = true)
#pragma warning restore IDE1006 // Adlandýrma Stilleri
        {
            if (keys)
                foreach (var i in Dict.Keys.OfType<string>().ToArray())
                    p(i);
            else
                foreach (var i in Dict.Values.OfType<string>().ToArray())
                    p(i);
        }

        //allow to copy only one folder 
        private void DropLabel_DragEnter(object sender, DragEventArgs e)
        {
            DragDropEffects effects = DragDropEffects.None;
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                var path = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (Directory.Exists(path[0]) && path.Length == 1)
                    effects = DragDropEffects.Copy;
            }

            e.Effect = effects;
        }

        private void DropLabel_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                var _path = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
                FolderPath = _path;
                p("Added Folder Path: " + _path);
            }
        }

        void test(string str)
        {
        }

        private void MergeButton_Click(object sender, EventArgs e)
        {
            if (FolderPath != null)
            {
                SubFolders = Directory.GetDirectories(FolderPath, "*", SearchOption.AllDirectories).ToList();
                p(SubFolders);
                p("Subfolders Added:");
                SubFolders.Add(FolderPath);
                /* // getting images as bitmaps:
                List<List<Bitmap>> images = new List<List<Bitmap>>();
                for (int i = 0; i < SubFolders.Count; i++)
                {
                    (var bitmapPaths,var bitmaps) = GetAllPicsInFolder(SubFolders[i]);
                    if (bitmaps != null)
                        images.Add(new List<Bitmap>(bitmaps));
                }*/
                List<List<string>> images = new List<List<string>>();
                for (int i = 0; i < SubFolders.Count; i++)
                {
                    //TODO: delete debug messages:
                    var ImagePaths = GetAllPicPathsInFolder(SubFolders[i]);
                    if (ImagePaths != null && ImagePaths.Length != 0)
                    {
                        //MessageBox.Show("images.Add\nImagePaths[" + i + "][0] = " + ImagePaths[0]);
                        images.Add(new List<string>(ImagePaths));
                        //MessageBox.Show("images.Add\nimages[" + (images.Count-1) + "][0] = " + images[(images.Count - 1)][0]);
                    }
                }
                /*MessageBox.Show("loop is done");
                    MessageBox.Show("SubFolders.Count: " + SubFolders.Count + 
                        "\nimages is not null = " + (images!=null) +
                        "\nPath.GetFileNameWithoutExtension(images[0][0]) = " + (Path.GetFileNameWithoutExtension(images[0][0]))
                        );/**/
                //TODO: make this optional for user and more clear.
                var PathOfAllCollagesV2 = Path.GetDirectoryName(FolderPath) + "\\" + PathOfAllCollages;

                foreach (var i in images)
                {
                    CreateCollage(i.ToArray(), PathOfAllCollagesV2, PrefixForCollageFileName +
                        Path.GetFileNameWithoutExtension(i[0]) + ImageExtention);
                }

                p("all collages saved into:" + PathOfAllCollagesV2);
                /**/
            }
        }

        /// <summary>
        /// returns all pictures in a folder as bitmap and returns their paths.
        /// </summary>
        /// <param name="FolderPath">The folder path</param>
        (string[]?, Bitmap[]?) GetAllPicsInFolder(string FolderPath)
        {
            string[]? jpegFiles = Directory.GetFiles(FolderPath, "*" + ImageExtention, SearchOption.TopDirectoryOnly);
            Bitmap[]? bitmaps = new Bitmap[jpegFiles.Length];
            for (int i = 0; i < jpegFiles.Length; i++)
            {
                bitmaps[i] = new Bitmap(jpegFiles[i]);
                p(i + " JPG file added: " + Path.GetFileName(jpegFiles[i]));
            }
            return (jpegFiles, bitmaps);
        }

        /// <summary>
        /// returns all pictures in a folder as string of path.
        /// </summary>
        string[]? GetAllPicPathsInFolder(string FolderPath)
        {
            string[] jpegFiles = Directory.GetFiles(FolderPath, "*" + ImageExtention, SearchOption.TopDirectoryOnly);
            if (jpegFiles.Length == 0) return null;
            int i = 0;
            jpegFiles.ToList().ForEach(x => p(++i + ".) JPG file added: " + Path.GetFileName(x)));

            return jpegFiles;
        }

        //test purpose, ignore this function:
        private void button1_Click(object sender, EventArgs e)
        {
            string[] pics = GetAllPicPathsInFolder("TestImages");
            string prompt = string.Join(" ", pics.Select(x => "\"TestImages\\" + Path.GetFileName(x) + "\""));
            System.Diagnostics.Process.Start("montage", prompt + "-resize 1920x1104 -gravity center -background white TestImages\\collage3.jpg");
            p("done");
        }

        void CreateCollage(string[] PathsOfImagesToCollage, string CollagePathToSave = "", string CollageFileName = "Collage.jpg",
            string Options = "-resize 1920x1104 -background white -geometry +0+0 -border 0x0")
        {
            //TODO: make options variable more optional and functional. i mean seperate the options. get them from user.

            if (IsVerticalCheckBox.Checked)
            {
                int imageCount = PathsOfImagesToCollage.Length;
                Options += " -tile 1x" + imageCount;
            }

            string PathsInOneLine = string.Join(" ", PathsOfImagesToCollage.Select(x => "\"" + x + "\""));

            string command = "montage" + " " + PathsInOneLine + " " + Options + " " + "\"" + CollagePathToSave + CollageFileName + "\"";
            //p("Given command: " + command);
            string _createPath = CollagePathToSave;
            if (_createPath[_createPath.Length - 1] == '\\')
                _createPath = _createPath.Substring(0, _createPath.Length - 1);
            if (!Directory.Exists(_createPath))
                Directory.CreateDirectory(_createPath);
            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    //RedirectStandardInput = true,
                    //RedirectStandardOutput = true,
                    FileName = "cmd.exe",
                    Arguments = "/c " + command,
                    CreateNoWindow = true,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    Verb = "runas",
                    UseShellExecute = true,
                }
            };
            process.Start();/**/
            p("using command: " + command);
            /*process.StandardInput.WriteLine(command);
            process.StandardInput.Flush();
            process.StandardInput.Close();
            p(process.StandardOutput.ReadToEnd());
            p("CLI Output:");/**/

            /*p("process started:");
            Process.Start(command);
            p("process finished");/**/
        }

        private void IsVerticalCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}