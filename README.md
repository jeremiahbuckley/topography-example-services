# topography-example-services

A small project with a franken-topography of windows services technologies and endpoints, just to show it all working together.

## windows 4.0 services with:
1. wcf communication
2. sql

## WCF Communication Setup

Currently the WCF communication is over http, so you will need to set this up this user access. You can, of course, run everything (Services for Production, Visual Studio for debugging) as Administrator, but that's not great. Better to grant network access

Assuming that at least two or three users will be using this service (the developer as Themselves, and then whatever role is running the actual prod service), this command will do it for you.

\\> netsh http add "http://localhost:3700/Service/" "\Everyone"

## SQL Setup

AdminSvc -> App.config has a connectionString. You may need to edit this if you chose a different login than the one described in the Database README.md

## Running
1. For Debugging purposes, can be run directly out of Visual Studio, which is nice.
2. For Production, run: 


\\> InstallUtil .\AdminSvc\bin\Release\AdminSvc.exe