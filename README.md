Loner - CSV Network Aggrigator
======
Jumo Project
<p align="center">
    <img width = "100" src="https://avatars0.githubusercontent.com/u/53395?v=3&s=400" alt=""/>
    <img width = "100" src="http://devstickers.com/assets/img/pro/2p4i.png" alt=""/>
</p>

## Overview:
Every two months we are given a text file from our accounting department detailing all the loans given out on our networks. This needs to be a validated against our internal systems by the tuple of (Network, Product, Month). We will drill down as necessary into problem areas.  

Given a CSV from our accounting department calculate the aggregate loans by the tuple of (Network, Product, Month) with the total currency amounts and counts and output into a file CSV file Output.csv

## Language and Dependencies
I used C# to write this application in as it is something that I am fairly familiar with especially with regards to turning this into a "microservice" as later described. The IDE of choice was Xamerin and the default .NET framework it comes with was Mono.

## Scaling, Performance and Extendability
Even though this was a small project, I wanted to create and architect a solution that would be extendable in future. There are multiple projects within this solution that are designed to contain specific classes and functions. Namely:
- <b>App.Loner.Utils - </b> Used for project wide libary sharing. Incase multiple data sources gets introduced (such as FTP connection objects, any database connection objects in the case of data source change) or other project wide utilities that would need to be shared. I have just created a  small Logcat class used for logging multiple kinds of messages.
- <b>App.Loner.Serializers - </b> Used to contain conversions and protocals for transforming data from one or multiple data sources to a transaction (or other models) object. In here I have placed the CSV serializer (for reading and writing) but if the data type were to change to JSON or XML (for example) they would be contained within this project.
- <b>App.Loner.DataTypes - </b> A contained project for placing the various models and data types.
- <b>App.Loner.Core - </b> A place where I have created a Context object, used as a static and single reference that would call specific objects within the Utils or any other project. I created this under the assumption that incase the data source were to change, we would be able to quickly and easily reference the FTP connection object or API call from this class. Currently, the Logcat object gets called through this class.
- <b>App.Loner.Importers - </b> A project namely for containing importers. Even though for this small scenario, this may not be needed, I almost want to assume that in future there may be multiple uses for this solution that would import data not specific to this project but from other places and situations as well. If we were also dealing with user data we would place that users importer within this project. 
- <b>App.Loner - </b> The main entry point of the application.
