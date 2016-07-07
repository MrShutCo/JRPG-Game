using System;
using System.Collections.Generic;
using System.IO;
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
using System.Xml;
using System.Xml.Linq;

namespace JRPG_Creator {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            enemyDoc = new XDocument();
        }

        XDocument enemyDoc;
        string enemyFile = "enemyList.xml"; 

        private void EnemyName_TextChanged(object sender, TextChangedEventArgs e) {

        }

        private void EnemyAtk_TextChanged(object sender, TextChangedEventArgs e) {

        }

        private void EnemyMP_TextChanged(object sender, TextChangedEventArgs e) {

        }

        private void EnemyDef_TextChanged(object sender, TextChangedEventArgs e) {

        }

        private void EnemySpd_TextChanged(object sender, TextChangedEventArgs e) {

        }

        private void EnemyXp_TextChanged(object sender, TextChangedEventArgs e) {

        }

        private void EnemyGold_TextChanged(object sender, TextChangedEventArgs e) {

        }

        private void EnemyHP_TextChanged(object sender, TextChangedEventArgs e) {
        }

        private void CreateEnemy_Click(object sender, RoutedEventArgs e) {
            var enemy = new XElement("enemy", new XAttribute("Name", EnemyName.Text), new XAttribute("HP", EnemyHP.Text), new XAttribute("MP", EnemyMP.Text), new XAttribute("Atk", EnemyAtk.Text), new XAttribute("Def", EnemyDef.Text),
                                              new XAttribute("Spd", EnemySpd.Text), new XAttribute("Gold", EnemyGold.Text), new XAttribute("XP", EnemyXp.Text));
            if (File.Exists(enemyFile)) {
                enemyDoc = XDocument.Load(enemyFile);
                enemyDoc.Element("enemies").Add(enemy);
            }
            else {
                enemyDoc = new XDocument(new XElement("enemies", enemy));
            }
            enemyDoc.Save(enemyFile);
        }
    }
}
