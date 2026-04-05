# World Cup Statistics App (.NET)

A desktop application for displaying and analyzing statistics from the FIFA World Cup 2018 (men) and 2019 (women), built using .NET technologies.

The project consists of multiple applications sharing a common data layer and consuming data from a public API.

## 🚀 Features

### Windows Forms Application

* Select preferred championship (men/women) and language (HR/EN)
* Choose favorite national team
* Select and manage favorite players (drag & drop, context menu)
* Display player information (name, number, position, captain status)
* Add custom player images
* Generate ranking lists:
  * Goals scored
  * Yellow cards
  * Match attendance
* Export rankings to PDF
* Persistent settings stored locally

### WPF Application

* Responsive UI with selectable resolutions / fullscreen
* Display match results between selected teams
* Animated navigation between views
* Visual representation of team lineups on a football field
* Detailed player and team statistics
* Shared settings with Windows Forms app

### Data Layer (Class Library)

* Fetch data from API or local JSON files
* Parse and map JSON data into models
* Provide processed data to client apps
* Handle file storage and retrieval
* Configurable data source (API vs JSON)

## 🛠️ Tech Stack

* C# (.NET)
* Windows Forms
* Windows Presentation Foundation (WPF)
* REST API consumption
* JSON parsing
* File I/O (text files)
* Asynchronous programming (async/await)

## 🌐 API Used

Data is retrieved from:

* https://worldcup-vua.nullbit.hr/men/
* https://worldcup-vua.nullbit.hr/women/


## ▶️ Running the Project

### Windows Forms Application

1. Navigate to the build directory: WorldCupViewer\WorldCup.WinForms\bin\Debug
2. Run the application: WorldCup.WinForms.exe

### Windows WPF

1. Navigate to the build directory: WorldCupViewer\WorldCup.WPF\bin\Debug
2. Run the application: WorldCup.WPF.exe

Make sure the project is built before running the executables.
