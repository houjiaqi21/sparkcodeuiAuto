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
using System.Collections;
using System.Configuration;

namespace P0TestCase
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class CodedUITest1
    {
        static string projectName = ConfigurationSettings.AppSettings["ProjectName"];
        static string testProjectPath = ConfigurationSettings.AppSettings["TestProjectPath"];

        static DateTime time = DateTime.Now;
        static string timenow = DateTimeTool.DateTimeToStamp(time);

        static WinWindow VisualStudioStart = MyFun._window("Microsoft Visual Studio");
        static WinWindow VsProjectN = MyFun._window(projectName + " - Microsoft Visual Studio");
        static WinWindow VsProject = MyFun._window("test" + timenow + " - Microsoft Visual Studio");



        //public CodedUITest1()
        //{
        //}

        [Timeout(6000000)]
        [TestMethod]
        public void CreateScopeproject()
        {
            WinWindow AAD = MyFun._window("AAD Account");

            MyFun.LaunchVs();
            MyFun._MyWpfButton(VisualStudioStart, "Create a _new project");
            MyFun._WpfEdit(VisualStudioStart, "scope", "_Search for templates (Alt+S)");
            MyFun._MyWpfListItem(VisualStudioStart, "SCOPE Application");
            MyFun._MyWinButton(VisualStudioStart, "_Next");
            MyFun._WpfEdit(VisualStudioStart, "test" + timenow, "Project name");
            MyFun._WpfEdit(VisualStudioStart, @"E:\test", "Location");
            MyFun._MyWinButton(VisualStudioStart, "Create");

            if (AAD.Exists)
            {
                MyFun._MyWinButton(AAD, "OK");
                WinMenuItem Extensions = MyFun._MyWinMenuItem(VsProject, "Extensions");

                WpfMenuItem Scopem = new WpfMenuItem(Extensions);
                Scopem.SearchProperties[WpfMenuItem.PropertyNames.Name] = "Scope";
                Mouse.Hover(Scopem);

                WpfMenuItem ScopeOptions = new WpfMenuItem(Scopem);
                ScopeOptions.SearchProperties[WpfMenuItem.PropertyNames.Name] = "Options and Settings...";
                Mouse.Click(ScopeOptions);
                
                WpfGroup Login = new WpfGroup(VsProject);
                Scopem.SearchProperties[WpfGroup.PropertyNames.Name] = "Login";

                WpfRadioButton AADAccount = new WpfRadioButton(Login);
                AADAccount.SearchProperties[WpfRadioButton.PropertyNames.Name] = "AAD Account";

                if (AADAccount.Exists == true)
                {
                    Mouse.Click(AADAccount);
                }
               

            }

            Image shot = VsProject.CaptureImage();
            shot.Save(@"E:\test\1.png");


        }

        [TestMethod]
        public void Openexistingscopeproject()
        {

            MyFun.Openscopeproject(testProjectPath);

        }

        [TestMethod]
        public void SelectVC()
        {
            MyFun.Openscopeproject(testProjectPath);


            MyFun.SelectVC();

            CustomFun.CaptureImage(VsProjectN, "SelectVC");

        }

        [TestMethod]
        public void Openjobbrowser()
        {
            MyFun.Openscopeproject(testProjectPath);
            while (!MyFun._MyWinText(VsProjectN, "cosmos08").Exists)
            {
                MyFun.SelectVC();
            }

            WinTreeItem selectCluster = MyFun._MyWinTreeItem(VsProjectN, "cosmos08");

            while (!MyFun._MyWinText(selectCluster, "sandbox").Exists)
            {
                Mouse.Click(selectCluster);
            }

            WinText selectClusterunder = MyFun._MyWinText(selectCluster, "sandbox");
            if (MyFun._MyWinTreeItem(selectClusterunder, "Cosmos Jobs").Exists)
            {
                WinTreeItem cosmosJobs = MyFun._MyWinTreeItem(selectClusterunder, "Cosmos Jobs");
                Mouse.DoubleClick(cosmosJobs);
            }
            else
            {
                Mouse.DoubleClick(selectClusterunder);
                WinTreeItem cosmosJobs = MyFun._MyWinTreeItem(selectClusterunder, "Cosmos Jobs");
                Mouse.DoubleClick(cosmosJobs);
            }

        }

        [TestMethod]
        public void Openfileexplorer()
        {
            MyFun.Openscopeproject(testProjectPath);
            while (!MyFun._MyWinText(VsProjectN, "cosmos08").Exists)
            {
                MyFun.SelectVC();
            }
            
            WinTreeItem selectCluster = MyFun._MyWinTreeItem(VsProjectN, "cosmos08");

            while (!MyFun._MyWinText(selectCluster, "sandbox").Exists)
            {
                Mouse.Click(selectCluster);
            }

            WinText selectClusterunder = MyFun._MyWinText(selectCluster, "sandbox");
            if (MyFun._MyWinTreeItem(selectClusterunder, "Cosmos Store").Exists)
            {
                WinTreeItem cosmosJobs = MyFun._MyWinTreeItem(selectClusterunder, "Cosmos Store");
                Mouse.DoubleClick(cosmosJobs);
            }
            else
            {
                Mouse.DoubleClick(selectClusterunder);
                WinTreeItem cosmosJobs = MyFun._MyWinTreeItem(selectClusterunder, "Cosmos Store");
                Mouse.DoubleClick(cosmosJobs);
            }
            
        }

        [TestMethod]
        public void UploadPreviewfile()
        {
            Openfileexplorer();
            WinPane fileExplorer = new WinPane(VsProjectN);
            fileExplorer.SearchProperties[WinEdit.PropertyNames.Name] = "File Explorer";
            WinComboBox folderlocation = new WinComboBox(fileExplorer);
            folderlocation.SearchProperties[WinComboBox.PropertyNames.ControlType] = "ComboBox";
            Mouse.Click(folderlocation);
            Keyboard.SendKeys("https://cosmos08.osdinfra.net:443/cosmos/sandbox/users/v-jiaqihou@microsoft.com/test/");
            Keyboard.SendKeys("{Enter}");

            UITestControl gridView = new UITestControl(fileExplorer);
            gridView.SearchProperties[UITestControl.PropertyNames.Name] = "dataGridViewStreams Data Grid";
            Mouse.Click(gridView, MouseButtons.Right);

            WpfMenuItem Upload = MyFun._MyWpfMenuItem(VsProjectN, "Upload");
            Mouse.Hover(Upload);

            WpfMenuItem AsText = MyFun._MyWpfMenuItem(Upload, "As Text");
            Mouse.Click(AsText);

            WpfWindow upload = MyFun._wpfwindow("Upload File");
            MyFun._MyWinButton(upload, "Previous Locations");

            Keyboard.SendKeys(@"E:\test\testfiles");
            Keyboard.SendKeys("{Enter}");

            WinList list = new WinList(upload);
            list.SearchProperties[WinGroup.PropertyNames.ControlType] = "List";
            Mouse.Click(list);

            Keyboard.SendKeys("a", ModifierKeys.Control);

            MyFun._MyWinButton(upload, "Open");

            while (MyFun._wpfwindow(VsProjectN, "VC Explorer").Exists)
            {
                WpfWindow warring = MyFun._wpfwindow(VsProjectN, "VC Explorer");
                WpfButton re = new WpfButton(warring);
                re.SearchProperties[WinGroup.PropertyNames.ControlType] = "Button";
                Mouse.Click(re);
            }
            CustomFun.CaptureImage(VsProject, "uploadastext");

            Mouse.Click(gridView);

            UITestControl dataitem = new UITestControl(gridView);
            dataitem.SearchProperties[UITestControl.PropertyNames.Name] = "Microsoft.Cosmos.ScopeStudio.BusinessObjects.Common.VCUtility.StreamItem";
            Mouse.Click(gridView);
            Mouse.DoubleClick(dataitem);
            CustomFun.CaptureImage(VsProject, "uploadasbinary");
            Mouse.Click();
            Playback.Wait(3000);
            Keyboard.SendKeys("{F4}", ModifierKeys.Control);
            Playback.Wait(1000);
            Mouse.Click(dataitem);
            Keyboard.SendKeys("a", ModifierKeys.Control);
            Mouse.Click(dataitem, MouseButtons.Right);

            Mouse.Click(MyFun._MyWpfMenuItem(VsProjectN, "Delete All"));
            WpfWindow delete = MyFun._wpfwindow(VsProjectN, "Delete");
            MyFun._MyWpfButton(VsProjectN, "OK");


            Mouse.Click(gridView);
            Mouse.Click(gridView, MouseButtons.Right);

            Mouse.Hover(Upload);

            WpfMenuItem asBinary = MyFun._MyWpfMenuItem(Upload, "As Binary");
            Mouse.Click(asBinary);

            MyFun._MyWinButton(upload, "Previous Locations");

            Keyboard.SendKeys(@"E:\test\testfiles");
            Keyboard.SendKeys("{Enter}");

            Mouse.Click(list);

            Keyboard.SendKeys("a", ModifierKeys.Control);

            MyFun._MyWinButton(upload, "Open");

            while (MyFun._wpfwindow(VsProjectN, "VC Explorer").Exists)
            {
                WpfWindow warring = MyFun._wpfwindow(VsProjectN, "VC Explorer");
                WpfButton re = new WpfButton(warring);
                re.SearchProperties[WinGroup.PropertyNames.ControlType] = "Button";
                Mouse.Click(re);
            }
            CustomFun.CaptureImage(VsProject, "uploadasbinary");

            Mouse.Click(gridView);

            Mouse.Click(dataitem);
            Keyboard.SendKeys("a", ModifierKeys.Control);
            Mouse.Click(dataitem, MouseButtons.Right);

            Mouse.Click(MyFun._MyWpfMenuItem(VsProjectN, "Delete All"));

            MyFun._MyWpfButton(VsProjectN, "OK");

            Playback.Wait(5000);
        }

        [TestMethod]
        public void Clusterbuild()
        {
            WinWindow VsProjectN = MyFun._window("Sample_1" + " - Microsoft Visual Studio");

            MyFun.Openscopeproject(@"E:\test\Sample_1\Sample_1.sln");
            WpfPane solution = MyFun._MyWpfPane(VsProjectN, "Solution Explorer");
            WinTreeItem projectn = MyFun._MyWinTreeItem(solution, "Scope.script");
            Mouse.DoubleClick(projectn);

            WinPane ScopePane = MyFun._MyWinPane(VsProjectN, "Scope.script");
            WinComboBox Clustersbox = new WinComboBox(ScopePane);
            UITestControlCollection winbox = Clustersbox.FindMatchingControls();
            int i = 0;
            foreach (UITestControl x in winbox)
            {
                if (i == 0)
                {
                    Mouse.Click(x);
                    MyFun._MyWpfListItem(x, "Cluster");
                }
                if (i == 1)
                {

                    Mouse.Click(x);
                    MyFun._MyWpfListItem(x, "Cosmos");
                }
                if (i == 2)
                {
                    Mouse.Click(x);
                    MyFun._MyWpfListItem(x, "cosmos08.sandbox");
                    break;
                }
                i++;
            }
            Mouse.Click(projectn);
            WinMenuItem Build = MyFun._MyWinMenuItem(VsProjectN, "Build");
            Mouse.Click(Build);

            WpfMenuItem Rebuild = MyFun._MyWpfMenuItem(Build, "Rebuild Solution");
            Mouse.Click(Rebuild);

            Playback.Wait(30000);
        }

        [TestMethod]
        public void Localbuild()
        {
            WinWindow VsProjectN = MyFun._window("Sample_1" + " - Microsoft Visual Studio");

            MyFun.Openscopeproject(@"E:\test\Sample_1\Sample_1.sln");
            WpfPane solution = MyFun._MyWpfPane(VsProjectN, "Solution Explorer");
            WinTreeItem projectn = MyFun._MyWinTreeItem(solution, "Scope.script");
            Mouse.DoubleClick(projectn);

            WinPane ScopePane = MyFun._MyWinPane(VsProjectN, "Scope.script");
            WinComboBox Clustersbox = new WinComboBox(ScopePane);
            UITestControlCollection winbox = Clustersbox.FindMatchingControls();
            foreach (UITestControl x in winbox)
            {
               
                    Mouse.Click(x);
                    MyFun._MyWpfListItem(x, "Local");

                    break;
                
            }
            Mouse.Click(projectn);
            WinMenuItem Build = MyFun._MyWinMenuItem(VsProjectN, "Build");
            Mouse.Click(Build);

            WpfMenuItem Rebuild = MyFun._MyWpfMenuItem(Build, "Rebuild Solution");
            Mouse.Click(Rebuild);

            Playback.Wait(30000);
        }

        [TestMethod]
        public void DebugLocally()
        {

            WinWindow VsProjectN = MyFun._window("Sample_1" + " - Microsoft Visual Studio");

            MyFun.Openscopeproject(@"E:\test\Sample_1\Sample_1.sln");
            WpfPane solution = MyFun._MyWpfPane(VsProjectN, "Solution Explorer");

            WinTreeItem projectn = MyFun._MyWinTreeItem(solution, "Scope.script");
            Mouse.Click(projectn);
            Mouse.Click(projectn, MouseButtons.Right);
            this.FindFun.clickbuild();

            Playback.Wait(30000);
            Keyboard.SendKeys("{Enter}");
        }



        [TestMethod]
        public void LocalRun()
        {
            WinWindow VsProjectN = MyFun._window("Sample_1" + " - Microsoft Visual Studio");

            MyFun.Openscopeproject(@"E:\test\Sample_1\Sample_1.sln");
            WpfPane solution = MyFun._MyWpfPane(VsProjectN, "Solution Explorer");
            WinTreeItem projectn = MyFun._MyWinTreeItem(solution, "Scope.script");
            Mouse.DoubleClick(projectn);

            Keyboard.SendKeys("{F5}", ModifierKeys.Control);
            Playback.Wait(30000);
        }

        [TestMethod]
        public void UnitTest()
        {
            WinWindow VsProjectN = MyFun._window("Sample_1" + " - Microsoft Visual Studio");

            MyFun.Openscopeproject(@"E:\test\Sample_1\Sample_1.sln");
            WpfPane solution = MyFun._MyWpfPane(VsProjectN, "Solution Explorer");

            WinTreeItem projectn = MyFun._MyWinTreeItem(solution, "Scope.script");
            Mouse.Click(projectn);
            Mouse.Click(projectn, MouseButtons.Right);
            this.MenuFun.clickbuild();

            WpfWindow destination = MyFun._wpfwindow(VsProjectN, "Destination file exists");
            MyFun._MyWpfButton(destination, "Yes");

            WinTreeItem projectn1 = MyFun._MyWinTreeItem(solution, "Sample_1UnitTest");
            Mouse.Click(projectn1);
            Mouse.Click(projectn1, MouseButtons.Right);
            this.MenuFun.clickrun();

            Playback.Wait(30000);

        }

        [TestMethod]
        public void SubmitAll_in_One()
        {
            WinWindow VsProjectN = MyFun._window("ScopAll_In_One" + " - Microsoft Visual Studio");

            MyFun.Openscopeproject(@"E:\test\ScopAll_In_One\ScopAll_In_One.sln");

            WpfPane solution = MyFun._MyWpfPane(VsProjectN, "Solution Explorer");
            WinTreeItem projectn = MyFun._MyWinTreeItem(solution, "Scope17.script");
            Mouse.Click(projectn);
            Mouse.Click(projectn, MouseButtons.Right);
            this.FindFun.clicksubmit();

            WpfPane submitJob = MyFun._MyWpfPane(VsProjectN, "Submit Job");

            WpfEdit editbox1 = new WpfEdit(submitJob);
            UITestControlCollection editbox = editbox1.FindMatchingControls();
            foreach (UITestControl x in editbox)
            {
                x.DrawHighlight();

                Keyboard.SendKeys("ScopAll_In_One_Scope17_houjiaqi" + timenow);
                break;
            }
            WinComboBox Clustersbox = new WinComboBox(submitJob);
            UITestControlCollection winbox = Clustersbox.FindMatchingControls();
            int i = 0;
            foreach (UITestControl x in winbox)
            {
                if (i == 0)
                {
                    Mouse.Click(x);
                    Keyboard.SendKeys("cosmos");
                    Keyboard.SendKeys("{Enter}");
                }
                if (i == 1)
                {
                    Mouse.Click(x);
                    Keyboard.SendKeys("cosmos08.sandbox");
                    Keyboard.SendKeys("{Enter}");
                    break;
                }
                i++;
            }

            WinText submitB = MyFun._MyWinText(submitJob, "Submi_t");
            Mouse.Click(submitB);

            Playback.Wait(100000);
            Keyboard.SendKeys("{F4}", ModifierKeys.Control);
        }
        #region Additional test attributes

            // You can use the following additional attributes as you write your tests:

            ////Use TestInitialize to run code before running each test 
        [TestInitialize()]
        public void MyTestInitialize()
        {
            // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        }

        ////Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void MyTestCleanup()
        {
            //MessageBox.Show("1111");
        }

        #endregion

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        private TestContext testContextInstance;

        public UIMap UIMap
        {
            get
            {
                if (this.map == null)
                {
                    this.map = new UIMap();
                }

                return this.map;
            }
        }
        private UIMap map;
        public FindFun FindFun
        {
            get
            {
                if (this.findFun == null)
                {
                    this.findFun = new FindFun();
                }

                return this.findFun;
            }
        }

        private FindFun findFun;

        public MenuFun MenuFun
        {
            get
            {
                if (this.menuFun == null)
                {
                    this.menuFun = new MenuFun();
                }

                return this.menuFun;
            }
        }

        private MenuFun menuFun;
    }
}
