﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LogonVistaOrbInstaller.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("LogonVistaOrbInstaller.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Byte[].
        /// </summary>
        internal static byte[] app {
            get {
                object obj = ResourceManager.GetObject("app", resourceCulture);
                return ((byte[])(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap background {
            get {
                object obj = ResourceManager.GetObject("background", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap Logo {
            get {
                object obj = ResourceManager.GetObject("Logo", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;?xml version=&quot;1.0&quot; encoding=&quot;UTF-16&quot;?&gt;
        ///&lt;Task version=&quot;1.2&quot; xmlns=&quot;http://schemas.microsoft.com/windows/2004/02/mit/task&quot;&gt;
        ///  &lt;RegistrationInfo&gt;
        ///    &lt;Date&gt;2024-08-11T00:48:32.8953235&lt;/Date&gt;
        ///    &lt;Author&gt;xxxman360&lt;/Author&gt;
        ///    &lt;URI&gt;\LogonVistaOrb&lt;/URI&gt;
        ///  &lt;/RegistrationInfo&gt;
        ///  &lt;Triggers&gt;
        ///    &lt;EventTrigger&gt;
        ///      &lt;Enabled&gt;true&lt;/Enabled&gt;
        ///      &lt;Subscription&gt;&amp;lt;QueryList&amp;gt;&amp;lt;Query Id=&quot;0&quot; Path=&quot;System&quot;&amp;gt;&amp;lt;Select Path=&quot;System&quot;&amp;gt;*[System[EventID=1074]]&amp;lt;/Select&amp;gt;&amp;lt;/Query&amp;gt;&amp;lt;/QueryList&amp;gt [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string LogonVistaOrb {
            get {
                return ResourceManager.GetString("LogonVistaOrb", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Byte[].
        /// </summary>
        internal static byte[] segoeuisl {
            get {
                object obj = ResourceManager.GetObject("segoeuisl", resourceCulture);
                return ((byte[])(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Byte[].
        /// </summary>
        internal static byte[] Settings {
            get {
                object obj = ResourceManager.GetObject("Settings", resourceCulture);
                return ((byte[])(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.IO.UnmanagedMemoryStream similar to System.IO.MemoryStream.
        /// </summary>
        internal static System.IO.UnmanagedMemoryStream Shutdown {
            get {
                return ResourceManager.GetStream("Shutdown", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.IO.UnmanagedMemoryStream similar to System.IO.MemoryStream.
        /// </summary>
        internal static System.IO.UnmanagedMemoryStream WAVE5051 {
            get {
                return ResourceManager.GetStream("WAVE5051", resourceCulture);
            }
        }
    }
}
