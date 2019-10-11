/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System;
using OutSystems.RuntimeCommon;
using OutSystems.RuntimeCommon.Settings;

namespace OutSystems.HubEdition.RuntimePlatform {

// TODO RRCT
#pragma warning disable 618 // still using Settings class in this file to access the config names. This class itself needs to be moved to the ServerCommon

    public class Remoting {

        protected static Remoting instance;

        protected static Remoting Instance {
            get {
                if (instance == null) {
                    instance = new Remoting();
                }
                return instance;
            }
            set { instance = value; }
        }

        private static ICompiler compiler;
        public static void SetICompiler(ICompiler icompiler) {
            compiler = icompiler;
        }

        public static ICompiler GetICompiler(ISettingsProvider settingsProvider) {
            return compiler ?? Instance.InnerGetICompiler(settingsProvider);
        }

        public static ICompiler GetNonCachedICompiler(string compilerUri, string hostname, int port) {
            return Instance.InnerGetICompiler(compilerUri, hostname, Convert.ToString(port));
        }

        public static TDeploymentControllerInterface GetDeploymentControllerInterface<TDeploymentControllerInterface>(string uriToUse, ISettingsProvider settingsProvider) 
                where TDeploymentControllerInterface: class {

            return Instance.InnerGetDeploymentControllerInterface<TDeploymentControllerInterface>(uriToUse, settingsProvider);
        }

        private TDeploymentControllerInterface InnerGetDeploymentControllerInterface<TDeploymentControllerInterface>(string uriToUse, string hostname, string portStr) 
                where TDeploymentControllerInterface: class {

            if (string.IsNullOrEmpty(uriToUse))
                throw new InvalidOperationException("Missing '" + Settings.Configs.CompilerService_Uri + "' setting.");
            if (string.IsNullOrEmpty(portStr))
                throw new InvalidOperationException("Missing '" + Settings.Configs.CompilerService_Port + "' setting.");
            if (!Char.IsNumber(portStr, 0) || Int32.Parse(portStr) == 0)
                throw new InvalidOperationException("Invalid '" + Settings.Configs.CompilerService_Port + "' setting.");
            if (string.IsNullOrEmpty(hostname))
                throw new InvalidOperationException("Invalid '" + Settings.Configs.CompilerService_HostName + "' setting.");
            TDeploymentControllerInterface comp = null;
            try {
                int port = Int32.Parse(portStr);
                comp = GetObjectForRemoting<TDeploymentControllerInterface>(hostname, port, uriToUse);
            } catch {
                throw;
            }
            if (comp == null) {
                throw new InvalidOperationException("Could not locate service " + uriToUse + " on server " + hostname);
            }
            return comp;
        }

        private TDeploymentControllerInterface InnerGetDeploymentControllerInterface<TDeploymentControllerInterface>(string uriToUse, ISettingsProvider settingsProvider)
          where TDeploymentControllerInterface : class {

            string compilerPort = settingsProvider.Get(new Setting<string>(Settings.Configs.CompilerService_Port, null));
            string compilerHostName = settingsProvider.Get(new Setting<string>(Settings.Configs.CompilerService_HostName, null));
            return InnerGetDeploymentControllerInterface<TDeploymentControllerInterface>(
                uriToUse,
                compilerHostName,
                compilerPort);
        }
        
        protected virtual ICompiler InnerGetICompiler(ISettingsProvider settingsProvider) {
            var uri = settingsProvider.Get(new Setting<string>(Settings.Configs.CompilerService_Uri, null));
            return InnerGetDeploymentControllerInterface<ICompiler>(uri, settingsProvider);
        }

        protected virtual ICompiler InnerGetICompiler(string compilerUri, string hostname, string port) {
            return InnerGetDeploymentControllerInterface<ICompiler>(compilerUri, hostname, port);
        }

        public static TObject GetObjectForRemoting<TObject>(string host, int port, string uriPath) {
            return GetObjectForRemoting<TObject>(host, Convert.ToString(port), uriPath);
        }

        public static TObject GetObjectForRemoting<TObject>(string host, string port, string uriPath) {
            return GetObjectForRemoting<TObject>(host, port + "/" + uriPath);
        }

        public static TObject GetObjectForRemoting<TObject>(string host, string portAndPath) {
            string uri = "tcp://" + RuntimePlatformUtils.FixHostIPForIPV6(host) + ":" + portAndPath;
            return (TObject)Activator.GetObject(typeof(TObject), uri);
        }
    }
}
#pragma warning restore 618
