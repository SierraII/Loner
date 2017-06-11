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
I used C# to write this application in as it is something that I am fairly familiar with especially with regards to turning this into a "microservice" as later described. The IDE of choice was Xamerin and the default .NET framework it comes with was Mono. I did not commit the bin or exe files in this repository. You are able to build and run this application from Xamerin (or any other C# IDE) with the provided .sln file within the src folder.

## Scaling, Performance and Extendability
Even though this was a small project, I wanted to create and architect a solution that would be extendable in future. There are multiple projects within this solution that are designed to contain specific classes and functions. Namely:
- <b>App.Loner - </b> The main entry point of the application.
- <b>App.Loner.Utils - </b> Used for project wide libary sharing. Incase multiple data sources gets introduced (such as FTP connection objects, any database connection objects in the case of data source change) or other project wide utilities that would need to be shared. I have just created a  small Logcat class used for logging multiple kinds of messages.
- <b>App.Loner.Serializers - </b> Used to contain conversions and protocals for transforming data from one or multiple data sources to a transaction (or other models) object. In here I have placed the CSV serializer (for reading and writing) but if the data type were to change to JSON or XML (for example) they would be contained within this project.
- <b>App.Loner.DataTypes - </b> A contained project for placing the various models and data types.
- <b>App.Loner.Core - </b> A place where I have created a Context object, used as a static and single reference that would call specific objects within the Utils or any other project. I created this under the assumption that incase the data source were to change, we would be able to quickly and easily reference the FTP connection object or API call from this class. Currently, the Logcat object gets called through this class.
- <b>App.Loner.Importers - </b> A project namely for containing importers. Even though for this small scenario, this may not be needed, I almost want to assume that in future there may be multiple uses for this solution that would import data not specific to this project but from other places and situations as well. If we were also dealing with user data we would place that users importer within this project.

I assumed while creating this project that it should be build for extensability and future-proofing. I created a Transaction Importer for assumption that we may want to push serialized records to a database or use those transactions for some other processing task. This importer's sole purpose is getting correct data from a CSV and, if there were any issues with one record, add the raw data to a failed_transactions.csv file. This also won't affect any other transactions that come before or after it.

The application assumes that there will be only one CSV file (namely loans.csv) outside the src folder. This application can be extended for reading all files from folders but currently does not support such functionality. The output.csv file and any failed transactions also gets put on the same level as the loans.csv file.

The performance of this application is something that could also do with a little bit of work.  Currently, if we have one CSV file with N records, the aggrigation process will only start once all the records are read and not one by one. I build the application this way as I wanted to assume that the raw transaction records (running in one thread) could be pushed to a database and then after a few moments have another thread and import worker transforming that data into the relavent objects and models. Doing it this way, we would keep all historic data and would not be held up by having a CSV file(s) with millions or records in. For the sake of keeping the amount of time spent on this project to a minimum and not using a wide array of technoligies (such as databases) and hence the simple architecture. 

Following on from this project, I have created a separate repository for running and creating this into a microservice running on Kubernetes.  
I did not want to clutter this project up with unnessesary setups and technologies that were out of scope for this interview project. I did, however want to go above and beyond the question and add more work into it than was required.
Please follow on to <a href="https://github.com/SierraII/Loner-MicroService">my second repository</a> where I domonstrait deployment of this project and push the application onto KUbernetes.
