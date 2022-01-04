using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P0TestCase
{
    public partial class FindFun
    {
        public void clickbuild()
        {
            #region Variable Declarations
            WpfMenuItem uIBuildScriptMenuItem = this.UIWpfWindow1.UIItemMenu1.UIDebugLocallyMenuItem1;
            #endregion

            Mouse.Click(uIBuildScriptMenuItem);
        }

        public void clicktests()
        {
            #region Variable Declarations
            WpfMenuItem uIBuildScriptMenuItem = this.UIWpfWindow1.UIItemMenu1.UICreateUnitTestsMenuItem;
            #endregion

            Mouse.Click(uIBuildScriptMenuItem);
        }

        public void clicksubmit()
        {
            #region Variable Declarations
            WpfMenuItem uIBuildScriptMenuItem = this.UIWpfWindow1.UIItemMenu1.UISubmitScriptMenuItem;
            #endregion

            Mouse.Click(uIBuildScriptMenuItem);
        }
        public UIWpfWindow1 UIWpfWindow1
        {
            get
            {
                if ((this.mUIWpfWindow1 == null))
                {
                    this.mUIWpfWindow1 = new UIWpfWindow1();
                }
                return this.mUIWpfWindow1;
            }
        }


        #region Fields
        private UIWpfWindow1 mUIWpfWindow1;
        #endregion
    }

    public class UIWpfWindow1 : WpfWindow
    {

        public UIWpfWindow1()
        {
            #region Search Criteria
            this.SearchProperties.Add(new PropertyExpression(WpfWindow.PropertyNames.ClassName, "HwndWrapper", PropertyExpressionOperator.Contains));
            #endregion
        }

        #region Properties
        public UIItemMenu1 UIItemMenu1
        {
            get
            {
                if ((this.mUIItemMenu1 == null))
                {
                    this.mUIItemMenu1 = new UIItemMenu1(this);
                }
                return this.mUIItemMenu1;
            }
        }
        #endregion

        #region Fields
        private UIItemMenu1 mUIItemMenu1;
        #endregion
    }

    public class UIItemMenu1 : WpfMenu
    {

        public UIItemMenu1(UITestControl searchLimitContainer) :
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WpfMenu.PropertyNames.ClassName] = "Uia.ContextMenu";
            this.SearchProperties[WpfMenu.PropertyNames.Name] = "Item";
            #endregion
        }



        #region Properties
        public WpfMenuItem UIDebugLocallyMenuItem1
        {
            get
            {
                if ((this.mUIDebugLocallyMenuItem1 == null))
                {
                    this.mUIDebugLocallyMenuItem1 = new WpfMenuItem(this);
                    #region Search Criteria
                    this.mUIDebugLocallyMenuItem1.SearchProperties[WpfMenuItem.PropertyNames.Name] = "Debug Locally";
                    #endregion
                }
                return this.mUIDebugLocallyMenuItem1;
            }
        }

        public WpfMenuItem UIBuildScriptMenuItem2
        {
            get
            {
                if ((this.mUIBuildScriptMenuItem2 == null))
                {
                    this.mUIBuildScriptMenuItem2 = new WpfMenuItem(this);
                    #region Search Criteria
                    this.mUIBuildScriptMenuItem2.SearchProperties[WpfMenuItem.PropertyNames.Name] = "Build Script";
                    #endregion
                }
                return this.mUIBuildScriptMenuItem2;
            }
        }

        public WpfMenuItem UICreateUnitTestsMenuItem
        {
            get
            {
                if ((this.mUICreateUnitTestsMenuItem == null))
                {
                    this.mUICreateUnitTestsMenuItem = new WpfMenuItem(this);
                    #region Search Criteria
                    this.mUICreateUnitTestsMenuItem.SearchProperties[WpfMenuItem.PropertyNames.Name] = "Create Unit Tests";
                    #endregion
                }
                return this.mUICreateUnitTestsMenuItem;
            }
        }

        public WpfMenuItem UISubmitScriptMenuItem
        {
            get
            {
                if ((this.mUISubmitScriptMenuItem == null))
                {
                    this.mUISubmitScriptMenuItem = new WpfMenuItem(this);
                    #region Search Criteria
                    this.mUISubmitScriptMenuItem.SearchProperties[WpfMenuItem.PropertyNames.Name] = "Submit Script";
                    #endregion
                }
                return this.mUISubmitScriptMenuItem;
            }
        }
        #endregion

        #region Fields
        private WpfMenuItem mUIDebugLocallyMenuItem1;
        private WpfMenuItem mUIBuildScriptMenuItem2;
        private WpfMenuItem mUICreateUnitTestsMenuItem;
        private WpfMenuItem mUISubmitScriptMenuItem;
        #endregion
    }
}
