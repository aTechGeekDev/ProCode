using System;
using System.Collections.Generic;
using System.Linq;
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
using Microsoft.Web.WebView2.Core;
using EO;

namespace ProCodeX
{
    /// <summary>
    /// Interaction logic for feedback.xaml
    /// </summary>
    public partial class feedback : Window
    {
        public feedback()
        {
            EO.WebBrowser.Runtime.AddLicense("IdoPvXXY8P0a9nez5fUPn63w9PbooX7GstQT8ajk6bPL9Z7p9/oa7XaZtsHZr1uXs8/n4J3bpAUk7560ptb6rZDc5rPL9Z7p9/oa7XaZtsHZr1uXs8/n4J3bpAUk7560ptb6rYnb6rPL9Z7p9/oa7XaZtsHZr1uXs8/n4J3bpAUk7560ptb6rZDn6rPL9Z7p9/oa7XaZtsHZr1uXs8/nrprj8AAivXXm9vUQ8YLl6gDL45rr6c7NsGios8Hbr2qZpAQg4X7v9Pod5Ky4+M7NsGios8rkuHKZpAcQ8azg8//ooWuZpMDpu6zg6/8M867p6c8d0a/o19Lc8qDE+Nfe2Ifh9vcY7ay4wc7nrqzg6/8M867p6c/nrqXg5/YZ8p61dePt9BDtrNzCzRfonNzyBBDInbW1xN62dabw+g7kp+rp");
            InitializeComponent();
            browser.WebView.LoadUrl("https://forms.gle/Nq1A5pZ8TbqwWBc9A");
        }

    }
}
