using Emu.Common;
using Emu.Logic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Emu.Wpf
{
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            /*
             * 
             * This is just a quick hack to show how the different layers fit together
             * Our User Interface will also be in a layered system such as MVVM
             * MVVM moves the decision making out of the code that handles clicks and draws the UI
             * 
             * Diagram  :
             *              http://i.msdn.microsoft.com/dynimg/IC448690.png
             * 
             * Articles :
             *              http://www.codeproject.com/Articles/100175/Model-View-ViewModel-MVVM-Explained
             *              http://www.codeproject.com/Articles/278901/MVVM-Pattern-Made-Simple
             */

            IExampleLogic Logic { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Logic = new ExampleLogic();
        }

        string FormatUserList( List<ExampleUser> users )
        {
            var strings = users.Select( user => string.Format( "{0:50}   {1:5}", user.UserName, user.Active ) );
            return string.Join( "\n", strings );
        }

        private void FindBnewton_Click( object sender, RoutedEventArgs e )
        {
            var users = new List<ExampleUser>();
            users.Add( Logic.FindUser( Guid.Parse( "8f32ee69-6d6f-11e2-adc8-001b24568fca" ) ) );

            MessageBox.Show( FormatUserList(users) );
        }

        private void FindActive_Click( object sender, RoutedEventArgs e )
        {
            var users = Logic.ActiveUsers();

            MessageBox.Show( FormatUserList(users) );
        }
    }
}
