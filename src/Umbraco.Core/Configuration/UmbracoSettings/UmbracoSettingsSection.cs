﻿using System;
using System.Configuration;

namespace Umbraco.Core.Configuration.UmbracoSettings
{
    public class UmbracoSettingsSection : ConfigurationSection, IUmbracoSettings
    {

        ///// <summary>
        ///// Get the current settings
        ///// </summary>
        //public static UmbracoSettings Current
        //{
        //    get { return (UmbracoSettings) ConfigurationManager.GetSection("umbracoConfiguration/settings"); }
            
        //}

        [ConfigurationProperty("content")]
        internal ContentElement Content
        {
            get { return (ContentElement)this["content"]; }
        }

        [ConfigurationProperty("security")]
        internal SecurityElement Security
        {
            get { return (SecurityElement)this["security"]; }
        }

        [ConfigurationProperty("requestHandler")]
        internal RequestHandlerElement RequestHandler
        {
            get { return (RequestHandlerElement)this["requestHandler"]; }
        }

        [ConfigurationProperty("templates")]
        internal TemplatesElement Templates
        {
            get { return (TemplatesElement)this["templates"]; }
        }

        [ConfigurationProperty("developer")]
        internal DeveloperElement Developer
        {
            get { return (DeveloperElement)this["developer"]; }
        }

        [ConfigurationProperty("viewstateMoverModule")]
        internal ViewstateMoverModuleElement ViewstateMoverModule
        {
            get { return (ViewstateMoverModuleElement)this["viewstateMoverModule"]; }
        }

        [ConfigurationProperty("logging")]
        internal LoggingElement Logging
        {
            get { return (LoggingElement)this["logging"]; }
        }

        [ConfigurationProperty("scheduledTasks")]
        internal ScheduledTasksElement ScheduledTasks
        {
            get { return (ScheduledTasksElement)this["scheduledTasks"]; }
        }

        [ConfigurationProperty("distributedCall")]
        internal DistributedCallElement DistributedCall
        {
            get { return (DistributedCallElement)this["distributedCall"]; }
        }

        private RepositoriesElement _defaultRepositories;

        [ConfigurationProperty("repositories")]
        internal RepositoriesElement PackageRepositories
        {
            get
            {

                if (_defaultRepositories != null)
                {
                    return _defaultRepositories;
                }

                //here we need to check if this element is defined, if it is not then we'll setup the defaults
                var prop = Properties["repositories"];
                var repos = this[prop] as ConfigurationElement;
                if (repos != null && repos.ElementInformation.IsPresent == false)
                {
                    var collection = new RepositoriesCollection
                        {
                            new RepositoryElement() {Name = "Umbraco package Repository", Id = new Guid("65194810-1f85-11dd-bd0b-0800200c9a66")}
                        };

                    
                    _defaultRepositories = new RepositoriesElement()
                        {
                            Repositories = collection
                        };

                    return _defaultRepositories;
                }

                return (RepositoriesElement)base["repositories"];
            }
        }

        [ConfigurationProperty("providers")]
        internal ProvidersElement Providers
        {
            get { return (ProvidersElement)this["providers"]; }
        }

        [ConfigurationProperty("help")]
        internal HelpElement Help
        {
            get { return (HelpElement)this["help"]; }
        }

        [ConfigurationProperty("web.routing")]
        internal WebRoutingElement WebRouting
        {
            get { return (WebRoutingElement)this["web.routing"]; }
        }

        [ConfigurationProperty("scripting")]
        internal ScriptingElement Scripting
        {
            get { return (ScriptingElement)this["scripting"]; }
        }
        
        IContentSection IUmbracoSettings.Content
        {
            get { return Content; }
        }

        ISecurity IUmbracoSettings.Security
        {
            get { return Security; }
        }

        IRequestHandler IUmbracoSettings.RequestHandler
        {
            get { return RequestHandler; }
        }

        ITemplates IUmbracoSettings.Templates
        {
            get { return Templates; }
        }

        IDeveloper IUmbracoSettings.Developer
        {
            get { return Developer; }
        }

        IViewstateMoverModule IUmbracoSettings.ViewstateMoverModule
        {
            get { return ViewstateMoverModule; }
        }

        ILogging IUmbracoSettings.Logging
        {
            get { return Logging; }
        }

        IScheduledTasks IUmbracoSettings.ScheduledTasks
        {
            get { return ScheduledTasks; }
        }

        IDistributedCall IUmbracoSettings.DistributedCall
        {
            get { return DistributedCall; }
        }

        IRepositories IUmbracoSettings.PackageRepositories
        {
            get { return PackageRepositories; }
        }

        IProviders IUmbracoSettings.Providers
        {
            get { return Providers; }
        }

        IHelp IUmbracoSettings.Help
        {
            get { return Help; }
        }

        IWebRouting IUmbracoSettings.WebRouting
        {
            get { return WebRouting; }
        }

        IScripting IUmbracoSettings.Scripting
        {
            get { return Scripting; }
        }
    }
}