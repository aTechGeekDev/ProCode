using System;
using System.Threading.Tasks;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.Windows;
using System.Windows.Input;
using System.Diagnostics;
using System.IO;
using System.ComponentModel;
using ActiproSoftware.Text.Languages.CSharp.Implementation;
using ActiproSoftware.Text.Languages.VB.Implementation;
using ActiproSoftware.Text.Languages.Xml.Implementation;
using ActiproSoftware.Text.Languages.JavaScript.Implementation;
using ActiproSoftware.Windows.Themes;
using ActiproSoftware.Text;
using ActiproSoftware.Text.Implementation;
using Telerik.Windows.Controls;
using ActiproSoftware.Windows.Themes;

namespace ProCodeX
{

    /// <summary>
    /// Interaction logic for Welcome.xaml
    /// </summary>
    public partial class MainWindow
    {
        public string language = "";
        string filename;
        string filepath;
        bool savedfirsttime = false;
        bool cSharpcompiledfirsttime = false;
        bool VBcompiledfirsttime = false;


        public MainWindow()
        {
            InitializeComponent();
            ThemesAeroThemeCatalogRegistrar.Register();
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
            compilationtext.Visibility = Visibility.Hidden;
            ActiproSoftware.Windows.Themes.ThemeManager.SetTheme(syntaxEditor, ThemeNames.Black);
            ActiproSoftware.Windows.Themes.ThemeManager.SetAreNativeThemesEnabled(syntaxEditor, true);
            MainWindow radWindow = new MainWindow();
            radWindow.IconTemplate = this.Resources["WindowIconTemplate"] as DataTemplate;


        }

        public void start()
        {
            try
            {
                Process p2 = new Process();
                p2.StartInfo.FileName = "compilation.exe";
                p2.Start();
            }
            catch (Win32Exception e)
            {
                System.Windows.MessageBox.Show("E010" + e + Environment.NewLine + "Your code have some problems, Errors Written below", "ProCode is mad", MessageBoxButton.OK, MessageBoxImage.Error);
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
                syntaxEditor.Document.LoadFile(dlg.FileName);
                    filename = System.IO.Path.GetFileName(dlg.FileName); ;
                    savedfirsttime = true;
                  
            }
        }
        public void saveascommand()
        {
            Microsoft.Win32.SaveFileDialog dlgs = new Microsoft.Win32.SaveFileDialog();
            dlgs.FileName = "Document"; // Default file name
            dlgs.DefaultExt = ".text"; // Default file extension
            dlgs.Filter = "C# (.cs)|*.cs|VB.NET (.vb)|*.vb|HTML (.html)|*.html|JavaScript (.js)|*.js|XML (.xml)|*.xml|XAML (.xaml)|*.xaml|SQL (.sql)|*.sql"; // Filter files by extension
            Nullable<bool> result = dlgs.ShowDialog();
            if (result == true)
            {
                    syntaxEditor.Document.SaveFile(dlgs.FileName, LineTerminator.CarriageReturnNewline);
                    filename = System.IO.Path.GetFileName(dlgs.FileName);
                    filepath = dlgs.FileName;
                    savedfirsttime = true;
               

            }


        }

        public void SaveAsCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            saveascommand();
        }
        private void NewCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Window win2 = new Window();
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
                if (syntaxEditor.Text == "")
                {
                    System.Windows.MessageBox.Show("E002" + Environment.NewLine + "Yo, you can't save an empty file", "ProCode is mad", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    syntaxEditor.Document.SaveFile(filename, LineTerminator.CarriageReturnNewline);
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
            syntaxEditor.Document.Language = new CSharpSyntaxLanguage();
            language = "C#";
        }

        private void syntaxEditor_TextInput(object sender, TextCompositionEventArgs e)
        {
           
        }

        private void new_Click(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            Window win2 = new Window();
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
                    syntaxEditor.Document.LoadFile(dlg.FileName);
                    string filepath = dlg.FileName;
                    filename = System.IO.Path.GetFileName(dlg.FileName); ;
                    savedfirsttime = true;

                }
            }
        }

        public void VBNETbutton_Click(object sender, RoutedEventArgs e)
        {
            syntaxEditor.Document.Language = new VBSyntaxLanguage();
            language = "VBNET";
        }

        private void HTMLbutton_Click(object sender, RoutedEventArgs e)
        {
            syntaxEditor.Document.Language = new XmlSyntaxLanguage();
            language = "HTML";

        }

        private void syntaxEditor_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {

        }

        private void save_Click(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            
            }

        private void javascriptButton_Click(object sender, RoutedEventArgs e)
        {
            syntaxEditor.Document.Language = new JavaScriptSyntaxLanguage();
            language = "JAVASCRIPT";
        }

        private void XMLbutton_Click(object sender, RoutedEventArgs e)
        {
            syntaxEditor.Document.Language = new XmlSyntaxLanguage();
            language = "XML";
        }

        private void XAMLbutton_Click(object sender, RoutedEventArgs e)
        {
            syntaxEditor.Document.Language = new XmlSyntaxLanguage();
            language = "XAML";
        }

        private void SQLbutton_Click(object sender, RoutedEventArgs e)
        {
            SyntaxLanguageDefinitionSerializer serializer = new SyntaxLanguageDefinitionSerializer();
            string path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\langdef\Sql.langdef";
            ISyntaxLanguage language = serializer.LoadFromFile(path);
            this.syntaxEditor.Document.Language = language;
        }

        private void RadMenuItem_Click_1(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
        }

        private void undoButton_Click(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            syntaxEditor.Document.UndoHistory.Undo();
        }

        private void redoButton_Click(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            syntaxEditor.Document.UndoHistory.Redo();
        }

        private void cutButton_Click(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            syntaxEditor.ActiveView.CutToClipboard();

        }

        private void copyButton_Click(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            syntaxEditor.ActiveView.CopyToClipboard();
        }

        private void pasteButton_Click(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            syntaxEditor.ActiveView.PasteFromClipboard();
        }

        private void deleteButton_Click(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
        }

        private void selectAll_Click(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            syntaxEditor.ActiveView.Selection.SelectAll();
        }

        private void zoomIn_Click(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            var level = syntaxEditor.ZoomLevel;
            syntaxEditor.ZoomLevel = level + 1.0;
        }

        private void zoomOut_Click(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            var level = syntaxEditor.ZoomLevel;
            syntaxEditor.ZoomLevel = level - 0.1;
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            var level = syntaxEditor.ZoomLevel;
            syntaxEditor.ZoomLevel = level + 0.1;
        }

        private void CommandBinding_Executed_1(object sender, ExecutedRoutedEventArgs e)
        {
            var level = syntaxEditor.ZoomLevel;
            syntaxEditor.ZoomLevel = level - 0.1;
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

        private void minimizeButton_Click(object sender, Telerik.Windows.RadRoutedEventArgs e) {
            Window win = new Window();
            win.WindowState = System.Windows.WindowState.Minimized;

        }

        private void minimizeButton_Click_1(object sender, Telerik.Windows.RadRoutedEventArgs e) {

            Window win = new Window();
            win.WindowState = System.Windows.WindowState.Minimized;
        }

        private void aboutBtn_Click(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            AboutScreen ab = new AboutScreen();
            ab.Show();
        }

        private void CompileBtn_Click(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            if (savedfirsttime == false)
            {
                System.Windows.MessageBox.Show("E003" + Environment.NewLine + "Yo, save the file b4 compiling", "ProCode is mad", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if (language == "")
            {
                System.Windows.MessageBox.Show("E004" + Environment.NewLine + "Yo, Choose a language b4 getting excited", "ProCode is mad", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if (language == "HTML")
            {
                System.Windows.MessageBox.Show("E005" + Environment.NewLine + "This Language isn't a programming language, Go to File>Save As Instead", "ProCode is sad", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if (language == "JAVASCRIPT")
            {
                System.Windows.MessageBox.Show("E005" + Environment.NewLine + "This Language isn't supported for exporting, Go to File>Save As Instead", "ProCode is sad", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if (language == "XML")
            {
                System.Windows.MessageBox.Show("E005" + Environment.NewLine + "This Language isn't a programming language, Go to File>Save As Instead", "ProCode is sad", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if (language == "XAML")
            {
                System.Windows.MessageBox.Show("E005" + Environment.NewLine + "This Language isn't a programming language, Go to File>Save As Instead", "ProCode is sad", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if (language == "SQL")
            {
                System.Windows.MessageBox.Show("E005" + Environment.NewLine + "This Language isn't a programming language, Go to File>Save As Instead", "ProCode is sad", MessageBoxButton.OK, MessageBoxImage.Error);
            }
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

                string fileName = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\compilation.cs";
                if (!File.Exists(fileName))
                {
                    File.Create(fileName).Close();
                    using (StreamWriter sw = File.AppendText(fileName))
                    {
                        syntaxEditor.Document.SaveFile(fileName, LineTerminator.CarriageReturnNewline);
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
                string fileName = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\compilation.vb";
                if (!File.Exists(fileName))
                {
                    File.Create(fileName).Close();
                    using (StreamWriter sw = File.AppendText(fileName))
                    {
                    syntaxEditor.Document.SaveFile(fileName, LineTerminator.CarriageReturnNewline);
                    }

                }
                compilationtext.Visibility = Visibility.Visible;
                hidebutton.Visibility = Visibility.Visible;
                status.Content = "Status: Compiling...";
                Process p = new Process();
                p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.FileName = "vbc.exe";
                p.StartInfo.Arguments = "compilation.vb"; //or your thing
                p.Start();
                p.WaitForExit();
                string result = p.StandardOutput.ReadToEnd();

                compilationtext.Text = result;
                status.Content = "Status: Compilation finished";
                VBcompiledfirsttime = true;


            }
        }
        private async void startButton_Click(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            if (savedfirsttime == false)
            {
                System.Windows.MessageBox.Show("E003" + Environment.NewLine + "Yo, save the file b4 compiling", "ProCode is mad", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (language == "")
            {
                System.Windows.MessageBox.Show("E004" + Environment.NewLine + "Yo, Choose a language b4 getting excited", "ProCode is mad", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (language == "HTML")
            {
                System.Windows.MessageBox.Show("E005" + Environment.NewLine + "This Language isn't a programming language, Go to File>Save As Instead", "ProCode is sad", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (language == "JAVASCRIPT")
            {
                System.Windows.MessageBox.Show("E005" + Environment.NewLine + "This Language isn't supported for exporting, Go to File>Save As Instead", "ProCode is sad", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (language == "XML")
            {
                System.Windows.MessageBox.Show("E005" + Environment.NewLine + "This Language isn't a programming language, Go to File>Save As Instead", "ProCode is sad", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (language == "XAML")
            {
                System.Windows.MessageBox.Show("E005" + Environment.NewLine + "This Language isn't a programming language, Go to File>Save As Instead", "ProCode is sad", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (language == "SQL")
            {
                System.Windows.MessageBox.Show("E005" + Environment.NewLine + "This Language isn't a programming language, Go to File>Save As Instead", "ProCode is sad", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
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

                string fileName = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\compilation.cs";
                if (!File.Exists(fileName))
                {
                    File.Create(fileName).Close();

                        syntaxEditor.Document.SaveFile(fileName, LineTerminator.CarriageReturnNewline);

                }
                compilationtext.Visibility = Visibility.Visible;
                hidebutton.Visibility = Visibility.Visible;
                status.Content = "Status: Compiling..";
                Process p = new Process();
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.FileName = "csc.exe";
                p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                p.StartInfo.Arguments = "compilation.cs"; //or your thing
                p.Start();
                p.WaitForExit();
                string result = p.StandardOutput.ReadToEnd();

                compilationtext.Text = result;
                status.Content = "Status: Compilation finished";
                cSharpcompiledfirsttime = true;
                await Task.Delay(1000);
                start();


            }
            if (language == "VBNET")
            {
                string fileName = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\compilation.vb";
                if (!File.Exists(fileName))
                {
                    File.Create(fileName).Close();
                        syntaxEditor.Document.SaveFile(fileName, LineTerminator.CarriageReturnNewline);

                }
                compilationtext.Visibility = Visibility.Visible;
                hidebutton.Visibility = Visibility.Visible;
                status.Content = "Status: Compiling..";
                Process p = new Process();
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                p.StartInfo.FileName = "vbc.exe";
                p.StartInfo.Arguments = "compilation.vb"; //or your thing
                p.Start();
                p.WaitForExit();
                string result = p.StandardOutput.ReadToEnd();
                compilationtext.Text = result;
                status.Content = "Status: Compilation finished";
                VBcompiledfirsttime = true;
                await Task.Delay(1000);
                start();


            }
        }


        private void hidebutton_Click(object sender, RoutedEventArgs e)
        {
            compilationtext.Visibility = Visibility.Hidden;
            hidebutton.Visibility = Visibility.Hidden;
        }

        private void publishBtn_Click(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            if (language == "C#")
            {
                if (savedfirsttime == false)
                {
                    System.Windows.MessageBox.Show("E003" + Environment.NewLine + "Yo, save the file b4 publishing", "ProCode is mad", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (language == "")
                {
                    System.Windows.MessageBox.Show("E004" + Environment.NewLine + "Yo, Choose a language b4 getting excited", "ProCode is mad", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (language == "HTML")
                {
                    System.Windows.MessageBox.Show("E004" + Environment.NewLine + "This Language isn't a programming language, Go to File>Save As Instead", "ProCode is sad", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                else if (language == "JAVASCRIPT")
                {
                    System.Windows.MessageBox.Show("E004" + Environment.NewLine + "This Language isn't supported for exporting, Go to File>Save As Instead", "ProCode is sad", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                else if (language == "XML")
                {
                    System.Windows.MessageBox.Show("E004" + Environment.NewLine + "This Language isn't a programming language, Go to File>Save As Instead", "ProCode is sad", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                else if (language == "XAML")
                {
                    System.Windows.MessageBox.Show("E004" + Environment.NewLine + "This Language isn't a programming language, Go to File>Save As Instead", "ProCode is sad", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                else if (language == "SQL")
                {
                    System.Windows.MessageBox.Show("E004" + Environment.NewLine + "This Language isn't a programming language, Go to File>Save As Instead", "ProCode is sad", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                else
                { 
                        string fileName = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\compilation.cs";
                        if (!File.Exists(fileName))
                        {
                            File.Create(fileName).Close();
                            using (StreamWriter sw = File.AppendText(fileName))
                            {
                            syntaxEditor.Document.SaveFile(fileName, LineTerminator.CarriageReturnNewline);
                        }

                    }
                        compilationtext.Visibility = Visibility.Visible;
                        hidebutton.Visibility = Visibility.Visible;

                        Process p = new Process();
                        p.StartInfo.UseShellExecute = false;
                        p.StartInfo.RedirectStandardOutput = true;
                        p.StartInfo.FileName = "csc.exe";
                        p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        p.StartInfo.Arguments = "compilation.cs"; //or your thing
                        p.Start();
                        p.WaitForExit();
                        string results = p.StandardOutput.ReadToEnd();

                        compilationtext.Text = results;
                        status.Content = "Status: Compilation Successful";
                        var dlgw = new CommonOpenFileDialog();
                        dlgw.Title = "Export your code:";
                        dlgw.IsFolderPicker = true;

                        dlgw.AddToMostRecentlyUsedList = false;
                        dlgw.AllowNonFileSystemItems = false;
                        dlgw.EnsureFileExists = true;
                        dlgw.EnsurePathExists = true;
                        dlgw.EnsureReadOnly = false;
                        dlgw.EnsureValidNames = true;
                        dlgw.Multiselect = false;
                        dlgw.ShowPlacesList = true;

                        if (dlgw.ShowDialog() == CommonFileDialogResult.Ok)
                        {
                        var folder = dlgw.FileName;
                        File.Copy(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\compilation.cs", folder + @"\compilation.cs");
                        File.Copy(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\compilation.exe", folder + @"\compilation.exe");
                    }
                }
            }
        }

        private void new_Click_1(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            Window mw = new Window();
            mw.Show();
        }
        private void Window_Closing(object sender, CancelEventArgs e)
        {
            
            MessageBoxResult result = System.Windows.MessageBox.Show("Do you want to save b4 exit?", "Warning", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
            if (result == MessageBoxResult.No)
            {
            }
            if(result == MessageBoxResult.Yes){
                if (savedfirsttime == false)
                {
                    saveascommand();
                }
                else
                {
                    if (syntaxEditor.Text == "")
                    {
                        System.Windows.MessageBox.Show("E002" + Environment.NewLine + "Yo, you can't save an empty file", "ProCode is mad", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        syntaxEditor.Document.SaveFile(filename, LineTerminator.CarriageReturnNewline);
                    }
                }
            }
            if(result == MessageBoxResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        private void syntaxEditor_DragOver(object sender, System.Windows.DragEventArgs e)
        {

        }

        private void undoContext_Click(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            syntaxEditor.Document.UndoHistory.Undo();
        }

        private void redoContext_Click(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            syntaxEditor.Document.UndoHistory.Redo();
        }

        private void cutContext_Click(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            syntaxEditor.ActiveView.CutToClipboard();
        }

        private void copyContext_Click(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            syntaxEditor.ActiveView.CopyToClipboard();
        }

        private void pasteContext_Click(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            syntaxEditor.ActiveView.PasteFromClipboard();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }

}





