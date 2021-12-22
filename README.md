# Plex-Backend

This repository contains the .NET Core backend for the Plex platform.

## Quick Links
* <a href="https://github.com/PLEX-Platform/plex-backend/wiki">Check out the Wiki</a>
* <a href="https://github.com/PLEX-Platform/plex-backend/wiki/Getting-Started">Get started with development</a>

## What is the purpose of plex?
During their studies FHICT students will work on multiple group projects. The semester owner needs to select a number of projects and share them with his students. The students will then be able to see the details of the projects the semester owner selected for them. The students will then be able to submit their preference of the available projects. The semester owner can then use the students preferences to divide the students into groups. 

The purpose of plex is to simplify this process for both the student and teacher by centralizing and automating this process. Plex should help reduce the workload of the semester owner aswell as provide a more user friendly experience for the students.

### Dex intergration
Plex will be using the project information from the <a href="https://dex.software/home">DEX-platform</a> another fontys designed platform. For more information about DEX checkout <a href="https://github.com/DigitalExcellence/dex-backend/wiki/General-Description">DEX git</a>.

### Centralize
The information on the projects the students could choose from tended to be scattered over multiple seperate documents or had to be combined into one document by the semester owner. Plex will centralize all the relevant info in one easy accesible location.

### Automatic group creation
Students will be able to use Plex to submit their project preferences. The Plex-platform will be able to provide the semester owner with a group composition suggestion based on the provided preferences. This will be done via a sorting algorithm. The teacher can then edit these groups to their own discretion before saving them to the school's system.
