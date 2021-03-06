# Sitecore XPathBuilder with SPEAK3 UI
The repository contains source code and documentation for the Sitecore XPathBuilder with SPEAK3 UI

# Table of Contents
* [Introduction](#Introduction)
    * [Purpose](#Purpose)
    * [Supported Sitecore Versions](#Supported-Sitecore-Versions) 
    * [Releases](#Releases)
    * [Installation](#Installation)
        * [ConfigurationFiles](#Configuration-files)

# Introduction

* [BlogPost](https://medium.com/@mitya_1988/sitecore-xpathbuilder-with-new-look-ab66ef859692)


## Purpose
Ability to run Sitecore Queries in the Sitecore Admin. 


## Supported Sitecore Versions

- Sitecore 9.0
- Sitecore 9.0 Update-1
- Sitecore 9.0 Update-2
- Sitecore 9.1 
- Sitecore 9.1 Update-1
- Sitecore 9.2
- Sitecore 9.3 
- Sitecore 10

## Releases
- 1.0  - [package](sc.package/Sitecore.XPathBuilder-1.0.zip)
  - Initial Release

## Installation

Provide detailed instructions on how to install the module, and include screenshots where necessary.

1. Use the Sitecore Installation wizard to install the [package](sc.package/Sitecore.XPathBuilder-1.0.zip)
2. Make sure if your search indexes are working correctly
3. Go the LaunchPad and open the XPath application

### Configuration files
The package contains a configuration patch, which sets the "Sitecore.Services.SecurityPolicy" to "ServicesOnPolicy" - it is required for the Speak application.

**Settings in the Sitecore.XPathBuilder.config**

## Screenshots
![Builder](documentation/builder.png)
![Cheatsheet](documentation/cheatsheet.png)
![Relative](documentation/Relative.png)

# Configure the developer environment

If you want to enhance or contribute into the module, you should perform the following steps to setup the codebase locally.

## How to setup the API
* It should work with Sitecore 9.0, 9.1, 9.2, 9.3
* Build the XPathBuilder.Service.sln Visual Studio Solution. 
* Copy the **XPathBuilder.Service.dll** and pdb files into your Sitecore's bin folder. 
* Copy the Configuration files from the XPathBuilder.Service\App_Config\Include\XPathBuilder folder into your Sitecore instance
* Sync the items with Unicorn

## How to setup the client Application
- go to the \src\XPathBuilder.Client\ folder
- make sure you are using node version 8.x
- run "npm install" in the folder
- run "npm run build" command
- Copy the DIST folder content to \sitecore\shell\client\Applications\xpathbuilder\ (Create the xpath folder)
- Open in http://sc.local/sitecore/shell/client/Applications/xpathbuilder/ url

