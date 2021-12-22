# Plex-Backend

This repository contains the .NET Core backend for the Plex platform.

## Quick Links
* <a href="https://github.com/PLEX-Platform/plex-backend/wiki">Check out the Wiki</a>

# Table of Contents
- Installation
    - ASP.NET Core 5.0
        - Windows
        - macOS
        - Linux (Ubuntu)
- Usage
    - API Calls 
        - Algorithm Sorting
        - Dex Integration
    - Data persistency / Storing
- Contributing
- Credits
- License

# Installation #

## ASP.NET Core ##
We're using the .NET CORE 5.0 SDK. So we'll be installing that SDK. There currently are no plans to migrate to the 6.0 SDK but it could be something we might consider.  


<details>
    <summary>
        Windows
    </summary>
    <p>
        1.Go to: <a href="https://dotnet.microsoft.com/download/dotnet/thank-you/sdk-5.0.403-windows-x64-installer"> https://dotnet.microsoft.com/download/dotnet/thank-you/sdk-5.0.403-windows-x64-installer </a>
        </br>
        2.Walk through the installer and finish the installation.
        </br>
        3.Verify the installation by opening the <i>"Command Prompt"</i>
        </br>
        4.Type in the command: `dotnet --version`  
    </p>
</details>
 
 <details>
    <summary>
        macOS
    </summary>
    <p>
        1.Go to:<a href="https://dotnet.microsoft.com/download/dotnet/thank-you/sdk-5.0.403-macos-x64-installer"> https://dotnet.microsoft.com/download/dotnet/thank-you/sdk-5.0.403-macos-x64-installer </a>
        </br>
        2.Walk through the installer finish the installation.
        </br>
        3.Verify the installation by opening the <i>"Terminal"</i>
        </br>
        4.Type i the command: `sudo dotnet --version`.
    </p>
</details>

<details>
    <summary>
        Linux(Ubuntu)
    </summary>
    <p>
        1.Open the <i>"Terminal"</i>
        </br>
        2. //If you're running 16.04 Ubuntu LTS or up, you don't need to install "snap" since it is already pre-packaged
        </br>
        3.Run this command: `sudo snap install dotnet-sdk --classic --channel=5.0`
        </br>
        4.After the installation has finished, run this command: `sudo snap alias dotnet-sdk.dotnet dotnet`  so you can invoke the dotnet command from terminal.
        </br>
        5.Run: `sudo nano ~/.bashrc` and you will be able to edit the PATH variables. 
        </br>
        6.Add this to the end of the file: `export DOTNET_ROOT=/snap/dotnet-sdk/current`
        </br> 
        7.Press <kbd> CTRL + X </kbd> to save the changes you made and exit the nano text editor
        </br>
        8.Run the command: `sudo dotnet --info` to verify if the installation completed. If everything went well, it should output the location and version of the dotnet installation
    </p>
</details>
