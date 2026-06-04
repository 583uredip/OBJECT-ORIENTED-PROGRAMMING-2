// 
// Updates an ApplicationHost.config file in the current user's
// profile directory from IIS 7.5 Express to IIS 10.0 Express.
// 

var strCommitPath = "MACHINE/WEBROOT/APPHOST";
var strFirstItem  = "##FIRST#ITEM##";
var strLastItem   = "##LAST#ITEM##";

// ------------------------------------------------------------
// Check for an existing ApplicationHost.config file.
// ------------------------------------------------------------

var objFSO = new ActiveXObject("scripting.filesystemobject");
var strUserConfig = GetUserDirectory() + "\\config\\ApplicationHost.config";
if (objFSO.FileExists(strUserConfig))
{
	// Backup existing an existing ApplicationHost.config file.
	try
	{
		var dtmDate = new Date();
		var strDate = dtmDate.getYear().toString() + 
			PadNumber(dtmDate.getMonth()+1) + 
			PadNumber(dtmDate.getDate()) + 
			PadNumber(dtmDate.getHours()) + 
			PadNumber(dtmDate.getMinutes()) + 
			PadNumber(dtmDate.getSeconds());
	 	objFSO.CopyFile(strUserConfig,strUserConfig + "." + strDate + ".bak",true);
	}
	catch(e)
	{
		ErrorMessage(e,"An error occurred trying to back up your ApplicationHost.config file");
	}
}
else
{
	// Exit if no applicationhost.config file exists. (This is not an error condition.)
	WScript.Echo("No ApplicationHost.config file exists in the current user's profile directory - exiting.");
	WScript.Quit(0);
}

// ------------------------------------------------------------
// Retrieve the necessary objects for the rest of the script.
// ------------------------------------------------------------

WScript.Echo("Migrating your ApplicationHost.config file...\n");
var objAdminManager      = GetAdminManager();
var objConfigManager     = objAdminManager.ConfigManager;
var objAppHostConfig     = objConfigManager.GetConfigFile(strCommitPath);
var objRootSectionGroup  = objAppHostConfig.RootSectionGroup;

// ------------------------------------------------------------
WScript.Echo("...adding new section groups...");
// ------------------------------------------------------------

var objSystemWebServer = FindSectionGroup(objRootSectionGroup,"system.webServer");
AddSection(objSystemWebServer,"applicationInitialization","Allow","MachineToApplication","");
AddSection(objSystemWebServer,"webSocket","Deny","","");
var objSecurity = FindSectionGroup(objSystemWebServer,"security");
AddSection(objSecurity,"dynamicIpSecurity","Deny","","");

// ------------------------------------------------------------
WScript.Echo("...adding new global modules...");
// ------------------------------------------------------------

var objGlobalModules = objAdminManager.GetAdminSection("system.webServer/globalModules", strCommitPath);
AddGlobalModule(objGlobalModules.Collection,"DynamicIpRestrictionModule","%IIS_BIN%\\diprestr.dll","","IpRestrictionModule");
AddGlobalModule(objGlobalModules.Collection,"ApplicationInitializationModule","%IIS_BIN%\\warmup.dll","","ConfigurationValidationModule");
AddGlobalModule(objGlobalModules.Collection,"WebSocketModule","%IIS_BIN%\\iiswsock.dll","","ApplicationInitializationModule");
AddGlobalModule(objGlobalModules.Collection,"ManagedEngine64","%windir%\\Microsoft.NET\\Framework64\\v2.0.50727\\webengine.dll","integratedMode,runtimeVersionv2.0,bitness64","ManagedEngine");
AddGlobalModule(objGlobalModules.Collection,"ManagedEngineV4.0_64bit","%windir%\\Microsoft.NET\\Framework64\\v4.0.30319\\webengine4.dll","integratedMode,runtimeVersionv4.0,bitness64","ManagedEngineV4.0_32bit");

// ------------------------------------------------------------
WScript.Echo("...adding new ISAPI filters...");
// ------------------------------------------------------------

var objIsapiFilters = objAdminManager.GetAdminSection("system.webServer/isapiFilters", strCommitPath);
AddIsapiFilter(objIsapiFilters.Collection,"ASP.Net_2.0.50727-64","%windir%\\Microsoft.NET\\Framework64\\v2.0.50727\\aspnet_filter.dll","","true","bitness64,runtimeVersionv2.0",strFirstItem);
AddIsapiFilter(objIsapiFilters.Collection,"ASP.Net_4.0_64bit","%windir%\\Microsoft.NET\\Framework64\\v4.0.30319\\aspnet_filter.dll","","true","bitness64,runtimeVersionv4.0","ASP.Net_4.0_32bit");

// ------------------------------------------------------------
WScript.Echo("...adding new ISAPI/CGI restrictions...");
// ------------------------------------------------------------

var objIsapiCgiRestrictions = objAdminManager.GetAdminSection("system.webServer/security/isapiCgiRestriction", strCommitPath);
AddIsapiCgiRestriction(objIsapiCgiRestrictions.Collection,"%windir%\\Microsoft.NET\\Framework64\\v4.0.30319\\webengine4.dll","true","ASP.NET_v4.0","ASP.NET_v4.0",strFirstItem);
AddIsapiCgiRestriction(objIsapiCgiRestrictions.Collection,"%windir%\\Microsoft.NET\\Framework64\\v2.0.50727\\aspnet_isapi.dll","true","ASP.NET v2.0.50727","ASP.NET v2.0.50727",strLastItem);
AddIsapiCgiRestriction(objIsapiCgiRestrictions.Collection,"%windir%\\Microsoft.NET\\Framework\\v2.0.50727\\aspnet_isapi.dll","true","ASP.NET v2.0.50727","ASP.NET v2.0.50727",strLastItem);

// ------------------------------------------------------------
WScript.Echo("...adding new MIME maps...");
// ------------------------------------------------------------

var objStaticContent = objAdminManager.GetAdminSection("system.webServer/staticContent", strCommitPath);
AddMimeMap(objStaticContent.Collection,".3g2","video/3gpp2");
AddMimeMap(objStaticContent.Collection,".3gp2","video/3gpp2");
AddMimeMap(objStaticContent.Collection,".3gp","video/3gpp");
AddMimeMap(objStaticContent.Collection,".3gpp","video/3gpp");
AddMimeMap(objStaticContent.Collection,".aac","audio/aac");
AddMimeMap(objStaticContent.Collection,".adt","audio/vnd.dlna.adts");
AddMimeMap(objStaticContent.Collection,".adts","audio/vnd.dlna.adts");
AddMimeMap(objStaticContent.Collection,".cab","application/vnd.ms-cab-compressed");
AddMimeMap(objStaticContent.Collection,".dvr-ms","video/x-ms-dvr");
AddMimeMap(objStaticContent.Collection,".eot","application/vnd.ms-fontobject");
AddMimeMap(objStaticContent.Collection,".js","application/javascript");
AddMimeMap(objStaticContent.Collection,".m2ts","video/vnd.dlna.mpeg-tts");
AddMimeMap(objStaticContent.Collection,".m4a","audio/mp4");
AddMimeMap(objStaticContent.Collection,".m4v","video/mp4");
AddMimeMap(objStaticContent.Collection,".mp4","video/mp4");
AddMimeMap(objStaticContent.Collection,".mp4v","video/mp4");
AddMimeMap(objStaticContent.Collection,".oga","audio/ogg");
AddMimeMap(objStaticContent.Collection,".ogg","video/ogg");
AddMimeMap(objStaticContent.Collection,".ogv","video/ogg");
AddMimeMap(objStaticContent.Collection,".ogx","application/ogg");
AddMimeMap(objStaticContent.Collection,".otf","font/otf");
AddMimeMap(objStaticContent.Collection,".spx","audio/ogg");
AddMimeMap(objStaticContent.Collection,".svg","image/svg+xml");
AddMimeMap(objStaticContent.Collection,".svgz","image/svg+xml");
AddMimeMap(objStaticContent.Collection,".ts","video/vnd.dlna.mpeg-tts");
AddMimeMap(objStaticContent.Collection,".tts","video/vnd.dlna.mpeg-tts");
AddMimeMap(objStaticContent.Collection,".webm","video/webm");
AddMimeMap(objStaticContent.Collection,".woff","font/x-woff");
AddMimeMap(objStaticContent.Collection,".wtv","video/x-ms-wtv");
AddMimeMap(objStaticContent.Collection,".xht","application/xhtml+xml");
AddMimeMap(objStaticContent.Collection,".xhtml","application/xhtml+xml");

// ------------------------------------------------------------
WScript.Echo("...adding new trace provider definitions...");
// ------------------------------------------------------------

var objTraceProviderDefinitions = objAdminManager.GetAdminSection("system.webServer/tracing/traceProviderDefinitions", strCommitPath);
AddTraceProviderDefinitions(objTraceProviderDefinitions.Collection,"WWW Server","WebSocket","16384");

// ------------------------------------------------------------
WScript.Echo("...updating trace areas...");
// ------------------------------------------------------------

var objTraceAreas = objAdminManager.GetAdminSection("system.webServer/tracing/traceFailedRequests", strCommitPath);
UpdateTraceAreas(objTraceAreas.Collection,"WWW Server","Authentication,Security,Filter,StaticFile,CGI,Compression,Cache,RequestNotifications,Module,Rewrite,WebSocket","Verbose");

// ------------------------------------------------------------
WScript.Echo("...updating WebDAV global settings...");
// ------------------------------------------------------------

var objWebDavGlobalSettings = objAdminManager.GetAdminSection("system.webServer/webdav/globalSettings", strCommitPath);
UpdateWebDavGlobalSettings(objWebDavGlobalSettings.ChildElements.Item("propertyStores").Collection,"webdav_simple_prop","%IIS_BIN%\\webdav_simple_prop.dll","%IIS_BIN%\\webdav_simple_prop.dll");
UpdateWebDavGlobalSettings(objWebDavGlobalSettings.ChildElements.Item("lockStores").Collection,"webdav_simple_lock","%IIS_BIN%\\webdav_simple_lock.dll","%IIS_BIN%\\webdav_simple_lock.dll");

// ------------------------------------------------------------
WScript.Echo("...adding new modules...");
// ------------------------------------------------------------

var objModules = objAdminManager.GetAdminSection("system.webServer/modules", strCommitPath);
AddModule(objModules.Collection,"WebMatrixSupportModule","true","","","IISCertificateMappingAuthenticationModule");
AddModule(objModules.Collection,"DynamicIpRestrictionModule","true","","","IpRestrictionModule");
AddModule(objModules.Collection,"ApplicationInitializationModule","true","","","UrlMappingsModule");
AddModule(objModules.Collection,"WebSocketModule","true","","","ApplicationInitializationModule");
AddModule(objModules.Collection,"ConfigurationValidationModule","true","","","ServiceModel-4.0");

// ------------------------------------------------------------
WScript.Echo("...adding new handlers...");
// ------------------------------------------------------------

var objHandlers = objAdminManager.GetAdminSection("system.webServer/handlers", strCommitPath);
AddHandler(objHandlers.Collection,"vbhtml-ISAPI-4.0_64bit","*.vbhtml","GET,HEAD,POST,DEBUG","IsapiModule","","%windir%\\Microsoft.NET\\Framework64\\v4.0.30319\\aspnet_isapi.dll","classicMode,runtimeVersionv4.0,bitness64","0","",strFirstItem);
AddHandler(objHandlers.Collection,"vbhtm-ISAPI-4.0_64bit","*.vbhtm","GET,HEAD,POST,DEBUG","IsapiModule","","%windir%\\Microsoft.NET\\Framework64\\v4.0.30319\\aspnet_isapi.dll","classicMode,runtimeVersionv4.0,bitness64","0","",strFirstItem);
AddHandler(objHandlers.Collection,"cshtml-ISAPI-4.0_64bit","*.cshtml","GET,HEAD,POST,DEBUG","IsapiModule","","%windir%\\Microsoft.NET\\Framework64\\v4.0.30319\\aspnet_isapi.dll","classicMode,runtimeVersionv4.0,bitness64","0","",strFirstItem);
AddHandler(objHandlers.Collection,"cshtm-ISAPI-4.0_64bit","*.cshtm","GET,HEAD,POST,DEBUG","IsapiModule","","%windir%\\Microsoft.NET\\Framework64\\v4.0.30319\\aspnet_isapi.dll","classicMode,runtimeVersionv4.0,bitness64","0","",strFirstItem);
AddHandler(objHandlers.Collection,"aspq-ISAPI-4.0_64bit","*.aspq","*","IsapiModule","","%windir%\\Microsoft.NET\\Framework64\\v4.0.30319\\aspnet_isapi.dll","classicMode,runtimeVersionv4.0,bitness64","0","",strFirstItem);
AddHandler(objHandlers.Collection,"xamlx-ISAPI-4.0_64bit","*.xamlx","GET,HEAD,POST,DEBUG","IsapiModule","","%windir%\\Microsoft.NET\\Framework64\\v4.0.30319\\aspnet_isapi.dll","classicMode,runtimeVersionv4.0,bitness64","","",strFirstItem);
AddHandler(objHandlers.Collection,"xoml-ISAPI-4.0_64bit","*.xoml","*","IsapiModule","","%windir%\\Microsoft.NET\\Framework64\\v4.0.30319\\aspnet_isapi.dll","classicMode,runtimeVersionv4.0,bitness64","","",strFirstItem);
AddHandler(objHandlers.Collection,"rules-ISAPI-4.0_64bit","*.rules","*","IsapiModule","","%windir%\\Microsoft.NET\\Framework64\\v4.0.30319\\aspnet_isapi.dll","classicMode,runtimeVersionv4.0,bitness64","","",strFirstItem);
AddHandler(objHandlers.Collection,"svc-ISAPI-4.0_64bit","*.svc","*","IsapiModule","","%windir%\\Microsoft.NET\\Framework64\\v4.0.30319\\aspnet_isapi.dll","classicMode,runtimeVersionv4.0,bitness64","","",strFirstItem);
AddHandler(objHandlers.Collection,"HttpRemotingHandlerFactory-soap-ISAPI-4.0_64bit","*.soap","GET,HEAD,POST,DEBUG","IsapiModule","","%windir%\\Microsoft.NET\\Framework64\\v4.0.30319\\aspnet_isapi.dll","classicMode,runtimeVersionv4.0,bitness64","0","",strFirstItem);
AddHandler(objHandlers.Collection,"HttpRemotingHandlerFactory-rem-ISAPI-4.0_64bit","*.rem","GET,HEAD,POST,DEBUG","IsapiModule","","%windir%\\Microsoft.NET\\Framework64\\v4.0.30319\\aspnet_isapi.dll","classicMode,runtimeVersionv4.0,bitness64","0","",strFirstItem);
AddHandler(objHandlers.Collection,"WebServiceHandlerFactory-ISAPI-4.0_64bit","*.asmx","GET,HEAD,POST,DEBUG","IsapiModule","","%windir%\\Microsoft.NET\\Framework64\\v4.0.30319\\aspnet_isapi.dll","classicMode,runtimeVersionv4.0,bitness64","0","",strFirstItem);
AddHandler(objHandlers.Collection,"SimpleHandlerFactory-ISAPI-4.0_64bit","*.ashx","GET,HEAD,POST,DEBUG","IsapiModule","","%windir%\\Microsoft.NET\\Framework64\\v4.0.30319\\aspnet_isapi.dll","classicMode,runtimeVersionv4.0,bitness64","0","",strFirstItem);
AddHandler(objHandlers.Collection,"PageHandlerFactory-ISAPI-4.0_64bit","*.aspx","GET,HEAD,POST,DEBUG","IsapiModule","","%windir%\\Microsoft.NET\\Framework64\\v4.0.30319\\aspnet_isapi.dll","classicMode,runtimeVersionv4.0,bitness64","0","",strFirstItem);
AddHandler(objHandlers.Collection,"AXD-ISAPI-4.0_64bit","*.axd","GET,HEAD,POST,DEBUG","IsapiModule","","%windir%\\Microsoft.NET\\Framework64\\v4.0.30319\\aspnet_isapi.dll","classicMode,runtimeVersionv4.0,bitness64","0","",strFirstItem);
AddHandler(objHandlers.Collection,"svc-ISAPI-4.0_32bit","*.svc","*","IsapiModule","","%windir%\\Microsoft.NET\\Framework\\v4.0.30319\\aspnet_isapi.dll","classicMode,runtimeVersionv4.0,bitness32","","","HttpRemotingHandlerFactory-soap-ISAPI-4.0_32bit");
AddHandler(objHandlers.Collection,"rules-ISAPI-4.0_32bit","*.rules","*","IsapiModule","","%windir%\\Microsoft.NET\\Framework\\v4.0.30319\\aspnet_isapi.dll","classicMode,runtimeVersionv4.0,bitness32","","","svc-ISAPI-4.0_32bit");
AddHandler(objHandlers.Collection,"xoml-ISAPI-4.0_32bit","*.xoml","*","IsapiModule","","%windir%\\Microsoft.NET\\Framework\\v4.0.30319\\aspnet_isapi.dll","classicMode,runtimeVersionv4.0,bitness32","","","rules-ISAPI-4.0_32bit");
AddHandler(objHandlers.Collection,"xamlx-ISAPI-4.0_32bit","*.xamlx","GET,HEAD,POST,DEBUG","IsapiModule","","%windir%\\Microsoft.NET\\Framework\\v4.0.30319\\aspnet_isapi.dll","classicMode,runtimeVersionv4.0,bitness32","","","xoml-ISAPI-4.0_32bit");
AddHandler(objHandlers.Collection,"aspq-ISAPI-4.0_32bit","*.aspq","*","IsapiModule","","%windir%\\Microsoft.NET\\Framework\\v4.0.30319\\aspnet_isapi.dll","classicMode,runtimeVersionv4.0,bitness32","0","","xamlx-ISAPI-4.0_32bit");
AddHandler(objHandlers.Collection,"ScriptResourceIntegrated-4.0","*ScriptResource.axd","GET,HEAD","","System.Web.Handlers.ScriptResourceHandler, System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35","","integratedMode,runtimeVersionv4.0","","","ScriptHandlerFactoryAppServices-Integrated-4.0");
AddHandler(objHandlers.Collection,"TraceHandler-Integrated","trace.axd","GET,HEAD,POST,DEBUG","","System.Web.Handlers.TraceHandler","","integratedMode,runtimeVersionv2.0","","","ISAPI-dll");
AddHandler(objHandlers.Collection,"WebAdminHandler-Integrated","WebAdmin.axd","GET,DEBUG","","System.Web.Handlers.WebAdminHandler","","integratedMode,runtimeVersionv2.0","","","TraceHandler-Integrated");
AddHandler(objHandlers.Collection,"AssemblyResourceLoader-Integrated","WebResource.axd","GET,DEBUG","","System.Web.Handlers.AssemblyResourceLoader","","integratedMode,runtimeVersionv2.0","","","WebAdminHandler-Integrated");
AddHandler(objHandlers.Collection,"PageHandlerFactory-Integrated","*.aspx","GET,HEAD,POST,DEBUG","","System.Web.UI.PageHandlerFactory","","integratedMode,runtimeVersionv2.0","","","AssemblyResourceLoader-Integrated");
AddHandler(objHandlers.Collection,"SimpleHandlerFactory-Integrated","*.ashx","GET,HEAD,POST,DEBUG","","System.Web.UI.SimpleHandlerFactory","","integratedMode,runtimeVersionv2.0","","","PageHandlerFactory-Integrated");
AddHandler(objHandlers.Collection,"svc-ISAPI-2.0-64","*.svc","*","IsapiModule","","%windir%\\Microsoft.NET\\Framework64\\v2.0.50727\\aspnet_isapi.dll","classicMode,runtimeVersionv2.0,bitness64","","","HttpRemotingHandlerFactory-soap-ISAPI-2.0");
AddHandler(objHandlers.Collection,"AXD-ISAPI-2.0-64","*.axd","GET,HEAD,POST,DEBUG","IsapiModule","","%windir%\\Microsoft.NET\\Framework64\\v2.0.50727\\aspnet_isapi.dll","classicMode,runtimeVersionv2.0,bitness64","0","","svc-ISAPI-2.0-64");
AddHandler(objHandlers.Collection,"PageHandlerFactory-ISAPI-2.0-64","*.aspx","GET,HEAD,POST,DEBUG","IsapiModule","","%windir%\\Microsoft.NET\\Framework64\\v2.0.50727\\aspnet_isapi.dll","classicMode,runtimeVersionv2.0,bitness64","0","","AXD-ISAPI-2.0-64");
AddHandler(objHandlers.Collection,"SimpleHandlerFactory-ISAPI-2.0-64","*.ashx","GET,HEAD,POST,DEBUG","IsapiModule","","%windir%\\Microsoft.NET\\Framework64\\v2.0.50727\\aspnet_isapi.dll","classicMode,runtimeVersionv2.0,bitness64","0","","PageHandlerFactory-ISAPI-2.0-64");
AddHandler(objHandlers.Collection,"WebServiceHandlerFactory-ISAPI-2.0-64","*.asmx","GET,HEAD,POST,DEBUG","IsapiModule","","%windir%\\Microsoft.NET\\Framework64\\v2.0.50727\\aspnet_isapi.dll","classicMode,runtimeVersionv2.0,bitness64","0","","SimpleHandlerFactory-ISAPI-2.0-64");
AddHandler(objHandlers.Collection,"HttpRemotingHandlerFactory-rem-ISAPI-2.0-64","*.rem","GET,HEAD,POST,DEBUG","IsapiModule","","%windir%\\Microsoft.NET\\Framework64\\v2.0.50727\\aspnet_isapi.dll","classicMode,runtimeVersionv2.0,bitness64","0","","WebServiceHandlerFactory-ISAPI-2.0-64");
AddHandler(objHandlers.Collection,"HttpRemotingHandlerFactory-soap-ISAPI-2.0-64","*.soap","GET,HEAD,POST,DEBUG","IsapiModule","","%windir%\\Microsoft.NET\\Framework64\\v2.0.50727\\aspnet_isapi.dll","classicMode,runtimeVersionv2.0,bitness64","0","","HttpRemotingHandlerFactory-rem-ISAPI-2.0-64");
AddHandler(objHandlers.Collection,"rules-64-ISAPI-2.0","*.rules","*","IsapiModule","","%windir%\\Microsoft.NET\\Framework64\\v2.0.50727\\aspnet_isapi.dll","classicMode,runtimeVersionv2.0,bitness64","","","HttpRemotingHandlerFactory-soap-ISAPI-2.0-64");
AddHandler(objHandlers.Collection,"xoml-64-ISAPI-2.0","*.xoml","*","IsapiModule","","%windir%\\Microsoft.NET\\Framework64\\v2.0.50727\\aspnet_isapi.dll","classicMode,runtimeVersionv2.0,bitness64","","","rules-64-ISAPI-2.0");
AddHandler(objHandlers.Collection,"SSINC-stm","*.stm","GET,HEAD,POST","ServerSideIncludeModule","","","","","File","CGI-exe");
AddHandler(objHandlers.Collection,"SSINC-shtm","*.shtm","GET,HEAD,POST","ServerSideIncludeModule","","","","","File","SSINC-stm");
AddHandler(objHandlers.Collection,"SSINC-shtml","*.shtml","GET,HEAD,POST","ServerSideIncludeModule","","","","","File","SSINC-shtm");
AddHandler(objHandlers.Collection,"ExtensionlessUrlHandler-ISAPI-4.0_64bit","*.","GET,HEAD,POST,DEBUG","IsapiModule","","%windir%\\Microsoft.NET\\Framework64\\v4.0.30319\\aspnet_isapi.dll","classicMode,runtimeVersionv4.0,bitness64","0","","ExtensionlessUrl-ISAPI-4.0_32bit");
AddHandler(objHandlers.Collection,"ExtensionlessUrl-Integrated-4.0","*.","GET,HEAD,POST,DEBUG","","System.Web.Handlers.TransferRequestHandler","","integratedMode,runtimeVersionv4.0","0","","ExtensionlessUrlHandler-ISAPI-4.0_64bit");

// ------------------------------------------------------------
// Commit changes and exit.
// ------------------------------------------------------------

try
{
	objAdminManager.CommitChanges();
}
catch(e)
{
	ErrorMessage(e,"An error occurred trying to commit the changes");
}

WScript.Echo("\nFinished!");
WScript.Quit(0);

// ================================================================================

function AddSection(tmpSectionGroup,tmpSectionName,tmpOverrideModeDefault,tmpAllowDefinition,tmpAllowLocation)
{
	try
	{
		// Retrieve the index within the collection.
		var tmpElementPosition = FindElement2(tmpSectionGroup.sections,tmpSectionName);
		var tmpNewSection = null;
		if (tmpElementPosition == -1)
		{
			tmpNewSection = tmpSectionGroup.Sections.AddSection(tmpSectionName);
		}
		else
		{
			tmpNewSection = tmpSectionGroup.Sections.Item(tmpElementPosition);
		}
		// Add the required attributes.
		tmpNewSection.OverrideModeDefault = tmpOverrideModeDefault;
		tmpNewSection.AllowDefinition = tmpAllowDefinition;
		tmpNewSection.AllowLocation = tmpAllowLocation;
	}
	catch(e)
	{
		ErrorMessage(e,"An error occurred trying to add a section");
	}
}

// ================================================================================

function AddGlobalModule(tmpModuleGroup,tmpModuleName,tmpImage,tmpPreCondition,tmpPreviousModuleName)
{
	try
	{
		// Retrieve the index within the collection.
		var tmpElementPosition = FindElement1(tmpModuleGroup,"add",["name",tmpModuleName]);
		// Delete the item if it already exists.
		if (tmpElementPosition != -1) tmpModuleGroup.DeleteElement(tmpElementPosition);
		// Create a new element
		var tmpNewElement = tmpModuleGroup.CreateNewElement("add");
		// Add the required properties.
		tmpNewElement.Properties.Item("name").Value = tmpModuleName;
		tmpNewElement.Properties.Item("image").Value = tmpImage;
		// Add any optional properties.
		if (tmpPreCondition.length != 0) tmpNewElement.Properties.Item("preCondition").Value = tmpPreCondition;
		// Retrieve the previous index within the collection.
		tmpElementPosition = FindElement3(tmpModuleGroup,tmpPreviousModuleName);
		// Add the new element.
		tmpModuleGroup.AddElement(tmpNewElement, tmpElementPosition + ((tmpElementPosition>0) ? 1 : 0));
	}
	catch(e)
	{
		ErrorMessage(e,"The following error occurred trying to add a global module");
	}
}

// ================================================================================

function AddIsapiFilter(tmpIsapiFilterCollection,tmpName,tmpPath,tmpEnabled,tmpEnableCache,tmpPreCondition,tmpPreviousFilterName)
{
	try
	{
		// Retrieve the index within the collection.
		var tmpElementPosition = FindElement1(tmpIsapiFilterCollection,"filter",["name",tmpName]);
		// Delete the item if it already exists.
		if (tmpElementPosition != -1) tmpIsapiFilterCollection.DeleteElement(tmpElementPosition);
		// Create a new element
		var tmpNewElement = tmpIsapiFilterCollection.CreateNewElement("filter");
		// Add the required properties.
		tmpNewElement.Properties.Item("name").Value = tmpName;
		tmpNewElement.Properties.Item("path").Value = tmpPath;
		// Add any optional properties.
		if (tmpEnabled.length != 0) tmpNewElement.Properties.Item("enabled").Value = tmpEnabled;
		if (tmpEnableCache.length != 0) tmpNewElement.Properties.Item("enableCache").Value = tmpEnableCache;
		if (tmpPreCondition.length != 0) tmpNewElement.Properties.Item("preCondition").Value = tmpPreCondition;
		// Retrieve the previous index within the collection.
		tmpElementPosition = FindElement3(tmpIsapiFilterCollection,tmpPreviousFilterName);
		// Add the new element.
		tmpIsapiFilterCollection.AddElement(tmpNewElement, tmpElementPosition + ((tmpElementPosition>0) ? 1 : 0));
	}
	catch(e)
	{
		ErrorMessage(e,"The following error occurred trying to add an ISAPI filter");
	}
}

// ================================================================================

function AddIsapiCgiRestriction(tmpIsapiCgiRestrictionCollection,tmpPath,tmpAllowed,tmpGroupId,tmpDescription,tmpPrevious)
{
	try
	{
		// Retrieve the index within the collection.
		var tmpElementPosition = FindElement1(tmpIsapiCgiRestrictionCollection,"add",["path",tmpPath]);
		// Delete the item if it already exists.
		if (tmpElementPosition != -1) tmpIsapiCgiRestrictionCollection.DeleteElement(tmpElementPosition);
		// Create a new element
		var tmpNewElement = tmpIsapiCgiRestrictionCollection.CreateNewElement("add");
		// Add the required properties.
		tmpNewElement.Properties.Item("path").Value = tmpPath;
		tmpNewElement.Properties.Item("allowed").Value = tmpAllowed;
		// Add any optional properties.
		if (tmpGroupId.length != 0) tmpNewElement.Properties.Item("groupId").Value = tmpGroupId;
		if (tmpDescription.length != 0) tmpNewElement.Properties.Item("description").Value = tmpDescription;
		// Retrieve the previous index within the collection.
		tmpElementPosition = FindElement3(tmpIsapiCgiRestrictionCollection,tmpPrevious);
		// Add the new element.
		tmpIsapiCgiRestrictionCollection.AddElement(tmpNewElement, tmpElementPosition + ((tmpElementPosition>0) ? 1 : 0));
	}
	catch(e)
	{
		ErrorMessage(e,"The following error occurred trying to add an ISAPI/CGI restriction");
	}
}

// ================================================================================

function AddMimeMap(tmpStaticContentCollection,tmpFileExtension,tmpMimeType)
{
	try
	{
		// Retrieve the index within the collection.
		var tmpElementPosition = FindElement1(tmpStaticContentCollection,"mimeMap",["fileExtension",tmpFileExtension]);
		// Delete the item if it already exists.
		if (tmpElementPosition != -1) tmpStaticContentCollection.DeleteElement(tmpElementPosition);
		// Create a new element
		var tmpNewElement = tmpStaticContentCollection.CreateNewElement("mimeMap");
		// Add the required properties.
		tmpNewElement.Properties.Item("fileExtension").Value = tmpFileExtension;
		tmpNewElement.Properties.Item("mimeType").Value = tmpMimeType;
		// Add the new element.
		tmpStaticContentCollection.AddElement(tmpNewElement, -1);
	}
	catch(e)
	{
		ErrorMessage(e,"The following error occurred trying to add a MIME map");
	}
}

// ================================================================================

function AddTraceProviderDefinitions(tmpTraceProviderDefinitionCollection,tmpParent,tmpName,tmpValue)
{
	try
	{
		// Retrieve the index within the collection.
		var tmpElementPosition1 = FindElement1(tmpTraceProviderDefinitionCollection,"add",["name",tmpParent]);
		if (tmpElementPosition1 != -1)
		{
			var objWwwServerDefinitions = tmpTraceProviderDefinitionCollection.Item(tmpElementPosition1).ChildElements.Item(0).Collection;
			// Retrieve the index within the collection.
			var tmpElementPosition2 = FindElement1(objWwwServerDefinitions,"add",["name",tmpName]);
			// Delete the item if it already exists.
			if (tmpElementPosition2 != -1) objWwwServerDefinitions.DeleteElement(tmpElementPosition2);
			// Create a new element.
			var tmpNewElement = objWwwServerDefinitions.CreateNewElement("add");
			// Add the required properties.
			tmpNewElement.Properties.Item("name").Value = tmpName;
			tmpNewElement.Properties.Item("value").Value = tmpValue;
			// Add the new element.
			objWwwServerDefinitions.AddElement(tmpNewElement, -1);
		}
	}
	catch(e)
	{
		ErrorMessage(e,"The following error occurred trying to add a trace provider definition");
	}
}

// ================================================================================

function UpdateTraceAreas(tmpTraceAreasCollection,tmpProvider,tmpAreas,tmpVerbosity)
{
	try
	{
		// Retrieve the index within the collection.
		var objTraceAreas = tmpTraceAreasCollection.Item(0).ChildElements.Item(0).Collection;
		// Retrieve the index within the collection.
		var tmpElementPosition = FindElement1(objTraceAreas,"add",["provider",tmpProvider]);
		// Delete the item if it already exists.
		if (tmpElementPosition != -1) objTraceAreas.DeleteElement(tmpElementPosition);
		// Create a new element.
		var tmpNewElement = objTraceAreas.CreateNewElement("add");
		// Add the required properties.
		tmpNewElement.Properties.Item("provider").Value = tmpProvider;
		tmpNewElement.Properties.Item("areas").Value = tmpAreas;
		tmpNewElement.Properties.Item("verbosity").Value = tmpVerbosity;
		// Add the new element.
		objTraceAreas.AddElement(tmpNewElement, -1);
	}
	catch(e)
	{
		ErrorMessage(e,"The following error occurred trying to update the trace areas");
	}
}

// ================================================================================

function UpdateWebDavGlobalSettings(tmpWebDavStore,tmpName,tmpImage,tmpImage32)
{
	try
	{
		// Retrieve the index within the collection.
		var tmpElementPosition = FindElement1(tmpWebDavStore,"add",["name",tmpName]);
		// Delete the item if it already exists.
		if (tmpElementPosition != -1) tmpWebDavStore.DeleteElement(tmpElementPosition);
		// Create a new element.
		var tmpNewElement = tmpWebDavStore.CreateNewElement("add")
		// Add the required properties.
		tmpNewElement.Properties.Item("name").Value = tmpName;
		tmpNewElement.Properties.Item("image").Value = tmpImage;
		tmpNewElement.Properties.Item("image32").Value = tmpImage32;
		// Add the new element.
		tmpWebDavStore.AddElement(tmpNewElement, -1);
	}
	catch(e)
	{
		ErrorMessage(e,"The following error occurred trying to update the WebDAV settings");
	}
}

// ================================================================================

function AddModule(tmpModuleGroup,tmpModuleName,tmpLockItem,tmpType,tmpPreCondition,tmpPreviousModuleName)
{
	try
	{
		// Retrieve the index within the collection.
		var tmpElementPosition = FindElement1(tmpModuleGroup,"add",["name",tmpModuleName]);
		// Delete the item if it already exists.
		if (tmpElementPosition != -1) tmpModuleGroup.DeleteElement(tmpElementPosition);
		// Create a new element.
		var tmpNewElement = tmpModuleGroup.CreateNewElement("add");
		// Add the required properties.
		tmpNewElement.Properties.Item("name").Value = tmpModuleName;
		// Add any optional properties.
		if (tmpLockItem.length != 0) tmpNewElement.SetMetadata("lockItem", (tmpLockItem.toLowerCase() == "true") ? true : false );
		if (tmpType.length != 0) tmpNewElement.Properties.Item("type").Value = tmpType;
		if (tmpPreCondition.length != 0) tmpNewElement.Properties.Item("preCondition").Value = tmpPreCondition;
		// Retrieve the previous index within the collection.
		tmpElementPosition = FindElement3(tmpModuleGroup,tmpPreviousModuleName);
		// Add the new element.
		tmpModuleGroup.AddElement(tmpNewElement, tmpElementPosition + ((tmpElementPosition>0) ? 1 : 0));
	}
	catch(e)
	{
		ErrorMessage(e,"The following error occurred trying to add a module");
	}
}

// ================================================================================

function AddHandler(tmpHandlerCollection,tmpName,tmpPath,tmpVerb,tmpModules,tmpType,tmpScriptProcessor,tmpPreCondition,tmpPesponseBufferLimit,tmpResourceType,tmpPrevious)
{
	try
	{
		// Retrieve the index within the collection.
		var tmpElementPosition = FindElement1(tmpHandlerCollection,"add",["name",tmpName]);
		// Delete the item if it already exists.
		if (tmpElementPosition != -1) tmpHandlerCollection.DeleteElement(tmpElementPosition);
		// Create a new element.
		var tmpNewElement = tmpHandlerCollection.CreateNewElement("add");
		// Add the required properties.
		tmpNewElement.Properties.Item("name").Value = tmpName;
		tmpNewElement.Properties.Item("verb").Value = tmpVerb;
		tmpNewElement.Properties.Item("path").Value = tmpPath;
		// Add any optional properties.
		if (tmpType.length != 0) tmpNewElement.Properties.Item("type").Value = tmpType;
		if (tmpModules.length != 0) tmpNewElement.Properties.Item("modules").Value = tmpModules;
		if (tmpScriptProcessor.length != 0) tmpNewElement.Properties.Item("scriptProcessor").Value = tmpScriptProcessor;
		if (tmpPreCondition.length != 0) tmpNewElement.Properties.Item("preCondition").Value = tmpPreCondition;
		if (tmpPesponseBufferLimit.length != 0) tmpNewElement.Properties.Item("responseBufferLimit").Value = tmpPesponseBufferLimit;
		if (tmpResourceType.length != 0) tmpNewElement.Properties.Item("resourceType").Value = tmpResourceType;
		// Retrieve the previous index within the collection.
		tmpElementPosition = FindElement3(tmpHandlerCollection,tmpPrevious);
		// Add the new element.
		tmpHandlerCollection.AddElement(tmpNewElement, tmpElementPosition + ((tmpElementPosition>0) ? 1 : 0));
	}
	catch(e)
	{
		ErrorMessage(e,"The following error occurred trying to add a handler");
	}
}

// ================================================================================

function PadNumber(tmpNumber)
{
	return (tmpNumber < 10) ? ("0" + tmpNumber.toString()) : tmpNumber.toString();
}

// ================================================================================

function ErrorMessage(tmpError,tmpMessage)
{
	WScript.Echo("\n" + tmpMessage + ":\n" + tmpError.description);
	WScript.Quit(tmpError.number);
}

// ================================================================================

function GetAdminManager()
{
	try
	{
		var tmpVersionManager = WScript.CreateObject("Microsoft.IIS.VersionManager");
		var tmpVersionObject = tmpVersionManager.GetVersionObject("10.0", 1);
		var tmpAdminManager = tmpVersionObject.CreateObjectFromProgId("Microsoft.ApplicationHost.WritableAdminManager");
		return tmpAdminManager;
	}
	catch(e)
	{
		ErrorMessage(e,"The following error occurred trying to obtain the Admin Manager");
	}
}

// ================================================================================

function GetUserDirectory()
{
	try
	{
		var tmpVersionManager = WScript.CreateObject("Microsoft.IIS.VersionManager");
		var tmpVersionObject = tmpVersionManager.GetVersionObject("10.0", 1);
		var tmpUserData = tmpVersionObject.GetPropertyValue("userInstanceHelper")
		var tmpUserDirectory = tmpUserData.IISDirectory;
		if (tmpUserDirectory.length > 0) return tmpUserDirectory;
		throw("The User Directory cannot be determined.");
	}
	catch(e)
	{
		ErrorMessage(e,"The following error occurred trying to obtain the User Directory");
	}
}

// ================================================================================

function FindSectionGroup(tmpParentSectionGroup,tmpName)
{
	try
	{
		// Retrieve the index within the sectionGroup.
		var tmpElementPosition = FindElement2(tmpParentSectionGroup,tmpName);
		// Fail completely if we can't retrive the index.
		if (tmpElementPosition == -1) throw("Cannot retrieve index for '" & tmpName & "'.");
		return tmpParentSectionGroup.Item(tmpElementPosition);
	}
	catch(e)
	{
		ErrorMessage(e,"An error occurred trying to add a section group");
	}
}

// ================================================================================

function FindElement1(tmpCollection, tmpElementTagName, tmpValuesArray)
{
   for (var tmpCount1 = 0; tmpCount1 < tmpCollection.Count; ++tmpCount1)
   {
      var tmpElement = tmpCollection.Item(tmpCount1);
      if (tmpElement.Name == tmpElementTagName)
      {
         var tmpMatches = true;
         for (var tmpCount2 = 0; tmpCount2 < tmpValuesArray.length; tmpCount2 += 2)
         {
            var tmpProperty = tmpElement.GetPropertyByName(tmpValuesArray[tmpCount2]);
            var tmpValue = tmpProperty.Value;
            if (tmpValue != null) tmpValue = tmpValue.toString();
            if (tmpValue != tmpValuesArray[tmpCount2 + 1])
            {
               tmpMatches = false;
               break;
            }
         }
         if (tmpMatches) return tmpCount1;
      }
   }
   return -1;
}

// ================================================================================

function FindElement2(tmpCollection,tmpName)
{
	for (var tmpCount = 0; tmpCount < tmpCollection.Count; ++tmpCount)
	{
		var tmpElement = tmpCollection.Item(tmpCount);
		if (tmpElement.Name == tmpName)
		{
			return tmpCount;
		}
	}
   return -1;
}

// ================================================================================

function FindElement3(tmpCollection,tmpName)
{
	if ((tmpName.length ==0) || (tmpName.toLowerCase() == strLastItem.toLowerCase())) return -1;
	if ((tmpName.length ==0) || (tmpName.toLowerCase() == strFirstItem.toLowerCase())) return 0;	
	return FindElement1(tmpCollection,"add",["name",tmpName]);
}

// SIG // Begin signature block
// SIG // MIIoKAYJKoZIhvcNAQcCoIIoGTCCKBUCAQExDzANBglg
// SIG // hkgBZQMEAgEFADB3BgorBgEEAYI3AgEEoGkwZzAyBgor
// SIG // BgEEAYI3AgEeMCQCAQEEEBDgyQbOONQRoqMAEEvTUJAC
// SIG // AQACAQACAQACAQACAQAwMTANBglghkgBZQMEAgEFAAQg
// SIG // qkLf6hUIUQIUdckZ0Q9IsyYTk/q7ULZ8ux3vr03b6zOg
// SIG // gg12MIIF9DCCA9ygAwIBAgITMwAAA061PHrBhG/rKwAA
// SIG // AAADTjANBgkqhkiG9w0BAQsFADB+MQswCQYDVQQGEwJV
// SIG // UzETMBEGA1UECBMKV2FzaGluZ3RvbjEQMA4GA1UEBxMH
// SIG // UmVkbW9uZDEeMBwGA1UEChMVTWljcm9zb2Z0IENvcnBv
// SIG // cmF0aW9uMSgwJgYDVQQDEx9NaWNyb3NvZnQgQ29kZSBT
// SIG // aWduaW5nIFBDQSAyMDExMB4XDTIzMDMxNjE4NDMyOVoX
// SIG // DTI0MDMxNDE4NDMyOVowdDELMAkGA1UEBhMCVVMxEzAR
// SIG // BgNVBAgTCldhc2hpbmd0b24xEDAOBgNVBAcTB1JlZG1v
// SIG // bmQxHjAcBgNVBAoTFU1pY3Jvc29mdCBDb3Jwb3JhdGlv
// SIG // bjEeMBwGA1UEAxMVTWljcm9zb2Z0IENvcnBvcmF0aW9u
// SIG // MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEA
// SIG // 3QiojSOiARVrryVJn+lnTiamZiMGLORuwCQ+VG3C+rbA
// SIG // vhATw269+qRRqNW7FKed50chWJ53KDIPBStHfIy5cNJY
// SIG // HsQw6+4InH9szgRVqn7/50i8MyRTT+VtNwxf9daGddq0
// SIG // hahpZvjuOnEY0wxQaTEQmWRnXWZUQY4r28tHiNVYEw9U
// SIG // 7wHXwWEHvNn4ZlkJGEf5VpgCvr1v9fmzu4x2sV0zQsSy
// SIG // AVtOxfDwY1HMBcccn23tphweIdS+FNDn2vh1/2kREO0q
// SIG // mGc+fbFzNskjn72MiI56kjvNDRgWs+Q78yBvPCdPgTYT
// SIG // rto5eg33Ko2ELNR/zzEkCCuhO5Vw10qV8wIDAQABo4IB
// SIG // czCCAW8wHwYDVR0lBBgwFgYKKwYBBAGCN0wIAQYIKwYB
// SIG // BQUHAwMwHQYDVR0OBBYEFJzHO2Z/7pCgbAYlpMHTX7De
// SIG // aXcAMEUGA1UdEQQ+MDykOjA4MR4wHAYDVQQLExVNaWNy
// SIG // b3NvZnQgQ29ycG9yYXRpb24xFjAUBgNVBAUTDTIzMDAx
// SIG // Mis1MDA1MTYwHwYDVR0jBBgwFoAUSG5k5VAF04KqFzc3
// SIG // IrVtqMp1ApUwVAYDVR0fBE0wSzBJoEegRYZDaHR0cDov
// SIG // L3d3dy5taWNyb3NvZnQuY29tL3BraW9wcy9jcmwvTWlj
// SIG // Q29kU2lnUENBMjAxMV8yMDExLTA3LTA4LmNybDBhBggr
// SIG // BgEFBQcBAQRVMFMwUQYIKwYBBQUHMAKGRWh0dHA6Ly93
// SIG // d3cubWljcm9zb2Z0LmNvbS9wa2lvcHMvY2VydHMvTWlj
// SIG // Q29kU2lnUENBMjAxMV8yMDExLTA3LTA4LmNydDAMBgNV
// SIG // HRMBAf8EAjAAMA0GCSqGSIb3DQEBCwUAA4ICAQA9tb/a
// SIG // R6C3QUjZRQI5pJseF8TmQD7FccV2w8kL9fpBg3vV6YAZ
// SIG // 09ZV58eyQ6RTCgcAMiMHSJ5r4SvaRgWt9U8ni96e0drN
// SIG // C/EgATz0SRwBJODR6QV8R45uEyo3swG0qqm4LMtdGOyg
// SIG // KcvvVKymtpBprLgErJPeT1Zub3puzpk7ONr5tASVFPiT
// SIG // 0C4PGP7HY907Uny2GGQGicEwCIIu3Yc5+YWrS6Ow4c/u
// SIG // E/jKxXfui1GtlN86/e0MMw7YcfkT/f0WZ7q+Ip80kLBu
// SIG // QwlSDKQNZdjVhANygHGtLSNpeoUDWLGii9ZHn3Xxwqz8
// SIG // RK8vKJyY8hhr/WCqC7+gDjuzoSRJm0Jc/8ZLGBtjfyUj
// SIG // ifkKmKRkxLmBWFVmop+x3uo4G+NSW6Thig3RP2/ldqv4
// SIG // F1IBXtoHcE6Qg7L4fEjEaKtfwTV3K+4kwFN/FYK/N4lb
// SIG // T2JhYWTlTNFC6f5Ck1aIqyKT9igsU+DnpDnLbfIK2J4S
// SIG // dekDI5jL+aOd4YzRVzsYoJEFmM1DvusOdINBQHhWvObo
// SIG // AggepVxJNtRRQdRXSB6Y0kH/iz/1tjlfx34Qt7kz4Cm0
// SIG // bV6PN02WBLnaKMmfwFbtPLIm2dzJBjiTkSxETcCpthu6
// SIG // KnTr+EI/GdCaxoDM4+OjRSgMZC0qROaB0GD9R7T8dZT3
// SIG // w+4jUmybD+i4lB1x9TCCB3owggVioAMCAQICCmEOkNIA
// SIG // AAAAAAMwDQYJKoZIhvcNAQELBQAwgYgxCzAJBgNVBAYT
// SIG // AlVTMRMwEQYDVQQIEwpXYXNoaW5ndG9uMRAwDgYDVQQH
// SIG // EwdSZWRtb25kMR4wHAYDVQQKExVNaWNyb3NvZnQgQ29y
// SIG // cG9yYXRpb24xMjAwBgNVBAMTKU1pY3Jvc29mdCBSb290
// SIG // IENlcnRpZmljYXRlIEF1dGhvcml0eSAyMDExMB4XDTEx
// SIG // MDcwODIwNTkwOVoXDTI2MDcwODIxMDkwOVowfjELMAkG
// SIG // A1UEBhMCVVMxEzARBgNVBAgTCldhc2hpbmd0b24xEDAO
// SIG // BgNVBAcTB1JlZG1vbmQxHjAcBgNVBAoTFU1pY3Jvc29m
// SIG // dCBDb3Jwb3JhdGlvbjEoMCYGA1UEAxMfTWljcm9zb2Z0
// SIG // IENvZGUgU2lnbmluZyBQQ0EgMjAxMTCCAiIwDQYJKoZI
// SIG // hvcNAQEBBQADggIPADCCAgoCggIBAKvw+nIQHC6t2G6q
// SIG // ghBNNLrytlghn0IbKmvpWlCquAY4GgRJun/DDB7dN2vG
// SIG // EtgL8DjCmQawyDnVARQxQtOJDXlkh36UYCRsr55JnOlo
// SIG // XtLfm1OyCizDr9mpK656Ca/XllnKYBoF6WZ26DJSJhIv
// SIG // 56sIUM+zRLdd2MQuA3WraPPLbfM6XKEW9Ea64DhkrG5k
// SIG // NXimoGMPLdNAk/jj3gcN1Vx5pUkp5w2+oBN3vpQ97/vj
// SIG // K1oQH01WKKJ6cuASOrdJXtjt7UORg9l7snuGG9k+sYxd
// SIG // 6IlPhBryoS9Z5JA7La4zWMW3Pv4y07MDPbGyr5I4ftKd
// SIG // gCz1TlaRITUlwzluZH9TupwPrRkjhMv0ugOGjfdf8NBS
// SIG // v4yUh7zAIXQlXxgotswnKDglmDlKNs98sZKuHCOnqWbs
// SIG // YR9q4ShJnV+I4iVd0yFLPlLEtVc/JAPw0XpbL9Uj43Bd
// SIG // D1FGd7P4AOG8rAKCX9vAFbO9G9RVS+c5oQ/pI0m8GLhE
// SIG // fEXkwcNyeuBy5yTfv0aZxe/CHFfbg43sTUkwp6uO3+xb
// SIG // n6/83bBm4sGXgXvt1u1L50kppxMopqd9Z4DmimJ4X7Iv
// SIG // hNdXnFy/dygo8e1twyiPLI9AN0/B4YVEicQJTMXUpUMv
// SIG // dJX3bvh4IFgsE11glZo+TzOE2rCIF96eTvSWsLxGoGyY
// SIG // 0uDWiIwLAgMBAAGjggHtMIIB6TAQBgkrBgEEAYI3FQEE
// SIG // AwIBADAdBgNVHQ4EFgQUSG5k5VAF04KqFzc3IrVtqMp1
// SIG // ApUwGQYJKwYBBAGCNxQCBAweCgBTAHUAYgBDAEEwCwYD
// SIG // VR0PBAQDAgGGMA8GA1UdEwEB/wQFMAMBAf8wHwYDVR0j
// SIG // BBgwFoAUci06AjGQQ7kUBU7h6qfHMdEjiTQwWgYDVR0f
// SIG // BFMwUTBPoE2gS4ZJaHR0cDovL2NybC5taWNyb3NvZnQu
// SIG // Y29tL3BraS9jcmwvcHJvZHVjdHMvTWljUm9vQ2VyQXV0
// SIG // MjAxMV8yMDExXzAzXzIyLmNybDBeBggrBgEFBQcBAQRS
// SIG // MFAwTgYIKwYBBQUHMAKGQmh0dHA6Ly93d3cubWljcm9z
// SIG // b2Z0LmNvbS9wa2kvY2VydHMvTWljUm9vQ2VyQXV0MjAx
// SIG // MV8yMDExXzAzXzIyLmNydDCBnwYDVR0gBIGXMIGUMIGR
// SIG // BgkrBgEEAYI3LgMwgYMwPwYIKwYBBQUHAgEWM2h0dHA6
// SIG // Ly93d3cubWljcm9zb2Z0LmNvbS9wa2lvcHMvZG9jcy9w
// SIG // cmltYXJ5Y3BzLmh0bTBABggrBgEFBQcCAjA0HjIgHQBM
// SIG // AGUAZwBhAGwAXwBwAG8AbABpAGMAeQBfAHMAdABhAHQA
// SIG // ZQBtAGUAbgB0AC4gHTANBgkqhkiG9w0BAQsFAAOCAgEA
// SIG // Z/KGpZjgVHkaLtPYdGcimwuWEeFjkplCln3SeQyQwWVf
// SIG // Liw++MNy0W2D/r4/6ArKO79HqaPzadtjvyI1pZddZYSQ
// SIG // fYtGUFXYDJJ80hpLHPM8QotS0LD9a+M+By4pm+Y9G6XU
// SIG // tR13lDni6WTJRD14eiPzE32mkHSDjfTLJgJGKsKKELuk
// SIG // qQUMm+1o+mgulaAqPyprWEljHwlpblqYluSD9MCP80Yr
// SIG // 3vw70L01724lruWvJ+3Q3fMOr5kol5hNDj0L8giJ1h/D
// SIG // Mhji8MUtzluetEk5CsYKwsatruWy2dsViFFFWDgycSca
// SIG // f7H0J/jeLDogaZiyWYlobm+nt3TDQAUGpgEqKD6CPxNN
// SIG // ZgvAs0314Y9/HG8VfUWnduVAKmWjw11SYobDHWM2l4bf
// SIG // 2vP48hahmifhzaWX0O5dY0HjWwechz4GdwbRBrF1HxS+
// SIG // YWG18NzGGwS+30HHDiju3mUv7Jf2oVyW2ADWoUa9WfOX
// SIG // pQlLSBCZgB/QACnFsZulP0V3HjXG0qKin3p6IvpIlR+r
// SIG // +0cjgPWe+L9rt0uX4ut1eBrs6jeZeRhL/9azI2h15q/6
// SIG // /IvrC4DqaTuv/DDtBEyO3991bWORPdGdVk5Pv4BXIqF4
// SIG // ETIheu9BCrE/+6jMpF3BoYibV3FWTkhFwELJm3ZbCoBI
// SIG // a/15n8G9bW1qyVJzEw16UM0xghoKMIIaBgIBATCBlTB+
// SIG // MQswCQYDVQQGEwJVUzETMBEGA1UECBMKV2FzaGluZ3Rv
// SIG // bjEQMA4GA1UEBxMHUmVkbW9uZDEeMBwGA1UEChMVTWlj
// SIG // cm9zb2Z0IENvcnBvcmF0aW9uMSgwJgYDVQQDEx9NaWNy
// SIG // b3NvZnQgQ29kZSBTaWduaW5nIFBDQSAyMDExAhMzAAAD
// SIG // TrU8esGEb+srAAAAAANOMA0GCWCGSAFlAwQCAQUAoIGu
// SIG // MBkGCSqGSIb3DQEJAzEMBgorBgEEAYI3AgEEMBwGCisG
// SIG // AQQBgjcCAQsxDjAMBgorBgEEAYI3AgEVMC8GCSqGSIb3
// SIG // DQEJBDEiBCC93OYXDMwxoCLGRcyKtUWK3ABu4NRsVow/
// SIG // I5oZqs/G7jBCBgorBgEEAYI3AgEMMTQwMqAUgBIATQBp
// SIG // AGMAcgBvAHMAbwBmAHShGoAYaHR0cDovL3d3dy5taWNy
// SIG // b3NvZnQuY29tMA0GCSqGSIb3DQEBAQUABIIBAM7ymoum
// SIG // 3PwMApq4PW2GEMYP+CyuvNQf0EzCJ6xXPzTXOmY+L24f
// SIG // O6XBNuqeKlNmNCGrs9TBD/qZE0ZL4fG0nKQJ11x3cOYZ
// SIG // Y6Qlv6yPiKRuwOq7psaRs0jjgzAYHcWUdmxerEyMbKKP
// SIG // lO0NvMsyAhSXicUUKFYvx5YdPsceA3AmD6zaLqyN4/d0
// SIG // 8oFXeErBmy/w+ctRl8pDpk9cM+qT1W1/kFWbQo8jbg0w
// SIG // Bnh6Wdipf0GAvjCWA55m6jRVlYzhHoN5AcvJia1pJsh7
// SIG // Nt3nfXNls9An82uHrr45BFIqJblIadL+XqsHUMuElfM0
// SIG // IOTb5Iq1bsUU4xbwamckn304YR+hgheUMIIXkAYKKwYB
// SIG // BAGCNwMDATGCF4Awghd8BgkqhkiG9w0BBwKgghdtMIIX
// SIG // aQIBAzEPMA0GCWCGSAFlAwQCAQUAMIIBUgYLKoZIhvcN
// SIG // AQkQAQSgggFBBIIBPTCCATkCAQEGCisGAQQBhFkKAwEw
// SIG // MTANBglghkgBZQMEAgEFAAQglImQcWesbbAs++1R9hCq
// SIG // 1jvySdvrnKZFA+VxhvYUZeACBmVWx2Y/aRgTMjAyMzEy
// SIG // MDgyMDExMTcuODE1WjAEgAIB9KCB0aSBzjCByzELMAkG
// SIG // A1UEBhMCVVMxEzARBgNVBAgTCldhc2hpbmd0b24xEDAO
// SIG // BgNVBAcTB1JlZG1vbmQxHjAcBgNVBAoTFU1pY3Jvc29m
// SIG // dCBDb3Jwb3JhdGlvbjElMCMGA1UECxMcTWljcm9zb2Z0
// SIG // IEFtZXJpY2EgT3BlcmF0aW9uczEnMCUGA1UECxMeblNo
// SIG // aWVsZCBUU1MgRVNOOjkyMDAtMDVFMC1EOTQ3MSUwIwYD
// SIG // VQQDExxNaWNyb3NvZnQgVGltZS1TdGFtcCBTZXJ2aWNl
// SIG // oIIR6jCCByAwggUIoAMCAQICEzMAAAHPUja+cUvNSMoA
// SIG // AQAAAc8wDQYJKoZIhvcNAQELBQAwfDELMAkGA1UEBhMC
// SIG // VVMxEzARBgNVBAgTCldhc2hpbmd0b24xEDAOBgNVBAcT
// SIG // B1JlZG1vbmQxHjAcBgNVBAoTFU1pY3Jvc29mdCBDb3Jw
// SIG // b3JhdGlvbjEmMCQGA1UEAxMdTWljcm9zb2Z0IFRpbWUt
// SIG // U3RhbXAgUENBIDIwMTAwHhcNMjMwNTI1MTkxMjExWhcN
// SIG // MjQwMjAxMTkxMjExWjCByzELMAkGA1UEBhMCVVMxEzAR
// SIG // BgNVBAgTCldhc2hpbmd0b24xEDAOBgNVBAcTB1JlZG1v
// SIG // bmQxHjAcBgNVBAoTFU1pY3Jvc29mdCBDb3Jwb3JhdGlv
// SIG // bjElMCMGA1UECxMcTWljcm9zb2Z0IEFtZXJpY2EgT3Bl
// SIG // cmF0aW9uczEnMCUGA1UECxMeblNoaWVsZCBUU1MgRVNO
// SIG // OjkyMDAtMDVFMC1EOTQ3MSUwIwYDVQQDExxNaWNyb3Nv
// SIG // ZnQgVGltZS1TdGFtcCBTZXJ2aWNlMIICIjANBgkqhkiG
// SIG // 9w0BAQEFAAOCAg8AMIICCgKCAgEAuD3LfteU2Mq1I3ue
// SIG // d5cwUKHYJneQc+1rh/EnR6QKFs/tNU6xxMQUrmjCp8b1
// SIG // TLMmLWrOYemqKVBgEuVilS2QL1LR+tkypgBNCSvotYWn
// SIG // 4gkly2T3EXscXkZDqnmXnywc16dJ7nTDl1FGm9990rPC
// SIG // 5KCuJdy2MZtRG7K929jk6Nnm7AKDSeJEsZlbjzOwvkQ4
// SIG // RrVSkfxJh7EPRnMBppbrueG6olRXdKABQW8OLcU1NZq7
// SIG // iBlj/4vrIIjar3Vf8Gof0HKyohpaVojq/WuWhqyWj0kA
// SIG // 9sYBA3T260n5WMbETHWQiSPL87zr+gZbj3DzxhlSxGlO
// SIG // zrM3WIyuX+GeUrv5TytXkk+TwuERbFXDokuC9LCOCBWc
// SIG // sCHQyR6CoHalkaekObxA5PJL2c+h1hZ2CzpR7qjBGL0C
// SIG // 6+joKKGFPc9AOXDCxxCB2FdcYmgc8dhEYkWPTFD1qIYf
// SIG // k6WVhFGZVJv6vWp11UTdLo3o5ujrFFRQ7LCDLM0TQqhK
// SIG // LSRsLRx5ucawiriZBa/Bn8DXpRZflw6B160GC/c2Ozaf
// SIG // n67E10KSkTZ5iNWrIXJ+RAvsMVLfxGSLJFs3sBH7dP/v
// SIG // 9IN/vGLTJFHWkBOfvHuwvFDIlzh5DCtuYzTUKiwnnZSc
// SIG // BSH/Yq/UqTHO9jUftY+lHm4s/2T1e+HaN43Vb6uw4jxZ
// SIG // U2/dlCsCAwEAAaOCAUkwggFFMB0GA1UdDgQWBBQ2nij7
// SIG // adHk0lXRvoGXOQQ5Gm04ODAfBgNVHSMEGDAWgBSfpxVd
// SIG // AF5iXYP05dJlpxtTNRnpcjBfBgNVHR8EWDBWMFSgUqBQ
// SIG // hk5odHRwOi8vd3d3Lm1pY3Jvc29mdC5jb20vcGtpb3Bz
// SIG // L2NybC9NaWNyb3NvZnQlMjBUaW1lLVN0YW1wJTIwUENB
// SIG // JTIwMjAxMCgxKS5jcmwwbAYIKwYBBQUHAQEEYDBeMFwG
// SIG // CCsGAQUFBzAChlBodHRwOi8vd3d3Lm1pY3Jvc29mdC5j
// SIG // b20vcGtpb3BzL2NlcnRzL01pY3Jvc29mdCUyMFRpbWUt
// SIG // U3RhbXAlMjBQQ0ElMjAyMDEwKDEpLmNydDAMBgNVHRMB
// SIG // Af8EAjAAMBYGA1UdJQEB/wQMMAoGCCsGAQUFBwMIMA4G
// SIG // A1UdDwEB/wQEAwIHgDANBgkqhkiG9w0BAQsFAAOCAgEA
// SIG // UIJuKZwNMZHf/bilyTM3TGMsVH1Jv2brFAWt9jBGV0Lj
// SIG // BqdtKUrl9lVvf7aUzKOW5GiXQVaFMndg2w7DW9ZI6/9+
// SIG // p7U9I7y9wKFkrQBYWQcqZqT28fgTyuPWZXo5TOHeXqV+
// SIG // uvLUURnxYqfU4pfcikX1wa15zP6uuCIpze81xENxRUIX
// SIG // STM7fIm1wpTu3hQPtR4sGT1srGFj2/2ThaGzxDL14nvh
// SIG // phG0ym4RObc3ukawPWno4z/r9aLhaA+WzI+UIPsH2V6n
// SIG // voX2CqTHfEDp0Mns/jZY9YrcpzmVn8B1Ue3VcFdMi0pT
// SIG // 0/shyDvIPt31ogMKaDte2w3J7Ume2DgZY16yIGneFuIF
// SIG // /uLadXgbHOl1iCEzwTc8UA2WUcQ+K18zgel0ZRFSXWGU
// SIG // PIG1zoq4P3Tb0thsXEedEHTlwwLpnRB2hjR2+stiJyWn
// SIG // Qj6dok+UCwuDJ80fmGZ6NW/JlqQnTnUbPYNtUG26yNOo
// SIG // i5PSg+tZ8eyuUXkrnLkuWfZ25CAWi1MQ3rBYa9cJndcp
// SIG // 39B0OdUsK8oe2CO0109I6/NZm77yPcbaKoxbyITQbCAn
// SIG // Qn00fdcpSUx/FrVJaQ4RIEqlrd4MzSz00r1wMV06SDOf
// SIG // N7GXXfv9mBgAzHlprfD7jHHuhrCHCwjhdjYmGddElx2U
// SIG // uR0ay6wobs3nQ0YrFqSLubkwggdxMIIFWaADAgECAhMz
// SIG // AAAAFcXna54Cm0mZAAAAAAAVMA0GCSqGSIb3DQEBCwUA
// SIG // MIGIMQswCQYDVQQGEwJVUzETMBEGA1UECBMKV2FzaGlu
// SIG // Z3RvbjEQMA4GA1UEBxMHUmVkbW9uZDEeMBwGA1UEChMV
// SIG // TWljcm9zb2Z0IENvcnBvcmF0aW9uMTIwMAYDVQQDEylN
// SIG // aWNyb3NvZnQgUm9vdCBDZXJ0aWZpY2F0ZSBBdXRob3Jp
// SIG // dHkgMjAxMDAeFw0yMTA5MzAxODIyMjVaFw0zMDA5MzAx
// SIG // ODMyMjVaMHwxCzAJBgNVBAYTAlVTMRMwEQYDVQQIEwpX
// SIG // YXNoaW5ndG9uMRAwDgYDVQQHEwdSZWRtb25kMR4wHAYD
// SIG // VQQKExVNaWNyb3NvZnQgQ29ycG9yYXRpb24xJjAkBgNV
// SIG // BAMTHU1pY3Jvc29mdCBUaW1lLVN0YW1wIFBDQSAyMDEw
// SIG // MIICIjANBgkqhkiG9w0BAQEFAAOCAg8AMIICCgKCAgEA
// SIG // 5OGmTOe0ciELeaLL1yR5vQ7VgtP97pwHB9KpbE51yMo1
// SIG // V/YBf2xK4OK9uT4XYDP/XE/HZveVU3Fa4n5KWv64NmeF
// SIG // RiMMtY0Tz3cywBAY6GB9alKDRLemjkZrBxTzxXb1hlDc
// SIG // wUTIcVxRMTegCjhuje3XD9gmU3w5YQJ6xKr9cmmvHaus
// SIG // 9ja+NSZk2pg7uhp7M62AW36MEBydUv626GIl3GoPz130
// SIG // /o5Tz9bshVZN7928jaTjkY+yOSxRnOlwaQ3KNi1wjjHI
// SIG // NSi947SHJMPgyY9+tVSP3PoFVZhtaDuaRr3tpK56KTes
// SIG // y+uDRedGbsoy1cCGMFxPLOJiss254o2I5JasAUq7vnGp
// SIG // F1tnYN74kpEeHT39IM9zfUGaRnXNxF803RKJ1v2lIH1+
// SIG // /NmeRd+2ci/bfV+AutuqfjbsNkz2K26oElHovwUDo9Fz
// SIG // pk03dJQcNIIP8BDyt0cY7afomXw/TNuvXsLz1dhzPUNO
// SIG // wTM5TI4CvEJoLhDqhFFG4tG9ahhaYQFzymeiXtcodgLi
// SIG // Mxhy16cg8ML6EgrXY28MyTZki1ugpoMhXV8wdJGUlNi5
// SIG // UPkLiWHzNgY1GIRH29wb0f2y1BzFa/ZcUlFdEtsluq9Q
// SIG // BXpsxREdcu+N+VLEhReTwDwV2xo3xwgVGD94q0W29R6H
// SIG // XtqPnhZyacaue7e3PmriLq0CAwEAAaOCAd0wggHZMBIG
// SIG // CSsGAQQBgjcVAQQFAgMBAAEwIwYJKwYBBAGCNxUCBBYE
// SIG // FCqnUv5kxJq+gpE8RjUpzxD/LwTuMB0GA1UdDgQWBBSf
// SIG // pxVdAF5iXYP05dJlpxtTNRnpcjBcBgNVHSAEVTBTMFEG
// SIG // DCsGAQQBgjdMg30BATBBMD8GCCsGAQUFBwIBFjNodHRw
// SIG // Oi8vd3d3Lm1pY3Jvc29mdC5jb20vcGtpb3BzL0RvY3Mv
// SIG // UmVwb3NpdG9yeS5odG0wEwYDVR0lBAwwCgYIKwYBBQUH
// SIG // AwgwGQYJKwYBBAGCNxQCBAweCgBTAHUAYgBDAEEwCwYD
// SIG // VR0PBAQDAgGGMA8GA1UdEwEB/wQFMAMBAf8wHwYDVR0j
// SIG // BBgwFoAU1fZWy4/oolxiaNE9lJBb186aGMQwVgYDVR0f
// SIG // BE8wTTBLoEmgR4ZFaHR0cDovL2NybC5taWNyb3NvZnQu
// SIG // Y29tL3BraS9jcmwvcHJvZHVjdHMvTWljUm9vQ2VyQXV0
// SIG // XzIwMTAtMDYtMjMuY3JsMFoGCCsGAQUFBwEBBE4wTDBK
// SIG // BggrBgEFBQcwAoY+aHR0cDovL3d3dy5taWNyb3NvZnQu
// SIG // Y29tL3BraS9jZXJ0cy9NaWNSb29DZXJBdXRfMjAxMC0w
// SIG // Ni0yMy5jcnQwDQYJKoZIhvcNAQELBQADggIBAJ1Vffwq
// SIG // reEsH2cBMSRb4Z5yS/ypb+pcFLY+TkdkeLEGk5c9MTO1
// SIG // OdfCcTY/2mRsfNB1OW27DzHkwo/7bNGhlBgi7ulmZzpT
// SIG // Td2YurYeeNg2LpypglYAA7AFvonoaeC6Ce5732pvvinL
// SIG // btg/SHUB2RjebYIM9W0jVOR4U3UkV7ndn/OOPcbzaN9l
// SIG // 9qRWqveVtihVJ9AkvUCgvxm2EhIRXT0n4ECWOKz3+SmJ
// SIG // w7wXsFSFQrP8DJ6LGYnn8AtqgcKBGUIZUnWKNsIdw2Fz
// SIG // Lixre24/LAl4FOmRsqlb30mjdAy87JGA0j3mSj5mO0+7
// SIG // hvoyGtmW9I/2kQH2zsZ0/fZMcm8Qq3UwxTSwethQ/gpY
// SIG // 3UA8x1RtnWN0SCyxTkctwRQEcb9k+SS+c23Kjgm9swFX
// SIG // SVRk2XPXfx5bRAGOWhmRaw2fpCjcZxkoJLo4S5pu+yFU
// SIG // a2pFEUep8beuyOiJXk+d0tBMdrVXVAmxaQFEfnyhYWxz
// SIG // /gq77EFmPWn9y8FBSX5+k77L+DvktxW/tM4+pTFRhLy/
// SIG // AsGConsXHRWJjXD+57XQKBqJC4822rpM+Zv/Cuk0+CQ1
// SIG // ZyvgDbjmjJnW4SLq8CdCPSWU5nR0W2rRnj7tfqAxM328
// SIG // y+l7vzhwRNGQ8cirOoo6CGJ/2XBjU02N7oJtpQUQwXEG
// SIG // ahC0HVUzWLOhcGbyoYIDTTCCAjUCAQEwgfmhgdGkgc4w
// SIG // gcsxCzAJBgNVBAYTAlVTMRMwEQYDVQQIEwpXYXNoaW5n
// SIG // dG9uMRAwDgYDVQQHEwdSZWRtb25kMR4wHAYDVQQKExVN
// SIG // aWNyb3NvZnQgQ29ycG9yYXRpb24xJTAjBgNVBAsTHE1p
// SIG // Y3Jvc29mdCBBbWVyaWNhIE9wZXJhdGlvbnMxJzAlBgNV
// SIG // BAsTHm5TaGllbGQgVFNTIEVTTjo5MjAwLTA1RTAtRDk0
// SIG // NzElMCMGA1UEAxMcTWljcm9zb2Z0IFRpbWUtU3RhbXAg
// SIG // U2VydmljZaIjCgEBMAcGBSsOAwIaAxUA6vMc1V8C4Lmr
// SIG // gEI9a6yeP08hDJuggYMwgYCkfjB8MQswCQYDVQQGEwJV
// SIG // UzETMBEGA1UECBMKV2FzaGluZ3RvbjEQMA4GA1UEBxMH
// SIG // UmVkbW9uZDEeMBwGA1UEChMVTWljcm9zb2Z0IENvcnBv
// SIG // cmF0aW9uMSYwJAYDVQQDEx1NaWNyb3NvZnQgVGltZS1T
// SIG // dGFtcCBQQ0EgMjAxMDANBgkqhkiG9w0BAQsFAAIFAOkd
// SIG // nQkwIhgPMjAyMzEyMDgxMzQ3NTNaGA8yMDIzMTIwOTEz
// SIG // NDc1M1owdDA6BgorBgEEAYRZCgQBMSwwKjAKAgUA6R2d
// SIG // CQIBADAHAgEAAgIFKjAHAgEAAgITszAKAgUA6R7uiQIB
// SIG // ADA2BgorBgEEAYRZCgQCMSgwJjAMBgorBgEEAYRZCgMC
// SIG // oAowCAIBAAIDB6EgoQowCAIBAAIDAYagMA0GCSqGSIb3
// SIG // DQEBCwUAA4IBAQAaozCk/0fK/28vo8P/8PXnBZ8ArxaX
// SIG // qJACFG6kgRizbVhLEFSMRisAgXgvh3kc+SFKnU2IvrEU
// SIG // 1KvBvG6tOA2IwgbgQWyE3kQwFjp1eY7KvS/lDsKHm7mr
// SIG // QkmFVC3gRJycCHZtE0VZYsw6O5cnnF0FNRdfMQaHN2zH
// SIG // crCprE+rz8l2OMm5pIqvstZynF3XLsyrcFsF5JUlchMg
// SIG // uTnHjkYIphzLBbFl4CHYMN81OGtvGPfFW/RQs37bb/aG
// SIG // 0PSpK7OykGqdsxlpzbiRomHHfiHyrA/bKUv4wP9Q9I/d
// SIG // 4a+hHKddKNk6dy8pH3dLkYEwymhI9T2UuTCL+3KamzfY
// SIG // Eo43MYIEDTCCBAkCAQEwgZMwfDELMAkGA1UEBhMCVVMx
// SIG // EzARBgNVBAgTCldhc2hpbmd0b24xEDAOBgNVBAcTB1Jl
// SIG // ZG1vbmQxHjAcBgNVBAoTFU1pY3Jvc29mdCBDb3Jwb3Jh
// SIG // dGlvbjEmMCQGA1UEAxMdTWljcm9zb2Z0IFRpbWUtU3Rh
// SIG // bXAgUENBIDIwMTACEzMAAAHPUja+cUvNSMoAAQAAAc8w
// SIG // DQYJYIZIAWUDBAIBBQCgggFKMBoGCSqGSIb3DQEJAzEN
// SIG // BgsqhkiG9w0BCRABBDAvBgkqhkiG9w0BCQQxIgQgPI8k
// SIG // hblZJ8wcQt3P1Onw8WlUTRmNBH7Bamadl2Z4HsgwgfoG
// SIG // CyqGSIb3DQEJEAIvMYHqMIHnMIHkMIG9BCCz6bC6njUu
// SIG // DbmFxNlSZTLr0HllQPNGQxYaTj40s4T2vzCBmDCBgKR+
// SIG // MHwxCzAJBgNVBAYTAlVTMRMwEQYDVQQIEwpXYXNoaW5n
// SIG // dG9uMRAwDgYDVQQHEwdSZWRtb25kMR4wHAYDVQQKExVN
// SIG // aWNyb3NvZnQgQ29ycG9yYXRpb24xJjAkBgNVBAMTHU1p
// SIG // Y3Jvc29mdCBUaW1lLVN0YW1wIFBDQSAyMDEwAhMzAAAB
// SIG // z1I2vnFLzUjKAAEAAAHPMCIEIHQPbVHkMnJ9/DgE542C
// SIG // N4c7xYAt2obFa9zkJ/h9vPPpMA0GCSqGSIb3DQEBCwUA
// SIG // BIICAGcsMFH25VptJyydVdOYV45f4zdUc53sl2UCziPm
// SIG // yLXjc/o+c4ccQ/HEK6LRpkRerkm06ITrtz4FzAlHRAOm
// SIG // dXa5uaWwAiDUzbuXMA4t7cAdghSpM6YvAJw458gE7GgK
// SIG // zN95J9HFCoLrcC7J0ghL6HljCpLxYd4z49Z6AFLasLVs
// SIG // Mnyeu9OJJpHKvZKZXcH4OGFK0yrxa++tqedzb5fjuKQo
// SIG // JWmDH1y5JLpyRWhsa32DhmhqS/PNtBjYfoMSb3LJg7gI
// SIG // XgiKOrB7JiPJdKNAAL4fldpvQbJQFe/w/XYlfNRILbrx
// SIG // YXlJGkuzlkOgFfzisOHdAT67FDP2L5smgwJFAEqoAzhy
// SIG // yp2FBWcprJxOGJjIWYXKaWSUeq/7bqYQM5dni4NxxA0f
// SIG // xcmo2KONp8TaRsZDAyNWe37cMpeucMyk7OG8L1PzxrxA
// SIG // 5fems+qKQN5OF4h10aNGYTYnvxtyEU52pr9/iRUWRqfL
// SIG // h2PiKpTFTFUJLmZ7sPDiRS79ZqRsZvasDqLF8mBC4V8R
// SIG // tbecYrIelX+N6TUyzHF5RDBxYe4bM2kHBmHRMBmGK+ns
// SIG // nJvagWqOdbAlcSc64YZl3dsOoXNfgbLo8SikQApyqzY6
// SIG // fucHzxhYG+gePyDswBNWH3KPSv9VzCEWGuYhFkAlKgT1
// SIG // EEg5knclk1g1ZHUAfpHYA7MxShfL
// SIG // End signature block
