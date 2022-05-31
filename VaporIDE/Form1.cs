using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VaporIDE
{
    public struct vaporDir
    {
        public static string directory = Form1.vapor_parser_location.Replace(Path.GetFileName(Form1.vapor_parser_location),""); //Directory.GetCurrentDirectory();
        public static string standardLibrary = vaporDir.directory + "Standard Library/";
        public static string[] cleanupDirectories = new string[] {
            vaporDir.directory + "/dist",
            vaporDir.directory + "/build",
            vaporDir.directory + "/__pycache__"
        };
        public static string[] cleanupFiles = new string[]
        {
            vaporDir.directory + "/output.spec",
            vaporDir.directory + "/output.py"
        };

        public static void doCleanup()
        {
            foreach(var d in vaporDir.cleanupDirectories)
            {
                Directory.Delete(d, true);
            }

            foreach(var d in vaporDir.cleanupFiles)
            {
                File.Delete(d);
            }
        }
    }
    public partial class Form1 : Form
    {
        public string active_dir = "";
        public static string vapor_parser_location = "";
        public string data_file = "vaporIDE_data.txt";
        public List<vaporMethod> usingMethods = new List<vaporMethod>();
        public Form1()
        {
            InitializeComponent();
            this.CenterToScreen();
            this.debugTextLabel.Text = "Vapor IDE 0.0.1 | Language and IDE Developed By Marc Davis"; // ( Hover over a button to see more info on what it does )";
            this.Text = this.debugTextLabel.Text;
            /*if(File.Exists(vaporDir.directory + this.data_file))
            {
                Form1.vapor_parser_location = File.ReadAllText(vaporDir.directory + this.data_file).Trim();
            }*/
            Dictionary<Button, string> btntooltips = new Dictionary<Button, string>()
            {
                { this.executeButton, "Executes the current code in the IDE" },
                { this.BuildButton, "Builds a single executable of the program" },
                { this.saveButton, "Saves the current code in the IDE" },
                { this.importButton, "Loads a .vap file into the IDE, not to be confused with the 'using' keyword" },
                { this.clearButton, "Clears the current IDE of ALL code" },
                { this.releaseButton, "Goes to the current Vapor Parser and Vapor IDE Github release" },
                { this.locateParserButton, "Link the Vapor IDE and the Vapor Parser together to be able to execute & compile code" },
                { this.documentationButton, "Generate documentation on the current method selected in the method list tab" },
                { this.standardLibraryButton, "Downloads the latest standard library from the Github" }
            };
            foreach(var b in btntooltips)
            {
                ToolTip ttip = new System.Windows.Forms.ToolTip();
                ttip.SetToolTip(b.Key, b.Value);
            }
            // this.getVaporData();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.getVaporData();
            this.codeView.SelectionTabs = new int[] { 20, 40, 60, 80 };
        }

        private void codeView_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    int index = this.codeView.SelectionStart;
                    int line = this.codeView.GetLineFromCharIndex(index);
                    var l = this.codeView.Lines[line-1];
                    if (this.codeView.Text[this.codeView.Text.Length - 2] == '{')
                    {
                        int i = codeView.SelectionStart;
                        this.codeView.Text += "\n}";
                        this.codeView.SelectionStart = i;
                    }
                }
                catch
                {

                }
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            this.textBox1.Focus();
            this.HideSelection(true);
            this.tryMethodAssertionAutoDetection();
            this.codeView.ForeColor = Color.White;
            this.CheckKeyword("{", Color.Orange, 0);
            this.CheckKeyword("}", Color.Orange, 0);
            this.CheckKeyword("m ", Color.PaleGoldenrod, 0);
            this.CheckKeyword("obj ", Color.PaleGoldenrod, 0);
            this.CheckKeyword(" true ", Color.LightCoral, 0);
            this.CheckKeyword(" false ", Color.LightCoral, 0);
            this.CheckKeyword("True", Color.Orange, 0);
            this.CheckKeyword("False", Color.Orange, 0);
            this.CheckKeyword("not ", Color.Orange, 0);
            this.CheckKeyword(" each ", Color.DarkOrchid, 0);
            this.CheckKeyword(" with ", Color.DarkOrchid, 0);
            this.CheckKeyword("while", Color.PaleGoldenrod, 0);
            this.CheckKeyword("thread ", Color.BurlyWood, 0);
            this.CheckKeyword("using ", Color.BurlyWood, 0);
            this.CheckKeyword("import ", Color.BurlyWood, 0);
            this.CheckKeyword("from ", Color.BurlyWood, 0);
            this.CheckKeyword("(", Color.DarkGoldenrod, 0);
            this.CheckKeyword(")", Color.DarkGoldenrod, 0);
            this.CheckKeyword("[", Color.DarkGoldenrod, 0);
            this.CheckKeyword("]", Color.DarkGoldenrod, 0);
            this.CheckKeyword("]]", Color.LemonChiffon, 0);
            this.CheckKeyword("[[", Color.LemonChiffon, 0);
            this.CheckKeyword(";", Color.Orange, 0);
            this.CheckKeyword("=", Color.LightCoral, 0);
            this.CheckKeyword("self", Color.PaleGoldenrod, 0);
            this.CheckKeyword("benchmark", Color.BurlyWood, 0);
            this.CheckKeyword("#", Color.Chartreuse, 0);
            this.CheckKeyword("'", Color.Magenta, 0);
            this.CheckKeyword("-> ", Color.LightCoral, 0);
            this.CheckKeyword(" bool", Color.CornflowerBlue, 0);
            this.CheckKeyword(" int", Color.CornflowerBlue, 0);
            this.CheckKeyword(" str", Color.CornflowerBlue, 0);
            this.CheckKeyword(" list", Color.CornflowerBlue, 0);
            this.CheckKeyword("if ", Color.Orange, 0);
            this.CheckKeyword(" else ", Color.Orange, 0);
            this.CheckKeyword(" in ", Color.Orange, 0);
            this.CheckKeyword(" is ", Color.Orange, 0);
            this.CheckKeyword("assert-type", Color.LightCoral, 0);
            this.CheckKeyword("cmd-line", Color.LightCoral, 0);
            this.CheckKeyword("v-input", Color.LightCoral, 0);
            this.CheckKeyword("ignore-rest", Color.Red, 0);
            this.CheckKeyword("!cmp ", Color.Orange, 0);
            this.CheckKeyword("cmp ", Color.Orange, 0);
            this.CheckKeyword("copy ", Color.LightCoral, 0);
            this.CheckKeyword("v ", Color.LightCoral, 0);
            this.CheckKeyword(".", Color.Chartreuse, 0);

            this.CheckBetween("m ", "(", Color.FromArgb(133, 178, 212), 0);
            this.CheckBetween("v ", "=", Color.PaleGoldenrod, 0);
            this.HideSelection(false);
            this.codeView.Focus();
            this.displayMethods();

            this.tryAutoComplete();
            this.tryUpdateUsingList();
        }

        public void tryUpdateUsingList()
        {
            List<string> added = new List<string>();
            this.usingMethodsList.Items.Clear();
            this.usingMethods.Clear();
            foreach(var l in this.codeView.Lines)
            {
                if(l.StartsWith("using "))
                {
                    var usingWhat = l.Split(" ")[1];
                    added.Add(usingWhat);
                    vaporMethod[] filevms = this.getVaporMethodsFromFile(usingWhat);
                    foreach(var vm in filevms)
                    {
                        this.usingMethodsList.Items.Add(vm.lineindex + " " + vm.methodRawLine);
                        this.usingMethods.Add(vm);
                    }
                }
            }
        }

        public void tryMethodAssertionAutoDetection()
        {
            bool checkNext = false;
            string checkNextString = "";
            int index = -1;
            string previousTabSpacing = "";
            foreach (var l in this.codeView.Lines)
            {
                index++;
                string tabSpacing = this.getTabSpacingFromLine(index);
                var l2 = "";
                if (tabSpacing.Length > 0)
                    l2 = l.Replace(tabSpacing, "");
                else
                    l2 = l;
                //var l2 = l.Replace(this.getTabSpacingFromLine(index),"");
                if (l2.StartsWith("m ") && l.Contains(":") && l.Contains("{"))
                {
                    checkNext = true;
                    checkNextString = l;
                    previousTabSpacing = tabSpacing;
                }
                else if(checkNext)
                {
                    checkNext = false;
                    if(!l.Contains("assert-type"))
                    {
                        if (checkNextString.Contains(',') == false)
                        {
                            // single assertion
                            
                            string vname = checkNextString.Split(':')[0].Split('(')[1].Trim();
                            string vtype = checkNextString.Split(':')[1].Split(')')[0].Trim();
                            this.insertTextAtLine(previousTabSpacing + "\tassert-type " + vname + " " + vtype, index);
                            checkNext = false;
                        }
                        else
                        {
                            string[] spl = checkNextString.Split(',');
                            string vname = "";
                            string vtype = "";
                            foreach (var sp in spl)
                            {
                                // MessageBox.Show("comma split value -> " + sp);
                                try
                                {
                                    if (sp.Contains('('))
                                    {
                                        // first var
                                        vname = sp.Split('(')[1].Split(':')[0].Trim();
                                        vtype = sp.Split('(')[1].Split(':')[1].Trim();
                                    }
                                    else if (sp.Contains(')'))
                                    {
                                        // last var
                                        vname = sp.Split(')')[0].Split(':')[0].Trim();
                                        vtype = sp.Split(')')[0].Split(':')[1].Trim();
                                    }
                                    else
                                    {
                                        //inner vars
                                        vname = sp.Split(':')[0].Trim();
                                        vtype = sp.Split(':')[1].Trim();
                                    }
                                } 
                                catch
                                {
                                    continue;
                                }

                                this.insertTextAtLine(previousTabSpacing + "\tassert-type " + vname + " " + vtype, index);
                            }
                            checkNext = false;
                        }

                    }
                    
                    // MessageBox.Show("check next -> " + checkNextString);
                }
            }
        }

        public void insertTextAtLine(string text, int index)
        {
            List<string> t = new List<string>();
            int ind = -1;
            int s = this.codeView.SelectionStart;
            foreach (var l in this.codeView.Lines)
            {
                ind++;
                if(ind == index)
                {
                    t.Add(text);
                }
                t.Add(l);
            }

            this.codeView.Lines = t.ToArray();
            this.codeView.SelectionStart = s + text.Length;
        }

        public void tryAutoComplete(string s="")
        {
            try
            {
                Int32 caretPosition = codeView.SelectionStart;
                Int32 lineNum = this.codeView.GetLineFromCharIndex(caretPosition);
                var line = this.codeView.Lines[lineNum];
            }
            catch
            {

            }
        }

        private void CheckKeyword(string word, Color color, int startIndex)
        {
            if (this.codeView.Text.Contains(word))
            {
                int index = -1;
                int selectStart = this.codeView.SelectionStart;
                
                while ((index = this.codeView.Text.IndexOf(word, (index + 1))) != -1)
                {
                    this.codeView.Select((index + startIndex), word.Length);
                    this.codeView.SelectionColor = color;
                    this.codeView.Select(selectStart, 0);
                    this.codeView.SelectionColor = Color.White;
                }
            }
        }

        private void CheckKeyword(string[] words, Color color, int startIndex)
        {
            foreach(var w in words)
            {
                this.CheckKeyword(w, color, startIndex);
            }
        }

        private void CheckBetween(string letter1, string letter2, Color color, int startIndex)
        {
            int selectStart = this.codeView.SelectionStart;
            foreach (var l in this.codeView.Lines)
            {
                if (l.Contains(letter1) && l.Contains(letter2))
                {
                    try
                    {
                        string selectstring = "selectstring: " + l;

                        // MessageBox.Show(line.ToString());
                        // MessageBox.Show(selectstring);
                        string selectstringsel = this.stringBetween(selectstring, letter1, letter2);
                        var line = this.codeView.Find(selectstringsel);
                        // MessageBox.Show(selectstringsel);
                        this.codeView.Select(line, selectstringsel.Length);
                        this.codeView.SelectionColor = color;
                        this.codeView.Select(selectStart, 0);
                        this.codeView.SelectionColor = Color.White;
                    }
                    catch
                    {

                    }
                }
            }
        }

        public string stringBetween(string STR, string FirstString, string LastString)
        {
            string FinalString;
            int Pos1 = STR.IndexOf(FirstString) + FirstString.Length;
            int Pos2;
            if(FirstString == LastString)
                Pos2 = STR.IndexOf(LastString, Pos1);
            else
                Pos2 = STR.IndexOf(LastString);

            if(LastString == "*")
            {
                FinalString = STR.Substring(Pos1);
            }
            else
                FinalString = STR.Substring(Pos1, Pos2 - Pos1);
            return FinalString;
        }

        public string[] getMethods()
        {
            int index = -1;
            List<string> app = new List<string>();
            foreach(var l in this.codeView.Lines)
            {
                index++;
                var lnew = l.Trim();
                // MessageBox.Show(lnew);
                while (lnew.IndexOf("  ") >= 0)
                {
                    lnew = lnew.Replace("  ", " ");
                }
                if (lnew.StartsWith("m "))
                {
                    var write = index + " " + l.Replace("{","").Replace("m ","").Trim();
                    app.Add(write);
                }
            }
            return app.ToArray();
        }

        public void displayMethods()
        {
            var m = this.getMethods();
            this.methodList.Items.Clear();

            foreach(var method in m)
            {
                this.methodList.Items.Add(method);
            }
            methodList.EndUpdate();
        }

        private void button1_MouseUp(object sender, MouseEventArgs e)
        {
            string[] lines = this.codeView.Lines;
        }

        private void executeButtonOnClick(object sender, EventArgs e)
        {
            if(this.codeView.Lines.Length <= 0)
            {
                this.debugTextLabel.Text = "No code to be executed, aborting.";
                return;
            }

            if(Form1.vapor_parser_location.Length > 0)
            {
                var f = File.Create(vaporDir.directory + "IDECode.vap");
                f.Close();
                f.Dispose();
                File.WriteAllLines(vaporDir.directory + "IDECode.vap", this.codeView.Lines);
                // MessageBox.Show("calling -> / k cd \"" + vaporDir.directory + "\" & vapor_parser.exe IDECode.vap");
                Process.Start("CMD.exe", "/k cd \"" + vaporDir.directory + "\" & vapor_parser.exe IDECode.vap");
                this.debugTextLabel.Text = @"Executed IDE Code";
            }
            else
            {
                this.debugTextLabel.Text = "Could not find vapor_parser executable. Make sure you've 'located' the vapor_parser.exe before trying to execute the code.";
            }
        }

        private void saveButtonOnClick(object sender, EventArgs e)
        {
            var savename = this.textBox1.Text;
            if(savename.Length <= 0)
            {
                // failed
                return;
            }
            if(!savename.Contains(".vap"))
            {
                savename = savename + ".vap";
            }

            // FileStream f = File.Create(Directory.GetCurrentDirectory() + "/" + savename);

            if (this.active_dir.Length > 0)
            {
                FileStream f = File.Create(this.active_dir + savename);
                f.Close();
                f.Dispose();
                File.WriteAllLines(this.active_dir + savename, this.codeView.Lines);
                (new SoundPlayer(Properties.Resources.saved)).Play();
                this.debugTextLabel.Text = @"Saved File To: " + this.active_dir + savename;
            }
            else 
            {
                FileStream f = File.Create(vaporDir.directory + savename);
                f.Close();
                f.Dispose();
                File.WriteAllLines(vaporDir.directory + savename, this.codeView.Lines);
                (new SoundPlayer(Properties.Resources.saved)).Play();
                this.debugTextLabel.Text = "Saved File To: " + vaporDir.directory + savename;
            }

        }

        private void importButtonOnClick(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Filter = "file|*.vap";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    if(dlg.FileName.Contains(".vap"))
                    {
                        var f = Path.GetFileName(dlg.FileName);
                        this.active_dir = dlg.FileName.Replace(f,"");
                        var lines = File.ReadAllText(dlg.FileName);
                        if(this.codeView.Lines.Count() > 0)
                        {
                            this.codeView.Text += "\n" + lines;
                        }
                        else
                        {
                            this.codeView.Text = lines;
                        }
                        this.textBox1.Text = f;
                        this.debugTextLabel.Text = @"Loaded file: " + f;
                        this.Text = f;
                    }
                    else
                    {
                        MessageBox.Show("The selected file is not a .vap file!");
                    }
                }
            }
        }

        public void ScrollToLine(int lineNumber, bool ignoreSearch = false)
        {
            if (lineNumber > this.codeView.Lines.Count()) return;

            if (!ignoreSearch)
                this.codeView.SelectionStart = this.codeView.Find(this.codeView.Lines[lineNumber]);
            else
                this.codeView.SelectionStart = lineNumber;
            this.codeView.ScrollToCaret();

        }

        public void ScrollToLine(string lineS)
        {
            this.codeView.SelectionStart = this.codeView.Find(lineS);
            this.codeView.ScrollToCaret();
        }

        private void releasesButtonOnClick(object sender, EventArgs e)
        {

            Process.Start("explorer.exe", "https://github.com/mwd1993/Vapor/releases");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        [DllImport("user32.dll")]
        static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, Int32 wParam, Int32 lParam);
        const int WM_USER = 0x400;
        const int EM_HIDESELECTION = WM_USER + 63;
        public void HideSelection(bool hide)
        {
            SendMessage(this.codeView.Handle, EM_HIDESELECTION, hide ? 1 : 0, 0);
        }

        private void listBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            var i = this.methodList.Items[this.methodList.SelectedIndex].ToString();
            var indexS = i.ToString().Split(" ")[0];
            int index = int.Parse(indexS);
            int indexNew = index - (1);
            this.ScrollToLine(index);
            try
            {
                if (this.codeView.Lines[indexNew].ToString().Contains("# VDocs:"))
                {
                    this.debugTextLabel.Text = this.codeView.Lines[indexNew].ToString();
                }
                else
                {
                    this.debugTextLabel.Text = "No documentation for selected method, try clicking the Documentation button.";
                }
            }
            catch
            {
                // invalid selection, do nothing..
            }

        }
        public int getCurrentLineSelected()
        {

            int firstcharindex = codeView.GetFirstCharIndexOfCurrentLine();
            int currentline = codeView.GetLineFromCharIndex(firstcharindex) + 1;

            return currentline;
        }

        private void clearButtonOnClick(object sender, EventArgs e)
        {
            this.codeView.Text = "";
            this.debugTextLabel.Text = "Cleared IDE of code";
        }

        private void locateParserButtonOnClick(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Filter = "file|*.exe";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    if (dlg.FileName.Contains("vapor_parser"))
                    {
                        var f = File.Create(Directory.GetCurrentDirectory() + "/vaporIDE_data.txt");
                        f.Close();
                        f.Dispose();
                        // MessageBox.Show("Creating file at " + Directory.GetCurrentDirectory() + "/vaporIDE_data.txt");
                        File.WriteAllText(Directory.GetCurrentDirectory() + "/vaporIDE_data.txt", dlg.FileName);
                        this.debugTextLabel.Text = "vapor_parser.exe set location to: " + dlg.FileName;
                        Form1.vapor_parser_location = dlg.FileName;
                        this.getVaporData();
                    }
                    else
                    {
                        MessageBox.Show("Not a valid vapor parser executable. Using desktop path instead.");
                        Form1.vapor_parser_location = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/vapor_parser.exe";
                    }
                }
            }
        }

        private void getVaporData()
        {
            if(!File.Exists(Directory.GetCurrentDirectory() + "/vaporIDE_data.txt"))
            {
                var f = File.Create(Directory.GetCurrentDirectory() + "/vaporIDE_data.txt");
                f.Close();
                f.Dispose();
            }
            var d = File.ReadAllLines(Directory.GetCurrentDirectory() + "/vaporIDE_data.txt");
            if(d.Length > 0)
            {
                Form1.vapor_parser_location = d[0];
                vaporDir.directory = d[0].Replace(Path.GetFileName(d[0]), "");
            }
        }

        public void insertLine(string text, int line, bool scrollToLine=false)
        {
            int cline = this.getCurrentLineSelected();
            this.textBox1.Focus();
            this.HideSelection(true);
            List<String> newlinesl = new List<string>();
            int index = -1;
            foreach(var l in this.codeView.Lines)
            {
                index++;
                if (index == line)
                {
                    newlinesl.Add(text);
                }
                newlinesl.Add(l);
            }
            this.codeView.Lines = newlinesl.ToArray();
            if(scrollToLine)
                this.ScrollToLine(cline);
            this.HideSelection(false);
            this.codeView.Focus();
        }

        public string getTabSpacingFromLine(int line)
        {
            var ls = this.codeView.Lines[line];
            var ts = "";
            foreach(var l in ls)
            {
                if(l == '\t')
                    ts = ts + "\t";
            }
            return ts;
        }

        private void documentationButtonOnClick(object sender, EventArgs e)
        {
            if (this.methodList.Items.Count > 0)
            {
                var docDescription = "# VDocs: ";
                var i = this.methodList.Items[this.methodList.SelectedIndex].ToString();
                var indexS = i.ToString().Split(" ")[0];
                var index = int.Parse(indexS);
                var tabspacing = this.getTabSpacingFromLine(index);
                this.insertLine(tabspacing + docDescription, index);
                this.ScrollToLine(docDescription);
            }
        }
        private void button8_Click()
        {
            if (this.methodList.Items.Count > 0)
            {
                var docDescription = "# VDocs: ";
                var i = this.methodList.Items[this.methodList.SelectedIndex].ToString();
                var indexS = i.ToString().Split(" ")[0];
                var index = int.Parse(indexS);
                var tabspacing = this.getTabSpacingFromLine(index);
                this.insertLine(tabspacing + docDescription, index);
                this.ScrollToLine(docDescription);
            }
        }

        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                var selected = this.methodList.SelectedIndex;
                this.button8_Click();
            }
        }

        private void codeView_KeyDown(object sender, KeyEventArgs e)
        {
            
            if(e.KeyCode == Keys.LControlKey && e.KeyCode == Keys.Space)
            {
                MessageBox.Show(e.ToString());
                this.methodList.SelectedIndex = 0;
                this.methodList.Focus();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        public vaporMethod[] getVaporMethodsFromFile(string standardLibraryFileName)
        {
            List<vaporMethod> vmr = new List<vaporMethod>();
            List<string> doclist = new List<string>();
            bool foundDoc = false;
         
            if(File.Exists(vaporDir.directory + "Standard Library\\" + standardLibraryFileName))
            {
                string[] stlb = File.ReadAllLines(vaporDir.directory + "Standard Library\\" + standardLibraryFileName);
                int ind = -1;
                foreach(var l in stlb)
                {
                    ind++;
                    var l2 = l.Replace("\t", "");
                    if(l2.StartsWith("#") && l2.Contains("VDocs"))
                    {
                        doclist.Add(l2);
                        foundDoc = true;
                    }
                    if(l2.StartsWith("m ")) {
                        vaporMethod vapm = new vaporMethod(l2, ind, vaporDir.directory + "Standard Library\\" + standardLibraryFileName);
                        if (foundDoc)
                        {
                            vapm.doc = doclist.Last();
                            foundDoc = false;
                        }
                        vmr.Add(vapm);
                        this.usingMethods.Add(vapm);

                    }
                }
            }
            return vmr.ToArray();
        }


        public string getVaporFileFromMethodString(string methodString, bool justFileName = false)
        {
            foreach (var vm in this.usingMethods)
            {
                if(vm.methodRawLine.Contains(methodString))
                {
                    if (justFileName)
                        return Path.GetFileName(vm.filepath);
                    return vm.filepath;
                }
            }
            return "";
        }

        private void methodList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void usingMethodsList_SelectedValueChanged(object sender, EventArgs e)
        {
            var i = this.usingMethodsList.Items[this.usingMethodsList.SelectedIndex].ToString();
            var m = i.Split(" ")[2];
            string doc = "";
            foreach(var um in this.usingMethods)
            {
                if(um.methodRawLine.Contains(m))
                {
                    doc = um.doc;
                    break;
                }
            }
            if (!String.IsNullOrEmpty(doc))
            {
                this.debugTextLabel.Text = doc;
            }
            else
            {
                this.debugTextLabel.Text = "Method from " + this.getVaporFileFromMethodString(m, true) + " | No docs available.";
            }
        }

        private void buildButton_click(object sender, EventArgs e)
        {
            MessageBox.Show(vaporDir.directory);

            var f = File.Create(vaporDir.directory + "IDECode.vap");
            f.Close();
            f.Dispose();
            File.WriteAllLines(vaporDir.directory + "IDECode.vap", this.codeView.Lines);

            // System.Diagnostics.Process.Start("CMD.exe", "/k cd C:/Users/Marc/Desktop/ & vapor_parser.exe test.vap");
            var pr = System.Diagnostics.Process.Start("CMD.exe", "/k cd \"" + Directory.GetCurrentDirectory() + "\" & vapor_parser.exe \"" + vaporDir.directory + "\\IDECode.vap\"");
            Task.Factory.StartNew(() =>
            {
                Thread.Sleep(2000);
                pr.Kill();
                pr.Close();
                pr.Dispose();
                // MessageBox.Show("Found Output: " + File.Exists("C:/Users/Marc/Desktop/output.py"));
                var pr2 = System.Diagnostics.Process.Start("CMD.exe", "/k cd \"" + vaporDir.directory + "\" & pyinstaller output.py --onedir --onefile");
                pr2.WaitForExit();
                pr2.Kill();
                pr2.Close();
                pr2.Dispose();

                while (!File.Exists(vaporDir.directory + "dist/output.exe"))
                {
                    Thread.Sleep(100);
                }
                
                if (File.Exists(vaporDir.directory + "VaporExecutable.exe"))
                    File.Delete(vaporDir.directory + "VaporExecutable.exe");
                File.Move(vaporDir.directory + "dist/output.exe",vaporDir.directory + "/VaporExecutable.exe");
                Directory.Delete(vaporDir.directory + "dist", true);
                Directory.Delete(vaporDir.directory + "build", true);
                Directory.Delete(vaporDir.directory + "__pycache__", true);
                File.Delete(vaporDir.directory + "output.spec");
                File.Delete(vaporDir.directory + "output.py");
                Process.Start("explorer.exe", "/select, \"" + vaporDir.directory + "VaporExecutable.exe\"");
                // Do things here.
                // NOTE: You may need to invoke this to your main thread depending on what you're doing
            });


        
            
            // System.Diagnostics.Process.Start("CMD.exe", "/k cd " + vapor_path + " & vapor_parser.exe " + Directory.GetCurrentDirectory() + "/IDECode.vap");
            this.debugTextLabel.Text = @"Executed IDE Code";
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                File.Delete(vaporDir.directory + "IDECode.vap");
                File.Delete(vaporDir.directory + "output.py");
            }
            catch
            {
                // nothing..
            }
            
        }

        private void standardLibraryButton_Click(object sender, EventArgs e)
        {
            static string GetStringBetween(string strBegin, string strEnd, string strSource, bool includeBegin=false, bool includeEnd=false)
            {
                string[] result = { string.Empty, string.Empty };
                int iIndexOfBegin = strSource.IndexOf(strBegin);

                if (iIndexOfBegin != -1)
                {
                    // include the Begin string if desired 
                    if (includeBegin)
                        iIndexOfBegin -= strBegin.Length;

                    strSource = strSource.Substring(iIndexOfBegin + strBegin.Length);

                    int iEnd = strSource.IndexOf(strEnd);
                    if (iEnd != -1)
                    {
                        // include the End string if desired 
                        if (includeEnd)
                            iEnd += strEnd.Length;
                        result[0] = strSource.Substring(0, iEnd);
                        // advance beyond this segment 
                        if (iEnd + strEnd.Length < strSource.Length)
                            result[1] = strSource.Substring(iEnd + strEnd.Length);
                    }
                }
                else
                    // stay where we are 
                    result[1] = strSource;
                return result[0];
            }

            this.debugTextLabel.Text = "Currently attempting to install Standard Library Modules. Be patient.";

            // Get the amount of standard library modules we have, via github
            string stdLibLocation = "https://github.com/mwd1993/Vapor/tree/main/Standard%20Library";
            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(stdLibLocation);
            myRequest.Method = "GET";
            WebResponse myResponse = myRequest.GetResponse();
            StreamReader sr = new StreamReader(myResponse.GetResponseStream(), System.Text.Encoding.UTF8);
            string result = sr.ReadToEnd();
            sr.Close();
            myResponse.Close();
            string[] resultsplit = result.Split("\n");
            List<string> libraryUrls = new List<string>() { };
            // ----------------------------------------------------------------

            // Parse some html to get the URLS for each module/library
            foreach (var rs in resultsplit)
            {
                if (rs.ToLower().Contains("link--primary") && rs.ToLower().Contains("#repo-content-pjax-container") && rs.ToLower().Contains(".vap"))
                {
                    string libraryUrl = (stdLibLocation + "/" + GetStringBetween("title=\"", ".vap", rs) + ".vap").Trim();
                    libraryUrls.Add(libraryUrl);
                }
            }
            // -------------------------------------------------------

            // Sanitize string and then download each library to our 
            // standard library directory
            foreach (var lib in libraryUrls)
            {
                string rawurl = lib.Replace("github", "raw.githubusercontent").Replace("tree/","");
                HttpWebRequest myRequest2 = (HttpWebRequest)WebRequest.Create(rawurl);
                myRequest2.Method = "GET";
                WebResponse myResponse2 = myRequest2.GetResponse();
                StreamReader sr2 = new StreamReader(myResponse2.GetResponseStream(), System.Text.Encoding.UTF8);
                string result2 = sr2.ReadToEnd();
                sr2.Close();
                myResponse2.Close();
                string stdlibdir = vaporDir.standardLibrary;
                string libname = Path.GetFileName(rawurl);
                if(!Directory.Exists(stdlibdir))
                {
                    Directory.CreateDirectory(stdlibdir);
                }
                File.WriteAllText(stdlibdir + libname, result2);
            }
            // ----------------------------------------------------

            this.debugTextLabel.Text = libraryUrls.Count + " Modules installed to: " + vaporDir.standardLibrary;

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void executeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.performHiddenButtonClick(executeButton);
        }

        public void performHiddenButtonClick(Button button)
        {
            var size = button.Size;
            button.Size = Size.Empty; // button still will be invisible
            button.Show(); // make it clickable
            button.PerformClick();
            button.Hide();  // hide again
            button.Size = size;
        }

        private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.performHiddenButtonClick(saveButton);
        }

        private void buildToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.performHiddenButtonClick(BuildButton);
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.performHiddenButtonClick(clearButton);
        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.performHiddenButtonClick(importButton);
        }

        private void locateParserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.performHiddenButtonClick(locateParserButton);
        }

        private void downloadStandardLibraryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.performHiddenButtonClick(standardLibraryButton);
        }

        private void viewReleasesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.performHiddenButtonClick(releaseButton);
        }

        private void vaporSyntaxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", "https://mwd1993.github.io/Vapor/syntax.html");
        }
    }
    public class vaporMethod
    {
        public string filepath;
        public string methodRawLine;
        public int lineindex;
        public string doc;
        public vaporMethod(string methodRawLine,int lineindex, string filepath)
        {
            this.methodRawLine = methodRawLine.Replace("{","").Trim();
            this.filepath = filepath;
            this.lineindex = lineindex;
        }

        public string getMethodString()
        {
            return "";
        }

    }
}
