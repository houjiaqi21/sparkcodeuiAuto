using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;

namespace P0TestCase
{
    public partial class MenuFun
    {

        public void clickbuild()
        {
            #region Variable Declarations
            WpfMenuItem uIBuildScriptMenuItem = this.UIWpfWindow.UIItemMenu.UIDebugLocallyMenuItem;
            #endregion

            Mouse.Click(uIBuildScriptMenuItem);
        }

        public void clickrun()
        {
            #region Variable Declarations
            WpfMenuItem uIBuildScriptMenuItem = this.UIWpfWindow.UIProjectMenu.UIRunTestsMenuItem;
            #endregion

            Mouse.Click(uIBuildScriptMenuItem);
        }



        #region Properties
        public UIWpfWindow UIWpfWindow
        {
            get
            {
                if ((this.mUIWpfWindow == null))
                {
                    this.mUIWpfWindow = new UIWpfWindow();
                }
                return this.mUIWpfWindow;
            }
        }
        #endregion

        #region Fields
        private UIWpfWindow mUIWpfWindow;
        #endregion
    }

    public class UIWpfWindow : WpfWindow
    {

        public UIWpfWindow()
        {
            #region Search Criteria
            this.SearchProperties.Add(new PropertyExpression(WpfWindow.PropertyNames.ClassName, "HwndWrapper", PropertyExpressionOperator.Contains));
            #endregion
        }

        #region Properties
        public UIItemMenu UIItemMenu
        {
            get
            {
                if ((this.mUIItemMenu == null))
                {
                    this.mUIItemMenu = new UIItemMenu(this);
                }
                return this.mUIItemMenu;
            }
        }

        public UIProjectMenu UIProjectMenu
        {
            get
            {
                if ((this.mUIProjectMenu == null))
                {
                    this.mUIProjectMenu = new UIProjectMenu(this);
                }
                return this.mUIProjectMenu;
            }
        }
        #endregion

        #region Fields
        private UIItemMenu mUIItemMenu;

        private UIProjectMenu mUIProjectMenu;
        #endregion
    }

    public class UIItemMenu : WpfMenu
    {

        public UIItemMenu(UITestControl searchLimitContainer) :
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WpfMenu.PropertyNames.ClassName] = "Uia.ContextMenu";
            this.SearchProperties[WpfMenu.PropertyNames.Name] = "Item";
            #endregion
        }

        #region Propertie
        public WpfMenuItem UIBuildScriptMenuItem
        {
            get
            {
                if ((this.mUIBuildScriptMenuItem == null))
                {
                    this.mUIBuildScriptMenuItem = new WpfMenuItem(this);
                    #region Search Criteria
                    this.mUIBuildScriptMenuItem.SearchProperties[WpfMenuItem.PropertyNames.Name] = "Create Unit Tests";
                    #endregion
                }
                return this.mUIBuildScriptMenuItem;
            }
        }

        public WpfMenuItem UIDebugLocallyMenuItem
        {
            get
            {
                if ((this.mUIDebugLocallyMenuItem == null))
                {
                    this.mUIDebugLocallyMenuItem = new WpfMenuItem(this);
                    #region Search Criteria
                    this.mUIDebugLocallyMenuItem.SearchProperties[WpfMenuItem.PropertyNames.Name] = "Create Unit Tests";
                    #endregion
                }
                return this.mUIDebugLocallyMenuItem;
            }
        }
        #endregion

        #region Fields
        private WpfMenuItem mUIBuildScriptMenuItem;

        private WpfMenuItem mUIDebugLocallyMenuItem;
        #endregion
    }

    public class UIProjectMenu : WpfMenu
    {

        public UIProjectMenu(UITestControl searchLimitContainer) :
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WpfMenu.PropertyNames.ClassName] = "Uia.ContextMenu";
            this.SearchProperties[WpfMenu.PropertyNames.Name] = "Project";
            #endregion
        }

        #region Properties
        public WpfMenuItem UIRunTestsMenuItem
        {
            get
            {
                if ((this.mUIRunTestsMenuItem == null))
                {
                    this.mUIRunTestsMenuItem = new WpfMenuItem(this);
                    #region Search Criteria
                    this.mUIRunTestsMenuItem.SearchProperties[WpfMenuItem.PropertyNames.Name] = "Run Tests";
                    #endregion
                }
                return this.mUIRunTestsMenuItem;
            }
        }
        #endregion

        #region Fields
        private WpfMenuItem mUIRunTestsMenuItem;
        #endregion
    }
}
