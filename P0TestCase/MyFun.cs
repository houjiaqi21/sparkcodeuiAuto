using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;
using System.Configuration;

namespace P0TestCase
{
    public class MyFun
    {
        static DateTime time = DateTime.Now;
        static string timenow = DateTimeTool.DateTimeToStamp(time);

        static WinWindow visualStudioStart = MyFun._window("Microsoft Visual Studio");
        static WinWindow VsProject = MyFun._window("test" + timenow + " - Microsoft Visual Studio");
        static WinWindow VsProjectN = MyFun._window(projectName + " - Microsoft Visual Studio");


        static string projectName = ConfigurationSettings.AppSettings["ProjectName"];
        static string testProjectPath = ConfigurationSettings.AppSettings["TestProjectPath"];
        static string location = ConfigurationSettings.AppSettings["vslocation"];



        //GENERAL FUNCTION FOR COMMON CONTROLS


        public static void LaunchVs()
        {
            ApplicationUnderTest.Launch(location);
        }


        /*--------------------获取winwindow--------------------*/
        public static WinWindow _window(string WinName)
        {
            WinWindow mywindow = new WinWindow();
            mywindow.SearchProperties[WinWindow.PropertyNames.Name] = WinName;
            return mywindow;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ParentWindow"></param>
        /// <param name="WinName"></param>
        /// <returns></returns>
        public static WinWindow _window(UITestControl ParentWindow, string WinName)
        {
            WinWindow mywindow = new WinWindow(ParentWindow);
            mywindow.SearchProperties[WinWindow.PropertyNames.Name] = WinName;
            return mywindow;
        }


        /*--------------------获取wpfwindow--------------------*/
        public static WpfWindow _wpfwindow(string WinName)
        {
            WpfWindow mywindow = new WpfWindow();
            mywindow.SearchProperties[WpfWindow.PropertyNames.Name] = WinName;
            return mywindow;
        }

        public static WpfWindow _wpfwindow(UITestControl ParentWindow, string WinName)
        {
            WpfWindow mywindow = new WpfWindow(ParentWindow);
            mywindow.SearchProperties[WpfWindow.PropertyNames.Name] = WinName;
            return mywindow;
        }

        /*--------------------获取WinButton，若存在则点击--------------------*/
        public static WinButton _MyWinButton(UITestControl ParentWindow,string PropertyName)
        {
            WinButton mybutton = new WinButton(ParentWindow);
            mybutton.SearchProperties[WinButton.PropertyNames.Name] = PropertyName;

            if(mybutton.Exists == true)
            {
                Mouse.Click(mybutton);
            }
            return mybutton;
        }


        /*--------------------获取WpfButton，若存在则点击--------------------*/
        public static UITestControl _MyWpfButton(UITestControl ParentWindow, string PropertyName)
        {
            WpfButton mybutton = new WpfButton(ParentWindow);
            mybutton.SearchProperties[WpfButton.PropertyNames.Name] = PropertyName;

            if (mybutton.Exists == true)
            {
                Mouse.Click(mybutton);
            }
            return mybutton;
        }


        /*--------------------获取WinEdit，若存在则输入--------------------*/
        public static WinEdit _WinEdit(UITestControl ParentWindow, string SendingValue, string PropertyName)
        {
            WinEdit mywinedit = new WinEdit(ParentWindow);
            mywinedit.SearchProperties[WinEdit.PropertyNames.Name] = PropertyName;
            Keyboard.SendKeys(mywinedit, SendingValue);
            return mywinedit;
        }
        public static UITestControl _WpfEdit(UITestControl ParentWindow, string SendingValue, string PropertyName)
        {
            WpfEdit mywpfedit = new WpfEdit(ParentWindow);
            mywpfedit.SearchProperties[WpfEdit.PropertyNames.Name] = PropertyName;
            Keyboard.SendKeys(mywpfedit, SendingValue);
            return mywpfedit;
        }


        /*--------------------获取ListItem--------------------*/
        public static WpfListItem _MyWpfListItem(UITestControl ParentWindow, string PropertyName)
        {
            WpfListItem mywpflistitem = new WpfListItem(ParentWindow);
            mywpflistitem.SearchProperties[WpfListItem.PropertyNames.Name] = PropertyName;

            if (mywpflistitem.Exists == true)
            {
                Mouse.Click(mywpflistitem);
            }
            return mywpflistitem;
        }

        public static WpfList _MyWpfList(UITestControl ParentWindow, string PropertyName)
        {
            WpfList mywpflist = new WpfList(ParentWindow);
            mywpflist.SearchProperties[WpfList.PropertyNames.Name] = PropertyName;
            return mywpflist;
        }

        /*--------------------获取MenuItem--------------------*/
        public static WinMenuItem _MyWinMenuItem(UITestControl ParentWindow, string PropertyName)
        {
            WinMenuItem mywinmenuitem = new WinMenuItem(ParentWindow);
            mywinmenuitem.SearchProperties[WinMenuItem.PropertyNames.Name] = PropertyName;
            return mywinmenuitem;
        }

        public static WpfMenuItem _MyWpfMenuItem(UITestControl ParentWindow, string PropertyName)
        {
            WpfMenuItem mywpfmenuitem = new WpfMenuItem(ParentWindow);
            mywpfmenuitem.SearchProperties[WpfMenuItem.PropertyNames.Name] = PropertyName;
            return mywpfmenuitem;
        }

        public static WinTreeItem _MyWinTreeItem(UITestControl ParentControl, string PropertyName)    
        {
            WinTreeItem selectCluster = new WinTreeItem(ParentControl);
            selectCluster.SearchProperties[WinMenuItem.PropertyNames.Name] = PropertyName;
            return selectCluster;
        }

        public static WpfTreeItem _MyWpfTreeItem(UITestControl ParentControl, string PropertyName)
        {
            WpfTreeItem selectCluster = new WpfTreeItem(ParentControl);
            selectCluster.SearchProperties[WpfMenuItem.PropertyNames.Name] = PropertyName;
            return selectCluster;
        }


        public static WinPane _MyWinPane(string PropertyName)
        {
            WinPane mywinPane = new WinPane();
            mywinPane.SearchProperties[WinPane.PropertyNames.Name] = PropertyName;
            return mywinPane;
        }
        public static WinPane _MyWinPane(UITestControl ParentWindow, string PropertyName)
        {
            WinPane mywinPane = new WinPane(ParentWindow);
            mywinPane.SearchProperties[WinPane.PropertyNames.Name] = PropertyName;
            return mywinPane;
        }


        public static WpfPane _MyWpfPane(string PropertyName)
        {
            WpfPane mywpfPane = new WpfPane();
            mywpfPane.SearchProperties[WpfPane.PropertyNames.Name] = PropertyName;
            return mywpfPane;
        }
        public static WpfPane _MyWpfPane(UITestControl ParentWindow, string PropertyName)
        {
            WpfPane mywpfPane = new WpfPane(ParentWindow);
            mywpfPane.SearchProperties[WpfPane.PropertyNames.Name] = PropertyName;
            return mywpfPane;
        }

        public static WinText _MyWinText(UITestControl ParentControl, string PropertyName)
        {
            WinText selectCluster = new WinText(ParentControl);
            selectCluster.SearchProperties[WinText.PropertyNames.Name] = PropertyName;
            return selectCluster;
        }
        /*--------------------打开project--------------------*/
        public static void Openscopeproject(string path)
        {
            WpfWindow OpenProject = _wpfwindow("Open Project/Solution");

            LaunchVs();
            MyFun._MyWpfButton(visualStudioStart, "Open a _project or solution");
            Keyboard.SendKeys(path);
            Keyboard.SendKeys("{Enter}");
        }

        public static void SelectVC()
        {
            WinMenuItem Extensions = MyFun._MyWinMenuItem(VsProjectN, "Extensions");
            Mouse.Click(Extensions);

            WpfMenuItem Scopem = MyFun._MyWpfMenuItem(Extensions, "Scope");
            Mouse.Hover(Scopem);

            WpfMenuItem ScopeOptions = MyFun._MyWpfMenuItem(Scopem, "VC Selector");
            Mouse.Click(ScopeOptions);

            WinGroup Clusters = new WinGroup(VsProjectN);
            Clusters.SearchProperties[WinGroup.PropertyNames.Name] = "Standard Virtual Clusters";

            WinText clu = new WinText(Clusters);
            clu.SearchProperties[WinText.PropertyNames.Name] = "Cluster:";

            WinComboBox Clustersbox = new WinComboBox(Clusters);
            UITestControlCollection winbox = Clustersbox.FindMatchingControls();
            int i = 0;
            foreach (UITestControl x in winbox)
            {
                if (i == 0)
                {
                    Mouse.Click(x);
                    Keyboard.SendKeys("cosmos08");
                    Keyboard.SendKeys("{Enter}");
                    i++;
                }
                if (i == 1)
                {
                    Mouse.Click(x);
                    Keyboard.SendKeys("sandbox");
                    Keyboard.SendKeys("{Enter}");
                }
            }

            MyFun._MyWinButton(VsProjectN, "Add Selected Item");

            WinWindow virtualClusterExplorer = MyFun._window("Virtual Cluster Explorer");
            if (virtualClusterExplorer.Exists == true)
            {
                MyFun._MyWinButton(virtualClusterExplorer, "OK");
            }
        }

    }
}
