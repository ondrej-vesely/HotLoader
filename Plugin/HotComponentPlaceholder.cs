using Grasshopper.Kernel;
using System.IO;
using System.Windows.Forms;

namespace HotLoader
{
    /// <summary>
    /// Placeholder that will be replaced with a real hot component at runtime.
    /// </summary>
    public class HotComponentPlaceholder : HotComponentBase
    {
        public HotComponentPlaceholder() : base("Custom C# Component", "C#", "A custom component written in C#") { }

        protected override void SolveInstance(IGH_DataAccess DA)
        {
            AddRuntimeMessage(GH_RuntimeMessageLevel.Remark, "This is a placeholder. Double click to edit the source code with your native C# editor.");
        }

        public override void AppendAdditionalMenuItems(ToolStripDropDown menu)
        {
            base.AppendAdditionalMenuItems(menu);

            Menu_AppendItem(menu, "Link to Existing Project", (ev, arg) =>
            {
                Rhino.UI.OpenFileDialog openFileDialog = new Rhino.UI.OpenFileDialog
                {
                    Filter = "C# Project Files (*.csproj)|*.csproj",
                    Title = "Select a C# project file to link to this component"
                };
                if (openFileDialog.ShowOpenDialog())
                {
                    ReplaceComponentWithPlaceholder(Path.GetDirectoryName(openFileDialog.FileName));
                }
            });
        }
    }
}
