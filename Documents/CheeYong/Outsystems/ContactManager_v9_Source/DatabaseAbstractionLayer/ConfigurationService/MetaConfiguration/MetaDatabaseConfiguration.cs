/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/

using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using OutSystems.PluginAPI.PluginConfiguration;
using OutSystems.PluginAPI.PluginConfiguration.Introspection;

namespace OutSystems.HubEdition.Extensibility.Data.ConfigurationService.MetaConfiguration {
    /// <summary>
    /// Represents the meta-information about a database configuration.
    /// </summary>

    public class MetaDatabaseConfiguration: MetaPluginConfiguration {        
        class DatabasePluginParameterFactory: DefaultPluginParameterFactory {
            public override IUserDefinedPluginParameter CreateUserDefinedPluginParameter(string propName, MethodInfo getter, MethodInfo setter, bool encrypt, bool persist, object configuration, 
                    MethodInfo visibilityChecker, IUserDefinedPluginConfiguration userConfigurationParameter) {

                return new UserDefinedDatabaseParameter(base.CreateUserDefinedPluginParameter(propName, getter, setter, encrypt, persist, configuration, visibilityChecker, userConfigurationParameter),
                    (UserDefinedConfigurationParameter) userConfigurationParameter);
            }

            public override IUserChosenOptionPluginParameter CreateUserChosenOptionPluginParameter(string propName, MethodInfo getter, MethodInfo setter, bool encrypt, bool persist, object configuration, 
                    MethodInfo visibilityChecker, IUserDefinedPluginConfiguration userConfigurationParameter, IDictionary<string, KeyValuePair<string, string>> helpInfo) {

                return new UserChosenOptionDatabaseParameter(
                    base.CreateUserChosenOptionPluginParameter(propName, getter, setter, encrypt, persist, configuration, visibilityChecker, userConfigurationParameter, helpInfo), 
                    (UserDefinedConfigurationParameter) userConfigurationParameter);
            }
        }
        
        protected override IPluginParameterFactory PluginParameterFactory => new DatabasePluginParameterFactory();
        
        public MetaDatabaseConfiguration(object configuration): base(configuration) {}

        /// <summary>
        /// Returns a parameter with the given name.
        /// </summary>
        ///
        /// <param name="name">The parameter's name.</param>
        ///
        /// <returns>A parameter with the given name.</returns>
        public override IPluginParameter GetParameter(string name) {
            return base.GetParameter(name) ??
                   AdvancedModeParameters().Cast<IPluginParameter>().FirstOrDefault(p => p.Name.Equals(name));
        }

        private IEnumerable<IUserDefinedDatabaseParameter> AdvancedModeParameters() {

            var integrationConf = Configuration as IIntegrationDatabaseConfiguration;
            if (integrationConf == null) yield break;
            yield return new AdvancedConnectionStringParam(integrationConf);
            yield return new ConnStringTemplateParam(integrationConf);
        }

        /// <summary>
        /// Gets a list of visible parameters.
        /// </summary>
        ///
        /// <value>The list of visible parameters.</value>
        public override IEnumerable<IUserDefinedPluginParameter> VisibleParameters => VisibleDatabaseParameters;

        public IEnumerable<IUserDefinedDatabaseParameter> VisibleDatabaseParameters {
            get {
                IEnumerable<IUserDefinedDatabaseParameter> result = base.VisibleParameters.Cast<IUserDefinedDatabaseParameter>();

                if (Configuration is IIntegrationDatabaseConfiguration && ((IIntegrationDatabaseConfiguration) Configuration).AdvancedConfiguration.IsSet()) {
                    result = result.Where(p => p.Region == ParameterRegion.UserSpecific).Union(AdvancedModeParameters().Where(p => p.Visible));
                }

                return result;
            }
        }
        
        public override IEnumerable<IPluginParameter> AllParameters {
            get {
                return AdvancedModeParameters().Cast<IPluginParameter>().Union(base.AllParameters);
            }
        }
    }
}
