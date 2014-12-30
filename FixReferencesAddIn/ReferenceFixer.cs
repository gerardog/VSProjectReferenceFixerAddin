using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvDTE80;
using EnvDTE;

namespace FixReferencesAddIn
{
    class ReferenceFixer
    {
        private DTE2 _applicationObject;
        private AddIn _addInInstance;
        OutputWindow outputWindow;

        public ReferenceFixer(DTE2 _applicationObject, AddIn _addInInstance)
        {
            this._addInInstance = _addInInstance;
            this._applicationObject = _applicationObject;

            Window window = _applicationObject.Windows.Item(EnvDTE.Constants.vsWindowKindOutput);
            outputWindow = (OutputWindow)window.Object;
            outputWindow.ActivePane.Activate();
        }

        public void Run()
        {
            var projects = _applicationObject.Solution.Projects;
            Dictionary<string, Project> outputs = GetProjectsOutputs(projects);

            foreach (Project p in projects)
            {
                var proj = p.Object as VSLangProj.VSProject;

                if (proj != null)
                {
                    for (int i = 1; i <= proj.References.Count; i++)
                    {
                        var r = proj.References.Item(i);

                        if (r.SourceProject == null && outputs.ContainsKey(r.Name))
                        {
                            var referenceName = r.Name; // must cache before removing reference
                            WriteLine(" Fixing References on project {0} for project {1}", p.Name, outputs[r.Name].Name);

                            r.Remove();
                            i = 0; // reset i to start over.

                            proj.References.AddProject(outputs[referenceName]);
                        }
                    }
                }
            }
        }

        private Dictionary<string, Project> GetProjectsOutputs(Projects projects)
        {
            var result = new Dictionary<string, Project>( StringComparer.OrdinalIgnoreCase  );

            foreach (Project p in projects)
            {
                var proj = p.Object as VSLangProj.VSProject;

                if (proj != null)
                {
                    var r = p.Properties.Item("OutputFileName");
                    if (r != null)
                    {   
                        result.Add(r.Value.ToString().Replace(".dll",""), p);
                        WriteLine(" Project {0} generates assembly: {1}", p.Name, r.Value.ToString().Replace(".dll",""));
                    }
                }
            }
            return result;
        }


        void WriteLine(string text, params object[] parameters)
        {
            outputWindow.ActivePane.OutputString(string.Format(text + "\n", parameters));
        }

    }
}
