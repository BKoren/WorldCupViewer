World Cup Statistics – .NET Project
Project Overview

The goal of the project is to create applications that display statistics from the FIFA World Cups:
Men’s World Cup 2018 and Women’s World Cup 2019.

The solution consists of three separate projects:
Data Layer (Class Library), Windows Forms Application, Windows Presentation Foundation (WPF) Application

Data Layer (Class Library) project is shared by both client applications and is responsible for all data manipulation.
Responsibilities: Fetching data from the REST API, loading data from JSON files, parsing and mapping JSON data to domain models, preparing data for client applications, saving data to text files, reading data from text files and selecting the data source (API or JSON files) via a configuration file.


The Windows Forms application focuses primarily on functionality and correct usage of WinForms controls.
Key Features: Asynchronous data fetching from the API, initial setup(tournament selection (men / women) and application language (Croatian / English)), persistent storage of settings in text files, favorite team selection, selection of three favorite players, custom player controls displaying, drag & drop and context menu support for player management, player images stored within the solution, rankings(by number of goals or yellow cards or match by attendance), export of rankings to PDF, confirmation dialogs for settings changes and application exit, full exception handling.

The WPF application emphasizes responsiveness, animations, and a richer user interface.
Key Features: Shared settings with the Windows Forms application, responsive layout, asynchronous data loading with loading animations, favorite and opponent team selection, display of match results between selected teams, snimated display of team details, visual representation of starting lineups on a football field, player display including animation on hover, settings window with confirmation, exit confirmation dialog

Technical information: All run-time input is stored in directory(Solution/WorldCup.DataLayer/Resources/Settings), the application runs on any compatible Windows machine without code modifications.

Combile conditions: Line endings must match LF format.

Author: Bruno Koren.
Year: 2025
