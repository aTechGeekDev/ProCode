using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Diagnostics;
using Telerik.Windows.Controls.SyntaxEditor.Tagging.Taggers;
using System.Windows.Forms;
using Telerik.Windows.SyntaxEditor.Core.Text;
using System.IO;
using Telerik.Windows.Controls.SyntaxEditor.UI.IntelliPrompt.Completion;
using Telerik.Windows.Controls.SyntaxEditor.Taggers;
using ProCodeX;
using System.CodeDom.Compiler;

namespace ProCodeX
{

    /// <summary>
    /// Interaction logic for Welcome.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string language = "";
        string filename;
        string filepath;
        bool savedfirsttime = false;
        bool cSharpcompiledfirsttime = false;
        bool VBcompiledfirsttime = false;


        public MainWindow()
        {
            InitializeComponent();
            if (File.Exists(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\compilation.cs"))
            {

                File.Delete(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\compilation.cs");
            }
            if (File.Exists(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\compilation.exe"))
            {

                File.Delete(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\compilation.exe");
            }
            if (File.Exists(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\compilation.vb"))
            {

                File.Delete(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\compilation.vb");
            }

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_GotFocus(object sender, RoutedEventArgs e)
        {
        }

        private void DonateButton_LostFocus(object sender, RoutedEventArgs e)
        {
        }

        private void RadMenuItem_Click(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {

        }
        private void OpenCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = ".cs";
            dlg.Filter = "C# (*.cs)|*.cs|VB.NET (*.vb)|*.vb|HTML (*.html)|*.html|CSS (*.css)|*.css|SQL(*.csv) | *.csv";
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                using (StreamReader reader = new StreamReader(dlg.FileName))
                {
                    this.syntaxEditor.Document = new TextDocument(reader);
                    filename = System.IO.Path.GetFileName(dlg.FileName); ;
                    savedfirsttime = true;
                    Title = "ProCode | " + filename;
                }
            }
        }
        public void saveascommand()
        {
            this.syntaxEditor.SelectAll();
            string selectedText = this.syntaxEditor.Selection.GetSelectedText();
            syntaxEditor.IsSelectionEnabled = false;
            Microsoft.Win32.SaveFileDialog dlgs = new Microsoft.Win32.SaveFileDialog();
            dlgs.FileName = "Document"; // Default file name
            dlgs.DefaultExt = ".text"; // Default file extension
            dlgs.Filter = "C# (.cs)|*.cs|VB.NET (.vb)|*.vb|HTML (.html)|*.html|JavaScript (.js)|*.js|XML (.xml)|*.xml|XAML (.xaml)|*.xaml|SQL (.sql)|*.sql"; // Filter files by extension
            Nullable<bool> result = dlgs.ShowDialog();
            if (result == true)
            {
                File.WriteAllText(dlgs.FileName, string.Empty);
                using (StreamWriter sw = File.AppendText(dlgs.FileName))
                {
                    sw.WriteLine(selectedText);
                    filename = System.IO.Path.GetFileName(dlgs.FileName);
                    filepath = dlgs.FileName;
                    savedfirsttime = true;
                    Title = "ProCode | " + filename;
                    syntaxEditor.IsSelectionEnabled = true;
                }
            }


        }

        public void SaveAsCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            saveascommand();
        }
        private void NewCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MainWindow win2 = new MainWindow();
            win2.Show();

        }
        public void SaveCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (savedfirsttime == false)
            {
                saveascommand();
            }
            else
            {

                this.syntaxEditor.SelectAll();
                string selectedText = this.syntaxEditor.Selection.GetSelectedText();
                syntaxEditor.IsSelectionEnabled = false;
                if (selectedText == "")
                {
                    System.Windows.MessageBox.Show("E002" + Environment.NewLine + "Yo, you can't save an empty file", "ProCode is mad", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    File.WriteAllText(filename, selectedText.ToString());
                    syntaxEditor.IsSelectionEnabled = true;
                }
            }
        }

        private void DonateButton_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("https://www.patreon.com/atechgeek");
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            Process.Start("https://www.youtube.com/channel/UCMr_qcjz9ru6gpnl-h88KUA?sub_confirmation=1");
        }

        private void csharpButton_Click(object sender, RoutedEventArgs e)
        {
            var cSharpTagger = new CSharpTagger(this.syntaxEditor);
            this.syntaxEditor.TaggersRegistry.RegisterTagger(cSharpTagger);
            language = "C#";
            this.status.Content = "Status: So far so good chief";
            LanguageButton.IsEnabled = false;
        }

        private void syntaxEditor_TextInput(object sender, TextCompositionEventArgs e)
        {
           
        }

        private void new_Click(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            MainWindow win2 = new MainWindow();
            win2.Show();
        }


        private void open_Click_2(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = ".cs";
            dlg.Filter = "C# (*.cs)|*.cs|VB.NET (*.vb)|*.vb|HTML (*.html)|*.html|CSS (*.css)|*.css|SQL(*.csv) | *.csv";
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                using (StreamReader reader = new StreamReader(dlg.FileName))
                {
                    this.syntaxEditor.Document = new TextDocument(reader);
                    this.status.Content = "Status: To enable syntax highlighting, choose a language from here";
                    string filepath = dlg.FileName;
                }
            }
        }

        public void VBNETbutton_Click(object sender, RoutedEventArgs e)
        {
            var VbnetTagger = new VisualBasicTagger(this.syntaxEditor);
            this.syntaxEditor.TaggersRegistry.RegisterTagger(VbnetTagger);
            this.status.Content = "Status: So far so good chief";
            language = "VBNET";
            LanguageButton.IsEnabled = false;
        }

        private void HTMLbutton_Click(object sender, RoutedEventArgs e)
        {
            var HTML = new XmlTagger(this.syntaxEditor);
            this.syntaxEditor.TaggersRegistry.RegisterTagger(HTML);
            this.status.Content = "Status: So far so good chief";
            language = "HTML";
            LanguageButton.IsEnabled = false;

        }

        private void syntaxEditor_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {

        }

        private void save_Click(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            
            }

        private void javascriptButton_Click(object sender, RoutedEventArgs e)
        {
            var javaScriptTagger = new JavaScriptTagger(this.syntaxEditor);
            this.syntaxEditor.TaggersRegistry.RegisterTagger(javaScriptTagger);
            this.status.Content = "Status: So far so good chief";
            language = "JAVASCRIPT";
            LanguageButton.IsEnabled = false;
        }

        private void XMLbutton_Click(object sender, RoutedEventArgs e)
        {
            var xml = new XmlTagger(this.syntaxEditor);
            this.syntaxEditor.TaggersRegistry.RegisterTagger(xml);
            this.status.Content = "Status: So far so good chief";
            language = "XML";
            LanguageButton.IsEnabled = false;
        }

        private void XAMLbutton_Click(object sender, RoutedEventArgs e)
        {
            var xaml = new XmlTagger(this.syntaxEditor);
            this.syntaxEditor.TaggersRegistry.RegisterTagger(xaml);
            this.status.Content = "Status: So far so good chief";
            language = "XAML";
            LanguageButton.IsEnabled = false;
        }

        private void SQLbutton_Click(object sender, RoutedEventArgs e)
        {
            var SQL = new SqlTagger(this.syntaxEditor);
            this.syntaxEditor.TaggersRegistry.RegisterTagger(SQL);
            this.status.Content = "Status: So far so good chief";
            language = "SQL";
            LanguageButton.IsEnabled = false;
        }

        private void RadMenuItem_Click_1(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            this.Close();
        }

        private void undoButton_Click(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            syntaxEditor.Undo();
        }

        private void redoButton_Click(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            syntaxEditor.Redo();
        }

        private void cutButton_Click(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            syntaxEditor.Cut();
        }

        private void copyButton_Click(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            syntaxEditor.Copy();
        }

        private void pasteButton_Click(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            syntaxEditor.Paste();
        }

        private void deleteButton_Click(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            syntaxEditor.Delete();
        }

        private void selectAll_Click(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            syntaxEditor.SelectAll();
        }

        private void zoomIn_Click(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            syntaxEditor.ZoomIn();
        }

        private void zoomOut_Click(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            syntaxEditor.ZoomOut();
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            syntaxEditor.ZoomIn();
        }

        private void CommandBinding_Executed_1(object sender, ExecutedRoutedEventArgs e)
        {
            syntaxEditor.ZoomOut();
        }

        private void RadMenuItem_Click_2(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {







        }

        private void settingsButton_Click(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            feedback fed = new feedback();
            fed.Show();
        }

        private void minimizeButton_Click(object sender, Telerik.Windows.RadRoutedEventArgs e) => this.WindowState = System.Windows.WindowState.Maximized;

        private void minimizeButton_Click_1(object sender, Telerik.Windows.RadRoutedEventArgs e) => this.WindowState = System.Windows.WindowState.Minimized;

        private void aboutBtn_Click(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            
        }

        private void CompileBtn_Click(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            if (language == "C#")
            {
                if (File.Exists(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\compilation.cs"))
                {

                    File.Delete(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\compilation.cs");
                }
                if (File.Exists(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\compilation.exe"))
                {

                    File.Delete(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\compilation.exe");
                }
                if (File.Exists(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\compilation.vb"))
                {

                    File.Delete(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\compilation.vb");
                }

                this.syntaxEditor.SelectAll();
                string selectedText = this.syntaxEditor.Selection.GetSelectedText();
                string fileName = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\compilation.cs";
                if (!File.Exists(fileName))
                {
                    File.Create(fileName).Close();
                    using (StreamWriter sw = File.AppendText(fileName))
                    {
                        sw.WriteLine(selectedText);
                    }

                }
                compilationtext.Visibility = Visibility.Visible;
                hidebutton.Visibility = Visibility.Visible;
                
                Process p = new Process();
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.FileName = "csc.exe";
                p.StartInfo.Arguments = "compilation.cs"; //or your thing
                p.Start();
                p.WaitForExit();
                string result = p.StandardOutput.ReadToEnd();

                compilationtext.Text = result;
                status.Content = "Status: Compilation Successful";
                cSharpcompiledfirsttime = true;


            }
            if (language == "VBNET")
            {
                if (File.Exists(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\compilation.cs")) { 
                
                    File.Delete(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\compilation.cs");
                }
                if (File.Exists(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\compilation.exe"))
                {

                    File.Delete(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\compilation.exe");
                }
                if (File.Exists(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\compilation.vb"))
                {

                    File.Delete(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\compilation.vb");
                }


                this.syntaxEditor.SelectAll();
                string selectedText = this.syntaxEditor.Selection.GetSelectedText();
                string fileName = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\compilation.vb";
                if (!File.Exists(fileName))
                {
                    File.Create(fileName).Close();
                    using (StreamWriter sw = File.AppendText(fileName))
                    {
                        sw.WriteLine(selectedText);
                    }

                }
                compilationtext.Visibility = Visibility.Visible;
                hidebutton.Visibility = Visibility.Visible;

                Process p = new Process();
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.FileName = "vbc.exe";
                p.StartInfo.Arguments = "compilation.vb"; //or your thing
                p.Start();
                p.WaitForExit();
                string result = p.StandardOutput.ReadToEnd();

                compilationtext.Text = result;
                status.Content = "Status: Compilation Successful";
                VBcompiledfirsttime = true;


            }
        }
        private void startButton_Click(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {

        }

        private void hidebutton_Click(object sender, RoutedEventArgs e)
        {
            compilationtext.Visibility = Visibility.Hidden;
            hidebutton.Visibility = Visibility.Hidden;
        }
    }
    }

