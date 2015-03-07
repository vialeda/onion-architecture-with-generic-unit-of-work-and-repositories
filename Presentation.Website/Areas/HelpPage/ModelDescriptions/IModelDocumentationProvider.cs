using System;
using System.Reflection;

namespace Viainternet.OnionArchitecture.Presentation.Website.Areas.HelpPage.ModelDescriptions
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}