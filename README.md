# PrateoWindow

This Application is a .NET Windows Form application composed in Visual Studio 19 Community.  The goal of this project is to test out the idea of building a frequency chart for interlock codes and, in a more broader sense, any tag that is a step function.

## Dependicies
This project uses the OSIsoft.AFSDK version 4.0.  These assemblies are usually found in the C:\Program Files (x86)\PIPC\AF\PublicAssemblies\4.0 folder

This project targets the .NET Framework 4.8

## LINQ
In order to replicate the functionality of SQL without having to initiate a SQL server instance, this project uses the LINQ functionality of the .NET environment.  Specifically a collection of data points is grouped by each instance of that data point.  It is this functionality that allows the program to organize data in order to produce a frequency chart.

## Build
Building the application will result in 5 files in the bin\Release folder:

OSIsoft.AFSDK.dll

OSIsoft.AFSDK.xml

PrateoWindow.exe

PrateoWindow.exe.config

PrateoWIndow.pnb

To run the application double click on PrateoWIndow.exe

## Naming
I'm not sure if this is technically a prateo chart, as a true prateo uses a bar chart in conjunction with a line chart, but that is the name that stuck.
