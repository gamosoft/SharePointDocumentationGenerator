# SharePoint Documentation Generator

## Project Description
New SharePoint 2007/2010 feature to automatically generate documentation/tables for fields, content types, lists, users, etc...


## Introduction
Ever wanted to document some components of an existing SharePoint site? This tool allows you to get a listing of fields, content types, lists, features and users of a specified site.
It installs as a new feature that creates a new option under _Site Settings_ | _Site Administration_ menu called **Documentation Generator**.
The whole project was born due to a need of looking at some content types in a structured fashion, so I could see at a glance columns, types, etc...

Currently displays information in the same web page, using templates for the different elements to be documented. These templates can be modified here:

_%12HIVE%\TEMPLATE\LAYOUTS\SharepointDocGenerator\Templates_

If you just want to change the look and feel, please use the same variables/names inside the templates, just modify styles, colors, etc to display them in a different way.
When you want to add/extend some properties you'll want to take a look at the code behind for the templates to see how this information is extracted.

This package uses jQuery and jQueryUI to display/collapse sections in the HTML page but you can change whatever styles to suit your needs and modify in the templates.
Only users with administrator privileges will be able to use this option (site administrators).

If you want to make changes to the code and regenerate the WSP package, you can use WSPBuilder [http://wspbuilder.codeplex.com/](http://wspbuilder.codeplex.com/).

## Installation
Installation is pretty simple using WSP deployment standards. Please check the [installation.md](installation.md) file for more information.

## Usage
Just choose the desired fields, content types, etc... from the main screen and hit the _OK_ button.

![Choose information](./images/Home_10.png)


A new screen shows the titles of each section.

![Results](./images/Home_11.png)


You can show/hide all sections clicking the appropriate button, or section by section in the desired headers.

![Fields](./images/Home_12_p.png)


There can be sections nested within sections, like fields inside content types

![Content types](./images/Home_13_p.png)


Or content types and fields inside lists, for instance

![Lists](./images/Home_14_p.png)


This project can be extended to make it more flexible, add printout capabilities, etc... but I wanted to upload it right now so other people can use it if needed. :-)

You can download the compiled binaries here:

[http://blog.gamosoft.com/sharepoint-documentation-generator/](http://blog.gamosoft.com/sharepoint-documentation-generator/)

Enjoy!
