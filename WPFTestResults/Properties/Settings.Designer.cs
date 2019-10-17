// ***********************************************************************
// Assembly         : WPFTestResults
// Author           : G.H.M.H. Schmeits
// Created          : 01-04-2018
//
// Last Modified By : G.H.M.H. Schmeits
// Last Modified On : 01-11-2018
// ***********************************************************************
// <copyright file="Settings.Designer.cs" company="SCHMEITS">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

/// <summary>
/// The Properties namespace.
/// </summary>
namespace WPFTestResults.Properties {


    /// <summary>
    /// Class Settings. This class cannot be inherited.
    /// </summary>
    /// <seealso cref="System.Configuration.ApplicationSettingsBase" />
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "15.5.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {

        /// <summary>
        /// The default instance
        /// </summary>
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));

        /// <summary>
        /// Gets the default.
        /// </summary>
        /// <value>The default.</value>
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
    }
}
